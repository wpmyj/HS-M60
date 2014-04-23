using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Comm
{
    public class Comm
    {
        static IPOSWS.POSWS posWSClass = new IPOSWS.POSWS();
        
        /// <summary>
        /// webservice 地址
        /// </summary>
        public static string URL
        {
            set
            {
                posWSClass.Url = value + "/POSWS.asmx";
            }
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userCode"></param>
        /// <param name="mpassword"></param>
        /// <param name="user"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool Logon(string userCode, string mpassword, out Model.CUser user, out string msg)
        {
            try
            {
                //登陆
                CMessage<CUser> cMessage =
                    CodeBetter.Json.Converter.Deserialize<CMessage<CUser>>(posWSClass.Logon(userCode, new Des().EncryStrHex(mpassword, "0125" + userCode)));
                msg = cMessage.Message;
                user = (CUser)cMessage.Obj;
                return cMessage.Status != 0;
                
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                user = null;
                return false;
            }
        }

        /// <summary>
        /// 交易
        /// </summary>
        /// <param name="sale"></param>
        /// <param name="salePay"></param>
        /// <param name="salePlu"></param>
        /// <returns></returns>
        public static bool Trade(Model.CSalSale sale, ICollection<Model.CSalSalePay> salePays, ICollection<Model.CSalSalePlu> salePlus, out string msg)
        {
            try
            {
                string saleJson = CodeBetter.Json.Converter.Serialize(sale),
                    salePayJson = CodeBetter.Json.Converter.Serialize(salePays),
                    salePluJson = CodeBetter.Json.Converter.Serialize(salePlus);

                CMessage<object> cMessage = CodeBetter.Json.Converter.Deserialize<CMessage<object>>(posWSClass.Trade(saleJson, salePayJson, salePluJson));
                msg = cMessage.Message;
                return cMessage.Status != 0;
            }
            catch (System.Exception ex)
            {
                msg = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// 获取支付方式
        /// </summary>
        /// <param name="payTypes"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetPayType(out ICollection<Model.CSalPayType> payTypes, out string msg)
        {
            try
            {
                string json = posWSClass.GetPayType();
                CMessage< List < Model.CSalPayType >> cMessage =
                    CodeBetter.Json.Converter.Deserialize<CMessage< List < Model.CSalPayType >>>(json);
                msg = cMessage.Message;
                payTypes =cMessage.Obj;
                return cMessage.Status != 0;
            }
            catch (System.Exception ex)
            {
                msg = ex.Message;
                payTypes = null;
                return false;
            }
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="code"></param>
        /// <param name="plu"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetGoods(string code, out Model.CPlu plu, out string msg)
        {
            try
            {
                CMessage<CPlu> cMessage = CodeBetter.Json.Converter.Deserialize<CMessage<CPlu>>(posWSClass.GetGoods(code));
                msg = cMessage.Message;
                plu = (CPlu)cMessage.Obj;
                return cMessage.Status != 0;
            }
            catch (System.Exception ex)
            {
                msg = ex.Message;
                plu = null;
                return false;
            }
        }
    }



}
