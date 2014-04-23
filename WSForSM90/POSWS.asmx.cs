using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSForSM90.DAL;
using Model;
using Newtonsoft.Json;
using System.Collections;

namespace WSForSM90
{
    /// <summary>
    /// POSWS 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class POSWS : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        /// <summary>
        /// 交易
        /// </summary>
        /// <param name="saleJson">交易流水</param>
        /// <param name="salePayJson">付款流水</param>
        /// <param name="salePluJson">交易明细</param>
        /// <returns></returns>
        [WebMethod]
        public string Trade(string saleJson, string salePayJson, string salePluJson)
        {
            CSalSale trade=JsonConvert.DeserializeObject<CSalSale>(saleJson);
            ICollection<CSalSalePay> payList = JsonConvert.DeserializeObject<ICollection<CSalSalePay>>(salePayJson);
            ICollection<CSalSalePlu> pluList = JsonConvert.DeserializeObject<ICollection<CSalSalePlu>>(salePluJson);
            CMessage<object> message = new CMessage<object>();
            using (TradeDAL dal = new TradeDAL())
            {
                message.Status = dal.Save(trade, payList, pluList, out message.Message) ? 1 : 0;
            }
            return JsonConvert.SerializeObject(message);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userCode">用户编码</param>
        /// <param name="mpassword">用户密码</param>
        /// <returns></returns>
        [WebMethod]
        public string Logon(string userCode, string mpassword)
        {
            CMessage<CUser> message=new CMessage<CUser>();
            using (UserDAL dal = new UserDAL())
            {
                message.Status = dal.Logon(userCode, mpassword, out message.Obj, out message.Message) ? 1 : 0;
            }
            return JsonConvert.SerializeObject(message);
        }

        /// <summary>
        /// 获取商品信息
        /// </summary>
        /// <param name="code">商品编码</param>
        /// <returns></returns>
        [WebMethod]
        public string GetGoods(string code)
        {
            CMessage<CPlu> message = new CMessage<CPlu>();
            using (GoodsDAL dal = new GoodsDAL())
            {
                message.Status = dal.GetGoods(code, out message.Obj, out message.Message) ? 1 : 0;
            }
            return JsonConvert.SerializeObject(message);
        }

        /// <summary>
        /// 获取支付方式
        /// </summary>
        /// <returns></returns>
        [WebMethod]
        public string GetPayType()
        {
            CMessage<List<CSalPayType>> message = new CMessage<List<CSalPayType>>();
            message.Status = 1;
            List<Model.CSalPayType> payTypes = new List<Model.CSalPayType>();
            payTypes.Add(new Model.CSalPayType() { PayCode = "01", PayType = "01", PayName = "现金", PayTypeName = "现金", IsChange=true });
            payTypes.Add(new Model.CSalPayType() { PayCode = "03", PayType = "03", PayName = "银行卡", PayTypeName = "银行卡",IsChange=false });
            message.Obj = payTypes;
            return Newtonsoft.Json.JsonConvert.SerializeObject(message);
        }
    }
}
