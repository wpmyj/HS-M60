using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model
{
    [Table(PrimaryKeyProperty="UserCode",TableName="tUser")]
    public class TUser
    {
        [Column(ColumnName="UserCode",SQLDbType=SqlDbType.NVarChar)]
        public string UserCode
        {
            get;
            set;
        }

        [Column(ColumnName = "UserName", SQLDbType = SqlDbType.NVarChar)]
        public string UserName
        {
            get;
            set;
        }

        [Column(ColumnName = "UPassword", SQLDbType = SqlDbType.NVarChar)]
        public string UPassword
        {
            get;
            set;
        }
    }
}
