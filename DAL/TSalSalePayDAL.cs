using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class TSalSalePayDAL:BaseDAL<Model.TSalSalePay>
    {
        public TSalSalePayDAL(SQLiteConnection connection)
            : base(connection) { }

        /// <summary>
        /// 获取付款流水
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="rpt"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool GetSalSalePay(string condition, ref List<Model.TSalSalePay> rpt, out string msg)
        {
            DataTable dt;
            if (!Select(condition, string.Empty, out dt, out msg))
            {
                return false;
            }
            ICollection<Model.TSalSalePay> tmp = ObjectTool.BuildObject<Model.TSalSalePay>(dt);
            rpt.Clear();
            rpt.AddRange(tmp);
            return true;
        }
    }
}
