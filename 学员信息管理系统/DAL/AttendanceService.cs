using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// 考勤数据访问类
    /// </summary>
   public class AttendanceService
    {
        /// <summary>
        /// 获取学员总数
        /// </summary>
        /// <returns></returns>
        public string GetAllStudent()
        {
            string sql = "select count(*) from Students";
            try
            {
                return Convert.ToString(SQLHelper.GetSingleResult(sql));
            }
            catch (Exception ex)
            {
                throw new Exception("暂时无法获取学员总数：" + ex.Message);
            }
        }
        /// <summary>
        /// 获取已经签到的学员总数
        /// </summary>
        /// <param name = "dt" ></ param >
        /// < param name="isToday"></param>
        /// <returns></returns>
        public string GetAttendStudents(DateTime dt, bool isToday)
        {
            DateTime dt1;
            if (isToday)//如果是当天，则直接获取服务器时间
            {
                dt1 = Convert.ToDateTime(SQLHelper.GetServerTime());
            }
            else dt1 = dt;
            DateTime dt2 = dt1.AddDays(1.0);//结束时间等于开始时间加1
            string sql = "select count(distinct CardNo) from Attendance where DTime between '{0:d}'and'{1:d}'";//注意日期格式不能带下午
            sql = string.Format(sql, dt1, dt2);
            try
            {
                return Convert.ToString(SQLHelper.GetSingleResult(sql));
            }
            catch (Exception ex)
            {
                throw new Exception("暂时无法获取实到学员总数：" + ex.Message);
            }
        }
        /// <summary>
        /// 添加打卡记录
        /// </summary>
        /// <param name = "cardNo" ></ param >
        /// < returns ></ returns >
        public string AdddRecord(string cardNo)
        {
            string sql = "insert into Attendance (CardNo) values('{0}')";
            sql = string.Format(sql, cardNo);
            try
            {
                SQLHelper.Update(sql);
                return "success";
            }
            catch (Exception ex)
            {
                return "打卡失败！请联系管理员：" + ex.Message;
            }
        }
    }
}
