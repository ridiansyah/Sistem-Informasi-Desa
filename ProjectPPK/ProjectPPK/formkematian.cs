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
    public partial class formkematian : Form
    {
        MySqlConnection koneksi = new MySqlConnection("SERVER=localhost;DATABASE=projekppk;UID=root;PASSWORD=;");
        public formkematian()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formberanda tampil = new formberanda();
            tampil.ShowDialog();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            maskedTextBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1 == null)
            {
                MessageBox.Show("Harap masukkan nik");
            }
            else
            {
                String NIK = maskedTextBox1.Text;
                koneksi.Open();
                MySqlCommand command1;
                command1 = koneksi.CreateCommand();
                command1.Parameters.AddWithValue("@nik", NIK);
                command1.CommandText = "Select * from penduduk where nik = @nik";
                command1.ExecuteNonQuery();
                MySqlDataReader input;
                try
                {
                    input = command1.ExecuteReader();
                    while (input.Read())
                    {
                        maskedTextBox9.Text = input.GetString("NIK");
                        maskedTextBox2.Text = input.GetString("No_kk");
                        maskedTextBox3.Text = input.GetString("nama");
                        maskedTextBox4.Text = input.GetString("alamat");
                        maskedTextBox5.Text = input.GetString("tempat_lahir");
                        maskedTextBox6.Text = input.GetString("tanggal_lahir");
                        maskedTextBox7.Text = input.GetString("tahun_lahir");
                        maskedTextBox8.Text = input.GetString("pekerjaan");
                    }
                }
                catch (Exception x) { }
                koneksi.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                koneksi.Open();
                MySqlCommand command1;
                command1 = koneksi.CreateCommand();
                String NIK = maskedTextBox9.Text;
                command1.Parameters.AddWithValue("@nik", NIK);
                command1.CommandText = "Delete from penduduk where NIK = @nik;";
                command1.ExecuteNonQuery();
                MySqlCommand comm2 = new MySqlCommand("SELECT jumlah FROM status where status = 'Meninggal';", koneksi);
                Int32 count2 = Convert.ToInt32(comm2.ExecuteScalar())+1;
                label4.Text = count2.ToString();
                MySqlCommand command;
                command = koneksi.CreateCommand();
                command.Parameters.AddWithValue("@nik", count2);
                command.CommandText = "update status set jumlah=@nik where status = 'Meninggal';";
                command.ExecuteNonQuery();
                koneksi.Close();
                formpenduduk tampil = new formpenduduk();
                this.Hide();
                tampil.Show();
            }
        }

        private void formkematian_Load(object sender, EventArgs e)
        {

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
