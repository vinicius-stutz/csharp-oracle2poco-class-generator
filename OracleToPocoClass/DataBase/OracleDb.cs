// <copyright file="OracleDB.cs" company="Vinicius de Araujo Stutz">
// Copyright (c) Vinicius de Araujo Stutz. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Stutz.EF.OracleToPoco.DataBase
{
    using System;
    using Oracle.ManagedDataAccess.Client;
    using Util;

    /// <summary>
    /// <see cref="OracleConnection"/>.
    /// </summary>
    internal class OracleDB
    {
        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection.
        /// </value>
        public static OracleConnection Conn
        {
            get; set;
        }

        /// <summary>
        /// Connects the specified <see cref="XmlData"/>.
        /// </summary>
        /// <param name="xd">The xd.</param>
        /// <exception cref="Exception">Error.</exception>
        public static void Connect(XmlData xd)
        {
            string dataSource = string.Format(
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})))",
                xd.Host,
                xd.Port1,
                xd.Service);

            try
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder()
                {
                    UserID = xd.Uid,
                    Password = xd.Pass,
                    DataSource = dataSource
                };

                Conn = new OracleConnection(ocsb.ConnectionString);

                Conn.Open();
            }
            catch (Exception)
            {
                try
                {
                    dataSource = string.Format(
                        "(DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (COMMUNITY = tcp.world)(PROTOCOL = TCP)(Host = {0})(Port = {1}))(ADDRESS = (COMMUNITY = tcp.world)(PROTOCOL = TCP)(Host = {0})(Port = {2})))(CONNECT_DATA = (SID = {3})))",
                        xd.Host,
                        xd.Port1,
                        xd.Port2,
                        xd.Service)
                    ;

                    OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder()
                    {
                        UserID = xd.Uid,
                        Password = xd.Pass,
                        DataSource = dataSource
                    };

                    Conn = new OracleConnection(ocsb.ConnectionString);

                    Conn.Open();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Closes this instance.
        /// </summary>
        public static void Close()
        {
            if (Conn != null)
            {
                Conn.Close();
                Conn.Dispose();
            }
        }
    }
}
