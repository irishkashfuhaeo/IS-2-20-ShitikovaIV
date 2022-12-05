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

namespace uc_prac
{
    public partial class upr3 : Form
    {

        Connect connect = new Connect("server=chuc.caseum.ru;port=33333;username=st_2_20_27;password=30534787;database=is_2_20_st27_KURS");
        MySqlConnection conn;
        MySqlDataAdapter MyDA = new MySqlDataAdapter();
        DataTable DT = new DataTable();
        BindingSource BindingS = new BindingSource();

        public void Matan()
        {
            DT.Clear();
            string table = "SELECT disciplines.id_disciplines AS `id`, disciplines.name_disciplines AS `дисциплина`, disciplines.hours_of_discipline AS `часы` FROM disciplines";
            conn.Open();
            MyDA.SelectCommand = new MySqlCommand(table, conn);
            MyDA.Fill(DT);
            BindingS.DataSource = DT;
            dataGridView1.DataSource = BindingS;
            conn.Close();

            dataGridView1.Columns[0].Visible = true;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;




            dataGridView1.Columns[0].FillWeight = 15;
            dataGridView1.Columns[1].FillWeight = 15;
            dataGridView1.Columns[2].FillWeight = 15;



            dataGridView1.Columns[0].ReadOnly = true;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;



            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersVisible = true;

        }

        public upr3()
        {
            InitializeComponent();
        }

        private void upr3_Load(object sender, EventArgs e)
        {
            conn = connect.Conn();
            Matan();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();

            conn.Open();
            string i1 = "";
            string i2 = "";
            string i3 = "";
            string sql = $"SELECT disciplines.id_disciplines AS `id`, disciplines.name_disciplines AS `дисциплина`, disciplines.hours_of_discipline AS `часы` FROM disciplines WHERE disciplines.id_disciplines = " + id;
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                i1 = reader[0].ToString();
                i2 = reader[1].ToString();
                i3 = reader[2].ToString();
            }
            reader.Close();
            MessageBox.Show($"id: {i1} дисциплина: {i2} часы: {i3}");
            conn.Close();
        }
    }
}
