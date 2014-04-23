using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Model
{
    public class CSalSalePay
    {
        /// <summary>
        /// 流水号
        /// </summary>
        public string SaleNo
        {
            get;
            set;
        }

        /// <summary>
        /// 支付卡号
        /// </summary>
        public string ZfNo
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式代码
        /// </summary>
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
        public decimal ZfTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 实收金额
        /// 实际冲抵的金额
        /// </summary>
        public decimal SsTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式流水号
        /// </summary>
        public int SerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// 收款员
        /// </summary>
        public string Operator
        {
            get;
            set;
        }

        public DateTime XsDate
        {
            get;
            set;
        }

        public string Stime
        {
            get;
            set;
        }

        public string PosNo
        {
            get;
            set;
        }
    }
}
