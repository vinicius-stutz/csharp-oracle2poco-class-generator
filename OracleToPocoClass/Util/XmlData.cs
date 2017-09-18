// <copyright file="XmlData.cs" company="Vinicius de Araujo Stutz">
// Copyright (c) Vinicius de Araujo Stutz. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Stutz.EF.OracleToPoco.Util
{
    /// <summary>
    /// XML Data.
    /// </summary>
    public class XmlData
    {
        /// <summary>
        /// Gets or sets the uid.
        /// </summary>
        /// <value>
        /// The uid.
        /// </value>
        public string Uid { get; set; }

        /// <summary>
        /// Gets or sets the pass.
        /// </summary>
        /// <value>
        /// The pass.
        /// </value>
        public string Pass { get; set; }

        /// <summary>
        /// Gets or sets the host.
        /// </summary>
        /// <value>
        /// The host.
        /// </value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the port1.
        /// </summary>
        /// <value>
        /// The port1.
        /// </value>
        public string Port1 { get; set; }

        /// <summary>
        /// Gets or sets the port2.
        /// </summary>
        /// <value>
        /// The port2.
        /// </value>
        public string Port2 { get; set; }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>
        /// The service.
        /// </value>
        public string Service { get; set; }

        /// <summary>
        /// Gets or sets the table space.
        /// </summary>
        /// <value>
        /// The table space.
        /// </value>
        public string TableSpace { get; set; }

        /// <summary>
        /// Gets or sets the namespace entidade.
        /// </summary>
        /// <value>
        /// The namespace entidade.
        /// </value>
        public string NamespaceEntidade { get; set; }

        /// <summary>
        /// Gets or sets the namespace persistencia.
        /// </summary>
        /// <value>
        /// The namespace persistencia.
        /// </value>
        public string NamespacePersistencia { get; set; }

        /// <summary>
        /// Gets or sets the namespace utility.
        /// </summary>
        /// <value>
        /// The namespace utility.
        /// </value>
        public string NamespaceUtil { get; set; }

        /// <summary>
        /// Gets or sets the namespace BLL.
        /// </summary>
        /// <value>
        /// The namespace BLL.
        /// </value>
        public string NamespaceBll { get; set; }

        /// <summary>
        /// Gets or sets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public string TableName { get; set; }

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
            Host = h.Replace(" ", string.Empty);
            Port1 = p1;
            Port2 = p2;
            Service = s;
            TableSpace = ts;
            NamespaceEntidade = namespaceEntidade;
            NamespaceBll = nameSpaceBll;
            NamespacePersistencia = namespacePersistencia;
            NamespaceUtil = namespaceUtil;
        }
    }
}