using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConnectDB;
using System.Net;

namespace uc_prac
{
    public partial class upr4 : Form
    {
        MySqlConnection conn;
        Class1 connect = new Class1("server=chuc.caseum.ru;port=33333;username=st_2_20_27;password=30534787;database=is_2_20_st27_KURS");
        MySqlDataAdapter MySQLDA = new MySqlDataAdapter();
        BindingSource BindingS = new BindingSource();
        DataTable DT = new DataTable();

        public void GetTable()
        {
            DT.Clear();
            string sqlview = "SELECT t_datatime.id AS `Код`, t_datatime.fio AS `ФИО`, t_datatime.date_of_Birth `Дата рождения`, t_datatime.photoUrl AS `Ссылка на фото` FROM `t_datatime`";
            conn.Open();

            MySQLDA.SelectCommand = new MySqlCommand(sqlview, conn);
            MySQLDA.Fill(DT);

            BindingS.DataSource = DT;

            dataGridView1.DataSource = BindingS;
            conn.Close();

            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[4].Visible = false;



            dataGridView1.Columns[0].FillWeight = 15;
            dataGridView1.Columns[1].FillWeight = 15;
            dataGridView1.Columns[2].FillWeight = 15;
            dataGridView1.Columns[3].FillWeight = 15;
            dataGridView1.Columns[4].FillWeight = 15;


            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            dataGridView1.Columns[4].ReadOnly = true;


            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;
        }


        public upr4()
        {
            InitializeComponent();
        }

        private void upr4_Load(object sender, EventArgs e)
        {
            conn = connect.Connection();
            GetTable();
        }

        void LoadImage(string a)
        {
            var rec = WebRequest.Create(a);
            using (var res = rec.GetResponse())
            using (var stream = res.GetResponseStream())
                pictureBox1.Image = Bitmap.FromStream(stream);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

                conn.Open();

                string sql = "SELECT t_datatime.photoUrl AS `Ссылка на фото` FROM `t_datatime` WHERE t_datatime.id =" + id;
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                string pic = cmd.ExecuteScalar().ToString();
                LoadImage(pic);
                conn.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
