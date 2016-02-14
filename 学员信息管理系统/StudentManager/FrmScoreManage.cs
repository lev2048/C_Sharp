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
    public partial class FrmScoreManage : Form
    {
        private ScoreListService objScoreService = new ScoreListService();
        public FrmScoreManage()
        {
            InitializeComponent();
            this.cboClass.DataSource = new StudentClassService().GetAllStuClass().Tables[0];//注意tables0错误
            this.cboClass.DisplayMember = "ClassName";
            this.cboClass.ValueMember = "ClassId";
            this.cboClass.SelectedIndex = -1;
            //消除事件
            this.cboClass.SelectedIndexChanged -= new EventHandler(this.cboClass_SelectedIndexChanged);
        }
        //根据班级查询
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //统计全校考试成绩
        private void btnStat_Click(object sender, EventArgs e)
        {
            this.gbStat.Text = "全校考试成绩";
            //展示考试成绩列表
            this.dgvScoreList.AutoGenerateColumns = false;
            this.dgvScoreList.DataSource = objScoreService.GetScoreList(null);
            //查询成绩统计结果
            Dictionary<string, string> dic = objScoreService.GetScoreInfo();
            this.lblAttendCount.Text = dic["stuCount"];
            this.lblCSharpAvg.Text = dic["avgCsharp"];
            this.lblDBAvg.Text = dic["avgDB"];
            this.lblCount.Text = dic["absentCount"];
            //显示缺考的学员姓名
            List<string> list = objScoreService.getAbsentList();
            this.lblList.Items.Clear();
            this.lblList.Items.AddRange(list.ToArray());
            
        }
        //关闭
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
