using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pub
{
    public class DS2Json
    {
        public static string DataSetToJson(DataSet ds, string tblname)//出于嵌套的需要，这里的JSON用竖线“|”字符代替单引号字符“'”
        {
            string json = string.Empty;
            try
            {
                if (ds.Tables.Count == 0)
                    throw new Exception("DataSet中Tables为0");
                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    json += "[";
                    for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                    {
                        json += "{";
                        for (int k = 0; k < ds.Tables[i].Columns.Count; k++)
                        {
                            json += "|" + ds.Tables[i].Columns[k].ColumnName + "|" + ":|" + ds.Tables[i].Rows[j][k].ToString() + "|";
                            if (k != ds.Tables[i].Columns.Count - 1)
                                json += ",";
                        }
                        json += "}";
                        if (j != ds.Tables[i].Rows.Count - 1)
                            json += ",";
                    }
                    json += "]";
                    if (i != ds.Tables.Count - 1)
                        json += ",";


                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return json;
        }

    }
}
