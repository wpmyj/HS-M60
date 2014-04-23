using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model
{
    [Table(PrimaryKeyProperty="Property",TableName="tSyscfg")]
    public class TSyscfg
    {
        /// <summary>
        /// 参数名称
        /// </summary>
        [Column(ColumnName = "Property",SQLDbType=SqlDbType.VarChar)]
        public string Property
        {
            get;
            set;
        }

        /// <summary>
        /// 参数值
        /// </summary>
        [Column(ColumnName="Value",SQLDbType=SqlDbType.VarChar)]
        public string Value
        {
            get;
            set;
        }
    }
}
