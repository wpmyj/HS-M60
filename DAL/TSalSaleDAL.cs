using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class TSalSaleDAL : BaseDAL<Model.TSalSale>
    {
        public TSalSaleDAL(SQLiteConnection connection)
            : base(connection) { }

        /// <summary>
        /// 获取交易流水
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="rpt"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool GetSalSale(string condition, ref List<Model.TSalSale> rpt, out string msg)
        {
            DataTable dt;
            if (!Select(condition, string.Empty, out dt, out msg))
            {
                return false;
            }
            ICollection<Model.TSalSale> tmp = ObjectTool.BuildObject<Model.TSalSale>(dt);
            rpt.Clear();
            rpt.AddRange(tmp);
            return true;
        }
    }
}
