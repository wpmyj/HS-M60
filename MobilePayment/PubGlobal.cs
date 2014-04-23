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
        public static Model.CUser Cur_User;

        /// <summary>
        /// 收款机号
        /// </summary>
        public static string PosNo
        {
            get;
            set;
        }

        /// <summary>
        /// 支付方式列表
        /// </summary>
        public static ICollection<Model.CSalPayType> sPayTypes;


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
            get
            {

                return CurrentPath + "\\Config.inf";
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
        public static Model.CVip Cur_Vip;

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

        ///// <summary>
        ///// 获取流水号
        ///// </summary>
        //public static string SaleNo
        //{
        //    get
        //    {
        //       return DAL.DAL.SyscfgDAL.GetFlowNo();
        //    }
        //}



        /// <summary>
        /// 当前数量
        /// </summary>
        public static decimal Cur_XsCount
        {
            get;
            set;
        }

        /// <summary>
        /// 是否为退货
        /// </summary>
        public static bool SaleBack
        {
            get;
            set;
        }

        /// <summary>
        /// 当前Plu
        /// </summary>
        public static Model.CPlu Cur_Plu;

        /// <summary>
        /// 当前交易是否成功
        /// </summary>
        public static bool Cur_TradeSucess = false;

        /// <summary>
        /// 当前付款流水
        /// </summary>
        public static List<Model.CSalSalePay> Cur_tSalSalePayList = new List<Model.CSalSalePay>();



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
        public static Model.CSalSale Cur_tSalSale;

        /// <summary>
        /// 当前流水明细
        /// </summary>
        public static List<Model.CSalSalePlu> Cur_tSalSalePluList = new List<Model.CSalSalePlu>();

        #endregion


    }


}
