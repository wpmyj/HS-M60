using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Model.TransModel
{
    /// <summary>
    /// 扫描生成的采购单
    /// </summary>
   
    public class TCgBill
    {
        /// <summary>
        /// 订单号
        /// </summary>
        
        public string BILLNO;

        /// <summary>
        /// 序号
        /// </summary>
        
        public string SERIALNO;

        /// <summary>
        /// 商品ID
        /// </summary>
        
        public string PLUID;
        
        /// <summary>
        /// 包装单位
        /// </summary>
        
        public string PACKUNIT;

        /// <summary>
        /// 包装细数
        /// </summary>
        
        public string PACKQTY;

        /// <summary>
        /// 包装数
        /// </summary>
        public string PACKCOUNT;

        /// <summary>
        /// 单件数
        /// </summary>
        public string SGLCOUNT;
    }
}
