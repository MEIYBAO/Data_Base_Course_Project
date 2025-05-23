using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabManagement
{
    public partial class DeviceEditForm : Form
    {
        private int? deviceId = null;
        private string connStr = "Data Source=localhost;Initial Catalog=LabDeviceManagement;Integrated Security=True;";

        public DeviceEditForm(int? id = null)
        {
            InitializeComponent();
            deviceId = id;
        }

        private void DeviceEditForm_Load(object sender, EventArgs e)
        {
            LoadLabAndManager();
            comboStatus.Items.Clear();
            comboStatus.Items.AddRange(new string[] { "正常", "借出", "维修", "报废" });

            if (deviceId.HasValue)
            {
                LoadDeviceInfo(deviceId.Value);
            }
        }

        private void LoadLabAndManager()
        {

            comboLab.Items.Clear();
            comboManager.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                SqlCommand labCmd = new SqlCommand("SELECT LabID, LabName FROM Lab", conn);
                SqlDataReader labReader = labCmd.ExecuteReader();
                while (labReader.Read())
                {
                    comboLab.Items.Add(new ComboBoxItem(labReader["LabName"].ToString(), (int)labReader["LabID"]));
                }
                labReader.Close();

                SqlCommand mgrCmd = new SqlCommand("SELECT ManagerID, Name FROM Manager", conn);
                SqlDataReader mgrReader = mgrCmd.ExecuteReader();
                while (mgrReader.Read())
                {
                    comboManager.Items.Add(new ComboBoxItem(mgrReader["Name"].ToString(), (int)mgrReader["ManagerID"]));
                }
            }
        }


        private void LoadDeviceInfo(int id)
        {
            string sql = "SELECT * FROM Device WHERE DeviceID = @id";
            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtName.Text = reader["DeviceName"].ToString();
                    txtModel.Text = reader["Model"].ToString();
                    datePurchase.Value = Convert.ToDateTime(reader["PurchaseDate"]);
                    comboStatus.Text = reader["Status"].ToString();

                    // 设置 comboLab 选中项
                    foreach (var obj in comboLab.Items)
                    {
                        if (obj is ComboBoxItem item && (int)item.Value == (int)reader["LabID"])
                        {
                            comboLab.SelectedItem = item;
                            break;
                        }
                    }

                    // 设置 comboManager 选中项
                    foreach (var obj in comboManager.Items)
                    {
                        if (obj is ComboBoxItem item && (int)item.Value == (int)reader["ManagerID"])
                        {
                            comboManager.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {
            string sql;
            if (deviceId.HasValue)
            {
                sql = @"UPDATE Device SET DeviceName=@name, Model=@model, PurchaseDate=@date,
                        Status=@status, LabID=@lab, ManagerID=@manager WHERE DeviceID=@id";
            }
            else
            {
                sql = @"INSERT INTO Device (DeviceName, Model, PurchaseDate, Status, LabID, ManagerID)
                        VALUES (@name, @model, @date, @status, @lab, @manager)";
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@model", txtModel.Text.Trim());
                cmd.Parameters.AddWithValue("@date", datePurchase.Value);
                cmd.Parameters.AddWithValue("@status", comboStatus.Text);
                cmd.Parameters.AddWithValue("@lab", ((ComboBoxItem)comboLab.SelectedItem).Value);
                cmd.Parameters.AddWithValue("@manager", ((ComboBoxItem)comboManager.SelectedItem).Value);
                if (deviceId.HasValue) cmd.Parameters.AddWithValue("@id", deviceId.Value);

                conn.Open();
                cmd.ExecuteNonQuery();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void comboLab_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public ComboBoxItem(string text, object value)
        {
            Text = text;
            Value = value;
        }
        public override string ToString() => Text;
    }
}
