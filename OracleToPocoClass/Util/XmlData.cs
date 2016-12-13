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
        /// <param name="ns">The NameSpace.</param>
        public void Set(string u, string p, string h, string p1, string p2, string s, string ts, string ns)
        {
            this.Uid = u;
            this.Pass = p;
            this.Host = h.Replace(" ", "");
            this.Port1 = p1;
            this.Port2 = p2;
            this.Service = s;
            this.TableSpace = ts;
            this.NameSpace = ns;
        }

        public string Uid { get; set; }
        public string Pass { get; set; }
        public string Host { get; set; }
        public string Port1 { get; set; }
        public string Port2 { get; set; }
        public string Service { get; set; }
        public string TableSpace { get; set; }
        public string NameSpace { get; set; }
    }
}