namespace OracleToPocoClass.Util
{
    public class XmlData
    {
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