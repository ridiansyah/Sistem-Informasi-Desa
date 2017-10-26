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
    public partial class formpenduduk : Form
    {
        int selectedRow;
        String NIK;
        MySqlConnection koneksi = new MySqlConnection("SERVER=localhost;DATABASE=projekppk;UID=root;PASSWORD=;");
        public formpenduduk()
        {
            InitializeComponent();
            loadmain();
        }
        public void loadmain() {
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
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            formberanda tampil = new formberanda();
            tampil.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            formtambah tampil = new formtambah();
            tampil.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (NIK == null) {
                MessageBox.Show("Data Belum Dipilih");
            }
            this.Hide();
            formedit tampil = new formedit(NIK);
            tampil.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            DataGridViewRow pilih = this.dataGridView1.Rows[selectedRow];
            maskedTextBox1.Text = pilih.Cells["NIK"].Value.ToString();
            NIK = pilih.Cells["NIK"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Apakah anda yakin?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                koneksi.Open();
                MySqlCommand command1;
                command1 = koneksi.CreateCommand();
                command1.Parameters.AddWithValue("@nik", NIK);
                command1.CommandText = "Delete from penduduk where NIK = @nik;";
                command1.ExecuteNonQuery();
                koneksi.Close();
                loadmain();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NIK = maskedTextBox1.Text;
            koneksi.Open();
            MySqlCommand command1;
            command1 = koneksi.CreateCommand();
            command1.Parameters.AddWithValue("@nik", NIK);
            command1.CommandText = "Select * from penduduk where NIK = @nik";
            MySqlDataAdapter adapter1 = new MySqlDataAdapter(command1);
            DataSet dataset1 = new DataSet();
            adapter1.Fill(dataset1);
            dataGridView1.DataSource = dataset1.Tables[0].DefaultView;
            koneksi.Close();
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
