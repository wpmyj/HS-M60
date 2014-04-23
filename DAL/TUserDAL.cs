using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;
using System.Collections;

namespace DAL
{
    public class TUserDAL : BaseDAL<Model.TUser>
    {
        public TUserDAL(SQLiteConnection _Connection)
            : base(_Connection) { }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Upassword"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public  bool Login(string UserCode, string Upassword,out Model.TUser user,out string msg)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("UserCode='{0}' And UPassword='{1}'",new string[]{UserCode,Upassword});
            DataTable dt;
            if (!Select(stringBuilder.ToString(),string.Empty,out dt,out msg))
            {
                user = null;
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                user = ObjectTool.BuildObject<Model.TUser>(dt).First();
                return true;
            }
            else
            {
                user = null;
                msg = "用户名或密码错误！";
                return false;
            }
        }
    }
}
