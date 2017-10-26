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
    public partial class formperpindahan : Form
    {
        MySqlConnection koneksi = new MySqlConnection("SERVER=localhost;DATABASE=projekppk;UID=root;PASSWORD=;");
        public formperpindahan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formberanda tampil = new formberanda();
            tampil.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1 != null)
            {
                if (MessageBox.Show("Apakah anda yakin?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes){
                    String NIK = maskedTextBox1.Text;
                    koneksi.Open();
                    MySqlCommand command1;
                    command1 = koneksi.CreateCommand();
                    command1.Parameters.AddWithValue("@nik", NIK);
                    command1.CommandText = "Delete from penduduk where NIK = @nik;";
                    command1.ExecuteNonQuery();
                    koneksi.Close();
                    this.Hide();
                    formpenduduk tampil = new formpenduduk();
                    tampil.ShowDialog();
                }
            }
            else {
                MessageBox.Show("Nik belum diinputkan");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            formtambah tampil = new formtambah();
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
