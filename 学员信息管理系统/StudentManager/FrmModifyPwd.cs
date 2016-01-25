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
    public partial class FrmModifyPwd : Form
    {
        private AdminService objAdminService = new AdminService();
        public FrmModifyPwd()
        {
            InitializeComponent();
        }
        //修改密码
        private void btnModify_Click(object sender, EventArgs e)
        {
            //校验旧密码
            if (this.txtOldPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入原密码","修改提示");
                this.txtOldPwd.Focus();
                return;
            }
            //判断原密码是否正确
            if(this.txtOldPwd.Text.Trim()!=Program.currentAdmin.LoginPwd)
            {
                MessageBox.Show("原密码不正确！","修改提示");
                this.txtOldPwd.Focus();
                this.txtOldPwd.SelectAll();
                return;
            }
            //判断新密码是否空
            if(this.txtNewPwd.Text.Trim().Length == 0)
            {
                MessageBox.Show("请输入新密码！", "修改提示");
                this.txtNewPwd.Focus();
                return;
            }
            //判断密码长度
            if(this.txtNewPwd.Text.Trim().Length < 6 ||this.txtNewPwd.Text.Trim().Length > 18)
            {
                MessageBox.Show("新密码长度必须在6-18位之间！", "密码修改提示");
                this.txtNewPwd.Focus();
                this.txtNewPwd.SelectAll();
                return;

            }
            //判断新密码是否一致
            if(this.txtNewPwd.Text.Trim()!=this.txtNewPwdConfirm.Text.Trim())
            {
                MessageBox.Show("两次输入的新密码不一致！", "密码修改提示");
                return;
            }
            //将新密码提交到数据库
            int result = objAdminService.ModifyPwd(Program.currentAdmin.LoginId.ToString(),this.txtNewPwd.Text.Trim());
            if (result == 1)
            {
                MessageBox.Show("新密码修改成功。", "修改提示");
                Program.currentAdmin.LoginPwd = this.txtNewPwdConfirm.Text.Trim();
                this.Close();
            }
        }
        //取消
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
