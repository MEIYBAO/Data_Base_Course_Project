using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabManagement
{
    public partial class AddLabForm : Form
    {
        private string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";

        public AddLabForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = txtLabName.Text.Trim();
            string location = txtLocation.Text.Trim();
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(location))
            {
                MessageBox.Show("请输入实验室名称和位置！");
                return;
            }

            string sql = "INSERT INTO Lab (LabName, Location) VALUES (@name, @loc)";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@loc", location);
                conn.Open();
                cmd.ExecuteNonQuery();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
