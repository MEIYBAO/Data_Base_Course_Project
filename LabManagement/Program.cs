using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LabManagement
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
           Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        LoginForm login = new LoginForm();
        if (login.ShowDialog() == DialogResult.OK)
        {
            // 登录成功后启动主窗口
            Application.Run(new MainForm(login.LoggedInRole)); // 可以传入角色
        }
        }
    }
}
