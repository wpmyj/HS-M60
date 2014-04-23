using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class TVipDAL:BaseDAL<Model.TVip>
    {
        public TVipDAL(SQLiteConnection connection)
            : base(connection) { }

        public bool GetVip(string code,out Model.TVip vip,out string msg)
        {
            DataTable dt;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("VipCardNo='{0}'", code);
            if (!Select(stringBuilder.ToString(), string.Empty, out dt, out msg))
            {
                vip = null;
                return false;
            }
            if (dt.Rows.Count > 0)
            {
                vip = ObjectTool.BuildObject<Model.TVip>(dt.Rows[0]);
                return true;
            }
            else
            {
                msg = "未找到该会员";
                vip = null;
                return false;
            }

        }
    }
}
