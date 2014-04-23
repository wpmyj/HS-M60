using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Model.TransModel;
using Model.DBModel;
using System.Data.SQLite;
using Pub;
namespace DAL
{
    public class SalSalePayDAL : BaseDAL
    {
        /// <summary>
        /// 增加一条付款流水
        /// </summary>
        /// <param name="pay"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool AddSalSalePay(List<TSalSalePay> payList, out string msg)
        {
            SQLiteTransaction tran;
            int i;
            if (!DBTool.BeginTransaction(out tran, out msg))
            {
                return false;
            }
            foreach (TSalSalePay pay in payList)
            {
                DBSalSalePay DBPay = new DBSalSalePay();
                DBPay.ID = Guid.NewGuid();
                DBPay.LrDate = DateTime.Now;
                DBPay.LrUser = PubGlobal.User.UserCode;
                DBPay.OrgCode = PubGlobal.OrgCode;
                DBPay.SaleNo = pay.SALENO;
                DBPay.SerialNo = int.Parse(pay.SERIALNO);
                DBPay.SsTotal = string.IsNullOrEmpty(pay.SSTOTAL) ? 0 : decimal.Parse(pay.SSTOTAL);
                DBPay.VipNo = string.IsNullOrEmpty(pay.VIPNO) ? string.Empty : pay.VIPNO;
                DBPay.ZfCode = pay.ZFCODE;
                DBPay.ZfNo = string.IsNullOrEmpty(pay.ZFNO)?string.Empty:pay.ZFNO;
                DBPay.ZfTotal = string.IsNullOrEmpty(pay.ZFTOTAL) ? 0 : decimal.Parse(pay.ZFTOTAL);
                if (!DBTool.Insert(DBPay, tran, out i, out msg))
                {
                    DBTool.RollbackTransaction(tran, out msg);//回滚
                    return false;
                }
            }
            return DBTool.CommitTransaction(tran, out msg);
        }

        /// <summary>
        /// 获取付款流水
        /// </summary>
        /// <param name="payList"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetSalSalePay(out List<TSalSalePay> payList, out string msg)
        {
            SQLiteDataReader rd;
            if (!DBTool.Select(string.Empty, new DBSalSalePay(), string.Empty, out rd, out msg))
            {
                payList = null;
                return false;
            }
            payList=new List<TSalSalePay>();
            while (rd.Read())
            {
                TSalSalePay pay = new TSalSalePay();
                pay.ORGCODE = Convert.ToString(rd["OrgCode"]);
                pay.SALENO = Convert.ToString(rd["SaleNo"]);
                pay.SERIALNO = Convert.IsDBNull(rd["SerialNo"]) ? "0" : rd["SerialNo"].ToString();
                pay.SSTOTAL = Convert.IsDBNull(rd["SsTotal"]) ? "0" : rd["SsTotal"].ToString();
                pay.VIPNO = Convert.ToString(rd["VipNo"]);
                pay.ZFCODE = Convert.ToString(rd["ZfCode"]);
                pay.ZFNO = Convert.ToString(rd["ZfNo"]);
                pay.ZFTOTAL = string.IsNullOrEmpty(rd["ZfTotal"].ToString()) ? "0" : rd["ZfTotal"].ToString();
                payList.Add(pay);
            }
            rd.Close();
            return true;
        }

        /// <summary>
        /// 移除流水
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RemoveSalSalePay(out string msg)
        {
            int i;
            return DBTool.ExecSql("Delete From tSalSalePay", out i, out msg);
        }
    }
}
