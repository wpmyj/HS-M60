using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SqlUtilities.Attributes;
using WSForSM90.Interface;

namespace Model
{
    [Table(TableName = "XtMuser")]
    public class CUser : IDBObject
    {
        [Column(ColumnName = "UserCode",DbType=DbType.String,PrimaryKey=true)]
        public string UserCode
        {
            get;
            set;
        }
        [Column(ColumnName = "UserName", DbType = DbType.String)]
        public string UserName
        {
            get;
            set;
        }
        [Column(ColumnName = "mpassword", DbType = DbType.String)]
        public string UPassword
        {
            get;
            set;
        }
    }
}
