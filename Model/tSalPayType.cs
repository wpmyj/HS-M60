using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model
{
    [Table(TableName = "tSalPayType", PrimaryKeyProperty = "PayCode")]
    public class TSalPayType
    {
        /// <summary>
        /// 支付方式编码
        /// </summary>
        [Column(ColumnName = "PayCode", SQLDbType = SqlDbType.NVarChar)]
        public string PayCode
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        [Column(ColumnName = "PayName", SQLDbType = SqlDbType.NVarChar)]
        public string PayName
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式类型
        /// </summary>
        [Column(ColumnName = "PayType", SQLDbType = SqlDbType.NVarChar)]
        public string PayType
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式类型名称
        /// </summary>
        [Column(ColumnName = "PayTypeName", SQLDbType = SqlDbType.NVarChar)]
        public string PayTypeName
        {
            get;
            set;
        }
        
        /// <summary>
        /// 是否找零
        /// </summary>
        [Column(ColumnName = "IsChange", SQLDbType = SqlDbType.Bit)]
        public bool IsChange
        {
            get;
            set;
        }
    }
}
