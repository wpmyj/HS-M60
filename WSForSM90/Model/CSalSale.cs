using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using SqlUtilities.Attributes;
using WSForSM90.Interface;
namespace Model
{
    [Table(TableName = "pos_TradeFlow")]
    public class CSalSale : IDBObject
    {
        [Column(ColumnName = "flow_no",DbType=DbType.String,PrimaryKey=true)]
        public string SaleNo
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [Column(ColumnName = "posno",DbType=DbType.String,Default="001",IsNull=false)]
        public string PosNO
        {
            get;
            set;
        }

        [Column(ColumnName = "squadno",DbType=DbType.String,Default="1",IsNull=false)]
        public string Squadno
        {
            get;
            set;
        }


        [Column(ColumnName = "tradetype",DbType=DbType.String,IsNull=false)]
        public string TradeType
        {
            get;
            set;
        }
        /// <summary>
        /// 实收金额
        /// </summary>
        [Column(ColumnName = "payje", DbType = DbType.Decimal)]
        public decimal SsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 会员卡号
        /// </summary>
        public string VipCardno
        {
            get;
            set;
        }

        /// <summary>
        /// 原始金额
        /// </summary>
        [Column(ColumnName = "total", DbType = DbType.Decimal)]
        public decimal YsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 优惠金额
        /// </summary>
        [Column(ColumnName = "zkje", DbType = DbType.Decimal)]
        public decimal YhTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 销售时间
        /// </summary>
        [Column(ColumnName = "stime", DbType = DbType.String)]
        public string XsTime
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
        /// <summary>
        /// 操作员
        /// </summary>
        [Column(ColumnName = "operater", DbType = DbType.String)]
        public string Operator
        {
            get;
            set;
        }

        /// <summary>
        /// 会员折扣
        /// </summary>
        public int VipDsc
        {
            get;
            set;
        }

        [Column(ColumnName="qty",DbType=DbType.Decimal,Default=1)]
        public decimal Qty
        {
            get;
            set;
        }

        [Column(ColumnName = "Change",DbType=DbType.Decimal,Default=0)]
        public decimal Change
        {
            get;
            set;
        }

    }
}
