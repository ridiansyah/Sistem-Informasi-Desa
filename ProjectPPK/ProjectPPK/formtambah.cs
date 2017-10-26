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
    public partial class formtambah : Form
    {
        MySqlConnection koneksi = new MySqlConnection("SERVER=localhost;DATABASE=projekppk;UID=root;PASSWORD=;");
        public formtambah()
        {
            InitializeComponent();
            status.Items.Add("Kaya");
            status.Items.Add("Miskin");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1 != null && maskedTextBox2 != null && maskedTextBox3 != null &&
                maskedTextBox4 != null && maskedTextBox5 != null && maskedTextBox6 != null
                && maskedTextBox7 != null && maskedTextBox8 != null && status != null){ 
                int nik = Int32.Parse(maskedTextBox1.Text);
                int nokk = Int32.Parse(maskedTextBox2.Text);
                String nama = maskedTextBox3.Text;
                String alamat = maskedTextBox4.Text;
                String tempatlahir = maskedTextBox5.Text;
                String tanggal = maskedTextBox6.Text;
                int tahun = Int32.Parse(maskedTextBox7.Text);
                String pekerjaan = maskedTextBox8.Text;
                String statuss = status.Text;
                koneksi.Open();
                MySqlCommand command;
                command = koneksi.CreateCommand();
                command.Parameters.AddWithValue("@nik", nik);
                command.Parameters.AddWithValue("@nokk", nokk);
                command.Parameters.AddWithValue("@nama", nama);
                command.Parameters.AddWithValue("@alamat", alamat);
                command.Parameters.AddWithValue("@tempatlahir", tempatlahir);
                command.Parameters.AddWithValue("@tanggal", tanggal);
                command.Parameters.AddWithValue("@tahun", tahun);
                command.Parameters.AddWithValue("@pekerjaan", pekerjaan);
                command.Parameters.AddWithValue("@status", statuss);
                command.CommandText = "insert into penduduk(nik,no_kk,nama,alamat,tempat_lahir,tanggal_lahir,tahun_lahir,pekerjaan,status) values(@nik,@nokk,@nama,@alamat,@tempatlahir,@tanggal,@tahun,@pekerjaan,@status)";
                command.ExecuteNonQuery();
                koneksi.Close();
                this.Hide();
                formpenduduk tampil = new formpenduduk();
                tampil.ShowDialog();
            }
            else {
                MessageBox.Show("Harap isi semua field");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formberanda tampil = new formberanda();
            tampil.ShowDialog();
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
