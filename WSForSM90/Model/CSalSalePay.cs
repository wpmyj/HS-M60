using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SqlUtilities.Attributes;
using WSForSM90.Interface;

namespace Model
{
    [Table(TableName = "pos_PayFlow")]
    public class CSalSalePay : IDBObject
    {
        /// <summary>
        /// 流水号
        /// </summary>
        [Column(ColumnName = "flow_no",DbType=DbType.String)]
        public string SaleNo
        {
            get;
            set;
        }
        [Column(ColumnName = "posno", DbType = DbType.String)]
        public string PosNo
        {
            get;
            set;
        }
        [Column(ColumnName = "squadno", DbType = DbType.String)]
        public string Squadno
        {
            get;
            set;
        }
        /// <summary>
        /// 支付卡号
        /// </summary>
        [Column(ColumnName = "cardno",DbType=DbType.String)]
        public string ZfNo
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式代码
        /// </summary>
        [Column(ColumnName = "paypmt", DbType = DbType.String)]
        public string ZfCode
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string ZfName
        {
            get;
            set;
        }
        /// <summary>
        /// 支付金额
        /// 实际交的金额
        /// </summary>
        [Column(ColumnName = "PayAmount", DbType = DbType.Decimal)]
        public decimal ZfTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 实收金额
        /// 实际冲抵的金额
        /// </summary>
        [Column(ColumnName = "total", DbType = DbType.Decimal)]
        public decimal SsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式流水号
        /// </summary>
        [Column(ColumnName = "flow_id", DbType = DbType.Int16)]
        public int SerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// 收款员
        /// </summary>
        [Column(ColumnName = "operater", DbType = DbType.String)]
        public string Operator
        {
            get;
            set;
        }
        [Column(ColumnName = "sdate", DbType = DbType.DateTime)]
        public DateTime XsDate
        {
            get;
            set;
        }
        [Column(ColumnName = "stime", DbType = DbType.String)]
        public string Stime
        {
            get;
            set;
        }
        [Column(ColumnName = "tradetype", DbType = DbType.String)]
        public string TradeType
        {
            get;
            set;
        }


    }
}
