using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using System.Data.SqlClient;
using SqlUtilities.Interface;
namespace WSForSM90.DAL
{
    public class PayDAL
    {
        public bool Save(ICollection<CSalSalePay> payList,ISqlTool dbTool, SqlTransaction tran,out string msg)
        {
            int i;
            foreach (CSalSalePay pay in payList)
            {
                if (!dbTool.Insert(pay, tran, out i, out msg))
                {
                    return false;
                }
            }
            msg = "ok";
            return true;
        }
    }
}
