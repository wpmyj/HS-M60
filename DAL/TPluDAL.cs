using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Data;

namespace DAL
{
    public class TPluDAL:BaseDAL<Model.TPlu>
    {
        public TPluDAL(SQLiteConnection connection)
            : base(connection) { }

        public bool GetByBarcode(string barcode,out Model.TPlu plu)
        {
            string msg;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Barcode='{0}'", barcode);
            DataTable dt;
            Select(stringBuilder.ToString(), string.Empty, out dt, out msg);
            if (dt.Rows.Count > 0)
            {
                plu = ObjectTool.BuildObject<Model.TPlu>(dt.Rows[0]);
                return true;
            }
            else
            {
                plu = null;
                return false;
            }
        }
    }
}
