using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabManagement
{
    public partial class DeviceManagementForm : Form
    {
        private string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";

        public DeviceManagementForm()
        {
            InitializeComponent();
        }

        private void DeviceManagementForm_Load(object sender, EventArgs e)
        {
            LoadDeviceList();
            ApplyPermissions();
        }

        private void LoadDeviceList()
        {
            string sql;

            if (CurrentUser.Role == "管理员")
            {
                sql = @"
            SELECT D.DeviceID, D.DeviceName, D.Model, D.PurchaseDate, D.Status,
                   L.LabName, U.User_name AS ManagerName
            FROM Device D
            JOIN Lab L ON D.LabID = L.LabID
            JOIN UserInfo U ON D.ManagerID = U.UserName";
            }
            else
            {
                sql = @"
            SELECT D.DeviceID, D.DeviceName, D.Model, D.PurchaseDate, D.Status,
                   L.LabName, U.User_name AS ManagerName
            FROM Device D
            JOIN Lab L ON D.LabID = L.LabID
            JOIN UserInfo U ON D.ManagerID = U.UserName
            WHERE D.ManagerID = @managerId";
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                if (CurrentUser.Role != "管理员")
                {
                    cmd.Parameters.AddWithValue("@managerId", CurrentUser.UserName);
                }

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvDevices.DataSource = table;
            }
        }

        private void ApplyPermissions()
        {
            btnAdd.Enabled = CurrentUser.Permissions.Contains("添加设备");
            btnEdit.Enabled = CurrentUser.Permissions.Contains("添加设备");
            btnDelete.Enabled = CurrentUser.Permissions.Contains("删除设备");
        }


        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            DeviceEditForm form = new DeviceEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadDeviceList();
            }
        }

        private void btnEdit_Click_1(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow != null)
            {
                int deviceId = Convert.ToInt32(dgvDevices.CurrentRow.Cells["DeviceID"].Value);
                DeviceEditForm form = new DeviceEditForm(deviceId);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadDeviceList();
                }
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvDevices.CurrentRow != null)
            {
                int deviceId = Convert.ToInt32(dgvDevices.CurrentRow.Cells["DeviceID"].Value);
                string deviceName = dgvDevices.CurrentRow.Cells["DeviceName"].Value.ToString();

                DialogResult result = MessageBox.Show(
                    $"确认要删除设备【{deviceName}】吗？",
                    "确认删除",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();

                        // 1️⃣ 删除设备
                        string sql = "DELETE FROM Device WHERE DeviceID = @id";
                        using (SqlCommand cmd = new SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", deviceId);
                            cmd.ExecuteNonQuery();
                        }

                        // 2️⃣ 写入日志
                        string logSql = @"INSERT INTO DeviceLog (DeviceID, Action, Operator, ActionDate, Note)
                                  VALUES (@deviceId, @action, @operator, @date, @note)";
                        using (SqlCommand logCmd = new SqlCommand(logSql, conn))
                        {
                            logCmd.Parameters.AddWithValue("@deviceId", deviceId);
                            logCmd.Parameters.AddWithValue("@action", "删除设备");
                            logCmd.Parameters.AddWithValue("@operator", CurrentUser.UserName);
                            logCmd.Parameters.AddWithValue("@date", DateTime.Now);
                            logCmd.Parameters.AddWithValue("@note", $"删除设备：{deviceName}");
                            logCmd.ExecuteNonQuery();
                        }
                    }

                    LoadDeviceList();
                }
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadDeviceList();
        }
    }
}
