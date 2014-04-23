using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model.DBModel
{
    [Table(TableName="tCgBill")]
    public class DBCgBill
    {
        /// <summary>
        /// ID
        /// </summary>
        [Column(ColumnName = "ID", DbType = DbType.Guid, PrimaryKey = true)]
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// 序号
        /// </summary>
        [Column(ColumnName="SerialNo",DbType=DbType.Int16,Default=0)]
        public int SerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// 商品ID
        /// </summary>
        [Column(ColumnName="PluID",DbType=DbType.String,IsNull=false)]
        public string PluID
        {
            get;
            set;
        }

        /// <summary>
        /// 商品编码
        /// </summary>
        [Column(ColumnName="PluCode",DbType=DbType.String,IsNull=false)]
        public string PluCode
        {
            get;
            set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        [Column(ColumnName="Unit",DbType=DbType.String,IsNull=true)]
        public string Unit
        {
            get;
            set;
        }

        /// <summary>
        /// 包装单位
        /// </summary>
        [Column(ColumnName="PackUnit",DbType=DbType.String,IsNull=true)]
        public string PackUnit
        {
            get;
            set;
        }

        /// <summary>
        /// 包装数量
        /// </summary>
        [Column(ColumnName="PackQty",DbType=DbType.Decimal,Default=0)]
        public decimal PackQty
        {
            get;
            set;
        }

        /// <summary>
        /// 包数
        /// </summary>
        [Column(ColumnName="PackCount",DbType=DbType.Decimal,Default=0)]
        public decimal PackCount
        {
            get;
            set;
        }

        /// <summary>
        /// 单件数
        /// </summary>
        [Column(ColumnName = "SGLCount", DbType = DbType.Decimal, Default = 0)]
        public decimal SGLCount
        {
            get;
            set;
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        [Column(ColumnName="PluName",DbType=DbType.String,IsNull=false)]
        public string PluName
        {
            get;
            set;
        }

        /// <summary>
        /// 条码
        /// </summary>
        [Column(ColumnName="Barcode",DbType=DbType.String)]
        public string Barcode
        {
            get;
            set;
        }

        /// <summary>
        /// 采购数量
        /// </summary>
        [Column(ColumnName = "CgCount", DbType = DbType.Decimal, Default = 0)]
        public decimal CgCount
        {
            get;
            set;
        }

        /// <summary>
        /// 录入人
        /// </summary>
        [Column(ColumnName="LrUser",DbType=DbType.String,IsNull=false)]
        public string LrUser
        {
            get;
            set;
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        [Column(ColumnName="LrDate",DbType=DbType.DateTime,IsNull=false)]
        public DateTime LrDate
        {
            get;
            set;
        }
    }
}
