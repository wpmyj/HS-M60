using System;
using System.Collections.Generic;
using System.Text;
using Model;
using Pub;
using Model.TransModel;
using System.Data;
using DAL;
using Model.DBModel;

namespace Comm
{
    public class Comm
    {
        /// <summary>
        /// webservice 地址
        /// </summary>
        public static string URL
        {
            set
            {
                GenParkChargeClass.Url = value + "//" + GENPARKCHARGE_FILENAME;
                GetPayModeClass.Url = value + "//" + GETPAYMODE_FILENAME;
                GetUserNameClass.Url = value + "//" + GETUSERNAME_FILENAME;
                LoginClass.Url = value + "//" + LOGIN_FILENAME;
                RecvParkClass.Url = value + "//" + RECVPARK_FILENAME;
                RecvParkPayClass.Url = value + "//" + RECVPARKPAY_FILENAME;
                RecvSalePayClass.Url = value + "//" + RECVSALEPAY_FILENAME;
                ViewSaleClass.Url = value + "//" + VIEWSALE_FILENAME;
                ViewSalePluClass.Url = value + "//" + VIEWSALEPLU_FILENAME;
                QueryKcClass.Url = value + "//" + QUERYKC_FILENAME;
                RecvCgBillClass.Url=value+"//"+RECVCGBILL_FILENAME;
                QueryCgBillClass.Url = value + "//" + QUERYCGBILL_FILENAME;
                RecvJhBillClass.Url = value + "//" + RECVJHBILL_FILENAME;
                GetBillPreInfoClass.Url = value + "//" + GETBILLPREINFO_FILENAME;
                RecvPdDataClass.Url = value + "//" + RECVPDDATA_FILENAME;
                QueryPluClass.Url = value + "//" + QUERYPLU_FILENAME;
            }
        }

        #region webservice 名称
        const string RECVSALEPAY_FILENAME = "RecvSalePay.asmx";
        const string VIEWSALE_FILENAME = "ViewSale.asmx";
        const string VIEWSALEPLU_FILENAME = "ViewSalePlu.asmx";
        const string GETPAYMODE_FILENAME = "GetPayMode.asmx";
        const string LOGIN_FILENAME = "Login.asmx";
        const string GETUSERNAME_FILENAME = "GetUserName.asmx";
        const string GENPARKCHARGE_FILENAME = "GenParkCharge.asmx";
        const string GETBILLPREINFO_FILENAME = "GetBillPreInfo.asmx";
        const string RECVPARK_FILENAME = "RecvPark.asmx";
        const string RECVPARKPAY_FILENAME = "RecvParkPay.asmx";
        const string QUERYKC_FILENAME = "RFQueryKc.asmx";
        const string QUERYPLU_FILENAME = "RFQueryPlu.asmx";
        const string RECVCGBILL_FILENAME="RFRecvCgBill.asmx";
        const string RECVJHBILL_FILENAME = "RFRecvJhBill.asmx";
        const string QUERYCGBILL_FILENAME = "RFQueryCgBill.asmx";
        const string RECVPDDATA_FILENAME = "RFRecvPdData.asmx";
        #endregion

        #region webservice 对象
        #region 登录
        /// <summary>
        /// 获取付款方式
        /// </summary>
        static WRGetPayMode.GetPayMode GetPayModeClass = new WRGetPayMode.GetPayMode();

        /// <summary>
        /// 获取用户名
        /// </summary>
        static WRGetUserName.GetUserName GetUserNameClass = new WRGetUserName.GetUserName();

        /// <summary>
        /// 登陆
        /// </summary>
        static WRLogin.Login LoginClass = new WRLogin.Login();

        /// <summary>
        /// 获取单据前缀
        /// </summary>
        static WRGetBillPreInfo.GetBillPreInfo GetBillPreInfoClass = new WRGetBillPreInfo.GetBillPreInfo();
        #endregion

        #region 停车收费
        /// <summary>
        /// 停车
        /// </summary>
        static WRRecvPark.RecvPark RecvParkClass = new WRRecvPark.RecvPark();

        /// <summary>
        /// 查询停车应收费
        /// </summary>
        static WRGenParkCharge.GenParkCharge GenParkChargeClass = new WRGenParkCharge.GenParkCharge();
        
        /// <summary>
        /// 停车付款
        /// </summary>
        static WRRecvParkPay.RecvParkPay RecvParkPayClass = new WRRecvParkPay.RecvParkPay();

        #endregion

