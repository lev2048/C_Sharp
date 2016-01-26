using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;

namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        private StudentClassService objClassService = new StudentClassService();
        public FrmAddStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClassName.DataSource = objClassService.GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";//displaymember用户看到的
            this.cboClassName.ValueMember = "ClassId";//classname对应的id

        }
        //添加新学员
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //选择新照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {

        }
    }
}
