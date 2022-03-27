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


namespace labkimia
{
    public partial class Form1 : Form
    {
        MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='dbscan';username=root;password=");
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void grupBox_antri_Enter(object sender, EventArgs e)
        {
            string selectQueryantri = "SELECT `kode_barang`, `nama_barang` FROM `tb_labkimia` WHERE status='antri'";
            DataTable table_antri = new DataTable();
            MySqlDataAdapter adapter_antri = new MySqlDataAdapter(selectQueryantri, connection);
            adapter_antri.Fill(table_antri);
            dataGridView1.DataSource = table_antri;

            string selectQueryproses = "SELECT `kode_barang`, `nama_barang` FROM `tb_labkimia` WHERE status='proses'";
            DataTable table_proses = new DataTable();
            MySqlDataAdapter adapter_proses = new MySqlDataAdapter(selectQueryproses, connection);
            adapter_proses.Fill(table_proses);
            dataGridView2.DataSource = table_proses;

            string selectQueryselesai = "SELECT `kode_barang`, `nama_barang` FROM `tb_labkimia` WHERE status='selesai'";
            DataTable table_selesai = new DataTable();
            MySqlDataAdapter adapter_selesai = new MySqlDataAdapter(selectQueryselesai, connection);
            adapter_selesai.Fill(table_selesai);
            dataGridView3.DataSource = table_selesai;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
