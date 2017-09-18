// <copyright file="XmlOperations.cs" company="Vinicius de Araujo Stutz">
// Copyright (c) Vinicius de Araujo Stutz. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Stutz.EF.OracleToPoco.Util
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// XML file operations.
    /// </summary>
    public class XmlOperations
    {
        private const string FileName = "oracle_ef_tool.config";
        private static StringWriter sw;

        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <param name="xd">The xd.</param>
        /// <param name="formClose">if set to <c>true</c> [form close].</param>
        public static void WriteFile(XmlData xd, bool formClose = false)
        {
            if (!File.Exists(FileName))
            {
                File.Create(FileName).Close();
            }

            XmlSerializer xs = new XmlSerializer(xd.GetType());

            // Why not "using (StringWriter sw = new StringWriter())"?
            // View CA2202 in https://msdn.microsoft.com/library/ms182334.aspx
            // * Before change:
            // 1 > ------Rebuild All started: Project: Stutz.EF.OracleToPoco, Configuration: Debug Any CPU------
            // 1 > Running Code Analysis...
            // 1 > Code Analysis Complete --0 error(s), 1 warning(s)
            // ========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========
            //  * After change:
            // 1 > ------Rebuild All started: Project: Stutz.EF.OracleToPoco, Configuration: Debug Any CPU------
            // 1 > Running Code Analysis...
            // 1 > Code Analysis Complete --0 error(s), 0 warning(s)
            // ========== Rebuild All: 1 succeeded, 0 failed, 0 skipped ==========
            if (sw == null)
            {
                sw = new StringWriter();
            }

            using (XmlWriter xw = XmlWriter.Create(sw))
            {
                xs.Serialize(xw, xd);

                using (TextWriter tw = new StreamWriter(FileName, false, Encoding.UTF8))
                {
                    tw.Write(sw.ToString());
                }
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
        /// <returns><see cref="XmlData"/></returns>
        public static XmlData ReadFile()
        {
            XmlData xd = new XmlData();

            if (File.Exists(FileName))
            {
                XmlSerializer xs = new XmlSerializer(xd.GetType());

                using (StreamReader sr = new StreamReader(FileName))
                {
                    xd = (XmlData)xs.Deserialize(sr);
                }
            }

            return xd;
        }
    }
}
