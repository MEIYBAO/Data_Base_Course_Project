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
    public partial class UserManagementForm : Form
    {
        private string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";

        public UserManagementForm()
        {
            InitializeComponent();
        }

        private void UserManagementForm_Load_1(object sender, EventArgs e)
        {
            LoadUserList();
        }
        private void LoadUserList()
        {
            string sql = @"
                SELECT U.UserName,U.User_name,U.contact
                FROM UserInfo U
                WHERE U.Role='普通用户'";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
            {
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvUsers.DataSource = table;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserEditForm form = new UserEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUserList();
            }
        }
    }
}