﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Models;


namespace StudentManager
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

            //显示登录窗体
            FrmUserLogin objLoginForm = new FrmUserLogin();
            DialogResult reuslt = objLoginForm.ShowDialog();

            //判断登录是否成功
            if (reuslt == DialogResult.OK)
                Application.Run(new FrmMain());
            else
                Application.Exit();//退出整个应用程序
        }

        //定义一个全局变量
        public static Admin currentAdmin = null;
    }
}
