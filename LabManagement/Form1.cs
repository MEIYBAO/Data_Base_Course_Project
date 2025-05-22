using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManagement
{
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();

            con.ConnectionString = "server=localhost;database=LabDeviceManagement;Integrated Security=True;";

            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "select * from Device";

            cmd.Connection = con;

            con.Open();

            SqlDataReader rd;

            rd = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(rd);

            dgvDevice.DataSource = dt;

            rd.Close();

            con.Close();
        }
    }
}
