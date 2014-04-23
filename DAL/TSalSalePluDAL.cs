using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class TSalSalePluDAL:BaseDAL<Model.TSalSalePlu>
    {
        public TSalSalePluDAL(SQLiteConnection connection)
            : base(connection) { }

        /// <summary>
        /// 获取明细流水
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="rpt"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool GetSalSalePlu(string condition, ref List<Model.TSalSalePlu> rpt, out string msg)
        {
            DataTable dt;
            if (!Select(condition, string.Empty, out dt, out msg))
            {
                return false;
            }
            ICollection<Model.TSalSalePlu> tmp = ObjectTool.BuildObject<Model.TSalSalePlu>(dt);
            rpt.Clear();
            rpt.AddRange(tmp);
            return true;
        }
    }
}
