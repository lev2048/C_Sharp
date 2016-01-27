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
using Models;
using Models.Ext;

namespace StudentManager
{
    public partial class FrmStudentManage : Form
    {
        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStudentService = new StudentService();
        public FrmStudentManage()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClass.DataSource = objClassService.GetAllClass();
            this.cboClass.DisplayMember = "ClassName";//displaymember用户看到的
            this.cboClass.ValueMember = "ClassId";//classname对应的id
            this.cboClass.SelectedIndex = -1;
        }
        //按照班级查询
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (this.cboClass.SelectedIndex == -1)
            {
                MessageBox.Show("请选择一个班级！", "查询提示");
                this.cboClass.Focus();
                return;
            }
            List<StudentExt> list = objStudentService.GetStudentByClassId(this.cboClass.SelectedValue.ToString());
            this.dgvStudentList.AutoGenerateColumns = false;//禁止生成不需要的列
            this.dgvStudentList.DataSource = list;
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
            DataGridViewStyle.DgvRowPostPaint(this.dgvStudentList, e);
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
