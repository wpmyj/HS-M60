using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class TSalPayTypeDAL:BaseDAL<Model.TSalPayType>
    {
        public TSalPayTypeDAL(SQLiteConnection _Connection)
            : base(_Connection) { }

        /// <summary>
        /// 读取付款方式
        /// </summary>
        /// <param name="payType"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool GetPayType(out ICollection<Model.TSalPayType> payType, out string msg)
        {
            DataTable dt;
            if (!Select(string.Empty, string.Empty, out dt, out msg))
            {
                payType = null;
                return false;
            }
            else
            {
                payType = ObjectTool.BuildObject<Model.TSalPayType>(dt);
                return true;
            }
        }

    }
}
