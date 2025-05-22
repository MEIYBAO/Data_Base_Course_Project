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

        public MainForm(string role)
        {
            InitializeComponent();

            userRole = role;
            this.Text = $"欢迎使用实验室仪器管理系统 - 当前角色：{userRole}";

            // 示例：根据角色隐藏某些控件
            if (userRole != "管理员")
            {
                // 比如隐藏“添加设备”按钮
                // btnAddDevice.Visible = false;
            }
        }
    }
}