        #region 移动支付
        /// <summary>
        /// 移动支付付款
        /// </summary>
        static WRRecvSalePay.RecvSalePay RecvSalePayClass = new WRRecvSalePay.RecvSalePay();

        /// <summary>
        /// 获取移动支付 货单
        /// </summary>
        static WRViewSale.ViewSale ViewSaleClass = new WRViewSale.ViewSale();

        /// <summary>
        /// 获取移动支付 明细
        /// </summary>
        static WRViewSalePlu.ViewSalePlu ViewSalePluClass = new WRViewSalePlu.ViewSalePlu();

        #endregion

        /// <summary>
        /// 查询商品信息
        /// </summary>
        static WRRFQueryPlu.RFQueryPlu QueryPluClass = new WRRFQueryPlu.RFQueryPlu();

        #region 库存查询、采购
        /// <summary>
        /// 查询库存
        /// </summary>
        static WRRFQueryKc.RFQueryKc QueryKcClass = new WRRFQueryKc.RFQueryKc();

        /// <summary>
        /// 提交采购单
        /// </summary>
        static WRRFRecvCgBill.RFRecvCgBill RecvCgBillClass=new WRRFRecvCgBill.RFRecvCgBill();
        #endregion

        #region 验收
        /// <summary>
        /// 查询采购单
        /// </summary>
        static WRRFQueryCgBill.RFQueryCgBill QueryCgBillClass = new WRRFQueryCgBill.RFQueryCgBill();

        /// <summary>
        /// 发送验收单
        /// </summary>
        static WRRFRecvJhBill.RFRecvJhBill RecvJhBillClass = new WRRFRecvJhBill.RFRecvJhBill();
        #endregion

        #region 盘点
        static WRRFRecvPdData.RFRecvPdData RecvPdDataClass = new WRRFRecvPdData.RFRecvPdData();
        #endregion
        #endregion

        #region JSON处理
        /// <summary>
        /// 获取服务器返回信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        private static bool RecvMessageObj<T>(string json,ref T obj, out string msg)
        {
            TMessage ReturnValue = Deserialize<TMessage>(json.Replace('\'', '"'));
            if (ReturnValue.Rs != "1")
            {
                obj = default(T);
                msg = ReturnValue.Msg;
                return false;
            }
            else
            {
                try
                {
                    obj = Deserialize<T>(ReturnValue.SJSON.Replace("|", "\""));
                    msg = ReturnValue.Msg;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    obj = default(T);
                    return false;
                }
                return true;
            }



        }

        private static bool RecvMessageObj(string json, out string msg)
        {
            TMessage ReturnValue = Deserialize<TMessage>(json.Replace('\'', '"'));
            if (ReturnValue.Rs != "1")
            {
                msg = ReturnValue.Msg;
                return false;
            }
            else
            {
                try
                {
                    msg = ReturnValue.Msg;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    return false;
                }
                return true;
            }

        }
        /// <summary>
        /// 序列化生成JSON
        /// </summary>
        /// <param name="obj"></param>
        /// <remarks>去除‘<’、‘>’、“k__BackingField”</remarks>
        /// <returns></returns>
        private static string Serialize(object obj)
        {
            return CodeBetter.Json.Converter.Serialize(obj);
        }

        /// <summary>
        /// 反序列化，JSON生成对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        private static T Deserialize<T>(string json)
        {
            try
            {
                return CodeBetter.Json.Converter.Deserialize<T>(json);
            }
            catch
            {
                throw;
            }
        }
        #endregion

