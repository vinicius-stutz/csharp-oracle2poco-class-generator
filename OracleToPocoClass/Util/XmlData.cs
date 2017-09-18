namespace Stutz.EF.OracleToPoco.Util
{
    /// <summary>
    /// XML Data.
    /// </summary>
    public class XmlData
    {
        /// <summary>
        /// Sets the specified u.
        /// </summary>
        /// <param name="u">The Uid.</param>
        /// <param name="p">The Pass.</param>
        /// <param name="h">The Host.</param>
        /// <param name="p1">The Port1.</param>
        /// <param name="p2">The Port2.</param>
        /// <param name="s">The Service.</param>
        /// <param name="ts">The TableSpace.</param>
        /// <param name="namespaceEntidade">The NameSpace.</param>
        /// <param name="namespacePersistencia">The namespace persistencia.</param>
        /// <param name="namespaceUtil">The namespace utility.</param>
        /// <param name="nameSpaceBll">The name space BLL.</param>
        public void Set(string u, string p, string h, string p1, string p2, string s, string ts, string namespaceEntidade, string namespacePersistencia, string namespaceUtil, string nameSpaceBll)
        {
            Uid = u;
            Pass = p;
            Host = h.Replace(" ", "");
            Port1 = p1;
            Port2 = p2;
            Service = s;
            TableSpace = ts;
            NamespaceEntidade = namespaceEntidade;
            NamespaceBll = nameSpaceBll;
            NamespacePersistencia = namespacePersistencia;
            NamespaceUtil = namespaceUtil;
        }

        public string Uid { get; set; }
        public string Pass { get; set; }
        public string Host { get; set; }
        public string Port1 { get; set; }
        public string Port2 { get; set; }
        public string Service { get; set; }
        public string TableSpace { get; set; }
        public string NamespaceEntidade { get; set; }
        public string NamespacePersistencia { get; set; }
        public string NamespaceUtil { get; set; }
        public string NamespaceBll { get; set; }
        public string TableName { get; set; }
    }
}