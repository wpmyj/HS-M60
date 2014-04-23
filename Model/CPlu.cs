using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Model
{
    public class CPlu
    {
        /// <summary>
        /// 商品编码
        /// </summary>
        public string PluCode
        {
            get;
            set;
        }

        /// <summary>
        /// 条码
        /// </summary>
        public string BarCode
        {
            get;
            set;
        }

        /// <summary>
        /// 品名
        /// </summary>
        public string PluName
        {
            get;
            set;
        }

        /// <summary>
        /// 单价
        /// </summary>
        public Decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// 单位
        /// </summary>
        public string Unit
        {
            get;
            set;
        }
    }
}
