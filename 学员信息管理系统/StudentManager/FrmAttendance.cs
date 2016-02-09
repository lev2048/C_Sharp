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
    public partial class FrmAttendance : Form
    {
        private AttendanceService objAttService = new AttendanceService();
        public FrmAttendance()
        {
            InitializeComponent();
            //获取考勤的学员总数
            this.lblCount.Text = objAttService.GetAllStudent().ToString();
            ShowStat();
        }
        //显示应出勤总数和签到总数
        private void ShowStat()
        {
            this.lblReal.Text = objAttService.GetAttendStudents(DateTime.Now, true).ToString();
            this.lblAbsenceCount.Text = (Convert.ToInt32(this.lblCount.Text) - Convert.ToInt32(this.lblReal.Text)).ToString();
        }
        //显示当前时间
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lblYear.Text = DateTime.Now.Year.ToString();
            this.lblMonth.Text = DateTime.Now.Month.ToString();
            this.lblDay.Text = DateTime.Now.Day.ToString();
            this.lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
            switch(DateTime.Now.DayOfWeek.ToString())
            {
                case "Monday":
                    this.lblWeek.Text = "一";
                    break;
                case "Tuesday":
                    this.lblWeek.Text = "二";
                    break;
                case "Wednesday":
                    this.lblWeek.Text = "三";
                    break;
                case "Thursday":
                    this.lblWeek.Text = "四";
                    break;
                case "Friday":
                    this.lblWeek.Text = "五";
                    break;
                case "Saturday":
                    this.lblWeek.Text = "六";
                    break;
                case "Sunday":
                    this.lblWeek.Text = "日";
                    break;
                default:
                    break;
            }
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
