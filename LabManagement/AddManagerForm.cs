using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabManagement
{
    public partial class AddManagerForm : Form
    {
        private string connStr = "Data Source=localhost;InitialCatalog=LabDeviceManagement;IntegratedSecurity=True;";

        public AddManagerForm()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string contact = txtContact.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contact))
            {
                MessageBox.Show("请输入管理员姓名和联系方式！");
                return;
            }

            string sql = "INSERT INTO Manager (Name, Contact) VALUES (@name, @contact)";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@contact", contact);
                conn.Open();
                cmd.ExecuteNonQuery();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void AddManagerForm_Load(object sender, EventArgs e)
        {

        }
    }
}
