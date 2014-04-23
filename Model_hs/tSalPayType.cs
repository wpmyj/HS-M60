using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model_hs
{
    public class TSalPayType
    {
        /// <summary>
        /// 支付方式编码
        /// </summary>
        public  string PAYCODE;

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public  string PAYNAME;

        /// <summary>
        /// 支付方式类型
        /// </summary>
        public  string PAYTYPE;

        /// <summary>
        /// 支付方式类型名称
        /// </summary>
        public  string PAYTYPENAME;
        
        /// <summary>
        /// 是否找零
        /// </summary>
        public  string ISCHANGE;
    }
}
