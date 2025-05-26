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
    public partial class AuthorizeForm: Form
    {
        private string strname = null;
        private string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";

        public AuthorizeForm(string str)
        {
            InitializeComponent();
            this.strname = str;
        }

        private void AuthorizeForm_Load(object sender, EventArgs e)
        {
            labelUser.Text = "用户名：    "+strname;

            // 权限 1
            string sql = @"SELECT P.PermissionName
                                FROM Permission P
                                WHERE P.PermissionID=@id";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", 1);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    label1.Text= reader["PermissionName"].ToString();
                }
            }

            // 权限 2
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", 2);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    label2.Text = reader["PermissionName"].ToString();
                }
            }

            // 权限 3
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", 3);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    label3.Text = reader["PermissionName"].ToString();
                }
            }

            // 权限 4
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", 4);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    label4.Text = reader["PermissionName"].ToString();
                }
            }

            // 是否拥有权限 1
            sql = @"SELECT 1
                    FROM UserPermission U JOIN Permission P 
                        ON U.PermissionID=P.PermissionID
                    WHERE U.UserName=@name AND P.PermissionID=@id";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", strname);
                cmd.Parameters.AddWithValue("@id", 1);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comboBox1.Text = "已授权";
                }
                else
                {
                    comboBox1.Text = "未授权";
                }
            }

            // 是否拥有权限 2
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", strname);
                cmd.Parameters.AddWithValue("@id", 2);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comboBox2.Text = "已授权";
                }
                else
                {
                    comboBox2.Text = "未授权";
                }
            }

            // 是否拥有权限 3
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", strname);
                cmd.Parameters.AddWithValue("@id", 3);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comboBox3.Text = "已授权";
                }
                else
                {
                    comboBox3.Text = "未授权";
                }
            }

            // 是否拥有权限 4
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", strname);
                cmd.Parameters.AddWithValue("@id", 4);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    comboBox4.Text = "已授权";
                }
                else
                {
                    comboBox4.Text = "未授权";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = @"SELECT 1
                            FROM UserPermission
                            WHERE UserName=@name AND PermissionID=@id";
            string sql1 = @"INSERT INTO UserPermission(UserName,PermissionID)
                            VALUES(@name,@id)";
            string sql2 = @"DELETE FROM UserPermission
                            WHERE UserName=@name AND PermissionID=@id";

            // 权限 1 更新
            if(comboBox1.Text=="已授权")
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", strname);
                    cmd.Parameters.AddWithValue("@id", 1);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        using (SqlConnection conn1 = new SqlConnection(connStr))
                        using (SqlCommand cmd1 = new SqlCommand(sql1, conn1))
                        {
                            cmd1.Parameters.AddWithValue("@name", strname);
                            cmd1.Parameters.AddWithValue("@id", 1);
                            conn1.Open();
                            cmd1.ExecuteReader();
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql2, conn))
                {
                    cmd.Parameters.AddWithValue("@name", strname);
                    cmd.Parameters.AddWithValue("@id", 1);
                    conn.Open();
                    cmd.ExecuteReader();
                }
            }

            // 权限 2 更新
            if (comboBox2.Text == "已授权")
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", strname);
                    cmd.Parameters.AddWithValue("@id", 2);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        using (SqlConnection conn1 = new SqlConnection(connStr))
                        using (SqlCommand cmd1 = new SqlCommand(sql1, conn1))
                        {
                            cmd1.Parameters.AddWithValue("@name", strname);
                            cmd1.Parameters.AddWithValue("@id", 2);
                            conn1.Open();
                            cmd1.ExecuteReader();
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql2, conn))
                {
                    cmd.Parameters.AddWithValue("@name", strname);
                    cmd.Parameters.AddWithValue("@id", 2);
                    conn.Open();
                    cmd.ExecuteReader();
                }
            }

            // 权限 3 更新
            if (comboBox3.Text == "已授权")
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", strname);
                    cmd.Parameters.AddWithValue("@id", 3);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        using (SqlConnection conn1 = new SqlConnection(connStr))
                        using (SqlCommand cmd1 = new SqlCommand(sql1, conn1))
                        {
                            cmd1.Parameters.AddWithValue("@name", strname);
                            cmd1.Parameters.AddWithValue("@id", 3);
                            conn1.Open();
                            cmd1.ExecuteReader();
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql2, conn))
                {
                    cmd.Parameters.AddWithValue("@name", strname);
                    cmd.Parameters.AddWithValue("@id", 3);
                    conn.Open();
                    cmd.ExecuteReader();
                }
            }

            // 权限 4 更新
            if (comboBox4.Text == "已授权")
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", strname);
                    cmd.Parameters.AddWithValue("@id", 4);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        using (SqlConnection conn1 = new SqlConnection(connStr))
                        using (SqlCommand cmd1 = new SqlCommand(sql1, conn1))
                        {
                            cmd1.Parameters.AddWithValue("@name", strname);
                            cmd1.Parameters.AddWithValue("@id", 4);
                            conn1.Open();
                            cmd1.ExecuteReader();
                        }
                    }
                }
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql2, conn))
                {
                    cmd.Parameters.AddWithValue("@name", strname);
                    cmd.Parameters.AddWithValue("@id", 4);
                    conn.Open();
                    cmd.ExecuteReader();
                }
            }
        }
    }
}
