using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data.SqlClient;
using SqlUtilities.Interface;
namespace WSForSM90.DAL
{
    public class SaleDAL
    {
        public bool Save(ICollection<CSalSalePlu> saleList, ISqlTool dbTool, SqlTransaction tran, out string msg)
        {
            int i;
            foreach (CSalSalePlu plu in saleList)
            {
                if (!dbTool.Insert(plu, tran, out i, out msg))
                {
                    return false;
                }
            }
            msg = "ok";
            return true;
        }
    }
}
