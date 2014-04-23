using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model.DBModel;
using Model.TransModel;
using System.Data.SQLite;

namespace DAL
{
    public class CgBillDAL:BaseDAL
    {
        /// <summary>
        /// 列表采购明细
        /// </summary>
        /// <param name="rst"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool ListBill(out List<DBCgBill> rst,out string msg)
        {
            DataTable dt;
            if (!Select(string.Empty, new DBCgBill(), "SerialNo", out dt, out msg))
            {
                rst = null;
                return false;
            }
            else
            {
                rst = ObjTool.BuildObject<DBCgBill>(dt).ToList();
                return true;
            }

        }

        /// <summary>
        /// 清空采购明细
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RemoveCgBill(out string msg)
        {
            int i=0;
            return DBTool.ExecSql("Delete from tCgBill", out i, out msg);
        }

        /// <summary>
        /// 获取要发送的采购明细
        /// </summary>
        /// <param name="rst"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetSendCgBill(out DataSet rst, out string msg)
        {
            if (!DBTool.ExecSql("select BillNo,SerialNo,PLUID ,PACKUNIT,PACKQTY,PACKCOUNT ,	SGLCOUNT from tCgBill",out rst,out msg))
            {
                rst = null;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 删除明细
        /// </summary>
        /// <param name="bill">明细</param>
        /// <param name="msg">返回的消息</param>
        /// <returns>是否成功</returns>
        public static bool DeleteBill(DBCgBill bill, out string msg)
        {
            int i;
            return DBTool.Delete(bill, out i, out msg);
        }
        
        /// <summary>
        /// 获取采购单最大编号
        /// </summary>
        /// <param name="serialNo">获取的最大编号</param>
        /// <param name="msg">返回的消息</param>
        /// <returns>返回是否成功</returns>
        public static bool GetMasSerialNo(out int serialNo, out string msg)
        {
            SQLiteDataReader rd;
            if (!DBTool.ExecSql("Select Max(SerialNo) SerialNo From tCgBill",out rd, out msg))
            {
                serialNo = -1;
                return false;
            }
            else
            {
                if (rd.Read())
                {
                    if (Convert.IsDBNull(rd["SerialNo"]))
                    {
                        serialNo = 0;
                        return true;
                    }
                    serialNo = Convert.ToInt16(rd["SerialNo"]);
                    rd.Close();
                    return true;
                }
                else
                {
                    serialNo = -1;
                    rd.Close();
                    return false;
                }

            }
        }
    }
}
