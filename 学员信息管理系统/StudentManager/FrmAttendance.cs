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
    public partial class FrmAttendance : Form
    {
        public FrmAttendance()
        {
            InitializeComponent();
        }
        //显示当前时间
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        //学员打卡
        private void txtStuCardNo_TextChanged(object sender, EventArgs e)
        {

        }
        //结束打卡
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
