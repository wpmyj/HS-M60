using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class VCashRptDAL : BaseDAL<Model.VCashRpt>
    {
        public VCashRptDAL(SQLiteConnection connection)
            : base(connection) { }

        /// <summary>
        /// 获取收款员报表
        /// </summary>
        /// <param name="Operator"></param>
        /// <param name="rpt"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool GetCashRpt(string Condition,ref List<Model.VCashRpt> rpt,out string msg)
        {
            DataTable dt;
            if (!Select(Condition, string.Empty, out dt, out msg))
            {
                return false;
            }
            rpt.Clear();
            foreach (DataRow row in dt.Rows)
            {
                Model.VCashRpt r = new Model.VCashRpt();
                r.Operator = Convert.ToString(row["Operator"]);
                r.ZfName = Convert.ToString(row["ZfName"]);
                r.total = Convert.ToDecimal(row["total"]);
                rpt.Add(r);
            }
            return true;
        }
    }
}
