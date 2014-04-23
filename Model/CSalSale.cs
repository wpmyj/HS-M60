using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Model
{
    public class CSalSale
    {
        public string TradeType
        {
            get;
            set;
        }

        public string SaleNo
        {
            get;
            set;
        }

        /// <summary>
        /// 实收金额
        /// </summary>
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
        public decimal YsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal YhTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 销售时间
        /// </summary>
        public string XsTime
        {
            get;
            set;
        }

        public DateTime XsDate
        {
            get;
            set;
        }
        /// <summary>
        /// 操作员
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        public string PosNo
        {
            get;
            set;
        }
    }
}
