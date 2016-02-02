using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using Models.Ext;
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
        /// <summary>
        /// 修改学员时判断身份证号是否重复
        /// </summary>
        /// <param name="idNo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool IsIdNoExisted(string idNo, string studentId)
        {
            string sql = "select count(*)from Students where StudentIdNo="
                + idNo + "and StudentId<>" + studentId;
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (result == 1) return true;
            else return false;
        }
        /// <summary>
        /// 验证考勤卡号
        /// </summary>
        /// <param name="cardNo"></param>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public bool IscardExisted(string cardNo, string studentId)
        {
            string sql = "select count(*)from Students where CardNo='"
                + cardNo + "' and StudentId<>" + studentId;//varchar类型溢出，需在cardNo上用单引号阔上
            int count = Convert.ToInt32(SQLHelper.GetSingleResult(sql));
            if (count == 1)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 修改学员对象
        /// </summary>
        /// <param name="objStudent"></param>
        /// <returns></returns>
        public int MondifyStudent(Student objStudent)
        {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("update Students set studentName='{0}',Gender='{1}',Birthday='{2}',");
            sqlBuilder.Append("StudentIdNo={3},Age={4},PhoneNumber='{5}',StudentAddress='{6}',CardNo='{7}',ClassId={8},StuImage='{9}'");
            sqlBuilder.Append("where StudentId={10}");
            string sql = string.Format(sqlBuilder.ToString(), objStudent.StudentName,
               objStudent.Gender, objStudent.Birthday.ToString("yyyy-MM-dd"),
               objStudent.StudentIdNo, objStudent.Age, objStudent.PhoneNumber,
               objStudent.StudentAddress, objStudent.CardNo,
               objStudent.ClassId,objStudent.StuImage,objStudent.StudentId);//studentid容易漏加
            try
            {
                return Convert.ToInt32(SQLHelper.Update(sql));
            }
            catch (Exception ex)
            {
                throw new Exception("保存数据出现问题！" + ex.Message);
            }
        }
        /// <summary>
        /// 根据班级编号查询学员对象
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<StudentExt>GetStudentByClassId(string classId)
        {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";//注意开头的空格
            sql += " where Students.ClassId=" + classId;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while (objReader.Read())
            {
                list.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        public StudentExt GetStudentByStuId(string stuId)
        {
            string sql = "select StudentName,StudentId,Age,Gender,Birthday,CardNo,ClassName,StudentIdNo,PhoneNumber,StudentAddress,StuImage from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";//注意开头的空格
            sql += " where StudentId=" + stuId;
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            StudentExt objStudent = null;
            if (objReader.Read())
            {
                objStudent = new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    CardNo = objReader["CardNo"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    Age = Convert.ToInt32(objReader["Age"]),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString(),
                    StuImage = objReader["StuImage"] is DBNull ? "" : objReader["StuImage"].ToString()
                };
            }
            objReader.Close();
            return objStudent;
        }
    }
}
