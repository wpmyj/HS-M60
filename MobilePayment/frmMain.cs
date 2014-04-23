using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MobilePayment.SalePay;
using Devices;

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
        //FrmSalSaleRpt frmSalSaleRpt = new FrmSalSaleRpt();
        //FrmCasherRpt frmCasherRpt = new FrmCasherRpt();
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {

            #region 读取本地参数
            StreamReader Sr = new StreamReader(PubGlobal.ConfigPath);
            Comm.Comm.URL = Sr.ReadLine().Split('=')[1];
            PubGlobal.PosNo = Sr.ReadLine().Split('=')[1];
            Sr.Dispose();
            #endregion

            #region 初始化付款方式
            ShowWait();
            string msg;
            if (!Comm.Comm.GetPayType(out PubGlobal.sPayTypes, out msg))
            {
                MessageBox.Show(msg);
            }
            HideWait();

            #endregion

            Login();
        }

        /// <summary>
        /// 登陆操作
        /// </summary>
        private void Login()
        {
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                Rectangle rectangle = Screen.PrimaryScreen.Bounds;
                PubGlobal.SetFullScreen(true, ref rectangle);//false为恢复状态栏
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
                    //case "PreSalePay"://预售结算
                    //   // frmPreSale.ShowDialog();
                    //    break;
                    ////case "SalSaleRpt"://流水报表
                    ////    frmSalSaleRpt.ShowDialog();
                    ////    break;
                    ////case "CashRpt"://收款报表
                    ////    frmCasherRpt.ShowDialog();
                    //    break;
                    ////case "ParkCarPay"://停车收费报表
                    //    //frmParkCarPay.ShowDialog();
                    //    break;
                }
        }

        private void FrmMain_Closing(object sender, CancelEventArgs e)
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            PubGlobal.SetFullScreen(false, ref rectangle);//false为恢复状态栏
            this.Close();
        }

    }
}