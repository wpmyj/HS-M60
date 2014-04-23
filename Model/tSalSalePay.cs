using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model
{
    [Table(PrimaryKeyProperty="ID",TableName="tSalSalePay")]
    public class TSalSalePay
    {
        [Column(ColumnName="ID",SQLDbType=SqlDbType.UniqueIdentifier)]
        public Guid ID
        {
            get;
            set;
        }

        /// <summary>
        /// 流水号
        /// </summary>
        [Column(ColumnName = "SaleNo", SQLDbType = SqlDbType.NVarChar)]
        public string SaleNo
        {
            get;
            set;
        }

        /// <summary>
        /// 支付卡号
        /// </summary>
        [Column(ColumnName = "ZfNo", SQLDbType = SqlDbType.NVarChar)]
        public string ZfNo
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式代码
        /// </summary>
        [Column(ColumnName = "ZfCode", SQLDbType = SqlDbType.NVarChar)]
        public string ZfCode
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        [Column(ColumnName = "ZfName", SQLDbType = SqlDbType.NVarChar)]
        public string ZfName
        {
            get;
            set;
        }
        /// <summary>
        /// 支付金额
        /// 实际交的金额
        /// </summary>
        [Column(ColumnName = "ZfTotal", SQLDbType = SqlDbType.Decimal)]
        public decimal ZfTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 实收金额
        /// 实际冲抵的金额
        /// </summary>
        [Column(ColumnName = "SsTotal", SQLDbType = SqlDbType.NVarChar)]
        public decimal SsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式流水号
        /// </summary>
        [Column(ColumnName = "SerialNo", SQLDbType = SqlDbType.SmallInt)]
        public int SerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// 收款员
        /// </summary>
        [Column(ColumnName = "Operator", SQLDbType = SqlDbType.NVarChar)]
        public string Operator
        {
            get;
            set;
        }

        [Column(ColumnName = "XsDate", SQLDbType = SqlDbType.VarChar)]
        public string XsDate
        {
            get;
            set;
        }
    }
}
