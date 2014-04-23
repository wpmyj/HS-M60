using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model
{
    [Table(PrimaryKeyProperty="VipCardNo",TableName="tVip")]
    public class TVip
    {
        [Column(ColumnName="VipCardNo",SQLDbType=SqlDbType.NVarChar)]
        public string VipCardNo
        {
            get;
            set;
        }


        [Column(ColumnName = "VipName", SQLDbType = SqlDbType.NVarChar)]
        public string VipName
        {
            get;
            set;
        }


        [Column(ColumnName = "VipDsc", SQLDbType = SqlDbType.SmallInt)]
        public int VipDsc
        {
            get;
            set;
        }
    }
}
