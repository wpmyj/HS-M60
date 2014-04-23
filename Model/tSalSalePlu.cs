using SqliteUtilities.Attributes;
using System;
using System.Data;
namespace Model
{
    [Table(PrimaryKeyProperty="ID",TableName="tSalSalePlu")]
    public class TSalSalePlu
    {
        [Column(ColumnName="ID",SQLDbType=SqlDbType.UniqueIdentifier)]
        public Guid ID
        {
            get;
            set;
        }

        [Column(ColumnName = "SaleNo", SQLDbType = SqlDbType.NVarChar)]
        public string SaleNo
        {
            get;
            set;
        }

        [Column(ColumnName = "SerialNo", SQLDbType = SqlDbType.Int)]
        public int SerialNo
        {
            get;
            set;
        }

        [Column(ColumnName = "PluCode", SQLDbType = SqlDbType.NVarChar)]
        public string PluCode
        {
            get;
            set;
        }

        [Column(ColumnName = "BarCode", SQLDbType = SqlDbType.NVarChar)]
        public string BarCode
        {
            get;
            set;
        }

        [Column(ColumnName = "PluName", SQLDbType = SqlDbType.NVarChar)]
        public string PluName
        {
            get;
            set;
        }

        [Column(ColumnName = "Unit", SQLDbType = SqlDbType.NVarChar)]
        public string Unit
        {
            get;
            set;
        }

        [Column(ColumnName = "Price", SQLDbType = SqlDbType.Decimal)]
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// 发生金额
        /// </summary>
        [Column(ColumnName = "FsPrice", SQLDbType = SqlDbType.Decimal)]
        public decimal FsPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 销售数量
        /// </summary>
        [Column(ColumnName = "XsCount", SQLDbType = SqlDbType.Decimal)]
        public decimal XsCount
        {
            get;
            set;
        }
    }
}
