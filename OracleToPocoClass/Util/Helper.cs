// <copyright file="Helper.cs" company="Vinicius de Araujo Stutz">
// Copyright (c) Vinicius de Araujo Stutz. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Stutz.EF.OracleToPoco.Util
{
    using System.Text;
    using DataBase;

    /// <summary>
    /// Helper for DB events/objects.
    /// </summary>
    internal class Helper
    {
        /// <summary>
        /// Gets the tables.
        /// </summary>
        /// <value>
        /// The tables.
        /// </value>
        internal static object Tables
        {
            get { return OracleDAL.Tables; }
        }

        /// <summary>
        /// Connects the specified xd.
        /// </summary>
        /// <param name="xd">The xd.</param>
        internal static void Connect(XmlData xd)
        {
            OracleDB.Connect(xd);
        }

        /// <summary>
        /// Closes the connection.
        /// </summary>
        internal static void CloseConnection()
        {
            OracleDB.Close();
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <param name="tableSpace">The table space.</param>
        /// <param name="table">The table.</param>
        /// <param name="nameSpace">The name space.</param>
        /// <param name="showDataLength">if set to <c>true</c> [show data length].</param>
        /// <param name="showComments">if set to <c>true</c> [show comments].</param>
        /// <returns><see cref="string"/>.</returns>
        internal static string GetCode(string tableSpace, string table, string nameSpace, bool showDataLength, bool showComments)
        {
            return OracleDAL.GenerateCode(tableSpace, table, nameSpace, showDataLength, showComments);
        }

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <param name="nsEntidade">The ns entidade.</param>
        /// <param name="nsPersistencia">The ns persistencia.</param>
        /// <param name="nsUtil">The ns utility.</param>
        /// <param name="nsBll">The ns BLL.</param>
        /// <param name="entidade">The entidade.</param>
        /// <returns><see cref="string"/></returns>
        internal static string GetCode(string nsEntidade, string nsPersistencia, string nsUtil, string nsBll, string entidade)
        {
            string bll = entidade + "BLL";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("namespace " + nsBll);
            sb.AppendLine("{");
            sb.AppendLine("    using System;");
            sb.AppendLine("    using System.Collections.Generic;");
            sb.AppendLine("    using System.Linq;");
            sb.AppendLine("    using System.Text;");
            sb.AppendLine("    using System.Threading.Tasks;");
            sb.AppendLine("    using " + nsEntidade + ";");
            sb.AppendLine("    using " + nsPersistencia + ";");
            sb.AppendLine("    using " + nsUtil + ";");
            sb.AppendLine(string.Empty);
            sb.AppendLine("    /// <summary>");
            sb.AppendLine("    /// A Unit of Work Business Logic Layer class.");
            sb.AppendLine("    /// </summary>");
            sb.AppendLine("    /// <seealso cref=\"" + nsUtil + ".Disposable\" />");
            sb.AppendLine("    public class " + bll + " : Disposable");
            sb.AppendLine("    {");
            sb.AppendLine("        #region Variables");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        private bool _disposed;");
            sb.AppendLine("        private IUnitOfWork<" + entidade + "> _work;");
            sb.AppendLine("        private IRepository<" + entidade + "> _repository;");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        #endregion");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        #region Constructor");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Initializes a new instance of the <see cref=\"" + bll + "\"/> class.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"beginTransaction\">if set to <c>true</c> [begin transaction].</param>");
            sb.AppendLine("        /// <param name=\"useProxy\">if set to <c>true</c> [use proxy].</param>");
            sb.AppendLine("        public " + entidade + "BLL(bool beginTransaction = false, bool useProxy = false)");
            sb.AppendLine("        {");
            sb.AppendLine("            _work = new UnitOfWork<" + entidade + ">(beginTransaction, useProxy);");
            sb.AppendLine("            _repository = _work.Repository;");
            sb.AppendLine("        }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        #endregion");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        #region Default methods");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Counts this instance.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns><see cref=\"System.Int32\"/>.</returns>");
            sb.AppendLine("        public int Count() { return _repository.Count(); }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Deletes the specified identifier.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"id\">The identifier.</param>");
            sb.AppendLine("        public void Delete(object id) { _repository.Delete(id); }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Verifica se uma determinada instância existe.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"id\">The identifier.</param>");
            sb.AppendLine("        /// <returns><see cref=\"bool\"/>.</returns>");
            sb.AppendLine("        public bool Exists(object id) { return _repository.Exists(id); }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Gets all.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <returns><see cref=\"List{T}\"/>.</returns>");
            sb.AppendLine("        public List< " + entidade + " > GetAll() { return _repository.GetAll().ToList(); }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Loads the specified identifier.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"id\">The identifier.</param>");
            sb.AppendLine("        /// <returns><see cref=\"" + entidade + "\"/>.</returns>");
            sb.AppendLine("        public " + entidade + " Load(object id) { return _repository.Load(id); }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Saves the specified entity.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"entity\">The entity.</param>");
            sb.AppendLine("        public void Save(" + entidade + " entity) { _repository.Save(entity); }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Updates the specified entity.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"entity\">The entity.</param>");
            sb.AppendLine("        public void Update(" + entidade + " entity) { _repository.Update(entity); }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        #endregion");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        #region Dispose with commit");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        /// <summary>");
            sb.AppendLine("        /// Releases unmanaged and - optionally - managed resources.");
            sb.AppendLine("        /// </summary>");
            sb.AppendLine("        /// <param name=\"disposing\"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>");
            sb.AppendLine("        protected override void Dispose(bool disposing)");
            sb.AppendLine("        {");
            sb.AppendLine("            if (!_disposed)");
            sb.AppendLine("            {");
            sb.AppendLine("                if (disposing)");
            sb.AppendLine("                {");
            sb.AppendLine("                    if (_work != null)");
            sb.AppendLine("                    {");
            sb.AppendLine("                        _work.Commit();");
            sb.AppendLine("                    }");
            sb.AppendLine("                }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("                _disposed = true;");
            sb.AppendLine("            }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("            base.Dispose(disposing);");
            sb.AppendLine("        }");
            sb.AppendLine(string.Empty);
            sb.AppendLine("        #endregion");
            sb.AppendLine("    }");
            sb.AppendLine("}");

            return sb.ToString();
        }
    }
}
