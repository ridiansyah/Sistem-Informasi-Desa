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
    public partial class formedit : Form
    {
        String nik;
        MySqlConnection koneksi = new MySqlConnection("SERVER=localhost;DATABASE=projekppk;UID=root;PASSWORD=;");
        public formedit()
        {
            InitializeComponent();
            status.Items.Add("Kaya");
            status.Items.Add("Miskin");
        }
        public formedit(String NIK) {
            this.nik = NIK;
            InitializeComponent();
            status.Items.Add("Kaya");
            status.Items.Add("Miskin");
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
                    maskedTextBox1.Text = input.GetString("NIK");
                    maskedTextBox2.Text = input.GetString("No_kk");
                    maskedTextBox3.Text = input.GetString("nama");
                    maskedTextBox4.Text = input.GetString("alamat");
                    maskedTextBox5.Text = input.GetString("tempat_lahir");
                    maskedTextBox6.Text = input.GetString("tanggal_lahir");
                    maskedTextBox7.Text = input.GetString("tahun_lahir");
                    maskedTextBox8.Text = input.GetString("pekerjaan");
                    status.Text = input.GetString("status");
                }
            }
            catch (Exception x) { }
            koneksi.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1 != null && maskedTextBox2 != null && maskedTextBox3 != null &&
                maskedTextBox4 != null && maskedTextBox5 != null && maskedTextBox6 != null
                && maskedTextBox7 != null && maskedTextBox8 != null && status != null)
            {
                if (MessageBox.Show("Apakah anda yakin?", "Edit Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
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
                    command.CommandText = "update penduduk set no_kk = @nokk, nama = @nama, " +
                        "alamat = @alamat, tempat_lahir = @tempatlahir, tanggal_lahir = @tanggal, " +
                        "tahun_lahir = @tahun, pekerjaan = @pekerjaan, status = @status where NIK = @nik;";
                    command.ExecuteNonQuery();
                    koneksi.Close();
                    this.Hide();
                    formpenduduk tampil = new formpenduduk();
                    tampil.ShowDialog();
                }
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
