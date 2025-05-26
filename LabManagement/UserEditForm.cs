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
    public partial class UserEditForm: Form
    {
        public UserEditForm()
        {
            InitializeComponent();
        }

        private void UserEditForm_Load(object sender, EventArgs e)
        {
            comboRole.Items.Clear();
            comboRole.Items.AddRange(new string[] { "管理员", "普通用户" });
        }
    }
}
