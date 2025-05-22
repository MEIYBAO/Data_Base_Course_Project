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

    public partial class LoginForm: Form
    {
        //全局变量：登录角色
        public string LoggedInRole { get; private set; }

        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "用户登录 - 实验室设备管理系统";
            this.Icon = new Icon(Application.StartupPath + @"\Resources\logo.ico");
            this.AcceptButton = btnLogin; // 让回车键触发登录按钮
            this.CancelButton = btnExit; // 设置 ESC 快捷键退出

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
                WHERE Username = @username 
                AND PasswordHash = HASHBYTES('SHA2_256', @password)";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.Add("@password", SqlDbType.VarChar, 64).Value = password;

                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        LoggedInRole = result.ToString();
                        DialogResult = DialogResult.OK; // 关闭登录窗口，允许进入主窗体
                        this.Close();
                    }
                    else
                    {
                        lblMessage.Text = "用户名或密码错误";
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "数据库连接失败：" + ex.Message;
                }
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
