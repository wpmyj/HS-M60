using System;
using System.Collections.Generic;
using System.Text;
using Model.TransModel;
using System.Data.SQLite;
using Model.DBModel;
using Pub;
using System.Linq;
using System.Data;
namespace DAL
{
    public class JhBillDAL : BaseDAL
    {

        /// <summary>
        /// 获取最大序号
        /// </summary>
        /// <param name="i"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetMaxSerialNo(out int i, out string msg)
        {
            SQLiteDataReader rd;
            if (!DBTool.ExecSql("Select Max(SerialNo) Serial From tJhBill", out rd, out msg))
            {
                i = -1;
                return false;
            }

            if (rd.Read())
            {
                if (Convert.IsDBNull(rd["Serial"]))
                {
                    i = 0;
                }
                else
                {
                    i = Convert.ToInt16(rd["Serial"]);
                }
                return true;
            }
            else
            {
                i = 0;
                return true;
            }
        }

        /// <summary>
        /// 插入采购单
        /// </summary>
        /// <param name="CgBill">采购单</param>
        /// <param name="msg">返回的消息</param>
        /// <returns>是否成功</returns>
        public static  bool AddBill(List<TRFQueryCgBill> CgBill, out string msg)
        {
            int i;
            if (!RemoveJhBill(out msg))
            {
                msg = "移除验收单失败：" + msg;
                return false;
            }
            SQLiteTransaction tran;
            if (!DBTool.BeginTransaction(out tran, out msg))
            {
                return false;
            }
            foreach (TRFQueryCgBill bill in CgBill)
            {

                DBJhBill DBBill = new DBJhBill();
                DBBill.ID = Guid.NewGuid();
                DBBill.Barcode = bill.BARCODE;
                DBBill.BillNo = string.Empty;
                DBBill.CgCount = decimal.Parse(bill.CGCOUNT);
                DBBill.Checked = "N";
                DBBill.LrDate = DateTime.Now;
                DBBill.LrUser = PubGlobal.User.UserCode;
                DBBill.CgPackCount = decimal.Parse(bill.PACKCOUNT);
                DBBill.PackQty = decimal.Parse(bill.PACKQTY);
                DBBill.PackUnit = bill.PACKUNIT;
                DBBill.PluCode = bill.PLUCODE;
                DBBill.PluID = bill.PLUID;
                DBBill.PluName = bill.PLUNAME;
                DBBill.ToSerialNo = int.Parse(bill.SERIALNO);
                DBBill.SerialNo = 0;
                DBBill.CgSGLCount = decimal.Parse(bill.SGLCOUNT);
                DBBill.Spec = bill.SPEC;
                DBBill.SsCount = 0;
                DBBill.Unit = bill.UNIT;
                if (!DBTool.Insert(DBBill, tran, out i, out msg))
                {
                    DBTool.RollbackTransaction(tran,out msg);
                    msg = "存储采购单失败。";
                    return false;
                }
            }
            return DBTool.CommitTransaction(tran, out msg);
        }

        /// <summary>
        /// 获取要发送的验收单明细
        /// </summary>
        /// <param name="rst"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetSendJhBill(out DataSet rst, out string msg)
        {
            if (!DBTool.ExecSql("Select  BILLNO,SERIALNO,TOSERIALNO,PLUID,PACKUNIT,PACKQTY, SsPACKCOUNT as PACKCOUNT, SsSGLCOUNT as SGLCOUNT ,ScDate as SCDATE From tJhBill Where Checked='Y'", out rst, out msg))
            {
                rst = null;
                return false;
            }
            return true;
        }

        /// <summary>
        /// 列表验收单
        /// </summary>
        /// <param name="jhBill"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool ListBill(out List<DBJhBill> jhBill, out string msg)
        {
            SQLiteDataReader rd;
            if (!DBTool.Select(string.Empty, new DBJhBill(), "Checked Desc", out rd, out msg))
            {
                jhBill = null;
                return false;
            }
            jhBill = new List<DBJhBill>();
            jhBill.AddRange(ObjTool.BuildObject<DBJhBill>(rd));
            rd.Close();
            return true;
        }

        /// <summary>
        /// 移除验收单
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RemoveJhBill(out string msg)
        {
            int i;
            return DBTool.ExecSql("Delete From tJhBill;Delete From tJhBillInfo", out i, out msg);
        }

