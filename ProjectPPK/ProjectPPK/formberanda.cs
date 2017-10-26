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
    public partial class formberanda : Form
    {
        MySqlConnection koneksi = new MySqlConnection("SERVER=localhost;DATABASE=projekppk;UID=root;PASSWORD=;");
        public formberanda()
        {
            InitializeComponent();
            koneksi.Open();
            MySqlCommand comm = new MySqlCommand("SELECT COUNT(nik) FROM penduduk", koneksi);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            label1.Text = count.ToString();
            MySqlCommand comm2 = new MySqlCommand("SELECT COUNT(distinct no_kk) FROM penduduk", koneksi);
            Int32 count2 = Convert.ToInt32(comm2.ExecuteScalar());
            label4.Text = count2.ToString();
            MySqlCommand command1;
            command1 = koneksi.CreateCommand();
            command1.CommandText = "Select * from status where status = 'Meninggal'";
            command1.ExecuteNonQuery();
            MySqlDataReader input;
            try
            {
                input = command1.ExecuteReader();
                while (input.Read())
                {
                    label12.Text = input.GetString("jumlah");
                }
            }
            catch (Exception x) { }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            formkelahiran tampil = new formkelahiran();
            tampil.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            formpenduduk tampil = new formpenduduk();
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
