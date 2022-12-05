using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uc_prac
{
    public class Connect
    {
        string connStr;
        MySqlConnection conn;

        public MySqlConnection Conn()
        {
            conn = new MySqlConnection(connStr);
            return conn;
        }
        public string RConn()
        {
            return connStr;
        }
        public Connect(string conn)
        {
            connStr = conn;
        }
    }

    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
