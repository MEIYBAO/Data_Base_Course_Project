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
    public partial class LoginForm : Form
    {
        private List<string> LoadUserPermissionsFromDatabase(string userName)
        {
            List<string> permissions = new List<string>();
            string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";

            string sql = @"
            SELECT P.PermissionName 
            FROM UserPermission UP
            JOIN Permission P ON UP.PermissionID = P.PermissionID
            WHERE UP.UserName = @userName";


            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@userName", userName);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        permissions.Add(reader.GetString(0));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("加载权限失败：" + ex.Message);
                }
            }

            return permissions;
        }

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "用户登录 - 实验室设备管理系统";
            this.Icon = new Icon(Application.StartupPath + @"\Resources\logo.ico");
            this.AcceptButton = btnLogin;
            this.CancelButton = btnExit;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "请输入用户名和密码";
                return;
            }

            string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";
            string sql = @"
                SELECT Role FROM UserInfo 
                WHERE UserName = @username 
                AND PasswordHash = HASHBYTES('SHA2_256', @password)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 64).Value = password;

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string role = reader.GetString(0);

                            // 设置当前用户信息（示例 CurrentUser）
                            CurrentUser.UserName = username;
                            CurrentUser.Role = role;

                            if (role == "管理员")
                            {
                                CurrentUser.Permissions = new List<string> { "查看设备", "添加设备", "删除设备", "管理用户" };
                            }
                            else
                            {
                                CurrentUser.Permissions = LoadUserPermissionsFromDatabase(username);
                            }

                            DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            lblMessage.Text = "用户名或密码错误";
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "数据库连接失败：" + ex.Message;
                }
            }
        }

        private void chkShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !chkShowPwd.Checked;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "确定要退出系统吗？",
                "退出确认",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