        /// <summary>
        /// 获取当前单据信息
        /// </summary>
        /// <param name="msg">返回的消息</param>
        /// <returns>返回是否成功</returns>
        public static bool GetJhBillInfo(out DBJhBillInfo billInfo, out string msg)
        {
            SQLiteDataReader rd;
            if (!DBTool.ExecSql("Select * From tJhBillInfo ", out rd, out msg))
            {
                billInfo = null;
                return false;
            }
            ICollection<DBJhBillInfo> list = ObjTool.BuildObject<DBJhBillInfo>(rd);
            rd.Close();
            if (list.Count>0)
            {
                billInfo = list.First();
                return true;
            }
            else
            {
                msg = "未找到验收单信息。";
                billInfo = null;
                return false;
            }
        }

        /// <summary>
        /// 开启验收单，保存验收单信息
        /// </summary>
        /// <param name="billInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SaveJhBillInfo(DBJhBillInfo billInfo,out string msg)
        {
            int i;

            if (!DBTool.ExecSql(" Delete From tJhBillInfo ", out i, out msg))
            {
                return false;
            }
            return DBTool.Insert(billInfo, out i, out msg);
        }

        /// <summary>
        /// 从单据中获取Plu信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="plus"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool QueryPluFromBill(string code,out List<TRFQueryPlu> plus,out string msg)
        {
            SQLiteDataReader rd;
            if (!DBTool.Select(" Barcode=@Barcode Or PluCode=@PluCode ", new DBJhBill() {Barcode=code,PluCode=code}, string.Empty, out rd, out msg))
            {
                plus = null;
                return false;
            }
            plus = new List<TRFQueryPlu>();
            while (rd.Read())
            {
                if (plus.Count == 0)
                {
                    //添加当前商品
                    TRFQueryPlu plu = new TRFQueryPlu();
                    plu.BARCODE = Convert.ToString(rd["Barcode"]);
                    plu.PLUCODE = Convert.ToString(rd["PluCode"]);
                    plu.PLUID = Convert.ToString(rd["PluID"]); ;
                    plu.PLUNAME = Convert.ToString(rd["PluName"]);
                    plu.SPEC = Convert.ToString(rd["Spec"]);
                    plu.UNIT =  Convert.ToString(rd["Unit"]);
                    plu.Packets = new List<TPacket>();
                    plus.Add(plu);
                }
                if (Convert.ToDecimal(rd["PackQty"]) != 0)
                {
                    TPacket packet = new TPacket();
                    packet.PACKETID = Convert.ToInt16(rd["ToSerialNo"]).ToString();//将SerialNo当作包装ID
                    packet.PACKQTY = Convert.ToDecimal(rd["PackQty"]).ToString("F2");
                    packet.PACKUNIT = Convert.ToString(rd["PackUnit"]);
                    plus[0].Packets.Add(packet);
                }
            }
            rd.Close();
            if (plus.Count > 0)
            {
                return true;
            }
            else
            {
                msg = "采购单中未找到该商品。";
                plus = null;
                return false;
            }
        }


