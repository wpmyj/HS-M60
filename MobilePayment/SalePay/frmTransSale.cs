using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Pub;
using Base;

namespace MobilePayment.SalePay
{
    public partial class FrmTransSale : FrmBase
    {
        public FrmTransSale()
        {
            InitializeComponent();
            dlgInputSaleNo = new DlgInputSaleNo(InputSerialNo);

        }

        /// <summary>
        /// 下一步
        /// </summary>
        protected override void NextStep()
        {
            if (tbSaleNo.Focused && !string.IsNullOrEmpty(tbSaleNo.Text.Trim()))
            {
                //输入焦点在流水框
                //点击确定进行查询流水
                button_1_Click(null, null);
            }
        }

        /// <summary>
        /// 上一步
        /// </summary>
        protected override void PreStep()
        {
            button_4_Click(null, null);
        }
        #region 窗口定义
        FrmSalePay PayWin = new FrmSalePay();
        FrmTransList TransListWin = new FrmTransList();
        #endregion
        private void button_1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSaleNo.Text))
            {
                return;
            }
            ShowWait("正查询交易记录...请稍候...");
            #region 服务器查询
            string msg;
            if (!Comm.Comm.ScanSale(PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, tbSaleNo.Text.Trim(), ref PubGlobal.Cur_tSalSale, out msg))
            {
                tbSaleInfo.Text = msg;
            }
            #endregion
            HideWait();
            ShowTrade();
            tbSaleNo.Focus();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_tSalSale != null)
            {
                PayWin.ShowDialog() ;
                
                tbSaleNo.Focus();
                
                ShowTrade();
            }
            else
            {
                MessageBox.Show("请先查询流水！");
            }
            tbSaleNo.Focus();
        }

        /// <summary>
        /// 显示交易信息
        /// </summary>
        public void ShowTrade()
        {
            if (PubGlobal.Cur_tSalSale != null)
            {
                tbSaleNo.Text = PubGlobal.Cur_tSalSale[0].SALENO;
                StringBuilder Sbuilder = new StringBuilder();
                Sbuilder.AppendFormat("会员卡号：{0}\r\n", PubGlobal.Cur_tSalSale[0].VIPCARDNO);
                Sbuilder.Append("------------------------------------------\r\n");
                Sbuilder.AppendFormat("应收金额：{0}\r\n", decimal.Parse(PubGlobal.Cur_tSalSale[0].YSTOTAL).ToString("F2"));
                Sbuilder.AppendFormat("优惠金额：{0}\r\n", decimal.Parse(PubGlobal.Cur_tSalSale[0].YHTOTAL).ToString("F2"));
                Sbuilder.AppendFormat("应付金额：{0}\r\n", PubGlobal.Cur_Sale_YFTotal.ToString("F2"));
                tbSaleInfo.Text = Sbuilder.ToString();
            }
            else
            {
                tbSaleInfo.Text = string.Empty;
            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            PubGlobal.CloseCur_Trade();
            ShowTrade();
            this.Close();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_tSalSale == null)
            {
                return;
            }
            ShowWait("正查询交易流水...请稍候...");
            #region 获取明细
            string msg;
            if(!Comm.Comm.ViewPlu(PubGlobal.OrgCode,PubGlobal.User.UserCode,PubGlobal.User.Password,PubGlobal.Cur_tSalSale[0].SALENO,ref PubGlobal.Cur_tSalSalePluList, out msg))
            {
                tbSaleInfo.Text = msg;
            }
            #endregion
            HideWait();
            if (PubGlobal.Cur_tSalSalePluList != null)
            {
                TransListWin.ShowDialog();
            }
            tbSaleNo.Focus();
        }

        private void FrmTransSale_Load(object sender, EventArgs e)
        {
            tbSaleNo.Text = string.Empty;
            ShowTrade();
            tbSaleNo.Focus();
        }

        private void tbSaleNo_GotFocus(object sender, EventArgs e)
        {
            tbSaleNo.SelectAll();
        }

        private void cSideBtn1_OnPressRightButton(object sender, EventArgs e)
        {
            cScanner1.Read();
        }

        private void cScanner1_OnRecvData(object sender, Devices.ScanRecvDataEventArgs e)
        {
            cBuzzer1.Beep(500);
            this.Invoke(dlgInputSaleNo, e.DataValue.Replace("\n",string.Empty).Replace("\r",string.Empty));
        }

        private delegate void DlgInputSaleNo(string saleNo);
        DlgInputSaleNo dlgInputSaleNo;
        private void InputSerialNo(string saleNo)
        {
            tbSaleNo.Text = saleNo;
            button_1_Click(null, null);
        }

        private void FrmTransSale_Activated(object sender, EventArgs e)
        {
            cSideBtn1.Init();
            cSideBtn1.Open();
            cScanner1.Open();
            cBuzzer1.Close();
        }

        private void FrmTransSale_Closing(object sender, CancelEventArgs e)
        {
            cSideBtn1.Close();
            cScanner1.Close();
            cBuzzer1.Close();
        }
        
    }
}