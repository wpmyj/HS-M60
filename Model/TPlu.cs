using System;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model
{
    [Table(TableName = "tPlu", PrimaryKeyProperty = "PluCode")]
    public class TPlu
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        [Column(ColumnName="PluCode",SQLDbType=SqlDbType.VarChar)]
        public string PluCode
        {
            get;
            set;
        }

        /// <summary>
        /// 条码
        /// </summary>
        [Column(ColumnName = "BarCode", SQLDbType = SqlDbType.VarChar)]
        public string BarCode
        {
            get;
            set;
        }

        /// <summary>
        /// 品名
        /// </summary>
        [Column(ColumnName = "PluName", SQLDbType = SqlDbType.VarChar)]
        public string PluName
        {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        [Column(ColumnName = "Price", SQLDbType = SqlDbType.Decimal)]
        public Decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        [Column(ColumnName = "Unit", SQLDbType = SqlDbType.VarChar)]
        public string Unit
        {
            get;
            set;
        }
    }
}
