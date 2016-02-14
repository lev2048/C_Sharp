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
    /// 成绩管理数据访问类
    /// </summary>
    public class ScoreListService
    {
        /// <summary>
        /// 查询考试成绩信息 
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<StudentExt> GetScoreList(string className)
        {
            string sql = "select StudentName,Students.StudentId,ClassName,CSharp,SQLServerDB from Students";
            sql += " inner join StudentClass on Students.ClassId=StudentClass.ClassId";
            sql += " inner join ScoreList on Students.StudentId=ScoreList.StudentId";
            if (className != null && className.Length != 0)
            {
                sql += string.Format(" where ClassName='{0}'",className);
            }
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<StudentExt> list = new List<StudentExt>();
            while(objReader.Read())
            {
                list.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    ClassName = objReader["ClassName"].ToString(),
                    CSharp = objReader["CSharp"].ToString(),
                    SQLServerDB = objReader["SQLServerDB"].ToString()
                });
            }
            objReader.Close();
            return list;
        }
        /// <summary>
        /// 查询考试综合统计结果
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,string>GetScoreInfo()
        {
            string sql = "select stuCount=count(*),avgCsharp=avg(Csharp),avgDB=avg(SQLServerDB) from ScoreList;";
            sql += "select absentCount=count(*) from Students where StudentId not in(select StudentId from ScoreList)";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            Dictionary<string, string> scoreInfo = null;
            if(objReader.Read())
            {
                scoreInfo = new Dictionary<string, string>();
                scoreInfo.Add("stuCount", objReader["stuCount"].ToString());
                scoreInfo.Add("avgCsharp", objReader["avgCsharp"].ToString());
                scoreInfo.Add("avgDB", objReader["avgDB"].ToString());
            }
            if(objReader.NextResult())
            {
                if (objReader.Read())
                {
                    scoreInfo.Add("absentCount", objReader["absentCount"].ToString());
                }
            }
            objReader.Close();
            return scoreInfo;
        }
        /// <summary>
        /// 查询缺考的成员姓名
        /// </summary>
        /// <returns></returns>
        public List<string>getAbsentList()
        {
            string sql = "select StudentName from Students where StudentId not in(select studentId from ScoreList)";
            SqlDataReader objReader = SQLHelper.GetReader(sql);
            List<string> list = new List<string>();
            while (objReader.Read())
            {
                list.Add(objReader["StudentName"].ToString());
            }
            objReader.Close();
            return list;
        }
    }
}
