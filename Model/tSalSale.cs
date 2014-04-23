using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using SqliteUtilities.Attributes;
using System.Data;

namespace Model
{
    [Table(PrimaryKeyProperty = "ID", TableName = "tSalSale")]
    public class TSalSale
    {
        [Column(ColumnName = "ID", SQLDbType = SqlDbType.UniqueIdentifier)]
        public Guid ID
        {
            get;
            set;
        }

        [Column(ColumnName="SaleNo",SQLDbType=SqlDbType.NVarChar)]
        public string SaleNo
        {
            get;
            set;
        }

        /// <summary>
        /// 实收金额
        /// </summary>
        [Column(ColumnName = "SsTotal", SQLDbType = SqlDbType.Decimal)]
        public decimal SsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 会员卡号
        /// </summary>
        [Column(ColumnName = "VipCardno", SQLDbType = SqlDbType.NVarChar)]
        public string VipCardno
        {
            get;
            set;
        }

        /// <summary>
        /// 原始金额
        /// </summary>
        [Column(ColumnName = "YsTotal", SQLDbType = SqlDbType.Decimal)]
        public decimal YsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 优惠金额
        /// </summary>
        [Column(ColumnName = "YhTotal", SQLDbType = SqlDbType.Decimal)]
        public decimal YhTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 销售时间
        /// </summary>
        [Column(ColumnName = "XsTime", SQLDbType = SqlDbType.DateTime)]
        public DateTime XsTime
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
        /// <summary>
        /// 操作员
        /// </summary>
        [Column(ColumnName="Operator",SQLDbType=SqlDbType.VarChar)]
        public string Operator
        {
            get;
            set;
        }

        /// <summary>
        /// 会员折扣
        /// </summary>
        [Column(ColumnName = "VipDsc", SQLDbType = SqlDbType.SmallInt)]
        public int VipDsc
        {
            get;
            set;
        }
    }
}
