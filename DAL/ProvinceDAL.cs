using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Pub;
using System.Collections;
using Model.DBModel;
using System.Data.SQLite;

namespace DAL
{
    public class ProvinceDAL : BaseDAL
    {
        /// <summary>
        /// 读取省份表
        /// </summary>
        /// <param name="provinceMap"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool LoadProvince(out Hashtable provinceMap,out string msg)
        {
            provinceMap = new Hashtable();
            SQLiteDataReader rd;
            if (!DBTool.Select(string.Empty, new DBProvince(), string.Empty, out rd, out msg))
            {
                return false;
            }
            else
            {
                while (rd.Read())
                {
                    provinceMap.Add(rd["Index"], rd["Province"]);
                }
                rd.Close();
                return true;
            }
        }
    }
}
