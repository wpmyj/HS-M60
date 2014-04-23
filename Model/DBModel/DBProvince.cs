using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model.DBModel
{
    [Table(TableName = "tProvince")]
    public class DBProvince
    {
        /// <summary>
        /// 省名
        /// </summary>
        [Column(ColumnName = "Province",DbType=DbType.String,IsNull=false)]
        public string Province
        {
            get;
            set;
        }

        /// <summary>
        /// 索引
        /// </summary>
        [Column(ColumnName = "Index", DbType = DbType.String, PrimaryKey=true)]
        public string Index
        {
            get;
            set;
        }
    }
}
