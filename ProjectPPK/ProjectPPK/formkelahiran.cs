using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectPPK
{
    public partial class formkelahiran : Form
    {
        MySqlConnection koneksi = new MySqlConnection("SERVER=localhost;DATABASE=projekppk;UID=root;PASSWORD=;");
        public formkelahiran()
        {
            InitializeComponent();
            loadmain();
        }
        public void loadmain()
        {
            koneksi.Open();
            MySqlCommand command1;
            command1 = koneksi.CreateCommand();
            command1.CommandText = "Select * from penduduk";
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(command1);
            DataSet dataset1 = new DataSet();
            adapter1.Fill(dataset1);
            dataGridView1.DataSource = dataset1.Tables[0].DefaultView;
            koneksi.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            formtambah tampil = new formtambah();
            tampil.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formberanda tampil = new formberanda();
            tampil.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            koneksi.Open();
            if (maskedTextBox1 != null)
            {
                MessageBox.Show("Harap masukkan tahun");
            }
            MySqlCommand command1;
            command1 = koneksi.CreateCommand();
            String tahun = maskedTextBox1.Text;
            command1.Parameters.AddWithValue("@tahun", tahun);
            command1.CommandText = "Select * from penduduk where tahun_lahir = @tahun";
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(command1);
            DataSet dataset1 = new DataSet();
            adapter1.Fill(dataset1);
            dataGridView1.DataSource = dataset1.Tables[0].DefaultView;
            koneksi.Close();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            formpenduduk tampil = new formpenduduk();
            tampil.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            formkelahiran tampil = new formkelahiran();
            tampil.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            formkematian tampil = new formkematian();
            tampil.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            formperpindahan tampil = new formperpindahan();
            tampil.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            raskin tampil = new raskin();
            tampil.ShowDialog();
        }
    }
}
