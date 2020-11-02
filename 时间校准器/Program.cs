using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace 时间校准器
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flag;
            using (new Mutex(true, Application.ProductName, out flag))
            {
                if (flag)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmMian());
                }
                else
                {
                    MessageBox.Show("抱歉，您的电脑中已有一个程序在运行，请关闭后再重启！");
                    Thread.Sleep(0x3e8);
                    Environment.Exit(1);
                }
            }
        }
    }
}
