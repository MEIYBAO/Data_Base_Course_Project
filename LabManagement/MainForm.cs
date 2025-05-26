using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabManagement
{
    public partial class MainForm: Form
    {

        private string userRole;

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 可留空或添加初始化代码
        }

        public MainForm()
        {
            InitializeComponent();

            this.Text = $"欢迎 {CurrentUser.UserName} 使用实验室仪器管理系统 - 当前角色：{CurrentUser.Role}";

            // 示例：根据角色隐藏某些控件
           
            // 权限控制
            btnUserManager.Visible = CurrentUser.Role == "管理员";
        }

        private void btnDeviceManager_Click(object sender, EventArgs e)
        {
            DeviceManagementForm form = new DeviceManagementForm();
            form.ShowDialog();
        }

        private void btnUserManager_Click(object sender, EventArgs e)
        {
            UserManagementForm form = new UserManagementForm();
            form.ShowDialog();
        }
    }
}
