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

                // 加载实验室
                SqlCommand labCmd = new SqlCommand("SELECT LabID, LabName FROM Lab", conn);
                SqlDataReader labReader = labCmd.ExecuteReader();
                while (labReader.Read())
                {
                    comboLab.Items.Add(new ComboBoxItem(labReader["LabName"].ToString(), (int)labReader["LabID"]));
                }
                labReader.Close();

                comboLab.Items.Add(new ComboBoxItem("➕ 添加新实验室", -1));

                if (CurrentUser.Role == "管理员")
                {
                    // 加载所有用户作为设备管理员
                    SqlCommand mgrCmd = new SqlCommand("SELECT UserName, User_name FROM UserInfo", conn);
                    SqlDataReader mgrReader = mgrCmd.ExecuteReader();
                    while (mgrReader.Read())
                    {
                        comboManager.Items.Add(new ComboBoxItem(mgrReader["User_name"].ToString(), mgrReader["UserName"].ToString()));
                    }
                    mgrReader.Close();

                    comboManager.Items.Add(new ComboBoxItem("➕ 添加新管理员", -1));
                }
                else
                {
                    // 普通用户，只能选择自己
                    comboManager.Items.Add(new ComboBoxItem(CurrentUser.UserName, CurrentUser.UserName));
                    comboManager.SelectedIndex = 0;
                    comboManager.Enabled = false; // 不允许修改
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
                        if (obj is ComboBoxItem item && item.Value.ToString() == reader["ManagerID"].ToString())
                        {
                            comboManager.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }

        private int GetLastInsertedDeviceId(SqlConnection conn)
        {
            SqlCommand cmd = new SqlCommand("SELECT IDENT_CURRENT('Device')", conn);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }



        private void btnSave_Click_1(object sender, EventArgs e)
        {

            string sql;
            bool isEdit = deviceId.HasValue;

            if (isEdit)
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
                if (CurrentUser.Role == "管理员")
                {
                    cmd.Parameters.AddWithValue("@manager", ((ComboBoxItem)comboManager.SelectedItem).Value);
                }
                else
                {
                    // 普通用户只能将自己作为设备负责人
                    cmd.Parameters.AddWithValue("@manager", CurrentUser.UserName);
                }

                if (isEdit) cmd.Parameters.AddWithValue("@id", deviceId.Value);

                conn.Open();
                cmd.ExecuteNonQuery();

                // ✅ 获取设备ID（新建需用 SELECT IDENT_CURRENT）
                int realDeviceId = isEdit ? deviceId.Value : GetLastInsertedDeviceId(conn);

                // ✅ 写入日志
                string logSql = @"INSERT INTO DeviceLog (DeviceID, Action, Operator, ActionDate, Note)
                          VALUES (@deviceId, @action, @operator, @date, @note)";
                using (SqlCommand logCmd = new SqlCommand(logSql, conn))
                {
                    logCmd.Parameters.AddWithValue("@deviceId", realDeviceId);
                    logCmd.Parameters.AddWithValue("@action", isEdit ? "修改设备信息" : "创建设备");
                    logCmd.Parameters.AddWithValue("@operator", CurrentUser.UserName);  // 登录用户
                    logCmd.Parameters.AddWithValue("@date", DateTime.Now);
                    logCmd.Parameters.AddWithValue("@note", "通过编辑页面自动记录");
                    logCmd.ExecuteNonQuery();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void comboLab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboLab.SelectedItem is ComboBoxItem selectedItem && (int)selectedItem.Value == -1)
            {
                // 打开新增实验室窗口
                AddLabForm addLab = new AddLabForm();
                if (addLab.ShowDialog() == DialogResult.OK)
                {
                    LoadLabAndManager();
                }
            }
        }

        private void comboManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboManager.SelectedItem is ComboBoxItem selectedItem && selectedItem.Value.ToString() == "-1")
            {
                // 打开新增管理员窗口
                AddManagerForm addMgr = new AddManagerForm();
                if (addMgr.ShowDialog() == DialogResult.OK)
                {
                    LoadLabAndManager();
                }
            }
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
