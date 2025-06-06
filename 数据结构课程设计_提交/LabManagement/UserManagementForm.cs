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
                SELECT U.UserName,U.User_name,U.contact,U.Role
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                string strname=dgvUsers.CurrentRow.Cells["UserName"].Value.ToString();
                UserEditForm form = new UserEditForm(strname);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadUserList();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                string strname = dgvUsers.CurrentRow.Cells["UserName"].Value.ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // 1️⃣ 检查是否有设备引用该用户作为管理员
                    string checkSql = "SELECT COUNT(*) FROM Device WHERE ManagerID = @name";
                    using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@name", strname);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show($"该用户【{strname}】目前被 {count} 个设备作为管理员使用，无法删除。", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // 2️⃣ 提示确认删除
                    DialogResult result = MessageBox.Show(
                        $"确认要删除用户名为【{strname}】的用户吗？",
                        "确认删除",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        // 3️⃣ 执行删除
                        string sql = @"DELETE FROM UserInfo WHERE UserName = @name";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@name", strname);
                            cmd.ExecuteNonQuery();
                        }

                        LoadUserList();
                    }
                }
            }
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                string strname = dgvUsers.CurrentRow.Cells["UserName"].Value.ToString();
                AuthorizeForm form = new AuthorizeForm(strname);
                form.ShowDialog();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadUserList();
        }
    }
}