using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConnectDB
{
    public class Class1
    {
        string StrConnect;
        MySqlConnection Conn;

        public MySqlConnection Connection()
        {
            Conn = new MySqlConnection(StrConnect);
            return Conn;
        }
        public string RConn()
        {
            return StrConnect;
        }
        public Class1(string connect)
        {
            StrConnect = connect;
        }

    }
}