        #region 移动支付
        /// <summary>
        /// 扫描单号，获取待支付金额
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <param name="SaleNo"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool ScanSale(string OrgCode,string UserCode,string Password,string SaleNo,ref  TSalSale[] tSalSale ,out string msg)
        {
            try
            {
                if (!RecvMessageObj<TSalSale[]>(ViewSaleClass.ScanSale(OrgCode, SaleNo, UserCode, Password), ref tSalSale, out msg))
                {
                    tSalSale = null;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                msg = "无流水信息";
                tSalSale = null;
                return false;
            }
        }

        /// <summary>
        /// 查询明细
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <param name="SaleNo"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool ViewPlu(string OrgCode, string UserCode, string Password, string SaleNo, ref  List<TSalSalePlu> tSalSalePluList,out string msg)
        {
            try
            {
                if (!RecvMessageObj<List<TSalSalePlu>>(ViewSalePluClass.ViewPlu(OrgCode, SaleNo, UserCode, Password), ref tSalSalePluList, out msg))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                tSalSalePluList = null;
                return false;
            }
        }


        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="payLst"></param>
        /// <param name="SendStatus">发送状态：0-正常发送，1-结算发送</param>
        /// <param name="msg"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        public static bool RecvPay(string OrgCode, string UserCode, string Password, List<TSalSalePay> payLst,string SendStatus,ref string ReturnMsg, out string msg)
        {
            string sJson = CodeBetter.Json.Converter.Serialize(payLst);
            try
            {
                if (!RecvMessageObj<string>(RecvSalePayClass.RecvSalePayFunc(sJson, SendStatus, UserCode, Password), ref ReturnMsg, out msg))
                {
                    if (SendStatus == "0")
                    {
                        throw new Exception(ReturnMsg);
                    }
                    else
                    {
                        if (!SalSalePayDAL.RemoveSalSalePay(out msg))
                        {
                            msg = "删除本地流水失败：" + msg;
                        }
                    }
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                //保存失败流水到本地数据库
                if (SendStatus=="0" && !SalSalePayDAL.AddSalSalePay(PubGlobal.Cur_tSalSalePayList, out msg))
                {
                    msg = "发送流水失败：" + ex.Message + "\r\n保存数据至本地失败：" + msg;
                }
                else
                {
                    msg = "发送流水失败：" + ex.Message + "\r\n已将流水存在本地数据库。当日结算时将再次发送。";
                }
                return false;
            }
        }

        #endregion

        #region 登录操作
        /// <summary>
        /// 读取支付方式
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool GetPayModeFunc(string OrgCode, string UserCode, string Password,ref List<TSalPayType> tSalePayTypeList, out string msg)
        {
            try
            {
                if (!RecvMessageObj<List<TSalPayType>>(GetPayModeClass.GetPayModeFunc(), ref tSalePayTypeList, out msg))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                tSalePayTypeList = null;
                return false;
            } 
        }

        /// <summary>
        /// 登陆用户
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool Logon(string OrgCode, string UserCode, string Password,ref TUserInfo User, out string msg)
        {
            try
            {
                //检测用户是否存在;



                User = new TUserInfo();
                if (!GetUser(OrgCode,  UserCode,Password, ref User, out msg))
                {
                    return false;
                }
                else
                {
                    //用户存在，登陆
                    if (!RecvMessageObj(LoginClass.MobileLogin(OrgCode,UserCode,Password),ref User.Rights,out msg))
                    {
                        return false;
                    }

                    if (User.Rights != null)
                    {
                        User.UserCode = UserCode;
                        User.Password = Password;
                        msg = "登陆成功！";
                        return true;
                    }
                    else
                    {
                        User = null;
                        msg = "登陆失败！密码错误！";
                        return false;
                    }
                }
            }
            catch 
            {
                msg ="查无此人";
                User = null;
                return false;
            }
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetUser(string OrgCode,string UserCode, string Password,ref TUserInfo User, out string msg)
        {
            try
            {
                if (!RecvMessageObj<TUserInfo>(GetUserNameClass.GetName(UserCode,OrgCode),ref User,out msg))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                User = null;
                return false;
            }

        }

        /// <summary>
        /// 获取单据前缀
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetBillPre(string OrgCode, string UserCode, string Password, out string msg)
        {
            string rs=string.Empty;
            try
            {
                if (!RecvMessageObj<string>(GetBillPreInfoClass.GetBillPreInfoFunc(OrgCode, UserCode, Password), ref rs, out msg))
                {
                    return false;
                }
                else
                {
                    PubGlobal.YwTypeRes.Clear();
                    foreach (string YwType in rs.Split(';'))
                    {
                        if (string.IsNullOrEmpty(YwType))
                        {
                            continue;
                        }
                        string[] info=YwType.Split('=');
                        PubGlobal.YwTypeRes.Add(info[0], info[1]);
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                msg = "通讯错误：" + ex.Message;
                return false;
            }
        }
        #endregion

        #region 停车场
        /// <summary>
        /// 获取停车信息
        /// </summary>
        /// <param name="License"></param>
        /// <param name="MobileIp"></param>
        /// <param name="UserCode"></param>
        /// <param name="UserName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GenParkChargeFunc(string License,string MobileIp,string VipNo,string OrgCode,string UserCode,string UserName,string Password, ref  TCarParkCharge[]  carParkInfo,out string msg)
        {
            try
            {
                if (!RecvMessageObj<TCarParkCharge[]>(GenParkChargeClass.GenParkChargeFunc(License,VipNo, MobileIp, UserCode, UserName,Password), ref carParkInfo, out msg))
                {
                    carParkInfo = null;
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                msg = "无停车信息";
                carParkInfo = null;
                return false;
            }
        }

        /// <summary>
        /// 停车
        /// </summary>
        /// <param name="License"></param>
        /// <param name="MobileIp"></param>
        /// <param name="UserCode"></param>
        /// <param name="UserName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RecvParkFunc(string License, string MobileIp, string OrgCode, string UserCode, string UserName, string Password,ref string ReturnMsg,out string msg)
        {
            try
            {
                return RecvMessageObj<string>(RecvParkClass.RecvParkFunc(License, MobileIp, UserCode, UserName,Password), ref ReturnMsg, out msg);
            }
            catch(Exception ex)
            {
                msg = ex.Message;
                ReturnMsg = null;
                return false;
            }
        }


        /// <summary>
        /// 停车场缴费
        /// </summary>
        /// <param name="License"></param>
        /// <param name="MobileIp"></param>
        /// <param name="OrgCode"></param>
        /// <param name="UserCode"></param>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RecvParkPayFunc(string License, string MobileIp, string OrgCode, string UserCode, string UserName, string Password, TCarParkPay carPay, List<TSalSalePay> payLst, ref string ReturnMsg, out string msg)
        {
            if (string.IsNullOrEmpty(carPay.FEECOST))
            {
                carPay.FEECOST = "0";
            }
            if (string.IsNullOrEmpty(carPay.FEEHOU))
            {
                carPay.FEEHOU = "0";
            }
            if (string.IsNullOrEmpty(carPay.FEEMDJE))
            {
                carPay.FEEMDJE = "0";
            }
            if (string.IsNullOrEmpty(carPay.VIPNO))
            {
                carPay.VIPNO = "";
            }
            string jsonStr = CodeBetter.Json.Converter.Serialize(carPay);
            string jsonPay = CodeBetter.Json.Converter.Serialize(payLst);
            try
            {
                return RecvMessageObj<string>(RecvParkPayClass.RecvParkPayFunc(jsonStr,jsonPay, UserCode, UserName, MobileIp,Password),ref ReturnMsg,out msg);
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                ReturnMsg = null;
                return false;
            }
        }

        #endregion

        #region 库存、订单
        /// <summary>
        /// 查询库存
        /// </summary>
        /// <param name="BarCode">条码或编码</param>
        /// <param name="OrgCode">组织编码</param>
        /// <param name="UserCode">用户编码</param>
        /// <param name="PassWord">用户密码</param>
        /// <param name="kc">库存</param>
        /// <param name="msg">返回的消息</param>
        /// <returns>是否成功</returns>
        public static bool QeryKc(string BarCode, string OrgCode, string UserCode, string PassWord ,ref TRFQueryKc[] kc,out string  msg)
        {
            string PacketJson = string.Empty;
            try
            {
                if (!RecvMessageObj<TRFQueryKc[]>(QueryKcClass.QueryKc(BarCode, OrgCode, UserCode, PassWord, ref PacketJson), ref kc, out msg))
                {
                    return false;
                }
                else
                {
                    //PubGlobal.Cur_TRFQueryKc[0].Packets = Deserialize<TPacket[]>(PacketJson.Replace('\'', '"'));
                    RecvMessageObj<List<TPacket>>(PacketJson, ref PubGlobal.Cur_TRFQueryKc[0].Packets, out msg);
                    return true;
                }
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                kc = null;
                return false;
            }
        }

        /// <summary>
        /// 接收采购单
        /// </summary>
        /// <param name="cgBill"></param>
        /// <param name="OrgCode"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool RecvCgBill(DataSet cgBill, string OrgCode, string UserCode, string Password, out string msg)
        {
            string BillNo=PubGlobal.OrgCode+PubGlobal.PosNo+DateTime.Now.ToString("yyyyMMddHHmmssfff");
            foreach (DataRow row in cgBill.Tables[0].Rows)
            {
                row["BillNo"] = BillNo;
            }
            try
            {
                string json = DS2Json.DataSetToJson(cgBill, string.Empty);
                string str = string.Empty;
                str=Comm.RecvCgBillClass.RecvCgBill(json, OrgCode, UserCode, Password);
                return RecvMessageObj(str,out msg);
            }
            catch (Exception ex)
            {
                msg = "通讯失败：" + ex.Message;
                return false;
            }
        }
        #endregion

        /// <summary>
        /// 检索商品信息
        /// </summary>
        /// <param name="BarCode">条码或编码</param>
        /// <param name="OrgCode">组织编码</param>
        /// <param name="UserCode">用户编码</param>
        /// <param name="Password">用户密码</param>
        /// <param name="plu">商品信息</param>
        /// <param name="msg">返回的消息</param>
        /// <returns>是否成功</returns>
        public static bool QeryPlu(string BarCode, string OrgCode, string UserCode, string Password, ref List<TRFQueryPlu> plu, out string msg)
        {
            string PacketJson = string.Empty;
            try
            {
                if (!RecvMessageObj<List<TRFQueryPlu>>(QueryPluClass.QueryPlu(BarCode, OrgCode, UserCode, Password, ref PacketJson), ref plu, out msg))
                {
                    return false;
                }
                else
                {
                    return RecvMessageObj<List<TPacket>>(PacketJson.Replace('\'', '"'),ref PubGlobal.Cur_TRFQueryPlu[0].Packets,out msg);
                }
            }
            catch (Exception ex)
            {
                plu = null;
                msg = ex.Message;
                return false;
            }
        }

        #region 验收单

        /// <summary>
        /// 查询获取订单
        /// </summary>
        /// <param name="CgBillNo">订单号</param>
        /// <param name="OrgCode">组织代码</param>
        /// <param name="UserCode">用户编码</param>
        /// <param name="PassWord">密码</param>
        /// <returns></returns>
        public static bool QueryCgBill(string CgBillNo, string OrgCode, string UserCode, string PassWord, out string msg)
        {
            List<TRFQueryCgBill> cgBill = new List<TRFQueryCgBill>();
            if (!RecvMessageObj(QueryCgBillClass.QueryCgBill(CgBillNo, OrgCode, UserCode, PassWord),ref cgBill ,out msg))
            {
                msg = "接收采购单失败：" + msg;
                return false;
            }
            else
            {
                //接收成功，将数据存入本地数据库
                if (!JhBillDAL.AddBill(cgBill, out msg))//清空验收单表
                {
                    msg = "保存采购单表失败：" + msg;
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// 发送验收单
        /// </summary>
        /// <param name="JhBill"></param>
        /// <param name="YwType"></param>
        /// <param name="RefBillNo"></param>
        /// <param name="CkCode"></param>
        /// <param name="OrgCode"></param>
        /// <param name="UserCode"></param>
        /// <param name="PassWord"></param>
        /// <returns></returns>
        public static bool RecvJhBill(DataSet JhBill, string YwType, string RefBillNo, string CkCode, string OrgCode, string UserCode, string PassWord,out string msg)
        {
            string BillNo = PubGlobal.OrgCode + PubGlobal.PosNo + DateTime.Now.ToString("yyyyMMddHHmmssfff");
            foreach (DataRow row in JhBill.Tables[0].Rows)
            {
                row["BillNo"] = BillNo;
            }
            try
            {
                string json = DS2Json.DataSetToJson(JhBill, string.Empty);
                string str = string.Empty;
                str = Comm.RecvJhBillClass.RecvJhBill(json,YwType,RefBillNo,CkCode, OrgCode, UserCode, PassWord);
                return RecvMessageObj(str, out msg);
            }
            catch (Exception ex)
            {
                msg = "通讯失败：" + ex.Message;
                return false;
            }
        }
        #endregion

        #region 盘点单
        public static bool RecvPdData(DataSet PdData, string CkCode,string PdDate, string OrgCode, string UserCode, string PassWord, out string msg)
        {
            int no;
            string BillNo;

            if (NextNoDAL.GetNextNo<DBPdData>(out no, out msg))
            {
                 BillNo= DateTime.Now.ToString("yyyyMMdd") + PubGlobal.PosNo + no.ToString().PadLeft(4,'0');
            }
            else
            {
                return false;
            }
            foreach (DataRow row in PdData.Tables[0].Rows)
            {
                row["PDNO"] = BillNo;
            }
            try
            {
                string json = DS2Json.DataSetToJson(PdData, string.Empty);
                string str = string.Empty;
                str = Comm.RecvPdDataClass.RecvPdData(json, CkCode, OrgCode, PdDate, UserCode, PassWord);
                if (RecvMessageObj(str, out msg))
                {
                    return NextNoDAL.SaveNextNo<DBPdData>(no, out msg);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                msg = "通讯失败：" + ex.Message;
                return false;
            }
        }
        #endregion
    }



}
