using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
{
    /// <summary>
    /// 扫描生成的验收单
    /// </summary>
    public class TJhBill
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string BILLNO;

        /// <summary>
        /// 相关单据号（采购单）
        /// </summary>
        public string REFBILLNO;

        /// <summary>
        /// 序号
        /// </summary>
        public string SERIALNO;

        /// <summary>
        /// 采购单序号
        /// </summary>
        public string TOSERIALNO;

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
        /// 包数
        /// </summary>
        public string PACKCOUNT;

        /// <summary>
        /// 件数
        /// </summary>
        public string SGLCOUNT;

        /// <summary>
        /// 生产日期
        /// </summary>
        public string SCDATE;
    }
}