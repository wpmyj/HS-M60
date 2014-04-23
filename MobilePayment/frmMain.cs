using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MobilePayment.SalePay;
using DAL;
using System.Data.SQLite;
using Devices;
using MobilePayment.Report;

namespace MobilePayment
{
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();
            
        }


        #region 子窗口
        FrmLogin frmLogin = new FrmLogin();
        FrmSalePlu frmSale = new FrmSalePlu();
        FrmSalSaleRpt frmSalSaleRpt = new FrmSalSaleRpt();
        FrmCasherRpt frmCasherRpt = new FrmCasherRpt();
        PreSalePay.FrmTransSale frmPreSale = new PreSalePay.FrmTransSale();//预售结算窗口
        ParkCarPay.FrmCarPark frmParkCarPay = new ParkCarPay.FrmCarPark();//停车收费窗口
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            //分辨率
            //int i=Win32.GetSystemMetrics(0);
            //int y = Win32.GetSystemMetrics(1);

            //Console.WriteLine(i.ToString() + "|" + y.ToString());

            #region 读取本地参数
            StreamReader Sr = new StreamReader(PubGlobal_hs.ConfigPath);
            Comm.Comm.URL = Sr.ReadLine().Split('=')[1];
            PubGlobal_hs.OrgCode = Sr.ReadLine().Split('=')[1];
            Sr.Dispose();
            #endregion

            string msg;
            DAL.DAL.Open(new SQLiteConnection(PubGlobal.SqlConnectionString), out msg);

            Model.TSyscfg ScanParam = new Model.TSyscfg() { Property = "ScannerType" };

            if (!DAL.DAL.SyscfgDAL.Load(ref ScanParam, out msg))
            {
                MessageBox.Show(msg);
            }
            else
            {
                #region 初始化扫描头
                Scanner.Init(int.Parse(ScanParam.Value));
                Scanner.Open();
                #endregion
            }

            #region 初始化侧键
            SideBtn.Init();
            #endregion

            #region 初始化付款方式
            if (!DAL.DAL.SalPayTypeDAL.GetPayType(out PubGlobal.sPayTypes, out msg))
            {
                MessageBox.Show(msg);
            }
            #endregion

            #region 初始化打印机
            Printer.Init(0, 0, 24, 24, 0);
            #endregion

            #region 初始化蜂鸣器
            Buzzer.Init();
            if (!Buzzer.Open())
            {
                MessageBox.Show("蜂鸣器打开失败");
            }
            #endregion

            Login();

            #region 初始化PubGlobal_hs
            PubGlobal_hs.User = new Model_hs.UserInfo();
            PubGlobal_hs.User.UserCode = PubGlobal.Cur_User.UserCode;
            PubGlobal_hs.User.USERNAME = PubGlobal.Cur_User.UserName;
            PubGlobal_hs.OrgCode = "1009";
            PubGlobal_hs.sPayTypes = new List<Model_hs.TSalPayType>();
            foreach (Model.TSalPayType type in PubGlobal.sPayTypes)
            {
                Model_hs.TSalPayType payType = new Model_hs.TSalPayType();
                payType.ISCHANGE = type.IsChange ? "1" : "0";
                payType.PAYCODE = type.PayCode;
                payType.PAYNAME = type.PayName;
                payType.PAYTYPE = type.PayType;
                payType.PAYTYPENAME = type.PayTypeName;
                PubGlobal_hs.sPayTypes.Add(payType);
            }
            #endregion
        }

        /// <summary>
        /// 登陆操作
        /// </summary>
        private void Login()
        {
            string msg;
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                Rectangle rectangle = Screen.PrimaryScreen.Bounds;
                PubGlobal.SetFullScreen(true, ref rectangle);//false为恢复状态栏

                ShowWait();
                //if (!Comm.Comm.GetPayModeFunc(PubGlobal.OrgCode,PubGlobal.User.UserCode,PubGlobal.User.Password,out PubGlobal.sPayTypes,out msg))//登陆成功，读取付款方式参数
                //{
                //    MessageBox.Show(msg);
                //}
                DataTable dt;
                if (!DAL.DAL.SalPayTypeDAL.Select(string.Empty, string.Empty, out dt, out msg))
                {
                    MessageBox.Show(msg);
                }
                else
                {
                    //DAL.TSalPayTypeDAL.ObjectTool.
                }
                HideWait();
            }
            else
            {
                this.Close();
            }
        }

        private  void button_4_Click(object sender, EventArgs e)
        {
            PubGlobal.Cur_User = null;
            this.Hide();
            Login();
            this.Show();
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
                switch (listView1.FocusedItem.Tag.ToString())
                {
                    case "SalePay"://商品销售
                        frmSale.ShowDialog();
                        break;
                    case "PreSalePay"://预售结算
                        frmPreSale.ShowDialog();
                        break;
                    case "SalSaleRpt"://流水报表
                        frmSalSaleRpt.ShowDialog();
                        break;
                    case "CashRpt"://收款报表
                        frmCasherRpt.ShowDialog();
                        break;
                    case "ParkCarPay"://停车收费报表
                        frmParkCarPay.ShowDialog();
                        break;
                }
        }

        private void FrmMain_Closing(object sender, CancelEventArgs e)
        {
            #region 关闭设备
            Scanner.Close();

            Buzzer.Close();

            Buzzer.Exit();

            Mcr_606_Reader.Close();
            #endregion

            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            PubGlobal.SetFullScreen(false, ref rectangle);//false为恢复状态栏
            this.Close();

            DAL.DAL.Close();
        }

    }
}