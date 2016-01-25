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
    /// 管理员数据访问类
    /// </summary>
    public class AdminService
    {
        /// <summary>
        /// 根据用户名或密码登录
        /// </summary>
        /// <param name="objAdmin"></param>
        /// <returns></returns>
        public Admin AdminLogin(Admin objAdmin)
        {
            string sql = "select AdminName from Admins where LoginId={0} and LoginPwd='{1}'";
            sql = string.Format(sql, objAdmin.LoginId, objAdmin.LoginPwd);
            //查询
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                if (objReader.Read())
                {
                    objAdmin.AdminName = objReader["AdminName"].ToString();
                }
                //如果没找到，清空objAdmin
                else
                {
                    objAdmin = null;
                }
                objReader.Close();
                return objAdmin;
            }
            catch (Exception ex)
            {
                throw new Exception("数据访问发生异常：" + ex.Message);
            }
        }
        /// <summary>
        /// 根据登录账号修改登录密码
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="newPwd"></param>
        /// <returns></returns>
        public int ModifyPwd(string loginId,string newPwd)
        {
            string sql = "update Admins set LoginPwd='{0}' where LoginId={1}";
            sql = string.Format(sql, newPwd, loginId);
            return SQLHelper.Update(sql);
        }
    }
} 
