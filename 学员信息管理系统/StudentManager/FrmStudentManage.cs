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
    public partial class FrmStudentManage : Form
    {
        public FrmStudentManage()
        {
            InitializeComponent();
        }
        //按照班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {

        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {

        }

        private void txtStudentId_TextChanged(object sender, EventArgs e)
        {

        }

        //双击选中的学员对象并显示详细信息
        private void dgvStudentList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //修改学员对象
        private void btnEidt_Click(object sender, EventArgs e)
        {

        }
        //姓名降序
        private void btnNameDESC_Click(object sender, EventArgs e)
        {

        }
        //学号降序
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {

        }
        //添加行号
        private void dgvStudentList_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }
        //打印当前学生信息
        private void btnPrint_Click(object sender, EventArgs e)
        {

        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
