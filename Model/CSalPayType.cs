using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Model
{
    public class CSalPayType
    {
        /// <summary>
        /// 支付方式编码
        /// 现金-01
        /// 银行卡-10
        /// </summary>
        public string PayCode
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式名称
        /// </summary>
        public string PayName
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式类型
        /// </summary>
        public string PayType
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式类型名称
        /// </summary>
        public string PayTypeName
        {
            get;
            set;
        }
        
        /// <summary>
        /// 是否找零
        /// </summary>
        public bool IsChange
        {
            get;
            set;
        }
    }
}
