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
            string sql = @"
                SELECT D.DeviceID, D.DeviceName, D.Model, D.PurchaseDate, D.Status,
                       L.LabName, M.Name AS ManagerName
                FROM Device D
                JOIN Lab L ON D.LabID = L.LabID
                JOIN Manager M ON D.ManagerID = M.ManagerID";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, conn))
            {
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
                string sql = "DELETE FROM Device WHERE DeviceID = @id";

                using (SqlConnection conn = new SqlConnection(connStr))
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@id", deviceId);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadDeviceList();
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadDeviceList();
        }
    }
}
