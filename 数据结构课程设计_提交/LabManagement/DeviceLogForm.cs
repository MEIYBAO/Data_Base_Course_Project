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
    public partial class DeviceLogForm: Form
    {
        private string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";

        public DeviceLogForm()
        {
            InitializeComponent();
        }

        private void DeviceLogForm_Load(object sender, EventArgs e)
        {
            LoadDeviceLog();
        }

        private void LoadDeviceLog()
        {
            string sql = @"SELECT LogID,DeviceID,Action,Operator,ActionDate,Note
                            FROM DeviceLog";

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dgvDeviceLog.DataSource = table;
            }
        }
    }
}
