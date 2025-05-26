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
    public partial class UserEditForm: Form
    {
        private string strname = null;
        private string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";

        public UserEditForm(string str=null)
        {
            InitializeComponent();
            this.strname = str;
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            comboRole.Items.Clear();
            comboRole.Items.AddRange(new string[] { "管理员", "普通用户" });

            if(strname != null)
            {
                LoadUserInfo(strname);
            }
        }

        private void LoadUserInfo(string str)
        {
            string sql = @"SELECT U.UserName,U.User_name,U.Contact,U.Role
                            FROM UserInfo U
                            WHERE U.UserName=@str";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@str", str);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = reader["UserName"].ToString();
                    txtName.Enabled = false;
                    txtRealName.Text = reader["User_name"].ToString();
                    txtContact.Text = reader["Contact"].ToString();
                    comboRole.Text = reader["Role"].ToString();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 🔒 表单验证
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入用户名！");
                txtName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRealName.Text))
            {
                MessageBox.Show("请输入用户姓名！");
                txtRealName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("请输入密码！");
                txtPassword.Focus();
                return;
            }

            if (comboRole.SelectedItem == null)
            {
                MessageBox.Show("请选择身份！");
                comboRole.DroppedDown = true;
                return;
            }

            string sql;
            if(strname!=null)
            {
                sql = @"UPDATE UserInfo
                        SET User_name=@realname,Contact=@contact,PasswordHash=HASHBYTES('SHA2_256',@password),Role=@role
                        WHERE UserName=@name";
            }
            else
            {
                sql = @"INSERT INTO UserInfo(UserName,User_name,Contact,PasswordHash,Role)
                            VALUES(@name,@realname,@contact,HASHBYTES('SHA2_256',@password),@role)";
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@realname", txtRealName.Text.Trim());
                cmd.Parameters.AddWithValue("@contact", txtContact.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txtPassword.Text.Trim());
                cmd.Parameters.AddWithValue("@role", comboRole.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
