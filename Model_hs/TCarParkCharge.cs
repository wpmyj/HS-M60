using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model_hs
{
    public class TCarParkCharge
    {
        public string ID;
        public string CHARGE;
        public string HOUR;
        public string VIPNO;
        public string OUTTIME;
        /// <summary>
        /// 每积分对应的金额
        /// </summary>
        public string PointsRate;

        /// <summary>
        /// 每券对应的金额
        /// </summary>
        public string CertiRate;

        /// <summary>
        /// 当前停车积分
        /// </summary>
        public string VipParkPoints;
    }
}
