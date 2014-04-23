using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data.SqlClient;

namespace WSForSM90.DAL
{
    public class TradeDAL : BaseDAL<CSalSale>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="trade"></param>
        /// <returns></returns>
        public bool Save(CSalSale trade,ICollection<CSalSalePay> payList,ICollection<CSalSalePlu> saleList,out string msg)
        {
            int i;
            if (!DbTool.Open(out msg))
            {
                return false;
            }
            SqlTransaction tran;
            if (!DbTool.BeginTransaction(out tran, out msg))
            {
                return false;
            }
            string saleNo;
            string grpNo;
            if (!GetSaleNo(trade.PosNO, out saleNo, tran,out msg))
            {
                return false;
            }
            if (!GetGrpNo(out grpNo, tran, out msg))
            {
                return false;
            }
            SaleDAL saleDAL=new SaleDAL();
            PayDAL payDAL=new PayDAL();


            trade.SaleNo = saleNo;
            trade.Squadno = "1";
            foreach (CSalSalePlu saleplu in saleList)
            {
                saleplu.SaleNo = saleNo;
                saleplu.STime = trade.XsTime;
                saleplu.SDate = trade.XsDate;
                saleplu.tradetype = trade.TradeType;
                saleplu.Operater = trade.Operator;
                saleplu.GrpNo = grpNo;
                saleplu.Squadno = "1";
                trade.Qty += saleplu.XsCount;
                saleplu.Disc = 100;
            }

            foreach (CSalSalePay salepay in payList)
            {
                salepay.SaleNo = saleNo;
                salepay.Stime = trade.XsTime;
                salepay.XsDate = trade.XsDate;
                salepay.TradeType = trade.TradeType;
                salepay.Operator = trade.Operator;
                salepay.Squadno = "1";
            }

            if (DbTool.Insert(trade, tran, out i, out msg) &&
                saleDAL.Save(saleList,DbTool, tran, out msg) &&
                payDAL.Save(payList,DbTool,tran, out msg))
            {
                if (!DbTool.CommitTransaction(tran, out msg))
                {
                    DbTool.Close(out msg);
                    return false;
                }
                else
                {
                    DbTool.Close(out msg);
                    return true;
                }
            }
            else
            {
                DbTool.RollbackTransaction(tran, out msg);
                DbTool.Close(out msg);
                return false;
            }
            
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <param name="PosNo"></param>
        /// <param name="SaleNo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private bool GetSaleNo(string PosNo,out string SaleNo,SqlTransaction tran, out string msg)
        {
            SqlDataReader rd;
            if (!DbTool.ExecSql("select flow_no from pos_TradeFlow where posno='"+PosNo+"' and sdate='"+DateTime.Now.ToString("yyyy-MM-dd")+"'order by flow_no desc",tran, out rd, out msg))
            {
                SaleNo = null;
                msg = "获取流水号失败";
                if (rd != null)
                {
                    if (!rd.IsClosed)
                    {
                        rd.Close();
                    }
                }
                return false;
            }
            else
            {
                if (rd.Read())
                {
                    SaleNo = Convert.ToString(rd[0]);
                    int i = int.Parse(SaleNo.Substring(11, 5))+1;
                    SaleNo = SaleNo.Substring(0, 11) + i.ToString().PadLeft(5, '0');
                }
                else
                {
                    SaleNo = PosNo+DateTime.Now.ToString("yyyyMMdd")+"00001";
                }
                rd.Close();
                return true;
            }

        }

        private bool GetGrpNo(out string GrpNo, SqlTransaction tran, out string msg)
        {
            SqlDataReader rd;
            if (!DbTool.ExecSql("select code from xtdept where dtype='s'", tran, out rd, out msg))
            {
                GrpNo = null;
                if (rd != null)
                {
                    if (!rd.IsClosed)
                    {
                        rd.Close();
                    }
                }
                return false;
            }
            else
            {
                if (rd.Read())
                {
                    GrpNo = Convert.ToString(rd[0]);
                    rd.Close();
                    return true;
                }
                else
                {
                    GrpNo = null;
                    msg = "未设置销售部门";
                    rd.Close();
                    return false;
                }
            }
        }
    }
}
