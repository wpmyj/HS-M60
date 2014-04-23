using System;
using System.Data;
using WSForSM90.Interface;
using SqlUtilities.Attributes;
namespace Model
{
    [Table(TableName = "pos_SaleFlow")]
    public class CSalSalePlu : IDBObject
    {
        [Column(ColumnName = "flow_no",DbType=DbType.String)]
        public string SaleNo
        {
            get;
            set;
        }
        [Column(ColumnName = "flow_id", DbType = DbType.Int16)]
        public int SerialNo
        {
            get;
            set;
        }
        [Column(ColumnName = "incode", DbType = DbType.String)]
        public string PluCode
        {
            get;
            set;
        }
        [Column(ColumnName = "barcode", DbType = DbType.String)]
        public string BarCode
        {
            get;
            set;
        }
        public string PluName
        {
            get;
            set;
        }
        
        public string Unit
        {
            get;
            set;
        }
        [Column(ColumnName = "price", DbType = DbType.Decimal)]
        public decimal Price
        {
            get;
            set;
        }

        [Column(ColumnName = "s_price", DbType = DbType.Decimal)]
        public decimal SPrice
        {
            get
            {
                return Price;
            }
        }

        /// <summary>
        /// 发生金额
        /// </summary>
        [Column(ColumnName = "total", DbType = DbType.Decimal)]
        public decimal FsPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 销售数量
        /// </summary>
        [Column(ColumnName = "qty", DbType = DbType.Decimal)]
        public decimal XsCount
        {
            get;
            set;
        }
        [Column(ColumnName = "posno", DbType = DbType.String,Default="001")]
        public string PosNo
        {
            get;
            set;
        }
        [Column(ColumnName = "sdate", DbType = DbType.DateTime)]
        public DateTime SDate
        {
            get;
            set;
        }
        [Column(ColumnName = "stime", DbType = DbType.String)]
        public string STime
        {
            get;
            set;
        }
        [Column(ColumnName = "operater", DbType = DbType.String)]
        public string Operater
        {
            get;
            set;
        }
        [Column(ColumnName = "squadno", DbType = DbType.String,Default="1")]
        public string Squadno
        {
            get;
            set;
        }
        [Column(ColumnName = "tradetype", DbType = DbType.String)]
        public string tradetype 
        {
            get;
            set;
        }

        [Column(ColumnName = "grpno", DbType = DbType.String,Default="000000",IsNull=false)]
        public string GrpNo
        {
            get;
            set;
        }

        [Column(ColumnName = "disc", DbType = DbType.Decimal,Default=100)]
        public decimal Disc
        {
            get;
            set;
        }

        [Column(ColumnName = "zkje", DbType = DbType.Decimal,Default=0)]
        public decimal Zkje
        {
            get;
            set;
        }
        [Column(ColumnName = "zkfs", DbType = DbType.String,IsNull=true)]
        public string Zkfs
        {
            get;
            set;
        }
    }
}
