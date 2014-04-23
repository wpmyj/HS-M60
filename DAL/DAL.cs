using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SQLite;

namespace DAL
{
    public class DAL
    {
        /// <summary>
        /// 数据库连接
        /// </summary>
        public static SQLiteConnection Connection
        {
            get;
            set;
        }

        /// <summary>
        /// 参数操作
        /// </summary>
        public static TSyscfgDAL SyscfgDAL;

        /// <summary>
        /// 用户操作
        /// </summary>
        public static TUserDAL UserDAL;

        /// <summary>
        /// 付款方式操作
        /// </summary>
        public static TSalPayTypeDAL SalPayTypeDAL;

        /// <summary>
        /// 商品信息操作
        /// </summary>
        public static TPluDAL PluDAL;

        /// <summary>
        /// 会员操作
        /// </summary>
        public static TVipDAL VipDAL;

        /// <summary>
        /// 交易流水操作
        /// </summary>
        public static TSalSaleDAL SalSaleDAL;

        /// <summary>
        /// 明细流水操作
        /// </summary>
        public static TSalSalePluDAL SalSalePluDAL;

        /// <summary>
        /// 付款流水操作
        /// </summary>
        public static TSalSalePayDAL SalSalePayDAL;

        public static VCashRptDAL CashRptDAL;

        public static bool Open(SQLiteConnection _Connection ,out string msg)
        {
            Connection = _Connection;
            try
            {
                Connection.Open();
                msg = string.Empty;
 
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                return false;
            }

            SyscfgDAL = new TSyscfgDAL(Connection);
            UserDAL = new TUserDAL(Connection);
            SalPayTypeDAL = new TSalPayTypeDAL(Connection);
            PluDAL = new TPluDAL(Connection);
            VipDAL = new TVipDAL(Connection);
            SalSaleDAL = new TSalSaleDAL(Connection);
            SalSalePayDAL = new TSalSalePayDAL(Connection);
            SalSalePluDAL = new TSalSalePluDAL(Connection);
            CashRptDAL = new VCashRptDAL(Connection);
            return true;
        }

        public static void Close()
        {
            Connection.Close();
        }
    }
}
