using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model.DBModel
{
    [Table(TableName="tPdData")]
    public class DBPdData
    {
        [Column(ColumnName="ID",DbType=DbType.Guid,PrimaryKey=true)]
        public Guid ID
        {
            get;
            set;
        }
        /// <summary>
        /// 盘点单号
        /// </summary>
        [Column(ColumnName="PdNo",DbType=DbType.String)]
        public string PdNo
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
        /// PluID
        /// </summary>
        [Column(ColumnName="PluID",DbType=DbType.String)]
        public string PluID
        {
            get;
            set;
        }

        /// <summary>
        /// 单件数
        /// </summary>
        [Column(ColumnName="SjCount",DbType=DbType.Decimal)]
        public decimal SjCount
        {
            get;
            set;
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        [Column(ColumnName="LrDate",DbType=DbType.DateTime)]
        public DateTime LrDate
        {
            get;
            set;
        }

        /// <summary>
        /// 录入人
        /// </summary>
        [Column(ColumnName="LrUser",DbType=DbType.String)]
        public string LrUser
        {
            get;
            set;
        }

        [Column(ColumnName="PluCode",DbType=DbType.String)]
        public string PluCode
        {
            get;
            set;
        }

        [Column(ColumnName="Barcode",DbType=DbType.String)]
        public string Barcode
        {
            get;
            set;
        }

        [Column(ColumnName="PluName",DbType=DbType.String)]
        public string PluName
        {
            get;
            set;
        }

        [Column(ColumnName="Price",DbType=DbType.Decimal)]
        public decimal Price
        {
            get;
            set;
        }

        [Column(ColumnName="Spec",DbType=DbType.String)]
        public string Spec
        {
            get;
            set;
        }

        [Column(ColumnName="Unit",DbType=DbType.String)]
        public string Unit
        {
            get;
            set;
        }
    }
}
