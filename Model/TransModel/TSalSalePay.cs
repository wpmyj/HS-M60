using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
{
    public class TSalSalePay
    {
        /// <summary>
        /// 组织号
        /// </summary>
        public string ORGCODE;

        /// <summary>
        /// 流水号
        /// </summary>
        public string SALENO;

        /// <summary>
        /// 支付卡号
        /// </summary>
        public string ZFNO;

        /// <summary>
        /// 支付方式代码
        /// </summary>
        public string ZFCODE;

        /// <summary>
        /// 支付金额
        /// 实际交的金额
        /// </summary>
        public string ZFTOTAL;

        /// <summary>
        /// 实收金额
        /// 实际冲抵的金额
        /// </summary>
        public string SSTOTAL;

        /// <summary>
        /// 支付方式流水号
        /// </summary>
        public string SERIALNO;

        /// <summary>
        /// 会员卡面号
        /// </summary>
        public string VIPNO;

    }
}
