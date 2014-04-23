using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Model.TransModel
{
    /// <summary>
    /// 停车场付款
    /// </summary>
    public class TCarParkPay
    {
        /// <summary>
        /// 停车记录ID
        /// </summary>
        public string ID;  
        
        /// <summary>
        /// 车牌号
        /// </summary>
        public string LISENCE; 
        
        /// <summary>
        /// 应收停车费 金额
        /// </summary>
        public string FEEYSJE ; 
        
        /// <summary>
        /// 免单金额   金额
        /// </summary>
        public string FEEMDJE ;
        
        /// <summary>
        /// 实收金额   金额（券，积分除外）
        /// </summary>
        public string FEESSJE; 
        
        /// <summary>
        /// 积分       
        /// 分数   精确至0.5   
        /// 目前1积分等于1小时
        /// </summary>
        public string FEECOST;       

        /// <summary>
        /// 停车券     
        /// 券数  精确至1    
        /// 目前1券等于1小时 
        /// </summary>
        public string FEEHOU ;

        /// <summary>
        /// 会员卡面号
        /// </summary>
        public string VIPNO;
    }
}
