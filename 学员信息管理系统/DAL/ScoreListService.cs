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
        public List<StudentExt> GetScoreList(string className)
        {
            string sql="select StudentName,Students.StudentId ClassName,CSharp,SQLServerDB from"
        }
    }
}
