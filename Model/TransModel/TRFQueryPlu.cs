using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
{
    public class TRFQueryPlu
    {
        /// <summary>
        /// 商品ID
        /// </summary>
        public string PLUID;

        /// <summary>
        /// 条码
        /// </summary>
        public string BARCODE;

        /// <summary>
        /// 商品编码
        /// </summary>
        public string PLUCODE;

        /// <summary>
        /// 商品名称
        /// </summary>
        public string PLUNAME;

        /// <summary>
        /// 品名缩写
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
        /// 价格
        /// </summary>
        public string PRICE;

        /// <summary>
        /// 包装规格
        /// </summary>
        public List<TPacket> Packets;
    }
}
