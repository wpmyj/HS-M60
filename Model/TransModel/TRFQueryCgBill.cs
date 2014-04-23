using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
{
    /// <summary>
    /// 从服务器查询的采购单
    /// </summary>
    public class TRFQueryCgBill
    {
        /// <summary>
        /// 单号
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
        /// 商品编码
        /// </summary>
        public string PLUCODE;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string PLUNAME;

        /// <summary>
        /// 条码
        /// </summary>
        public string BARCODE;

        /// <summary>
        /// 规格
        /// </summary>
        public string SPEC;

        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT;

        /// <summary>
        /// 包装单位
        /// </summary>
        public string PACKUNIT;

        /// <summary>
        /// 包装数量
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
        /// 采购数量
        /// </summary>
        public string CGCOUNT; 
    }
}
