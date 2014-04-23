using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace MobilePayment
{
    public class PubGlobal_hs
    {
        #region 配置信息

        /// <summary>
        /// 当前是否为测试模式
        /// </summary>
        public const bool IS_TEST_MODE = false;

        /// <summary>
        /// 当前用户
        /// </summary>
        public static Model_hs.UserInfo User=new Model_hs.UserInfo();

        /// <summary>
        /// 当前组织
        /// </summary>
        public static string OrgCode;

        /// <summary>
        /// 支付方式列表
        /// </summary>
        public static List<Model_hs.TSalPayType> sPayTypes;


        /// <summary>
        /// 设置全屏
        /// </summary>
        /// <param name="fullscreen"></param>
        /// <param name="rectOld"></param>
        /// <returns></returns>
        public static bool SetFullScreen(bool fullscreen, ref Rectangle rectOld)
        {
            int Hwnd = 0;
            Hwnd = Win32.FindWindow("HHTaskBar", null);
            if (Hwnd == 0) return false;
            if (fullscreen)
            {
                Win32.ShowWindow((IntPtr)Hwnd, Win32.SW_HIDE);
                Rectangle rectFull = Screen.PrimaryScreen.Bounds;
                Win32.SystemParametersInfo(Win32.SPI_GETWORKAREA, 0, ref rectOld, Win32.SPIF_UPDATEINIFILE);//get
                Win32.SystemParametersInfo(Win32.SPI_SETWORKAREA, 0, ref rectFull, Win32.SPIF_UPDATEINIFILE);//set
            }
            else
            {
                Win32.ShowWindow((IntPtr)Hwnd, Win32.SW_SHOW);
                Win32.SystemParametersInfo(Win32.SPI_SETWORKAREA, 0, ref rectOld, Win32.SPIF_UPDATEINIFILE);
            }

            return true;
        }

        /// <summary>
        /// 平台名称
        /// </summary>
        private static string Platform
        {
            get
            {
                return Environment.OSVersion.Platform.ToString();
            }
        }

        /// <summary>
        /// 程序所在路径
        /// </summary>
        public static string CurrentPath
        {
            get
            {
                string m_CurrentPath = "";

                if (Platform.Equals("WinCE"))
                {
                    m_CurrentPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                }
                else if (Platform.Equals("Win32NT"))
                {
                    m_CurrentPath = Directory.GetCurrentDirectory();
                }

                return m_CurrentPath;
            }
        }


        /// <summary>
        /// 配置程序路径
        /// </summary>
        public static string ConfigPath
        {
            get {

                return CurrentPath + "\\Config.inf";
            }
        }

        /// <summary>
        /// Ip地址
        /// </summary>
        public static string MobileIp
        {
            get
            {
                return IpHelper.GetIpAddress();
            }
        }

        #endregion

        #region 当前支付通用
        /// <summary>
        /// 当前交易是否成功
        /// </summary>
        public static bool Cur_TradeSucess = false;

        /// <summary>
        /// 当前付款流水
        /// </summary>
        public static List<Model_hs.TSalSalePay> Cur_tSalSalePayList;

        /// <summary>
        /// 关闭当前交易
        /// </summary>
        public static void CloseCur_Trade()
        {
            Cur_TradeSucess = false;
            Cur_tCarParkCharge = null;
            Cur_tCarParkPay = null;
            Cur_tSalSale = null;
            Cur_tSalSalePayList = null;
            Cur_tSalSalePluList = null;
            //GC.Collect();
            //GC.Collect();
        }

        #endregion

        #region 当前消费支付信息

        /// <summary>
        /// 消费已支付金额
        /// </summary>
        public static decimal Cur_Sale_PayTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 消费应付金额
        /// </summary>
        public static decimal Cur_Sale_YFTotal
        {
            get
            {
                decimal ysTotal;
                decimal yhTotal;
                try
                {
                    ysTotal = decimal.Parse(Cur_tSalSale.YSTOTAL);
                }
                catch
                {
                    ysTotal = 0;
                }

                try{
                    yhTotal = decimal.Parse(Cur_tSalSale.YHTOTAL);
                }
                catch
                {
                    yhTotal = 0;
                }
                return ysTotal - yhTotal;
            }

        }

        /// <summary>
        /// 消费支付余额
        /// </summary>
        public static decimal Cur_Sale_YETotal
        {
            get
            {
                return Cur_Sale_YFTotal - Cur_Sale_PayTotal;
            }
        }

        /// <summary>
        /// 当前流水
        /// </summary>
        public static Model_hs.TSalSale Cur_tSalSale;

        /// <summary>
        /// 当前流水明细
        /// </summary>
        public static List<Model_hs.TSalSalePlu> Cur_tSalSalePluList;

        #endregion

        #region 当前停车信息

        /// <summary>
        /// 当前停车信息
        /// </summary>
        public static Model_hs.TCarParkCharge Cur_tCarParkCharge;

        /// <summary>
        /// 当前停车支付信息
        /// </summary>
        public static Model_hs.TCarParkPay Cur_tCarParkPay;

        /// <summary>
        /// 车号
        /// </summary>
        public static string Cur_License
        {
            get;
            set;
        }

        /// <summary>
        /// 停车应付金额
        /// </summary>
        public static decimal Cur_Car_YFTotal
        {
            get
            {
                try
                {
                    return decimal.Parse(Cur_tCarParkPay.FEEYSJE);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 停车已付金额
        /// </summary>
        public static decimal Cur_Car_PayTotal
        {
            get
            {
                try
                {
                    return decimal.Parse(Cur_tCarParkPay.FEESSJE);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Cur_tCarParkPay.FEESSJE = value.ToString("F2");
            }
        }

        /// <summary>
        /// 停车余额
        /// </summary>
        public static decimal Cur_Car_YeTotal
        {
            get
            {
                return Cur_Car_YFTotal  -Cur_Car_PayTotal- Cur_Car_JfTotal * Cur_Car_JfRate - Cur_Car_QuanTotal * Cur_Car_QuanRate-Cur_Car_MdTotal;
            }
        }

        /// <summary>
        /// 停车免单金额
        /// </summary>
        public static decimal Cur_Car_MdTotal
        {
            get
            {
                try
                {
                    return decimal.Parse(Cur_tCarParkPay.FEEMDJE);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Cur_tCarParkPay.FEEMDJE = value.ToString("F2");
            }
        }

        /// <summary>
        /// 停车积分支付
        /// </summary>
        public static decimal Cur_Car_JfTotal
        {
            get
            {
                try
                {
                    return decimal.Parse(Cur_tCarParkPay.FEECOST);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Cur_tCarParkPay.FEECOST = value.ToString("F2");
            }
        }

        /// <summary>
        /// 停车券支付
        /// </summary>
        public static decimal Cur_Car_QuanTotal
        {
            get
            {
                try
                {
                    return decimal.Parse(Cur_tCarParkPay.FEEHOU);
                }
                catch
                {
                    return 0;
                }
            }
            set
            {
                Cur_tCarParkPay.FEEHOU = value.ToString("F2");
            }
        }

        /// <summary>
        /// 停车积分汇率
        /// </summary>
        public static decimal Cur_Car_JfRate
        {
            get
            {
                try
                {
                    return decimal.Parse(Cur_tCarParkCharge.PointsRate);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 停车券汇率
        /// </summary>
        public static decimal Cur_Car_QuanRate
        {
            get
            {
                try
                {
                    return decimal.Parse(Cur_tCarParkCharge.CertiRate);
                }
                catch
                {
                    return 0;
                }
            }
        }
        #endregion

    }


}
