﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        #region 嵌入窗体显示

        //打开窗体
        private void OpenForm(Form objForm)
        {
            objForm.TopLevel = false;//将当前子窗体设置成非顶级控件
            objForm.WindowState = FormWindowState.Maximized;//设置窗体最大化
            objForm.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            objForm.Parent = this.panelForm;//指定当前子窗体显示的容器
            objForm.Show();
        }
        /// <summary>
        /// 关闭窗体
        /// </summary>
        private void CloseForm()
        {
            foreach (Control item in this.panelForm.Controls)
            {
                if (item is Form)
                {
                    Form objControl = (Form)item;
                    objControl.Close();
                    this.panelForm.Controls.Remove(item);
                }
            }
        }
        //显示添加新学员窗体
        private void tsmiAddStudent_Click(object sender, EventArgs e)
        {
            CloseForm();
            FrmAddStudent objForm = new FrmAddStudent();
            this.OpenForm(objForm);
        }

        //考勤打卡
        private void tsmi_Card_Click(object sender, EventArgs e)
        {
            CloseForm();
            FrmAttendance objForm = new FrmAttendance();
            this.OpenForm(objForm);
        }
        //成绩快速查询【嵌入显示】
        private void tsmiQuery_Click(object sender, EventArgs e)
        {
            CloseForm();
            FrmScoreQuery objForm = new FrmScoreQuery();
            this.OpenForm(objForm);
        }
        //学员信息管理【嵌入显示】
        private void tsmiManageStudent_Click(object sender, EventArgs e)
        {
            CloseForm();
            FrmStudentManage objForm = new FrmStudentManage();
            this.OpenForm(objForm);
        }
        //显示成绩查询与分析窗口
        private void tsmiQueryAndAnalysis_Click(object sender, EventArgs e)
        {
            FrmScoreManage objForm = new FrmScoreManage();
        }
        //考勤查询
        private void tsmi_AQuery_Click(object sender, EventArgs e)
        {
            FrmAttendanceQuery objForm = new FrmAttendanceQuery();
        }
        
        #endregion

        #region 退出系统确认
        //退出系统
        private void tmiClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("确认退出吗？", "退出询问",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region 其他

        private void tmiModifyPwd_Click(object sender, EventArgs e)
        {
            FrmModifyPwd objPwd = new FrmModifyPwd();
            objPwd.ShowDialog();
        }

        private void tsbAddStudent_Click(object sender, EventArgs e)
        {
            tsmiAddStudent_Click(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tsmiManageStudent_Click(null, null);
        }

        private void tsbScoreAnalysis_Click(object sender, EventArgs e)
        {
            tsmiQueryAndAnalysis_Click(null, null);
        }

        private void tsbQuery_Click(object sender, EventArgs e)
        {
            tsmiQuery_Click(null, null);
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbModifyPwd_Click(object sender, EventArgs e)
        {
            tmiModifyPwd_Click(null, null);
        }
        //访问官网
        private void tsmi_linkxkt_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "https://lev.shield.asia");
        }
        //关于
        private void tsmi_about_Click(object sender, EventArgs e)
        {
            FrmAbout objAbout = new FrmAbout();
            objAbout.Show();
        }
        #endregion

        
    }
}
