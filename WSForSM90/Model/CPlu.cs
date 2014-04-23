using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SqlUtilities.Attributes;
using WSForSM90.Interface;

namespace Model
{
    [Table(TableName = "tbSpXinXi")]
    public class CPlu:IDBObject
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        [Column(ColumnName = "incode",DbType=DbType.String,PrimaryKey=true)]
        public string PluCode
        {
            get;
            set;
        }

        /// <summary>
        /// 条码
        /// </summary>
        [Column(ColumnName = "barcode",DbType=DbType.String)]
        public string BarCode
        {
            get;
            set;
        }

        /// <summary>
        /// 品名
        /// </summary>
        [Column(ColumnName = "fname", DbType = DbType.String,IsNull=false)]
        public string PluName
        {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        [Column(ColumnName = "rprc", DbType = DbType.Decimal)]
        public Decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        [Column(ColumnName = "unit", DbType = DbType.String)]
        public string Unit
        {
            get;
            set;
        }
    }
}
