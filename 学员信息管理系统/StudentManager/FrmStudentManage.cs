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
        private List<StudentExt> list = null;
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
            list = objStudentService.GetStudentByClassId(this.cboClass.SelectedValue.ToString());
            this.dgvStudentList.AutoGenerateColumns = false;//禁止生成不需要的列
            this.dgvStudentList.DataSource = list;
        }
        //根据学号查询
        private void btnQueryById_Click(object sender, EventArgs e)
        {
            if(this.txtStudentId.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入要查询的学号！", "查询提示");
                this.txtStudentId.Focus();
                return;
            }
            //根据学号查询学员对象
            StudentExt objStudent = objStudentService.GetStudentByStuId(this.txtStudentId.Text.Trim());
            if (objStudent == null)
            {
                MessageBox.Show("您输入的学号不正确，未找到该学员信息！","查询提示");
                this.txtStudentId.Focus();
                this.txtStudentId.SelectAll();
            }   
            else
            {
                //创建学员信息显示窗体
                FrmStudentinfo objStudentForm = new FrmStudentinfo(objStudent);
                objStudentForm.Show();
            }
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
            if (list == null || this.dgvStudentList.RowCount == 0) return;//防止误操作崩溃
            this.list.Sort(new NameDESC());//排序
            this.dgvStudentList.DataSource = null;
            this.dgvStudentList.DataSource = list;
        }
        //学号降序
        private void btnStuIdDESC_Click(object sender, EventArgs e)
        {
            if (list == null || this.dgvStudentList.RowCount == 0) return;
            this.list.Sort(new StudentIdDESC());//排序
            this.dgvStudentList.DataSource = null;
            this.dgvStudentList.DataSource = list;
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
        //回车查询
        private void txtStudentId_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtStudentId.Text.Trim().Length == 0) return;
            if (e.KeyValue == 13)
            {
                btnQueryById_Click(null, null);
            }
        }
    }
    /// <summary>
    /// 按照姓名降序排列
    /// </summary>

    class NameDESC:IComparer<StudentExt>
    {
        public int Compare(StudentExt x,StudentExt y)
        {
            return y.StudentName.CompareTo(x.StudentName);
        }
    }
    /// <summary>
    /// 按照学号降序排列
    /// </summary>
    class StudentIdDESC:IComparer<StudentExt>
    {
        public int Compare(StudentExt x, StudentExt y)
        {
            return y.StudentId.CompareTo(x.StudentId);
        }
    }
       
}
