using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using Model.DBModel;
using System.Data;

namespace DAL
{
    public class PdDataDAL:BaseDAL
    {
        /// <summary>
        /// 获取最大序号
        /// </summary>
        /// <param name="i"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetMaxSerialNo(out int i, out string msg)
        {
            SQLiteDataReader reader;
            if (!BaseDAL.DBTool.ExecSql("Select Max(SerialNo) Serial From tPdData", out reader, out msg))
            {
                i = -1;
                return false;
            }
            if (reader.Read())
            {
                if (Convert.IsDBNull(reader["Serial"]))
                {
                    i = 0;
                }
                else
                {
                    i = Convert.ToInt16(reader["Serial"]);
                }
                return true;
            }
            i = 0;
            return true;

        }

        /// <summary>
        /// 获取当前单据信息
        /// </summary>
        /// <param name="msg">返回的消息</param>
        /// <returns>返回是否成功</returns>
        public static bool GetPdDataInfo(out DBPdDataInfo PdDataInfo, out string msg)
        {
            SQLiteDataReader reader;
            if (!BaseDAL.DBTool.ExecSql("Select * From tPdDataInfo ", out reader, out msg))
            {
                PdDataInfo = null;
                return false;
            }
            ICollection<DBPdDataInfo> source = BaseDAL.ObjTool.BuildObject<DBPdDataInfo>(reader);
            reader.Close();
            if (source.Count > 0)
            {
                PdDataInfo = source.First<DBPdDataInfo>();
                return true;
            }
            msg = "未找到盘点单信息。";
            PdDataInfo = null;
            return false;

        }

        /// <summary>
        /// 开启盘点单，保存验收单信息
        /// </summary>
        /// <param name="billInfo"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SavePdDataInfo(DBPdDataInfo PdDataInfo, out string msg)
        {
            int num;
            if (!BaseDAL.DBTool.ExecSql(" Delete From tPdDataInfo ", out num, out msg))
            {
                return false;
            }
            return BaseDAL.DBTool.Insert<DBPdDataInfo>(PdDataInfo, out num, out msg);

        }

        /// <summary>
        /// 查询盘点数据
        /// </summary>
        /// <param name="PluID"></param>
        /// <param name="pdData"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetPdData(string pluID,out DBPdData pdData,out string msg)
        {
            SQLiteDataReader reader;
            if (!BaseDAL.DBTool.Select<DBPdData>("PluID=@PluID", new DBPdData() { PluID=pluID}, string.Empty, out reader, out msg))
            {
                pdData = null;
                return false;
            }
            ICollection<DBPdData> source = BaseDAL.ObjTool.BuildObject<DBPdData>(reader);
            reader.Close();
            if (source.Count > 0)
            {
                pdData = source.First<DBPdData>();
                return true;
            }
            msg = "未查询到盘点信息";
            pdData = null;
            return false;

        }

        /// <summary>
        /// 删除盘点数据
        /// </summary>
        /// <param name="pdData"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool DeletePdData(DBPdData pdData, out string msg)
        {
            int num;
            return DBTool.Delete<DBPdData>(pdData, out num, out msg);
        }

        /// <summary>
        /// 插入盘点数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private static bool InsertPdData(DBPdData bill, out string msg)
        {
            int num;
            if (!GetMaxSerialNo(out num, out msg))
            {
                return false;
            }
            bill.SerialNo = ++num;
            bill.ID = Guid.NewGuid();
            if (!BaseDAL.DBTool.Insert<DBPdData>(bill, out num, out msg))
            {
                return false;
            }
            return (num > 0x0);
        }

        /// <summary>
        /// 更新盘点数据
        /// </summary>
        /// <param name="bill"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool UpdatePdData(DBPdData bill, out string msg)
        {
            int i = 0;
            if (bill.SerialNo == 0)
            {
                if (!GetMaxSerialNo(out i, out msg))
                {
                    return false;
                }
                bill.SerialNo = ++i;
            }
            if (!BaseDAL.DBTool.Update<DBPdData>(bill, out i, out msg))
            {
                return false;
            }
            return (i > 0);
        }

        /// <summary>
        /// 保存盘点数据
        /// </summary>
        /// <param name="pdData"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SavePdData(DBPdData pdData, out string msg)
        {
            if (pdData.ID == Guid.Empty)
            {
                return InsertPdData(pdData, out msg);
            }
            return UpdatePdData(pdData, out msg);
        }

 

        /// <summary>
        /// 列表盘点数据
        /// </summary>
        /// <param name="pdData"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool ListPdData(out List<DBPdData> pdData, out string msg)
        {
            SQLiteDataReader reader;
            if (!BaseDAL.DBTool.Select<DBPdData>(string.Empty, new DBPdData(), string.Empty, out  reader, out msg))
            {
                pdData = null;
                return false;
            }
            pdData = new List<DBPdData>();
            pdData.AddRange(BaseDAL.ObjTool.BuildObject<DBPdData>(reader));
            reader.Close();
            return true;
        }

        /// <summary>
        /// 移除盘点数据
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RemovePdData(out string msg)
        {
            int num;
            return BaseDAL.DBTool.ExecSql("Delete From tPdData;Delete From tPdDataInfo", out num, out msg);
        }

        /// <summary>
        /// 获取要发送的盘点单明细
        /// </summary>
        /// <param name="rst"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetSendPdData(out DataSet rst, out string msg)
        {
            if (!DBTool.ExecSql("Select PDNO,SERIALNO,PLUID,SJCOUNT From tPdData", out rst, out msg))
            {
                rst = null;
                return false;
            }
            return true;
        }
    }
}
