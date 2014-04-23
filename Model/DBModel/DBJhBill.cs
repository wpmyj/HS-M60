using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model.DBModel
{
    [Table(TableName="tJhBill")]
    public class DBJhBill
    {
        [Column(ColumnName="ID",DbType=DbType.Guid,PrimaryKey=true)]
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// 序号
        /// </summary>
        [Column(ColumnName = "SerialNo", DbType = DbType.Int16,Default=0)]
        public int SerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// 采购单序号
        /// </summary>
        [Column(ColumnName="ToSerialNo",DbType=DbType.Int16,Default=0)]
        public int ToSerialNo
        {
            get;
            set;
        }
        /// <summary>
        /// 是否已查验
        /// </summary>
        [Column(ColumnName="Checked",DbType=DbType.String,Default="N")]
        public string Checked
        {
            get;
            set;
        }


        /// <summary>
        /// 单号
        /// </summary>
        [Column(ColumnName = "BillNo", DbType = DbType.String, IsNull = false)]
        public string BillNo
        {
            get;
            set;
        }



        /// <summary>
        /// 商品ID
        /// </summary>
        [Column(ColumnName = "PluID", DbType = DbType.String, IsNull = false)]
        public string PluID
        {
            get;
            set;
        }

        /// <summary>
        /// 包装单位
        /// </summary>
        [Column(ColumnName = "PackUnit", DbType = DbType.String)]
        public string PackUnit
        {
            get;
            set;
        }

        /// <summary>
        /// 包装数量
        /// </summary>
        [Column(ColumnName = "PackQty", DbType = DbType.Decimal, Default = 0)]
        public decimal PackQty
        {
            get;
            set;
        }

        /// <summary>
        /// 采购包数
        /// </summary>
        [Column(ColumnName = "CgPackCount", DbType = DbType.Decimal, Default = 0)]
        public decimal CgPackCount
        {
            get;
            set;
        }
        /// <summary>
        /// 实收包数
        /// </summary>
        [Column(ColumnName = "SsPackCount", DbType = DbType.Decimal, Default = 0)]
        public decimal SsPackCount
        {
            get;
            set;
        }
        /// <summary>
        /// 采购件数
        /// </summary>
        [Column(ColumnName = "CgSGLCount", DbType = DbType.Decimal, Default = 0)]
        public decimal CgSGLCount
        {
            get;
            set;
        }

        /// <summary>
        /// 实收件数
        /// </summary>
        [Column(ColumnName = "SsSGLCount", DbType = DbType.Decimal, Default = 0)]
        public decimal SsSGLCount
        {
            get;
            set;
        }

        /// <summary>
        /// 品名
        /// </summary>
        [Column(ColumnName = "PluName", DbType = DbType.String,IsNull=false)]
        public string PluName
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
        /// 规格
        /// </summary>
        [Column(ColumnName = "Spec", DbType = DbType.String, IsNull = false)]
        public string Spec
        {
            get;
            set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        [Column(ColumnName = "Unit", DbType = DbType.String, IsNull = false)]
        public string Unit
        {
            get;
            set;
        }

        /// <summary>
        /// 采购数量
        /// </summary>
        [Column(ColumnName = "CgCount", DbType = DbType.Decimal, IsNull = false, Default = 0)]
        public decimal CgCount
        {
            get;
            set;
        }

        /// <summary>
        /// 实收数量
        /// </summary>
        [Column(ColumnName = "SsCount", DbType = DbType.Decimal, IsNull = false, Default = 0)]
        public decimal SsCount
        {
            get;
            set;
        }
        /// <summary>
        /// 条码
        /// </summary>
        [Column(ColumnName = "Barcode", DbType = DbType.String)]
        public string Barcode
        {
            get;
            set;
        }

        /// <summary>
        /// 录入人
        /// </summary>
        [Column(ColumnName = "LrUser", DbType = DbType.String)]
        public string LrUser
        {
            get;
            set;
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        [Column(ColumnName = "LrDate", DbType = DbType.DateTime)]
        public DateTime LrDate
        {
            get;
            set;
        }

        /// <summary>
        /// 生产日期
        /// </summary>
        [Column(ColumnName="ScDate",DbType=DbType.String,Default="")]
        public string ScDate
        {
            get;
            set;
        }
    }
}
