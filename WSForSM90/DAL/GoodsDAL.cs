using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data.SqlClient;

namespace WSForSM90.DAL
{
    public class GoodsDAL : BaseDAL<CPlu>
    {
        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public bool GetGoods(string Code, out CPlu goods, out string msg)
        {
            if (!DbTool.Open(out msg))
            {
                goods = null;
                return false;
            }
            goods = new CPlu() { PluCode = Code, BarCode = Code };

            SqlDataReader rd;
            if (!DbTool.Select("incode=@incode or barcode=@barcode", goods, "", out rd, out msg))
            {
                string s;
                DbTool.Close(out s);
                return false;
            }
            ICollection<CPlu> gs = ObjTool.BuildObject<CPlu>(rd);
            rd.Close();
            if (gs != null && gs.Count > 0)
            {
                goods = gs.First();
                string s;
                DbTool.Close(out s);
                return true;
            }
            else
            {
                goods = null;
                string s;
                DbTool.Close(out s);
                return false;
            }
        }
    }
}
