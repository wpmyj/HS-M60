using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
{
    public class TRFQueryKc
    {
        /// <summary>
        /// 条码
        /// </summary>
        public string BARCODE;

        /// <summary>
        /// 商品编码
        /// </summary>
        public string PLUCODE;

        /// <summary>
        /// 商品ID
        /// </summary>
        public string PLUID;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string PLUNAME;
        
        /// <summary>
        /// 简称
        /// </summary>
        public string PLUABBRNAME;

        /// <summary>
        /// 单位
        /// </summary>
        public string UNIT;

        /// <summary>
        /// 规格
        /// </summary>
        public string SPEC;

        /// <summary>
        /// 库存数量
        /// </summary>
        public string KCCOOUNT;

        /// <summary>
        /// 售价
        /// </summary>
        public string PRICE;

        /// <summary>
        /// 促销价
        /// </summary>
        public string YHPRICE;

        /// <summary>
        /// 包装规格
        /// </summary>
        public List<TPacket> Packets;
    }
}
