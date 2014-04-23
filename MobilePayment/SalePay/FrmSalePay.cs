using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Data.SQLite;
using Devices;

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
        FrmBankPay BankPayBox = new FrmBankPay();
        /// <summary>
        /// 现金支付
        /// </summary>
        private void CashPay()
        {
            Model.TSalSalePay tSalSalePay = new Model.TSalSalePay();
            tSalSalePay.ZfCode = PayTypeBox.PayType.PayCode;
            tSalSalePay.ZfName = PayTypeBox.PayType.PayName;
            if (EnterBox.ShowDialog() == DialogResult.OK)
            {
                tSalSalePay.ZfTotal = EnterBox.Value;
            }
            else
            {
                return;
            }
            tSalSalePay.SaleNo = PubGlobal.Cur_tSalSale.SaleNo;
            tSalSalePay.SerialNo = ++PubGlobal.SalePaySerialNo;
            PubGlobal.Cur_tSalSalePayList.Add(tSalSalePay);//输入完毕，加入付款流水
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.AppendFormat("{0}-【{1}】  {2}元 \r\n", new string[] { tSalSalePay.SerialNo.ToString(), PayTypeBox.PayType.PayName, tSalSalePay.ZfTotal.ToString("F2") });
            tbPayList.Text += strBuilder.ToString();
            strBuilder.Remove(0, strBuilder.Length);
            PubGlobal.Cur_TradeSucess = PubGlobal.Cur_Sale_YETotal - tSalSalePay.ZfTotal <= 0;
            if (PubGlobal.Cur_TradeSucess)
            {
                decimal charge;
                if (PayTypeBox.PayType.IsChange)
                {
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
            BankPayBox.PayTotal = PubGlobal.Cur_Sale_YETotal ;

            if (BankPayBox.ShowDialog() == DialogResult.OK)
            {
                Model.TSalSalePay tSalSalePay = new Model.TSalSalePay();
                tSalSalePay.ZfCode = PayTypeBox.PayType.PayCode;
                tSalSalePay.ZfName = PayTypeBox.PayType.PayName;
                tSalSalePay.ZfTotal = BankPayBox.PayTotal;
                tSalSalePay.SsTotal = BankPayBox.PayTotal;
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
            if (PayTypeBox.ShowDialog() == DialogResult.OK)
            {
                //选定付款方式

                switch (PayTypeBox.PayType.PayType)
                {
                    case "2" ://银行卡
                        BankCardPay();
                        break;

                    case "0"://现金
                        CashPay();
                        break;
                }
                if (PubGlobal.Cur_TradeSucess)
                {
                    isTrade = true;
                    ShowPayInfo();
                    PubGlobal.Cur_tSalSale.SaleNo = PubGlobal.SaleNo;
                    PubGlobal.Cur_tSalSale.XsTime = DateTime.Now;
                    #region 保存流水
                    SQLiteTransaction tran;
                    string msg;
                    int i;

                    if (!DAL.DAL.SalSaleDAL.BeginTran(out tran, out msg))
                    {
                        MessageBox.Show(msg);
                    }

                    if (!DAL.DAL.SalSaleDAL.Save(PubGlobal.Cur_tSalSale, tran, out i, out msg))
                    {
                        DAL.DAL.SalSaleDAL.RollBack(tran, out msg);//回滚
                        tbPayList.Text += "结算保存失败！";
                        PubGlobal.Cur_TradeSucess = false;
                        return;
                    }

                    foreach (Model.TSalSalePlu salePlu in PubGlobal.Cur_tSalSalePluList)
                    {
                        salePlu.SaleNo = PubGlobal.Cur_tSalSale.SaleNo;
                        if (!DAL.DAL.SalSalePluDAL.Save(salePlu, tran, out i, out msg))
                        {
                            DAL.DAL.SalSaleDAL.RollBack(tran, out msg);//回滚
                            tbPayList.Text += "结算保存失败！";
                            PubGlobal.Cur_TradeSucess = false;
                            return;
                        }
                    }

                    foreach (Model.TSalSalePay salePay in PubGlobal.Cur_tSalSalePayList)
                    {
                        salePay.SaleNo = PubGlobal.Cur_tSalSale.SaleNo;
                        salePay.Operator = PubGlobal.Cur_tSalSale.Operator;
                        salePay.XsDate = PubGlobal.Cur_tSalSale.XsDate;
                        if (!DAL.DAL.SalSalePayDAL.Save(salePay, tran, out i, out msg))
                        {
                            DAL.DAL.SalSaleDAL.RollBack(tran, out msg);//回滚
                            tbPayList.Text += "结算保存失败！";
                            PubGlobal.Cur_TradeSucess = false;
                            return;
                        }
                    }

                    if (!DAL.DAL.SalSaleDAL.Commit(tran, out msg))
                    {
                        tbPayList.Text += "结算保存失败！";
                        PubGlobal.Cur_TradeSucess = false;
                        return;
                    }
                    #endregion

                    tbPayList.Text += "结算成功！";

                    #region 打印小票
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("海信M60手持设备演示小票\n");
                    stringBuilder.AppendFormat("流水号：{0}\n", PubGlobal.Cur_tSalSale.SaleNo);
                    stringBuilder.AppendFormat("收款人：{0}-{1}\n", new string[] { PubGlobal.Cur_User.UserCode, PubGlobal.Cur_User.UserName });
                    stringBuilder.AppendFormat("收款时间：{0}\n", PubGlobal.Cur_tSalSale.XsTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(PubGlobal.Cur_tSalSale.VipCardno))
                    {
                        stringBuilder.AppendFormat("会员卡号:{0}\n", PubGlobal.Cur_tSalSale.VipCardno);
                    }
                    stringBuilder.Append("******************************\n");
                    stringBuilder.Append("品名   \n ");
                    stringBuilder.Append("     单价      金额      数量 \n");
                    foreach (Model.TSalSalePlu salePlu in PubGlobal.Cur_tSalSalePluList)
                    {
                        stringBuilder.AppendFormat("{0}. {1}\n", new string[] {salePlu.SerialNo.ToString(),salePlu.PluName});
                        stringBuilder.AppendFormat("{0}{1}{2}\n",
                            new string[]{
                                salePlu.Price.ToString("F2").PadLeft(10,' '),
                                salePlu.FsPrice.ToString("F2").PadLeft(10,' '),
                                salePlu.XsCount.ToString().PadLeft(7,' ') });
                    }
                    stringBuilder.Append("******************************\n");
                    stringBuilder.AppendFormat("应付金额：{0}元\n", PubGlobal.Cur_tSalSale.YsTotal.ToString("F2"));
                    stringBuilder.AppendFormat("优惠金额：{0}元\n", PubGlobal.Cur_tSalSale.YhTotal.ToString("F2"));
                    stringBuilder.AppendFormat("实付金额：{0}元\n", PubGlobal.Cur_tSalSale.SsTotal.ToString("F2"));
                    foreach (Model.TSalSalePay salePay in PubGlobal.Cur_tSalSalePayList)
                    {
                        stringBuilder.AppendFormat("      {0}:{1}元\n", new string[] { salePay.ZfName, salePay.SsTotal.ToString("F2") });
                    }
                    stringBuilder.Append("******************************\n");
                    stringBuilder.Append("欢迎试用海信M60手持设备\n");
                    Printer.Print(stringBuilder.ToString());
                    Printer.Feed(6);
                    Printer.Feed(3);
                    #endregion

                    Application.DoEvents();

                    isTrade = false;
                    //PubGlobal.CloseCur_Trade();
                }
                ShowPayInfo();

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
                    foreach (Model.TSalSalePay pay in PubGlobal.Cur_tSalSalePayList)
                    {
                        foreach (Model.TSalPayType type in PubGlobal.sPayTypes)
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
            PubGlobal.Cur_tSalSalePayList = new List<Model.TSalSalePay>();
            PubGlobal.Cur_Sale_PayTotal = 0;
            tbPayList.Text = string.Empty;
            ShowPayInfo();
        }

        /// <summary>
        /// 显示付款信息
        /// </summary>
        private void ShowPayInfo()
        {
            if (PubGlobal.Cur_tSalSale != null)
            {
                tbYfMoney.Text = PubGlobal.Cur_Sale_YFTotal.ToString("F2");
                tbNowMoney.Text = PubGlobal.Cur_Sale_PayTotal.ToString("F2");
                TxbYhPrice.Text = PubGlobal.Cur_Sale_YhTotal.ToString("F2");
                button_1.Enabled = PubGlobal.Cur_Sale_YETotal > 0;
                button_3.Enabled = PubGlobal.Cur_Sale_YETotal > 0;
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