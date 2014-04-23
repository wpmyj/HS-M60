using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.ComponentModel;

namespace MobilePayment
{
    public class PubGlobal
    {
        #region 配置信息


        /// <summary>
        /// 当前用户
        /// </summary>
        public static Model.TUser Cur_User=new Model.TUser();


        /// <summary>
        /// 支付方式列表
        /// </summary>
        public static ICollection<Model.TSalPayType> sPayTypes;


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
        /// 数据库路径
        /// </summary>
        public static string SqlConnectionString
        {
            get {

                return  "data source=" + CurrentPath + @"\LocalDB";
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

        #region 当前消费信息
        /// <summary>
        /// 关闭当前交易
        /// </summary>
        public static void CloseCur_Trade()
        {
            Cur_Vip = null;
            Cur_Plu = null;
            Cur_XsCount = 1;
            Cur_TradeSucess = false;
            Cur_tSalSale = null;
            Cur_tSalSalePayList.Clear();
            Cur_tSalSalePluList.Clear();
            SalePaySerialNo = 0;
            SalePluSerialNo = 0;
            //GC.Collect();
            //GC.Collect();
        }

        /// <summary>
        /// 当前会员
        /// </summary>
        public static Model.TVip Cur_Vip;

        /// <summary>
        /// 明细流水序号
        /// </summary>
        [DefaultValue(0)]
        public static int SalePluSerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// 付款流水序号
        /// </summary>
        [DefaultValue(0)]
        public static int SalePaySerialNo
        {
            get;
            set;
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        public static string SaleNo
        {
            get
            {
               return DAL.DAL.SyscfgDAL.GetFlowNo();
            }
        }



        /// <summary>
        /// 当前数量
        /// </summary>
        public static decimal Cur_XsCount
        {
            get;
            set;
        }

        /// <summary>
        /// 当前Plu
        /// </summary>
        public static Model.TPlu Cur_Plu;

        /// <summary>
        /// 当前交易是否成功
        /// </summary>
        public static bool Cur_TradeSucess = false;

        /// <summary>
        /// 当前付款流水
        /// </summary>
        public static List<Model.TSalSalePay> Cur_tSalSalePayList = new List<Model.TSalSalePay>();



        /// <summary>
        /// 消费已支付金额
        /// </summary>
        public static decimal Cur_Sale_PayTotal
        {
            get;
            set;
        }

        /// <summary>
        /// 当前优惠金额
        /// </summary>
        public static decimal Cur_Sale_YhTotal
        {
            get
            {
                return Cur_tSalSale.YhTotal;
            }
            set
            {
                Cur_tSalSale.YhTotal = value;
            }
        }

        /// <summary>
        /// 消费应付金额
        /// </summary>
        public static decimal Cur_Sale_YFTotal
        {
            get
            {
                return Cur_tSalSale.YsTotal - Cur_tSalSale.YhTotal;
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
        public static Model.TSalSale Cur_tSalSale;

        /// <summary>
        /// 当前流水明细
        /// </summary>
        public static List<Model.TSalSalePlu> Cur_tSalSalePluList = new List<Model.TSalSalePlu>();

        #endregion

        #region 报表
        /// <summary>
        /// 交易流水
        /// </summary>
        public static List<Model.TSalSale> SalSaleRpt=new List<Model.TSalSale>();

        /// <summary>
        /// 付款流水
        /// </summary>
        public static List<Model.TSalSalePay> SalSalePayRpt = new List<Model.TSalSalePay>();

        /// <summary>
        /// 商品明细
        /// </summary>
        public static List<Model.TSalSalePlu> SalSalePluRpt = new List<Model.TSalSalePlu>();

        /// <summary>
        /// 收款员报表
        /// </summary>
        public static List<Model.VCashRpt> CashRpt = new List<Model.VCashRpt>();
        #endregion

        #region 当前停车信息

        /// <summary>
        /// 当前停车信息
        /// </summary>
        public static Model.TCarParkCharge Cur_tCarParkCharge;

        /// <summary>
        /// 当前停车支付信息
        /// </summary>
        public static Model.TCarParkPay Cur_tCarParkPay;

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
                return Cur_Car_YFTotal - Cur_Car_PayTotal - Cur_Car_JfTotal * Cur_Car_JfRate - Cur_Car_QuanTotal * Cur_Car_QuanRate - Cur_Car_MdTotal;
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
