using System;
using System.Data;
namespace Model
{
    public class CSalSalePlu
    {
        public string SaleNo
        {
            get;
            set;
        }

        public int SerialNo
        {
            get;
            set;
        }

        public string PluCode
        {
            get;
            set;
        }

        public string BarCode
        {
            get;
            set;
        }

        public string PluName
        {
            get;
            set;
        }

        public string Unit
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// 发生金额
        /// </summary>
        public decimal FsPrice
        {
            get;
            set;
        }

        /// <summary>
        /// 销售数量
        /// </summary>
        public decimal XsCount
        {
            get;
            set;
        }

        public string PosNo
        {
            get;
            set;
        }

        public string Operater
        {
            get;
            set;
        }
    }
}
