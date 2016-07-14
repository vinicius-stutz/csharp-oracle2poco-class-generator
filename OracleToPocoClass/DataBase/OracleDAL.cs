using Oracle.ManagedDataAccess.Client;
using OracleToPocoClass.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OracleToPocoClass.DataBase
{
    class OracleDAL
    {

        public static string GetDataType(string DBDATASCALE, string DBDATAPRECISION, string DBDATATYPE, string DBREQUIRED)
        {
            string tp = string.Empty;
            short prec = 0;
            short scale = 0;

            if (DBDATAPRECISION != null)
                if (!string.IsNullOrEmpty(DBDATAPRECISION))
                    prec = Convert.ToInt16(DBDATAPRECISION);

            if (DBDATASCALE != null)
                if (!string.IsNullOrEmpty(DBDATASCALE))
                    scale = Convert.ToInt16((DBDATASCALE));

            switch (DBDATATYPE)
            {
                case "NUMBER":
                    if (prec <= 3) tp = "byte";
                    else if (prec <= 5) tp = "short";
                    else if (prec <= 10) tp = "int";
                    else if ((prec <= 19) && (scale == 0)) tp = "long";
                    else if ((prec <= 18) && (scale <= 2)) tp = "decimal";
                    if (DBREQUIRED != "X") tp += "?";
                    break;
                case "BLOB": tp = "byte[]"; break;
                case "BINARY_FLOAT":
                    tp = "single";
                    if (DBREQUIRED != "X") tp += "?";
                    break;
                case "BINARY_DOUBLE":
                    tp = "double";
                    if (DBREQUIRED != "X") tp += "?";
                    break;
                case "RAW": tp = "Guid"; break;
                case "DATE":
                    tp = "DateTime";
                    if (DBREQUIRED != "X") tp += "?";
                    break;
                case "NCLOB": tp = "String"; break;
                case "CLOB": tp = "String"; break;
                case "NVARCHAR2": tp = "string"; break;
                case "VARCHAR2": tp = "string"; break;
                case "NCHAR": tp = "string"; break;
                case "CHAR": tp = "string"; break;
                case "LONG": tp = "string"; break;
                case "ROWID": tp = "string"; break;
                case "UROWID": tp = "string"; break;
                default: tp = "object"; break;
            }
            return tp;
        }


        public static ICollection<string> GetTables()
        {
            string sql = "SELECT TABLE_NAME FROM USER_TABLES ORDER BY TABLE_NAME";

            ICollection<string> list = new List<string>();

            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, OracleDB.conn))
                {
#if DEBUG
                    Debug.WriteLine(cmd.CommandText);
#endif

                    OracleDataReader dr = cmd.ExecuteReader();

                    if ((dr != null) && (dr.Read()))
                        while (dr.Read())
                            list.Add(dr["TABLE_NAME"].ToString());

                    dr.Dispose();

                    return list;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        public static string GenerateCode(string tableSpace, string table, string nameSpace, bool showLength, bool showComments)
        {
            string code = null;
            string tp = string.Empty;
            short prec = 0;
            short scale = 0;

            try
            {
                string sql =
                                    @"SELECT DECODE(UCC.COLUMN_NAME, NULL, NULL, 'X') AS DBKEY,
                             TC.COLUMN_NAME AS DBCOLUMN,
                             DECODE(TC.NULLABLE, 'N', 'X', 'Y', NULL) AS DBREQUIRED,
                             {0}
                             DECODE(TC.DATA_TYPE, 'VARCHAR2', 'StringLength') || CASE
                                 WHEN TC.DATA_TYPE LIKE '%CHAR%' THEN '(' || TC.DATA_LENGTH || ')'
                                 ELSE NULL
                             END AS DBSTRINGLENGTH,
                             CC.COMMENTS AS DBCOMMENTS,
                             TC.DATA_TYPE AS DBDATATYPE,
                             TC.DATA_PRECISION AS DBDATAPRECISION,
                             TC.DATA_SCALE AS DBDATASCALE,
                             TC.DATA_LENGTH AS DBDATALENGTH,
                             TABLEFK.TABLE_PK
                    FROM USER_TAB_COLUMNS TC
                    LEFT JOIN (SELECT CC.COLUMN_NAME, CC.TABLE_NAME, TR.TABLE_PK 
                                  FROM ALL_CONS_COLUMNS CC 
                                    INNER JOIN ALL_TAB_COLUMNS ATC ON CC.TABLE_NAME = ATC.TABLE_NAME AND ATC.COLUMN_NAME = CC.COLUMN_NAME
                                    INNER JOIN (SELECT C.CONSTRAINT_NAME, C2.TABLE_NAME TABLE_PK
                                                                FROM ALL_CONSTRAINTS C
                                                                  INNER JOIN ALL_CONSTRAINTS C2 ON C2.CONSTRAINT_NAME  = C.R_CONSTRAINT_NAME 
                                                              WHERE C.TABLE_NAME = :P_TABLE 
                                                                AND C2.status = 'ENABLED'                                
                                                                AND C.status = 'ENABLED'
                                                  ) TR ON CC.CONSTRAINT_NAME = TR.CONSTRAINT_NAME) TABLEFK
                         ON (TC.TABLE_NAME = TABLEFK.TABLE_NAME AND TC.COLUMN_NAME = TABLEFK.COLUMN_NAME)       
                    LEFT JOIN USER_COL_COMMENTS CC ON CC.COLUMN_NAME = TC.COLUMN_NAME AND CC.TABLE_NAME = TC.TABLE_NAME
                    LEFT JOIN USER_CONSTRAINTS UC ON UC.TABLE_NAME = TC.TABLE_NAME AND UC.CONSTRAINT_TYPE = 'P'
                    LEFT JOIN USER_CONS_COLUMNS UCC ON UCC.TABLE_NAME = UC.TABLE_NAME AND UCC.CONSTRAINT_NAME = UC.CONSTRAINT_NAME AND UCC.COLUMN_NAME = TC.COLUMN_NAME
                   WHERE CC.TABLE_NAME = UPPER(:P_TABLE)
                   ORDER BY DBKEY ASC, DBCOLUMN ASC
                ";

                if (showLength) // If show DBTYPENAME with DATA_PRECISION, DATA_SCALE and/or DATA_LENGTH
                {
                    sql = string.Format(sql,
                        @"TC.DATA_TYPE || CASE
                                  WHEN TC.DATA_TYPE = 'NUMBER' AND TC.DATA_PRECISION IS NOT NULL THEN '(' || TC.DATA_PRECISION || ',' || TC.DATA_SCALE || ')'
                                  WHEN TC.DATA_TYPE LIKE '%CHAR%' THEN '(' || TC.DATA_LENGTH || ')'
                                  ELSE NULL
                                   END AS DBTYPENAME,"
                        );
                }
                else { sql = string.Format(sql, "TC.DATA_TYPE AS DBTYPENAME,"); }

                using (OracleCommand cmd = new OracleCommand(sql, OracleDB.conn))
                {
                    cmd.Parameters.Add("P_TABLE", table);

#if DEBUG
                    Debug.WriteLine(cmd.CommandText);
#endif

                    OracleDataReader dr = cmd.ExecuteReader();

                    if ((dr != null))
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine("using System;");
                        sb.AppendLine("using System.Collections.Generic;");
                        sb.AppendLine("using System.ComponentModel.DataAnnotations;");
                        sb.AppendLine("using System.ComponentModel.DataAnnotations.Schema;");
                        sb.AppendLine("");
                        sb.AppendLine(string.Format("namespace {0}", nameSpace));
                        sb.AppendLine("{");
                        sb.AppendLine(@"    /// <summary>");
                        sb.AppendLine(string.Format(@"    /// Classe gerada automaticamente a partir da tabela {0}.{1} em {2}", tableSpace.ToUpper(), table.ToUpper(), DateTime.Now.ToString()));
                        sb.AppendLine(@"    /// </summary>");
                        sb.AppendLine("    [Table(\"" + table.ToUpper() + "\", Schema=\"" + tableSpace.ToUpper() + "\")]");
                        sb.AppendLine("    public class " + StringUtil.ToPascalCase(table.ToString()));
                        sb.AppendLine("    {");

                        sb.AppendLine("        public " + StringUtil.ToPascalCase(table.ToString()) + "()");
                        sb.AppendLine("        {");
                        sb.AppendLine(@"                // Seu construtor aqui");
                        sb.AppendLine("        }");
                        sb.AppendLine("");

                        if (showComments) // If show comments
                        {

                            sb.AppendLine("        // TODO: Você pode apagar estas linhas de comentários se desejar (classe " + StringUtil.ToPascalCase(table.ToString()) + ")");
                            sb.AppendLine("        /*");
                            sb.AppendLine("         * ----------------------- EXEMPLOS -----------------------");
                            //sb.AppendLine("         * Levando em consideração o seguinte cenário:");
                            //sb.AppendLine("         * - Classe Employee;");
                            //sb.AppendLine("         * - Classe DepartmentMaster.");
                            //sb.AppendLine("         * ");
                            //sb.AppendLine("         * --------------------------------------------------------");
                            //sb.AppendLine("         * ");
                            //sb.AppendLine("         * 1) FOREIGN KEY");
                            //sb.AppendLine("         * Se houver chave estrangeira use (na classe Employee):");
                            //sb.AppendLine("         *      [ForeignKey(\"DepartmentMaster\")]");
                            //sb.AppendLine("         *      public int DepartmentId { get; set; }");
                            //sb.AppendLine("         *      public virtual DepartmentMaster DepartmentMaster { get; set; }");
                            //sb.AppendLine("         *      ");
                            //sb.AppendLine("         * Já encontrei outros exemplos que utilizam:");
                            //sb.AppendLine("         *      public int DepartmentId { get; set; }");
                            //sb.AppendLine("         *      [ForeignKey(\"DepartmentId\")]");
                            //sb.AppendLine("         *      public DepartmentMaster DepartmentMaster { get; set; }");
                            //sb.AppendLine("         * ");
                            //sb.AppendLine("         * Fique à vontade para utilizar a solução que melhor atende suas necessidades.");
                            //sb.AppendLine("         * ");
                            //sb.AppendLine("         * --------------------------------------------------------");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         * 2) INVERSE PROPERTY");
                            sb.AppendLine("         * Se na Classe Employee houver:");
                            sb.AppendLine("         *      [InverseProperty(\"Employees\")]  ");
                            sb.AppendLine("         *      public DepartmentMaster MyDepartment { get; set; }");
                            sb.AppendLine("         * Na Classe DepartmentMaster use:");
                            sb.AppendLine("         *      public ICollection<Employee> Employees { get; set; }");
                            sb.AppendLine("         *      ");
                            sb.AppendLine("         * Se sua tabela possui relacionamentos, lembre-se de modificar os campos:");
                            sb.AppendLine("         * - 1:N) Para public virtual ICollection<NomeDaClasse> Campo { get; set; }");
                            sb.AppendLine("         * - 1:1) Para public virtual NomeDaClasse Campo { get; set; }");
                            sb.AppendLine("         * Lembre-se de sempre fazer as devidas referências na outra classe com");
                            sb.AppendLine("         * [InverseProperty(\"NomeDaOutraPropriedade\")] quando o relacionamento for 1:N!");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         * --------------------------------------------------------");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         * 3) COMPLEXTYPE");
                            sb.AppendLine("         * Tipos complexos não possuem chave ou Identity, então o Entity Framework");
                            sb.AppendLine("         * não pode gerenciar estes objetos. Eles podem ser usados como resultado");
                            sb.AppendLine("         * de uma Stored Procedure.");
                            sb.AppendLine("         *      [ComplexType]");
                            sb.AppendLine("         *      public class UserInfo");
                            sb.AppendLine("         *      {");
                            sb.AppendLine("         *          public DateTime CreatedDate { get; set; }");
                            sb.AppendLine("         *          public string CreatedBy { get; set; }");
                            sb.AppendLine("         *      }");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         *      [Table(\"Department\", Schema = \"dbo\")]");
                            sb.AppendLine("         *      public class DepartmentMaster");
                            sb.AppendLine("         *      {");
                            sb.AppendLine("         *          [Key]");
                            sb.AppendLine("         *          public int DepartmentId { get; set; }");
                            sb.AppendLine("         *          public UserInfo User { get; set; }");
                            sb.AppendLine("         *      }");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         * --------------------------------------------------------");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         * 4) NOTMAPPED");
                            sb.AppendLine("         * Atributos (ou classes) não mapeados para o EF.");
                            sb.AppendLine("         *      [NotMapped]");
                            sb.AppendLine("         *      public string DepartmentCodeName");
                            sb.AppendLine("         *      {");
                            sb.AppendLine("         *          get { return Code + \": \" + Name; }");
                            sb.AppendLine("         *      }");
                            sb.AppendLine("         *      ");
                            sb.AppendLine("         *      [NotMapped]");
                            sb.AppendLine("         *      public class InternalClass");
                            sb.AppendLine("         *      {");
                            sb.AppendLine("         *          public int Id { get; set; }");
                            sb.AppendLine("         *          public string Name { get; set; }");
                            sb.AppendLine("         *      }");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         * --------------------------------------------------------");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         * REFERÊNCIAS:");
                            sb.AppendLine("         * http://www.c-sharpcorner.com/UploadFile/ff2f08/entity-framework-code-first-data-annotations/");
                            sb.AppendLine("         * http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-a-more-complex-data-model-for-an-asp-net-mvc-application");
                            sb.AppendLine("         * http://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx");
                            sb.AppendLine("         * https://docs.oracle.com/cd/E11882_01/win.112/e23174/featLINQ.htm#ODPNT219");
                            sb.AppendLine("         * https://docs.oracle.com/cd/E56485_01/win.121/e55744/entityCodeFirst.htm#ODPNT8309");
                            sb.AppendLine("         * ");
                            sb.AppendLine("         * ------------------------- FIM -------------------------");
                            sb.AppendLine("         */");

                            sb.AppendLine("");
                        }

                        while (dr.Read())
                        {
                            //Obtendo o tipo de dados
                            tp = OracleDAL.GetDataType(dr["DBDATASCALE"].ToString(), dr["DBDATAPRECISION"].ToString(),
                                                       dr["DBDATATYPE"].ToString(), dr["DBREQUIRED"].ToString());

                            sb.AppendLine(@"        /// <summary>");

                            string comment = (dr["DBCOMMENTS"] == null) ?
                                string.Format("Propriedade referente ao campo {0} do tipo {1}.", dr["DBCOLUMN"].ToString(), tp) :
                                dr["DBCOMMENTS"].ToString();

                            sb.AppendLine(string.Format(@"        /// {0}", comment));
                            sb.AppendLine(@"        /// </summary>");

                            if ((dr["TABLE_PK"] == null) || (dr["TABLE_PK"].ToString().Equals("")))
                            {
                                if (dr["DBKEY"].ToString().ToUpper() == "X")
                                {
                                    sb.AppendLine("        [Key]");
                                    sb.AppendLine("        [DatabaseGenerated(DatabaseGeneratedOption.None)] // None, Computed ou Identity");
                                }

                                sb.AppendLine("        [Column(\"" + dr["DBCOLUMN"].ToString() + "\", TypeName=\"" + dr["DBTYPENAME"].ToString() + "\")]");
                                sb.AppendLine("        public virtual " + tp + " " + StringUtil.ToPascalCase(dr["DBCOLUMN"].ToString()) + " { get; set; }");
                                sb.AppendLine("");
                            }
                            else
                            {
                                sb.AppendLine("        public " + tp + " " + StringUtil.ToPascalCase(dr["DBCOLUMN"].ToString()) + "{ get; set; }");
                                sb.AppendLine("");
                                sb.AppendLine("        [ForeignKey(\"" + StringUtil.ToPascalCase(dr["DBCOLUMN"].ToString()) + "\")]");
                                sb.AppendLine("        public virtual " + StringUtil.ToPascalCase(dr["TABLE_PK"].ToString()) + " " + StringUtil.ToPascalCase(dr["TABLE_PK"].ToString()) + " { get; set; }");
                                sb.AppendLine("");
                            }
                        }
                        sb.AppendLine("    }");
                        sb.AppendLine("}");
                        code = sb.ToString();
                    }

                    dr.Dispose();

                    return code;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
