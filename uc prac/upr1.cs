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
    public partial class upr1 : Form
    {
        public upr1()
        {
            InitializeComponent();
        }

        private void upr1_Load(object sender, EventArgs e)
        {

        }


        abstract class Sbor<T>
        {
            public double price;
            public int year;
            public T Article;
            public Sbor(double price, int year, T arcticle)
            {
                this.price = price;
                this.year = year;
                Article = arcticle;
            }

            public virtual string Display()
            {
                return $"Цена: {price} \nГод выпуска: {year}";
            }
        }

        class Hard<T> : Sbor<T>
        {
            int Turns;
            public int Turn
            {
                get { return Turns; }
                set { Turns = value; }
            }
            string ConnectI;
            public string Connect
            {
                get { return ConnectI; }
                set { ConnectI = value; }
            }
            int Size;
            public int size
            {
                get { return Size; }
                set { Size = value; }
            }
            public Hard(double price, int year, T Art, int Turns, string ConnectI, int Size) : base(price, year, Art)
            {
                Turn = Turns;
                Connect = ConnectI;
                size = Size;
            }
            public override string Display()
            {
                return $"Цена: {price} \n Год выпуска: {year} \n Артикул: {Article}\n Скорость оборотов: {Turn} \n Интерфейс подключения: {Connect} \n Объем: {size} ";
            }
        }

        class Video<T> : Sbor<T>
        {
            double freq;
            string vendor;
            int mem;

            public double Freqq
            {
                get { return freq; }
                set { freq = value; }
            }

            public string Vend
            {
                get { return vendor; }
                set { vendor = value; }
            }

            public int Memo
            {
                get { return mem; }
                set { mem = value; }
            }

            public Video(double price, int year, T Art, double freq, string vendor, int mem) : base(price, year, Art)
            {
                Freqq = freq;
                Vend = vendor;
                Memo = mem;
            }

            public override string Display()
            {
                return $"Цена: {price} \n Год выпуска: {year} \n Артикул: {Article}\n Частота: {freq} \n Производитель: {vendor} \n Объем: {mem} ";
            }
        }

        Hard<int> hdd;
        Video<int> gpu;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                hdd = new Hard<int>(Convert.ToDouble(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox4.Text), textBox5.Text, Convert.ToInt32(textBox6.Text));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(hdd.Display());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                gpu = new Video<int>(Convert.ToDouble(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), Convert.ToDouble(textBox10.Text), textBox11.Text, Convert.ToInt32(textBox12.Text));
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(gpu.Display());
        }
    }
}
