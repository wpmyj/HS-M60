using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
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
        /// 停车积分余额
        /// </summary>
        public string JFYE;
    }
}
