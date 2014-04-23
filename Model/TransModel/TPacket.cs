using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
{
    public class TPacket
    {
        /// <summary>
        /// 包装ID
        /// </summary>
        public string PACKETID;

        /// <summary>
        /// 包装单位
        /// </summary>
        public string PACKUNIT;

        /// <summary>
        /// 包装细数
        /// </summary>
        public string PACKQTY;

        /// <summary>
        /// 包装规格
        /// 下拉列表显示项
        /// </summary>
        public string PackSpec
        {
            get
            {
                return PACKQTY + "/" + PACKUNIT;
            }
        }
    }
}
