using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ComputerToArduino
{
    public partial class labkimia : Form
    {
        //MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog='dbscan';username=root;password=");
        SqlConnection cnn = new SqlConnection ("Data Source=LAPTOP-D2834IOL;Initial Catalog=RFID_Scanner;Integrated Security=True");
        
        public labkimia()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            cnn.Open();
            string selectQueryantri = "SELECT kode_barang, nama_barang FROM Master_Loket WHERE EXISTS (SELECT uid from Antrian_LKimia WHERE Master_Loket.uid = Antrian_LKimia.uid)";
            DataTable table_antri = new DataTable();
            SqlDataAdapter adapter_antri = new SqlDataAdapter(selectQueryantri, cnn);
            adapter_antri.Fill(table_antri);
            dg_antrikimia.DataSource = table_antri;

            string selectQueryproses = "SELECT kode_barang, nama_barang FROM Master_Loket WHERE EXISTS (SELECT uid from Proses_LKimia WHERE Master_Loket.uid = Proses_LKimia.uid)";
            DataTable table_proses = new DataTable();
            SqlDataAdapter adapter_proses = new SqlDataAdapter(selectQueryproses, cnn);
            adapter_proses.Fill(table_proses);
            dg_proseskimia.DataSource = table_proses;

            string selectQueryselesai = "SELECT kode_barang, nama_barang FROM Master_Loket WHERE EXISTS (SELECT uid from Selesai_LKimia WHERE Master_Loket.uid = Selesai_LKimia.uid)";
            DataTable table_selesai = new DataTable();
            SqlDataAdapter adapter_selesai = new SqlDataAdapter(selectQueryselesai, cnn);
            adapter_selesai.Fill(table_selesai);
            dg_selesaikimia.DataSource = table_selesai;

        }

        private void labfisika_FormClosed(object sender, FormClosedEventArgs e)
        {
            utama.labkimiaform = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
