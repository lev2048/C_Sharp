using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    /// <summary>
    /// 学员数据访问类
    /// </summary>
    public class StudentService
    {
        /// <summary>
        /// 查询身份证号是否存在
        /// </summary>
        /// <param name="idcard"></param>
        /// <returns></returns>
        public bool IsIDCardExisted(string idcard)
        {
            string sql = "select count(*) from Students where StudentIdNo={0}";
            sql = string.Format(sql, idcard);
            int count = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (count == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 查询卡号是否存在
        /// </summary>
        /// <param name="cardNo"></param>
        /// <returns></returns>
        public bool IsCardNoExisted(string cardNo)
        {
            string sql = "select count(*) from Students where CardNo='{0}'";
            sql = string.Format(sql, cardNo);
            int count = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (count == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 添加学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int AddStudent(Student objStudent)
        {

            //string sql = "insert into Students (StudentName,Age,Gender,Birthday,CardNo,ClassId,StudentIdNo,PhoneNumber,StudentAddress,StuImage)";
            //sql += "values('{0}','{1}','{2}',{3},'{4}',{5},{6},'{7}','{8}','{9}')";
            //sql = string.Format(sql, objStudent.StudentName, objStudent.Age, objStudent.Gender, objStudent.Birthday, objStudent.CardNo, objStudent.ClassId, objStudent.StudentIdNo, objStudent.PhoneNumber, objStudent.StudentAddress, objStudent.StuImage);
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("insert into Students (StudentName,Gender,Birthday,");
            sqlBuilder.Append("StudentIdNo,Age,PhoneNumber,StudentAddress,CardNo,ClassId,StuImage)");
            sqlBuilder.Append("values('{0}','{1}','{2}',{3},{4},'{5}','{6}','{7}','{8}','{9}')");
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
               objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
               objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber,
               objStudent.StudentAddress, objStudent.CardNo,
               objStudent.ClassId, objStudent.StuImage);
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (Exception ex)
            {
                throw new Exception("保存数据出现问题！" + ex.Message);
            }
        }
    }
}
