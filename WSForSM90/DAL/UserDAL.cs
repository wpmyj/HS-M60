using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;

namespace WSForSM90.DAL
{
    public class UserDAL : BaseDAL<CUser>
    {
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="mpassword"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool Logon(string userCode, string mpassword, out CUser user,out string msg)
        {
            user = new CUser() { UserCode = userCode };
            if (!DbTool.Open(out msg))
            {
                return false;
            }
            if (!DbTool.Load(ref user, out msg))
            {
                user = null;
                return false;
            }
            if (user.UPassword==mpassword)
            {
                return true;
            }
            else
            {
                msg = "用户验证失败";
                return false;
            }
        }
    }
}
