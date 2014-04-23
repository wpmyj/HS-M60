using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model.DBModel
{
    [Table(TableName="tNextNo")]
    public class DBNextNo
    {
        [Column(ColumnName="ObjName",DbType=DbType.String,PrimaryKey=true)]
        public string ObjName
        {
            get;
            set;
        }
        [Column(ColumnName="LastDate",DbType=DbType.DateTime,IsNull=false)]
        public DateTime LastDate
        {
            get;
            set;
        }
        [Column(ColumnName="LastNo",DbType=DbType.Int16,Default=0)]
        public int LastNo
        {
            get;
            set;
        } 
    }
}
