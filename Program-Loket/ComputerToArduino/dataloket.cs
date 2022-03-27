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
    public partial class dataloket : Form
    {
        SqlConnection connection = new SqlConnection
            ("Data Source=LAPTOP-D2834IOL;Initial Catalog=RFID_Scanner;Integrated Security=True");
        public dataloket()
        {
            InitializeComponent();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {
            string selectQueryloket = "SELECT * from Master_Loket";
            DataTable table_loket = new DataTable();
            SqlDataAdapter adapter_loket = new SqlDataAdapter(selectQueryloket, connection);
            adapter_loket.Fill(table_loket);
            dataGridView1.DataSource = table_loket;
        }

        private void dataloket_FormClosed(object sender, FormClosedEventArgs e)
        {
            utama.dataloketform = false;
        }

    }
}
