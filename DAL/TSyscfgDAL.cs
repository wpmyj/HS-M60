using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;

namespace DAL
{
    public class TSyscfgDAL:BaseDAL<Model.TSyscfg>
    {
        public TSyscfgDAL(SQLiteConnection Connection)
            : base(Connection) { }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public string GetFlowNo()
        {
            int i;
            Model.TSyscfg LastDate = new Model.TSyscfg() { Property = "LastDate" };
            Model.TSyscfg SaleNo = new Model.TSyscfg() { Property = "SaleNo" };
            string msg;
            DAL.SyscfgDAL.Load(ref LastDate, out msg);
            DAL.SyscfgDAL.Load(ref SaleNo, out msg);
            if (DateTime.Now.ToString("yyyy-MM-dd").CompareTo(LastDate.Value)==0)
            {
                SaleNo.Value = (int.Parse(SaleNo.Value) + 1).ToString().PadLeft(5, '0');
            }
            else
            {
                LastDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
                DAL.SyscfgDAL.Save(ref LastDate, out i, out msg);
                SaleNo.Value = "00001";
            }
            DAL.SyscfgDAL.Save(ref SaleNo,out i,out msg);
            return LastDate.Value.Replace("-",string.Empty)+SaleNo.Value;
        }
    }
}
