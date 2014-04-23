using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Comm
{
    public class Comm
    {
        const bool Is_Test = false;
        const string RECVSALEPAY_FILENAME = "RecvSalePay.asmx";
        const string VIEWSALE_FILENAME = "ViewSale.asmx";
        const string VIEWSALEPLU_FILENAME = "ViewSalePlu.asmx";
        const string GETPAYMODE_FILENAME = "GetPayMode.asmx";
        const string LOGINFILE_NAME = "Login.asmx";
        const string GETUSERNAME_FILENAME = "GetUserName.asmx";
        const string GENPARKCHARGE_FILENAME = "GenParkCharge.asmx";
        const string RECVPARK_FILENAME = "RecvPark.asmx";
        const string RECVPARKPAY_FILENAME = "RecvParkPay.asmx";
        
        static WRGenParkCharge.GenParkCharge GenParkChargeClass = new WRGenParkCharge.GenParkCharge();
        static WRGetPayMode.GetPayMode GetPayModeClass = new WRGetPayMode.GetPayMode();
        static WRGetUserName.GetUserName GetUserNameClass = new WRGetUserName.GetUserName();
        static WRLogin.Login LoginClass = new WRLogin.Login();
        static WRRecvPark.RecvPark RecvParkClass = new WRRecvPark.RecvPark();
        static WRRecvParkPay.RecvParkPay RecvParkPayClass = new WRRecvParkPay.RecvParkPay();
        static WRRecvSalePay.RecvSalePay RecvSalePayClass = new WRRecvSalePay.RecvSalePay();
        static WRViewSale.ViewSale ViewSaleClass = new WRViewSale.ViewSale();
        static WRViewSalePlu.ViewSalePlu ViewSalePluClass = new WRViewSalePlu.ViewSalePlu();
        
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
                LoginClass.Url = value + "//" + LOGINFILE_NAME;
                RecvParkClass.Url = value + "//" + RECVPARK_FILENAME;
                RecvParkPayClass.Url = value + "//" + RECVPARKPAY_FILENAME;
                RecvSalePayClass.Url = value + "//" + RECVSALEPAY_FILENAME;
                ViewSaleClass.Url = value + "//" + VIEWSALE_FILENAME;
                ViewSalePluClass.Url = value + "//" + VIEWSALEPLU_FILENAME;
            }
        }

        /// <summary>
        /// 扫描单号，获取待支付金额
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <param name="SaleNo"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool ScanSale(string OrgCode, string UserCode, string Password, string SaleNo, out  Model_hs.TSalSale tSalSale, out string msg)
        {
            if (Is_Test)
            {
                System.Threading.Thread.Sleep(1000);
                msg = string.Empty;
                tSalSale = testData.sal;
                return  true;
            }
            else
            {
                string jsonStr = string.Empty;
                try
                {
                    jsonStr = ViewSaleClass.ScanSale(OrgCode, SaleNo, UserCode, Password).Replace('\'', '\"');
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    tSalSale = null;
                    return false;
                }
                try
                {
                    Model_hs.TSalSale[] sale = CodeBetter.Json.Converter.Deserialize<Model_hs.TSalSale[]>(jsonStr);
                    tSalSale = sale[0];
                    msg = string.Empty;
                    return true;
                }
                catch(Exception ex)
                {
                    msg = "无流水信息";
                    tSalSale = null;
                    return false;
                }

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
        public static bool ViewPlu(string OrgCode, string UserCode, string Password, string SaleNo, out  List<Model_hs.TSalSalePlu> tSalSalePluList,out string msg)
        {
            if (Is_Test)
            {
                System.Threading.Thread.Sleep(1000);
                msg = string.Empty;
                tSalSalePluList = testData.salplu;
                return true ;
            }
            else
            {
                string jsonStr;
                try
                {
                    jsonStr = ViewSalePluClass.ViewPlu(OrgCode, SaleNo, UserCode, Password).Replace('\'', '\"');
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    tSalSalePluList = null;
                    return false;
                }
                try
                {
                    msg = string.Empty;
                    tSalSalePluList = CodeBetter.Json.Converter.Deserialize<List<Model_hs.TSalSalePlu>>(jsonStr);
                    return true;
                }
                catch
                {
                    msg = "无流水明细";
                    tSalSalePluList = null;
                    return false;
                }
            }
        }


        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="payLst"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        public static bool Pay(string OrgCode, string UserCode, string Password, List<Model_hs.TSalSalePay> payLst,out string ReturnMsg, out string msg)
        {
            if (Is_Test)
            {
                msg=string.Empty;
                ReturnMsg="交易成功！";
                return true;
            }
            else
            {
                string sJson = CodeBetter.Json.Converter.Serialize(payLst);
                try
                {
                    msg = string.Empty;
                    ReturnMsg = RecvSalePayClass.RecvSalePayFunc(sJson, UserCode, Password); 
                    return true;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    ReturnMsg = null;
                    return false;
                }
            }
        }

        /// <summary>
        /// 读取支付方式
        /// </summary>
        /// <param name="OrgCode"></param>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool GetPayModeFunc(string OrgCode, string UserCode, string Password,out List<Model_hs.TSalPayType> tSalePayTypeList, out string msg)
        {
            if (Is_Test)
            {
                System.Threading.Thread.Sleep(1000);
                msg = string.Empty;
                tSalePayTypeList = testData.plist;
                return  true;
            }
            else
            {
                try
                {
                    string str = GetPayModeClass.GetPayModeFunc().Replace("'", "\"");
                    msg = string.Empty;
                    tSalePayTypeList=CodeBetter.Json.Converter.Deserialize<List<Model_hs.TSalPayType>>(str);
                    return true;
                }
                catch (Exception ex)
                {
                    msg = ex.Message;
                    tSalePayTypeList = null;
                    return false;
                }
            }
        }

        /// <summary>
        /// 登陆用户
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static bool Logon(string OrgCode, string UserCode, string Password,out Model_hs.UserInfo User, out string msg)
        {
            if (Is_Test)
            //if(true)
            {
                System.Threading.Thread.Sleep(1000);
                if (testData.user.UserCode == UserCode && testData.user.Password == Password)
                {
                    User=testData.user;
                    msg = string.Empty;
                    return true;
                }
                else
                {
                    msg = "用户名或密码错误！";
                    User = null;
                    return false;
                }
            }
            else
            {
                try
                {
                    //检测用户是否存在
                    string UserName=GetUserNameClass.GetName(UserCode, OrgCode).Replace('\'','"');

                    User = CodeBetter.Json.Converter.Deserialize<Model_hs.UserInfo>(UserName);
                    if (User == null & string.IsNullOrEmpty(User.USERNAME))
                    {
                        msg = "该用户不存在！";
                        User = null;
                        return false;
                    }
                    else
                    {
                        //登陆
                        User.Rights = CodeBetter.Json.Converter.Deserialize<Model_hs.UserRight[]>(LoginClass.MobileLogin(OrgCode, UserCode, MobilFuncManager.Hash.Hasher(Password)).Replace('\'', '"'));
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
                catch (Exception ex)
                {
                    msg ="查无此人";
                    User = null;
                    return false;
                }
            }
        }

        /// <summary>
        /// 获取用户名称
        /// </summary>
        /// <param name="UserCode"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GetUserName(string OrgCode, string Password,string UserCode,out string UserName, out string msg)
        {
            try
            {
                msg = string.Empty;
                UserName = CodeBetter.Json.Converter.Deserialize<Model_hs.UserInfo>(GetUserNameClass.GetName(UserCode, OrgCode)).USERNAME;

                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                UserName = null;
                return false;
            }

        }

        /// <summary>
        /// 获取停车信息
        /// </summary>
        /// <param name="License"></param>
        /// <param name="MobileIp"></param>
        /// <param name="UserCode"></param>
        /// <param name="UserName"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static bool GenParkChargeFunc(string License,string MobileIp,string OrgCode,string UserCode,string UserName,string Password, out  Model_hs.TCarParkCharge  carParkInfo,out string msg)
        {
            string jsonStr = string.Empty;
            try
            {
                msg = string.Empty;
                jsonStr = GenParkChargeClass.GenParkChargeFunc(License, MobileIp, UserCode, UserName).Replace('\'','"');
            }
            catch (System.Exception ex)
            {
                msg = ex.Message;
                carParkInfo = null;
                return false;
            }
            try
            {
                Model_hs.TCarParkCharge[] charge = CodeBetter.Json.Converter.Deserialize<Model_hs.TCarParkCharge[]>(jsonStr);
                carParkInfo = charge[0];
                msg = string.Empty;
                return true;
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
        public static bool RecvParkFunc(string License, string MobileIp, string OrgCode, string UserCode, string UserName, string Password,out string ReturnMsg,out string msg)
        {
            try
            {
                string str = RecvParkClass.RecvParkFunc(License, MobileIp, UserCode, UserName);
                msg = string.Empty;
                ReturnMsg = str;
                return true;
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
        public static bool RecvParkPayFunc(string License, string MobileIp, string OrgCode, string UserCode, string UserName, string Password,Model_hs.TCarParkPay carPay,List<Model_hs.TSalSalePay> payLst, out string ReturnMsg,out string msg)
        {
            string jsonStr = CodeBetter.Json.Converter.Serialize(carPay);
            string jsonPay = CodeBetter.Json.Converter.Serialize(payLst);
            try
            {
                jsonStr = RecvParkPayClass.RecvParkPayFunc(jsonStr,jsonPay, UserCode, UserName, MobileIp);
                ReturnMsg = jsonStr;
                msg = string.Empty;
                return true;
            }
            catch (Exception ex)
            {
                msg = ex.Message;
                ReturnMsg = null;
                return false;
            }
        }

        /// <summary>
        /// 测试数据
        /// </summary>
        public static Model_hs.TestData testData = new Model_hs.TestData();

    }



}
