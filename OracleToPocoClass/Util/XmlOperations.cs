using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Stutz.EF.OracleToPoco.Util
{
    /// <summary>
    /// XML file operations.
    /// </summary>
    public class XmlOperations
    {
        private static StringWriter sw;

        static string file = "conn.xml";

        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="xd">The xd.</param>
        /// <param name="formClose">if set to <c>true</c> [form close].</param>
        public static void WriteFile(XmlData xd, bool formClose = false)
        {
            if (!File.Exists(file))
                File
                    .Create(file)
                    .Close()
                ;

            XmlSerializer xs = new XmlSerializer(xd.GetType());

            // Why not "using (StringWriter sw = new StringWriter())"?
            // View CA2202 in https://msdn.microsoft.com/library/ms182334.aspx
            // * Before change:
            //1 > ------Rebuild All started: Project: Stutz.EF.OracleToPoco, Configuration: Debug Any CPU------
            //1 > Running Code Analysis...
            //1 > Code Analysis Complete --0 error(s), 1 warning(s)
            //========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========
            // * After change:
            //1 > ------Rebuild All started: Project: Stutz.EF.OracleToPoco, Configuration: Debug Any CPU------
            //1 > Running Code Analysis...
            //1 > Code Analysis Complete --0 error(s), 0 warning(s)
            //========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========
            if (sw == null) sw = new StringWriter();

            using (XmlWriter xw = XmlWriter.Create(sw))
            {
                xs.Serialize(xw, xd);

                using (TextWriter tw = new StreamWriter(file, false, Encoding.UTF8))
                    tw.Write(sw.ToString());
            }

            if (formClose)
            {
                sw.Dispose();
                sw = null;
            }
        }

        /// <summary>
        /// Reads the file.
        /// </summary>
        /// <returns></returns>
        public static XmlData ReadFile()
        {
            XmlData xd = new XmlData();

            if (File.Exists(file))
            {
                XmlSerializer xs = new XmlSerializer(xd.GetType());

                using (StreamReader sr = new StreamReader(file))
                    xd = (XmlData)xs.Deserialize(sr);
            }

            return xd;
        }
    }
}
