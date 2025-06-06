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
    public partial class EditLabForm: Form
    {
        private string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";
        public EditLabForm()
        {
            InitializeComponent();
        }

        private void EditLabForm_Load(object sender, EventArgs e)
        {

            this.dgvLab.CellClick += new DataGridViewCellEventHandler(this.dgvLab_CellClick);


            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT LabID, LabName, Location FROM Lab";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvLab.DataSource = table;
                }
            }
        }
        private void LoadLabs()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT LabID, LabName,Location FROM Lab";
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
                {
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dgvLab.DataSource = table;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtLabName.Text.Trim();
            string location = txtLabLocation.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(location))
            {
                MessageBox.Show("实验室名称和位置都不能为空！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "INSERT INTO Lab (LabName, Location) VALUES (@name, @location)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@location", location);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LoadLabs();
            txtLabName.Clear();
            txtLabLocation.Clear();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvLab.CurrentRow == null) return;

            int labId = Convert.ToInt32(dgvLab.CurrentRow.Cells["LabID"].Value);
            string newName = txtLabName.Text.Trim();
            string newLoc = txtLabLocation.Text.Trim();

            if (string.IsNullOrEmpty(newName) || string.IsNullOrEmpty(newLoc))
            {
                MessageBox.Show("实验室名称和位置都不能为空！", "输入错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "UPDATE Lab SET LabName=@name, Location=@loc WHERE LabID=@id";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", newName);
                    cmd.Parameters.AddWithValue("@loc", newLoc);
                    cmd.Parameters.AddWithValue("@id", labId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            LoadLabs();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvLab.CurrentRow == null) return;

            int labId = Convert.ToInt32(dgvLab.CurrentRow.Cells["LabID"].Value);
            string name = dgvLab.CurrentRow.Cells["LabName"].Value.ToString();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // 1️⃣ 检查是否有设备引用该实验室
                string checkSql = "SELECT COUNT(*) FROM Device WHERE LabID = @id";
                using (SqlCommand checkCmd = new SqlCommand(checkSql, conn))
                {
                    checkCmd.Parameters.AddWithValue("@id", labId);
                    int count = (int)checkCmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show($"该实验室【{name}】已被 {count} 个设备引用，无法删除。", "删除失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 2️⃣ 无引用，确认删除
                DialogResult result = MessageBox.Show($"确认要删除实验室【{name}】吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string deleteSql = "DELETE FROM Lab WHERE LabID = @id";
                    using (SqlCommand deleteCmd = new SqlCommand(deleteSql, conn))
                    {
                        deleteCmd.Parameters.AddWithValue("@id", labId);
                        deleteCmd.ExecuteNonQuery();
                    }

                    LoadLabs();
                }
            }
        }

        private void dgvLab_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvLab.CurrentRow != null)
            {
                txtLabName.Text = dgvLab.CurrentRow.Cells["LabName"].Value.ToString();
                txtLabLocation.Text = dgvLab.CurrentRow.Cells["Location"].Value?.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadLabs();
        }
    }
}
