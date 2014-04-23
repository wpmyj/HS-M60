using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MobilePayment.SalePay
{
    public partial class FrmSalePay : FrmBase
    {
        public FrmSalePay()
        {
            InitializeComponent();
        }
        FrmPayType PayTypeBox = new FrmPayType();
        FrmEnterBox EnterBox = new FrmEnterBox();
        /// <summary>
        /// 现金支付
        /// </summary>
        private void CashPay()
        {
            Model.CSalSalePay tSalSalePay = new Model.CSalSalePay();
            tSalSalePay.ZfCode = "01";
            tSalSalePay.ZfNo = "01";
            tSalSalePay.ZfName = "现金";
            tSalSalePay.PosNo = PubGlobal.PosNo;
            if (EnterBox.ShowDialog() == DialogResult.OK)
            {
                tSalSalePay.ZfTotal = EnterBox.Value*(PubGlobal.SaleBack?-1:1);
            }
            else
            {
                return;
            }
            tSalSalePay.SaleNo = PubGlobal.Cur_tSalSale.SaleNo;
            tSalSalePay.SerialNo = ++PubGlobal.SalePaySerialNo;
            PubGlobal.Cur_tSalSalePayList.Add(tSalSalePay);//输入完毕，加入付款流水
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendFormat("{0}-【{1}】  {2}元 \r\n", new string[] { tSalSalePay.SerialNo.ToString(), "现金", tSalSalePay.ZfTotal.ToString("F2") });
            tbPayList.Text += strBuilder.ToString();
            strBuilder.Remove(0, strBuilder.Length);
            if (PubGlobal.SaleBack)
            {
                PubGlobal.Cur_TradeSucess = PubGlobal.Cur_Sale_YETotal - tSalSalePay.ZfTotal >= 0;
            }
            else
            {
                PubGlobal.Cur_TradeSucess = PubGlobal.Cur_Sale_YETotal - tSalSalePay.ZfTotal <= 0;
            }
            if (PubGlobal.Cur_TradeSucess)
            {
                decimal charge;
                charge = tSalSalePay.ZfTotal - PubGlobal.Cur_Sale_YETotal;//找零金额
                tSalSalePay.SsTotal = tSalSalePay.ZfTotal - charge;
                PubGlobal.Cur_tSalSale.SsTotal += tSalSalePay.SsTotal;
                //允许找零
                strBuilder.AppendFormat("  【找零】{0}元\r\n", charge.ToString("F2"));
                tbPayList.Text += strBuilder.ToString();
            }
            else
            {
                tSalSalePay.SsTotal = tSalSalePay.ZfTotal;
            }
            PubGlobal.Cur_Sale_PayTotal += tSalSalePay.SsTotal;
        }

        /// <summary>
        /// 银行卡支付
        /// </summary>
        private void BankCardPay()
        {
            if (EnterBox.ShowDialog() == DialogResult.OK)
            {
                if (EnterBox.Value > PubGlobal.Cur_Sale_YETotal)
                {
                    MessageBox.Show("银行卡金额不允许大于余额！");
                    return;
                }
                Model.CSalSalePay tSalSalePay = new Model.CSalSalePay();
                tSalSalePay.ZfCode = PayTypeBox.PayType.PayCode;
                tSalSalePay.ZfNo = PayTypeBox.PayType.PayCode;
                tSalSalePay.ZfName = PayTypeBox.PayType.PayName;
                tSalSalePay.ZfTotal = EnterBox.Value;
                tSalSalePay.SsTotal = EnterBox.Value;
                tSalSalePay.PosNo = PubGlobal.PosNo;
                tSalSalePay.SaleNo = PubGlobal.Cur_tSalSale.SaleNo;
                tSalSalePay.SerialNo = ++PubGlobal.SalePaySerialNo;
                PubGlobal.Cur_tSalSalePayList.Add(tSalSalePay);//输入完毕，加入付款流水
                PubGlobal.Cur_tSalSale.SsTotal += tSalSalePay.SsTotal;
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("{0}-【{1}】  {2}元 \r\n", new string[] { tSalSalePay.SerialNo.ToString(), PayTypeBox.PayType.PayName, tSalSalePay.ZfTotal.ToString("F2") });
                tbPayList.Text += strBuilder.ToString();
                strBuilder.Remove(0, strBuilder.Length);
                PubGlobal.Cur_TradeSucess =true;
                tSalSalePay.SsTotal = tSalSalePay.ZfTotal;
                PubGlobal.Cur_Sale_PayTotal += tSalSalePay.SsTotal;
            }
        }

        bool isTrade = false;
        private void button_1_Click(object sender, EventArgs e)
        {
            if (PubGlobal.SaleBack)
            {
                //退货
                CashPay();
                if (PubGlobal.Cur_TradeSucess)
                {
                    isTrade = true;
                    ShowPayInfo();
                    PubGlobal.Cur_tSalSale.XsTime = DateTime.Now.ToString("HH:mm:ss");
                    #region 保存流水
                    string msg;

                    //foreach (Model.CSalSalePay salePay in PubGlobal.Cur_tSalSalePayList)
                    //{
                    //    salePay.SaleNo = PubGlobal.Cur_tSalSale.SaleNo;
                    //    salePay.Operator = PubGlobal.Cur_tSalSale.Operator;
                    //    salePay.XsDate = PubGlobal.Cur_tSalSale.XsDate;
                    //    salePay.Stime = PubGlobal.Cur_tSalSale.XsTime;
                    //}

                    ShowWait();
                    if (!Comm.Comm.Trade(PubGlobal.Cur_tSalSale, PubGlobal.Cur_tSalSalePayList, PubGlobal.Cur_tSalSalePluList, out msg))
                    {
                        //支付失败
                        MessageBox.Show(msg);
                        tbPayList.Text += "结算失败！";
                    }
                    else
                    {
                        tbPayList.Text += "结算成功！";
                    }
                    HideWait();
                    #endregion

                    Application.DoEvents();

                    isTrade = false;
                    //PubGlobal.CloseCur_Trade();
                }
                ShowPayInfo();

            }
            else
            {

                if (PayTypeBox.ShowDialog() == DialogResult.OK)
                {
                    //选定付款方式

                    switch (PayTypeBox.PayType.PayType)
                    {
                        case "03"://银行卡
                            BankCardPay();
                            break;

                        case "01"://现金
                            CashPay();
                            break;
                    }
                    if (PubGlobal.Cur_TradeSucess)
                    {
                        isTrade = true;
                        ShowPayInfo();
                        PubGlobal.Cur_tSalSale.XsTime = DateTime.Now.ToString("HH:mm:ss");
                        #region 保存流水
                        string msg;

                        foreach (Model.CSalSalePay salePay in PubGlobal.Cur_tSalSalePayList)
                        {
                            salePay.SaleNo = PubGlobal.Cur_tSalSale.SaleNo;
                            salePay.Operator = PubGlobal.Cur_tSalSale.Operator;
                            salePay.XsDate = PubGlobal.Cur_tSalSale.XsDate;
                            salePay.Stime = PubGlobal.Cur_tSalSale.XsTime;
                        }

                        ShowWait();
                        if (!Comm.Comm.Trade(PubGlobal.Cur_tSalSale, PubGlobal.Cur_tSalSalePayList, PubGlobal.Cur_tSalSalePluList, out msg))
                        {
                            //支付失败
                            MessageBox.Show(msg);
                            tbPayList.Text += "结算失败！";
                        }
                        else
                        {
                            tbPayList.Text += "结算成功！";
                        }
                        HideWait();
                        #endregion

                        Application.DoEvents();

                        isTrade = false;
                        //PubGlobal.CloseCur_Trade();
                    }
                    ShowPayInfo();

                }
            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_TradeSucess)
            {
                button_1.Enabled = true;
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                if (PubGlobal.Cur_tSalSalePayList != null)
                {
                    foreach (Model.CSalSalePay pay in PubGlobal.Cur_tSalSalePayList)
                    {
                        foreach (Model.CSalPayType type in PubGlobal.sPayTypes)
                        {
                            if (type.PayType == "5" || type.PayType == "2")
                            {
                                //银行卡和储值卡
                                //不允许退货
                                if (pay.ZfCode == type.PayCode)
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
            PubGlobal.Cur_tSalSalePayList = new List<Model.CSalSalePay>();
            PubGlobal.Cur_Sale_PayTotal = 0;
            tbPayList.Text = string.Empty;
            ShowPayInfo();
        }

        /// <summary>
        /// 显示付款信息
        /// </summary>
        private void ShowPayInfo()
        {
            if (PubGlobal.SaleBack)
            {
                if (PubGlobal.Cur_tSalSale != null)
                {
                    tbYfMoney.Text = PubGlobal.Cur_Sale_YFTotal.ToString("F2");
                    tbNowMoney.Text = PubGlobal.Cur_Sale_PayTotal.ToString("F2");
                    TxbYhPrice.Text = PubGlobal.Cur_Sale_YhTotal.ToString("F2");
                    button_1.Enabled = PubGlobal.Cur_Sale_YETotal < 0;
                    button_3.Enabled = false;
                }
            }
            else
            {
                if (PubGlobal.Cur_tSalSale != null)
                {
                    tbYfMoney.Text = PubGlobal.Cur_Sale_YFTotal.ToString("F2");
                    tbNowMoney.Text = PubGlobal.Cur_Sale_PayTotal.ToString("F2");
                    TxbYhPrice.Text = PubGlobal.Cur_Sale_YhTotal.ToString("F2");
                    button_1.Enabled = PubGlobal.Cur_Sale_YETotal > 0;
                    button_3.Enabled = PubGlobal.Cur_Sale_YETotal > 0 ;
                }
            }
            button_4.Enabled = !isTrade;
        }
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_3_Click(object sender, EventArgs e)
        {
            if (EnterBox.ShowDialog() == DialogResult.OK)
            {
                PubGlobal.Cur_Sale_YhTotal = EnterBox.Value;
                ShowPayInfo();
            }
        }

        /// <summary>
        /// 关闭交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSalePay_Closing(object sender, CancelEventArgs e)
        {
            //PubGlobal.CloseCur_Trade();
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