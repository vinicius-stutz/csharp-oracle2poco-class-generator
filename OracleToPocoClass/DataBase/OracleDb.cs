using Oracle.ManagedDataAccess.Client;
using OracleToPocoClass.Util;
using System;

namespace OracleToPocoClass.DataBase
{
    class OracleDB
    {
        public static OracleConnection conn;

        public static void Connect(XmlData xd)
        {
            string dataSource = string.Format(
                "(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})))",
                xd.Host,
                xd.Port1,
                xd.Service)
            ;

            try
            {
                OracleConnectionStringBuilder ocsb = new OracleConnectionStringBuilder()
                {
                    UserID = xd.Uid,
                    Password = xd.Pass,
                    DataSource = dataSource
                };

                conn = new OracleConnection(ocsb.ConnectionString);

                conn.Open();
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

                    conn = new OracleConnection(ocsb.ConnectionString);

                    conn.Open();
                }
                catch (Exception ex) { throw new Exception(ex.Message); }
            }
        }

        public static void Close()
        {
            if (conn != null)
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
