using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
{
    public class TUserInfo
    {
        public string UserCode;
        public string USERNAME;
        public string Password;
        public UserRight[] Rights;
    }

    /// <summary>
    /// 模块权限
    /// </summary>
    public class UserRight
    {
        public UserRight()
        {
        }

        public UserRight(string funCode, string isEnable,string funName)
        {
            FUNCODE = funCode;
            ISENABLE = isEnable;
            FUNNAME = funName;
        }
        public string FUNCODE;
        public string ISENABLE;
        public string FUNNAME;
    }
}
