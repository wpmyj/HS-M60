using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Model.DBModel;
using System.Data.SQLite;

namespace DAL
{
    public class NextNoDAL : BaseDAL
    {
        /// <summary>
        /// 获取下一个流水号
        /// </summary>
        /// <param name="ObjName"></param>
        /// <param name="no"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetNextNo<T>(out int no, out string msg)
        {
            string _ObjName = typeof(T).Name;
            SQLiteDataReader rd;
            switch (_ObjName)
            {
                case "DBPdData":
                    if (!DBTool.Select("ObjName=@ObjName And LastDate=@LastDate", new DBNextNo() {ObjName=_ObjName,LastDate=DateTime.Today }, string.Empty, out rd, out msg))
                    {
                        no = -1;
                        return false;
                    }
                    else
                    {
                        if (rd.Read())
                        {
                            no = Convert.ToInt16(rd["LastNo"]) + 1;
                        }
                        else
                        {
                            no = 1;
                        }
                        rd.Close();
                        return true;
                    }
                default:
                    no = -1;
                    msg = "错误：不存在对象";
                    return false;
            }
        }

        /// <summary>
        /// 保存当前流水号
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="no"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool SaveNextNo<T>(int no, out string msg)
        {
            string ObjName = typeof(T).Name;
            DBNextNo nextNo = new DBNextNo();
            nextNo.ObjName = ObjName;
            nextNo.LastDate = DateTime.Today;
            nextNo.LastNo = no;
            int i;
            DBTool.Delete(nextNo, out i, out msg);
            return DBTool.Insert(nextNo, out i, out msg);
        }
    }
}
