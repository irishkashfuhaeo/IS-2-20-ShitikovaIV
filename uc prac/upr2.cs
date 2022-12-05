using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace uc_prac
{
    public partial class upr2 : Form
    {
        public upr2()
        {
            InitializeComponent();
        }

        private void upr2_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connect);

            try
            {
                SQLcon.GetConnection(conn);
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            finally
            {
                conn.Close();
            }
        }

        public string connect = "server=chuc.caseum.ru;port=33333;user=uchebka;database=uchebka;password=uchebka;";


        public class SQLcon
        {
            public static MySqlConnection GetConnection(MySqlConnection mySql)
            {
                try
                {
                    MessageBox.Show("Подключено!");
                    return mySql;
                }

                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    return null;
                }
            }
        }

    }
}
