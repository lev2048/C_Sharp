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

namespace StudentManager
{
    public partial class FrmAddStudent : Form
    {
        private StudentClassService objClassService = new StudentClassService();
        private StudentService objStudentService = new StudentService();
        public FrmAddStudent()
        {
            InitializeComponent();
            //初始化班级下拉框
            this.cboClassName.DataSource = objClassService.GetAllClass();
            this.cboClassName.DisplayMember = "ClassName";//displaymember用户看到的
            this.cboClassName.ValueMember = "ClassId";//classname对应的id
            this.cboClassName.SelectedIndex = -1;

        }
        //添加新学员
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //数据验证
            if(this.txtStudentName.Text.Trim().Length == 0)
            {
                MessageBox.Show("请填写学员姓名！", "验证提示");
                this.txtStudentName.Focus();
                return;
            }
            if (!this.rdoMale.Checked&&!this.rdoFemale.Checked)
            {
                MessageBox.Show("请选择性别", "验证提示");
                return;
            }
            if((DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year)<18)
            {
                MessageBox.Show("学员年龄不能小于18","验证提示");
                this.dtpBirthday.Focus();
                return;
            }
            if(this.cboClassName.SelectedIndex == -1)
            {
                MessageBox.Show("请选择班级！", "验证提示");
                return;
            }
            if (this.txtStudentIdNo.Text.Trim().Length == 0) 
            {
                MessageBox.Show("请填写身份证号", "验证提示");
                this.txtStudentIdNo.Focus();
                return;
            }
            if(this.txtCardNo.Text.Trim().Length == 0)
            {
                MessageBox.Show("卡号不能为空","验证提示");
                this.txtCardNo.Focus();
                return;
            }
         //验证身份证号格式是否符合要求
         if(!DataValidate.IsIdentityCard(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号不符合要求！","验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //验证身份证号是否与出生日期相吻合
            string month = string.Empty;
            string day = string.Empty;
            if (Convert.ToDateTime(this.dtpBirthday.Text).Month < 10)
                month = "0" + Convert.ToDateTime(this.dtpBirthday.Text).Month;
            else
                month = Convert.ToDateTime(this.dtpBirthday.Text).Month.ToString();
            if (Convert.ToDateTime(this.dtpBirthday.Text).Day < 10)
                day = "0" + Convert.ToDateTime(this.dtpBirthday.Text).Day;
            else
                day = Convert.ToDateTime(this.dtpBirthday.Text).Day.ToString();
            string birthday=Convert.ToDateTime(this.dtpBirthday.Text).Year.ToString()+ month + day;
            if (!this.txtStudentIdNo.Text.Trim().Contains(birthday))
            {
                MessageBox.Show("身份证号和出生日期不匹配！", "验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //判断身份证号是否重复
            if(this.objStudentService.IsIDCardExisted(this.txtStudentIdNo.Text.Trim()))
            {
                MessageBox.Show("身份证号已经存在！", "验证提示");
                this.txtStudentIdNo.Focus();
                this.txtStudentIdNo.SelectAll();
                return;
            }
            //判断卡号是否重复
            if (this.objStudentService.IsCardNoExisted(this.txtCardNo.Text.Trim()))
            {
                MessageBox.Show("靠请卡号已经存在！", "验证提示");
                this.txtCardNo.Focus();
                this.txtCardNo.SelectAll();
                return;
            }
            //封装学员对象
            Student objStudent = new Student()
            {
                StudentName = this.txtStudentName.Text.Trim(),
                Gender = this.rdoMale.Checked ? "男" : "女",
                Birthday = Convert.ToDateTime(this.dtpBirthday.Text),
                Age = DateTime.Now.Year - Convert.ToDateTime(this.dtpBirthday.Text).Year,
                ClassId = Convert.ToInt32(this.cboClassName.SelectedValue),
                StudentIdNo = this.txtStudentIdNo.Text.Trim(),
                CardNo = this.txtCardNo.Text.Trim(),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtAddress.Text.Trim(),
                StuImage=this.pbStu.Image==null?"":new SerializeObjectToString().SerializeObject(this.pbStu.Image)
            };

            //提交对象
            try
            {
                int result = objStudentService.AddStudent(objStudent);
                if (result == 1)
                {
                    DialogResult dresult = MessageBox.Show("添加成功！还继续添加吗？", "添加询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dresult == DialogResult.OK)
                    {
                        //清空文本
                        //this.txtAddress.Text = "";
                        //this.txtAddress.Clear();
                        foreach (Control item in this.groupBox1.Controls)
                        {
                            if (item is TextBox)
                                item.Text = "";
                            else if (item is RadioButton)
                                ((RadioButton)item).Checked = false;
                            else if (item is ComboBox)
                                ((ComboBox)item).SelectedIndex = -1;
                        }
                        this.pbStu.Image = null;
                    }
                }
                else MessageBox.Show("添加失败", "添加提示");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        //关闭窗体
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //选择新照片
        private void btnChoseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            DialogResult result = fileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                this.pbStu.Image = Image.FromFile(fileDialog.FileName);
            }
        }
    }
}