        ///// <summary>
        ///// 获取指定采购单明细
        ///// </summary>
        ///// <param name="code"></param>
        ///// <param name="PackUnit"></param>
        ///// <param name="PackQty"></param>
        ///// <param name="bill"></param>
        ///// <param name="msg"></param>
        ///// <returns></returns>
        //public static bool GetBill(int  ToSerialNo, out DBJhBill bill, out string msg)
        //{
        //    SQLiteDataReader rd;
        //    if (!DBTool.Select(" ToSerialNo=@ToSerialNo ", new DBJhBill() { ToSerialNo = ToSerialNo }, string.Empty, out rd, out msg))
        //    {
        //        bill = null;
        //        return false;
        //    }
        //    if (rd.Read())
        //    {
        //        int i;
        //        if(!GetMaxSerialNo(out i,out msg))
        //        {
        //            //取SerialNo失败
        //            rd.Close();
        //            bill = null;
        //            return false;
        //        }
        //        bill = new DBJhBill();
        //        bill.ID = new Guid(Convert.ToString(rd["ID"]));
        //        bill.Barcode = Convert.ToString(rd["Barcode"]);
        //        bill.BillNo = Convert.ToString(rd["BillNo"]);
        //        bill.CgCount = Convert.ToDecimal(rd["CgCount"]);
        //        bill.Checked = Convert.ToString(rd["Checked"]);
        //        bill.LrDate = Convert.ToDateTime(rd["LrDate"]);
        //        bill.LrUser = Convert.ToString(rd["LrUser"]);
        //        bill.CgPackCount = Convert.ToDecimal(rd["CgPackCount"]);
        //        bill.SsPackCount = Convert.ToDecimal(rd["SsPackCount"]);
        //        bill.PackQty = Convert.ToDecimal(rd["PackQty"]);
        //        bill.PackUnit = Convert.ToString(rd["PackUnit"]);
        //        bill.PluCode = Convert.ToString(rd["PluCode"]);
        //        bill.PluID = Convert.ToString(rd["PluID"]);
        //        bill.PluName = Convert.ToString(rd["PluName"]);
        //        bill.SerialNo = i++;
        //        bill.ToSerialNo = Convert.ToInt16(rd["ToSerialNo"]);
        //        bill.CgSGLCount = Convert.ToDecimal(rd["CgSGLCount"]);
        //        bill.SsSGLCount = Convert.ToDecimal(rd["SsSGLCount"]);
        //        bill.Spec = Convert.ToString(rd["Spec"]);
        //        bill.SsCount = Convert.ToDecimal(rd["SsCount"]);
        //        bill.Unit = Convert.ToString(rd["Unit"]);
        //        return true;
        //    }
        //    else
        //    {
        //        msg = "未查询到采购信息";
        //        bill = null;
        //        return false;
        //    }

        //}

        /// <summary>
        /// 获取指定采购单明细
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="bill"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetBill(string Code,TPacket packet, out DBJhBill bill, out string msg)
        {

            SQLiteDataReader rd;
            if (!DBTool.Select("PluCode=@PluCode And PackQty=@PackQty And PackUnit=@PackUnit", new DBJhBill() {PluCode=Code, PackQty = decimal.Parse(packet.PACKQTY),PackUnit=packet.PACKUNIT }, string.Empty, out rd, out msg))
            {
                bill = null;
                return false;
            }
            ICollection<DBJhBill> list = ObjTool.BuildObject<DBJhBill>(rd);
            rd.Close();
            if (list.Count>0)
            {
                bill = list.First();
                return true;
            }
            else
            {
                msg = "未查询到采购信息";
                bill = null;
                return false;
            }
        }

        public static bool GetBill(string PLUID, out DBJhBill bill, out string msg)
        {
            SQLiteDataReader rd;
            if (!DBTool.Select("PluID=@PluID", new DBJhBill() { PluID=PLUID }, string.Empty, out rd, out msg))
            {
                bill = null;
                return false;
            }
            ICollection<DBJhBill> list = ObjTool.BuildObject<DBJhBill>(rd);
            rd.Close();
            if (list.Count>0)
            {
                bill = list.First();
                return true;
            }
            else
            {
                msg = "未查询到采购信息";
                bill = null;
                return false;
            }
        }
        /// <summary>
        /// 更新验收单明细
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool UpdateBill(DBJhBill bill, out string msg)
        {
            int i = 0;
            if (bill.SerialNo == 0)
            {
                if (!GetMaxSerialNo(out i, out msg))
                {
                    return false;
                }
                else
                {
                    bill.SerialNo = ++i;
                }
            }
            if (!DBTool.Update(bill,out i,out msg))
            {
                return false;
            }
            else
            {
                return i > 0;
            }
        }

        /// <summary>
        /// 插入验收单明细
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool InsertBill(DBJhBill bill, out string msg)
        {
            int i;
            if (!GetMaxSerialNo(out i, out msg))
            {
                return false;
            }

            bill.SerialNo = ++i;
            bill.ID = Guid.NewGuid();
            return DBTool.Insert(bill, out i, out msg);
        }


        /// <summary>
        /// 保存验收单明细
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SaveBill(DBJhBill bill, out string msg)
        {
            if (bill.ID == Guid.Empty)
            {
                return InsertBill(bill, out msg);
            }
            else
            {
                return UpdateBill(bill, out msg);
            }
        }

        /// <summary>
        /// 删除验收单明细
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool DeleteBill(DBJhBill bill, out string msg)
        {
            int i;
            return DBTool.Delete(bill, out i, out msg);
        }
    }
}
