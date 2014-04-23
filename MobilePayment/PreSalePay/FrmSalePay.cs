using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Devices;

namespace MobilePayment.PreSalePay
{
    public partial class FrmSalePay : FrmBase
    {
        public FrmSalePay()
        {
            InitializeComponent();
        }
        Frm_hs.FrmPayType PayTypeBox = new Frm_hs.FrmPayType();
        Frm_hs.FrmEnterBox EnterBox = new Frm_hs.FrmEnterBox();
        FrmBankPay BankPayBox = new FrmBankPay();
        int serialno = 1;

        bool isTrade = false;
        private void button_1_Click(object sender, EventArgs e)
        {
            isTrade = false;
            if (PayTypeBox.ShowDialog() == DialogResult.OK)
            {
                //选定付款方式
                Model_hs.TSalSalePay tSalSalePay = new Model_hs.TSalSalePay();
                tSalSalePay.ZFCODE = PayTypeBox.PayType.PAYTYPE;
                tSalSalePay.ZfName = PayTypeBox.PayType.PAYNAME;
                if (PayTypeBox.PayType.PAYTYPE == "2")
                {
                    //银行卡
                    BankPayBox.PayTotal = PubGlobal_hs.Cur_Sale_YETotal;
                    if (BankPayBox.ShowDialog() == DialogResult.OK) 
                    {
                        tSalSalePay.ZFTOTAL = BankPayBox.PayTotal.ToString("F2");
                    }
                    else
                    {
                        return;
                    }
                }
                else if (EnterBox.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        decimal.Parse(EnterBox.Value);//尝试转换为数字
                    }
                    catch
                    {
                        MessageBox.Show("输入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                    tSalSalePay.ZFTOTAL = EnterBox.Value;
                }
                else
                {
                    return;
                }
                tSalSalePay.SALENO = PubGlobal_hs.Cur_tSalSale.SALENO;
                tSalSalePay.SERIALNO = (serialno++).ToString();
                tSalSalePay.ORGCODE = PubGlobal_hs.OrgCode;
                PubGlobal_hs.Cur_tSalSalePayList.Add(tSalSalePay);//输入完毕，加入付款流水
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("{0}-【{1}】  {2}元 \r\n", new string[] { tSalSalePay.SERIALNO, PayTypeBox.PayType.PAYNAME, decimal.Parse(tSalSalePay.ZFTOTAL).ToString("F2") });
                tbPayList.Text += strBuilder.ToString();
                strBuilder.Remove(0, strBuilder.Length);
                PubGlobal_hs.Cur_TradeSucess = PubGlobal_hs.Cur_Sale_YETotal - decimal.Parse(tSalSalePay.ZFTOTAL) <= 0;
                if (PubGlobal_hs.Cur_TradeSucess)
                {
                    decimal charge;
                    if (PayTypeBox.PayType.ISCHANGE == "1")
                    {
                        charge = decimal.Parse(tSalSalePay.ZFTOTAL) - PubGlobal_hs.Cur_Sale_YETotal;//找零金额
                        tSalSalePay.SSTOTAL = (decimal.Parse(tSalSalePay.ZFTOTAL) - charge).ToString();
                        //允许找零
                        strBuilder.AppendFormat("  【找零】{0}元\r\n", charge.ToString("F2"));
                        tbPayList.Text += strBuilder.ToString();
                    }
                    else
                    {
                        tSalSalePay.SSTOTAL = decimal.Parse(tSalSalePay.ZFTOTAL).ToString();
                    }
                }
                else
                {
                    tSalSalePay.SSTOTAL = decimal.Parse(tSalSalePay.ZFTOTAL).ToString();
                }
                PubGlobal_hs.Cur_Sale_PayTotal += decimal.Parse(tSalSalePay.SSTOTAL);
                ShowPayInfo();

                if (PubGlobal_hs.Cur_TradeSucess)
                {
                    isTrade = true;
                    ShowPayInfo();
                    #region 打印小票
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("海信M60手持设备演示小票\n");
                    stringBuilder.Append("——预售结算功能\n");
                    stringBuilder.AppendFormat("流水号：{0}\n", PubGlobal_hs.Cur_tSalSale.SALENO);
                    stringBuilder.AppendFormat("收款人：{0}-{1}\n", new string[] { PubGlobal_hs.User.UserCode, PubGlobal_hs.User.USERNAME });
                    stringBuilder.AppendFormat("收款时间：{0}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(PubGlobal_hs.Cur_tSalSale.VIPCARDNO))
                    {
                        stringBuilder.AppendFormat("会员卡号:{0}\n", PubGlobal_hs.Cur_tSalSale.VIPCARDNO);
                    }
                    //stringBuilder.Append("******************************\n");
                    //stringBuilder.Append("品名   \n ");
                    //stringBuilder.Append("     单价      金额      数量 \n");
                    //int i = 0;
                    //foreach (Model_hs.TSalSalePlu salePlu in PubGlobal_hs.Cur_tSalSalePluList)
                    //{
                    //    stringBuilder.AppendFormat("{0}. {1}\n", new string[] { (++i).ToString(), salePlu.PLUNAME });
                    //    stringBuilder.AppendFormat("{0}{1}{2}\n",
                    //        new string[]{
                    //            salePlu.PRICE.PadLeft(10,' '),
                    //            salePlu.FSPRICE.PadLeft(10,' '),
                    //            salePlu.XSCOUNT.PadLeft(7,' ') });
                    //}
                    stringBuilder.Append("******************************\n");
                    stringBuilder.AppendFormat("应付金额：{0}元\n", PubGlobal_hs.Cur_tSalSale.YSTOTAL);
                    stringBuilder.AppendFormat("优惠金额：{0}元\n", PubGlobal_hs.Cur_tSalSale.YHTOTAL);
                    stringBuilder.AppendFormat("实付金额：{0}元\n", PubGlobal_hs.Cur_tSalSale.SSTOTAL);
                    foreach (Model_hs.TSalSalePay salePay in PubGlobal_hs.Cur_tSalSalePayList)
                    {
                        stringBuilder.AppendFormat("      {0}:{1}元\n", new string[] { salePay.ZfName, salePay.SSTOTAL });
                    }
                    stringBuilder.Append("******************************\n");
                    stringBuilder.Append("欢迎试用海信M60手持设备\n");
                    Printer.Print(stringBuilder.ToString());
                    Printer.Feed(6);
                    Printer.Feed(3);
                    #endregion

                    ShowWait();
                    #region 保存至服务器
                    string msg;
                    string ReturnMsg;
                    if (!Comm.Comm.Pay(PubGlobal_hs.OrgCode, PubGlobal_hs.User.UserCode, PubGlobal_hs.User.Password, PubGlobal_hs.Cur_tSalSalePayList, out ReturnMsg, out msg))
                    {
                        HideWait();
                        MessageBox.Show(msg);
                    }
                    else
                    {
                        HideWait();
                        button_3.Enabled = false;
                        button_4.Enabled = false;
                        tbPayList.Text = ReturnMsg;
                        Thread.Sleep(1500);
                        this.DialogResult = DialogResult.OK;

                    }
                    #endregion
                    HideWait();
                    isTrade = false;
                    //PubGlobal_hs.CloseCur_Trade();
                }
                ShowPayInfo();

            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (PubGlobal_hs.Cur_TradeSucess)
            {
                button_1.Enabled = true;
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                if (PubGlobal_hs.Cur_tSalSalePayList != null)
                {
                    foreach (Model_hs.TSalSalePay pay in PubGlobal_hs.Cur_tSalSalePayList)
                    {
                        foreach (Model_hs.TSalPayType type in PubGlobal_hs.sPayTypes)
                        {
                            if (type.PAYTYPE == "5" || type.PAYTYPE == "2")
                            {
                                //不允许退货
                                if (pay.ZFCODE == type.PAYCODE)
                                {
                                    MessageBox.Show("有银行卡或储值卡支付！不允许取消！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                    return;
                                }
                            }
                        }
                    }
                }
                if (MessageBox.Show("确认取消支付？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    MessageBox.Show("支付已取消！");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
            }
        }

        private void FrmPay_Load(object sender, EventArgs e)
        {
            PayTypeBox.Init();
            serialno = 1;
            PubGlobal_hs.Cur_tSalSalePayList = new List<Model_hs.TSalSalePay>();
            PubGlobal_hs.Cur_Sale_PayTotal = 0;
            tbPayList.Text = string.Empty;
            ShowPayInfo();
        }

        /// <summary>
        /// 显示付款信息
        /// </summary>
        private void ShowPayInfo()
        {
            if (PubGlobal_hs.Cur_tSalSale != null)
            {
                tbYfMoney.Text = PubGlobal_hs.Cur_Sale_YFTotal.ToString("F2");
                tbNowMoney.Text = PubGlobal_hs.Cur_Sale_PayTotal.ToString("F2");
                button_1.Enabled = PubGlobal_hs.Cur_Sale_YETotal > 0;
                button_3.Enabled = PubGlobal_hs.Cur_Sale_YETotal <= 0;
            }
            button_4.Enabled = !isTrade;
        }
        ///// <summary>
        ///// 完成
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void button_3_Click(object sender, EventArgs e)
        //{
        //    ShowWait();

        //}

        /// <summary>
        /// 关闭交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSalePay_Closing(object sender, CancelEventArgs e)
        {
            PubGlobal_hs.CloseCur_Trade();
            button_4.Enabled = true;
        }

        private void tbPayList_TextChanged(object sender, EventArgs e)
        {
            tbPayList.ScrollToCaret();
        }

        private void FrmSalePay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (!isTrade)
                    {
                        button_4_Click(null, null);
                    }
                    break;
            }
        }
    }
}