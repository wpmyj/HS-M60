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
using Model.TransModel;
using DAL;

namespace MobilePayment.SalePay
{
    public partial class FrmSalePay : FrmBase
    {
        public FrmSalePay()
        {
            InitializeComponent();
        }
        FrmPayType PayTypeBox = new FrmPayType();
        FrmMoneyInput EnterBox = new FrmMoneyInput();

        int serialno = 1;
        private void button_1_Click(object sender, EventArgs e)
        {
            string msg;
            string refNo;
            decimal SsMoney=0;
            if (PayTypeBox.ShowDialog() == DialogResult.OK)
            {
                //选定付款方式
                TSalSalePay tSalSalePay = new TSalSalePay();
                tSalSalePay.ZFCODE = PayTypeBox.PayType.PAYCODE;
                tSalSalePay.ZFNO = string.Empty;
                tSalSalePay.VIPNO = string.Empty;
                switch (PayTypeBox.PayType.PAYTYPE)
                {
                    case "2"://银联卡

                        //if (!Devices.Emvpboc.SendPay(PubGlobal.Cur_Sale_YETotal, Devices.Emvpboc.ActionType.消费, out SsMoney, out msg))
                        //{
                        //    MessageBox.Show("银联支付失败：" + msg);
                        //    return;
                        //}
                        SsMoney = PubGlobal.Cur_Sale_YETotal;
                        if (!cEmvpbocBank.Action(Devices.CEmvpboc.ActionType.消费, ref SsMoney, out refNo, out msg))
                        {
                            MessageBox.Show("银联支付失败：" + msg);
                            return;
                        }
                        else
                        {
                            tSalSalePay.SSTOTAL = SsMoney.ToString("F2");
                            tSalSalePay.ZFTOTAL = SsMoney.ToString("F2");
                            tSalSalePay.ZFNO = refNo;
                        }
                        break;
                    case "1"://储值卡
                        SsMoney = PubGlobal.Cur_Sale_YETotal;
                        if (!cEmvpbocBank.Action(Devices.CEmvpboc.ActionType.消费, ref SsMoney, out refNo, out msg))
                        {
                            MessageBox.Show("储值卡支付失败：" + msg);
                            return;
                        }
                        else
                        {
                            tSalSalePay.SSTOTAL = SsMoney.ToString("F2");
                            tSalSalePay.ZFTOTAL = SsMoney.ToString("F2");
                            tSalSalePay.ZFNO = refNo;
                        }
                        break;
                    default://其他

                        if (EnterBox.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                SsMoney = decimal.Parse(EnterBox.Value);//尝试转换为数字
                            }
                            catch
                            {
                                MessageBox.Show("输入错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                                SsMoney = 0;
                                return;
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                }

                tSalSalePay.ZFTOTAL = SsMoney.ToString("F2");
                tSalSalePay.SALENO = PubGlobal.Cur_tSalSale[0].SALENO;
                tSalSalePay.SERIALNO = (serialno++).ToString();
                tSalSalePay.ORGCODE = PubGlobal.OrgCode;
                PubGlobal.Cur_tSalSalePayList.Add(tSalSalePay);//输入完毕，加入付款流水
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("{0}-【{1}】  {2}元 \r\n", new string[] { tSalSalePay.SERIALNO, PayTypeBox.PayType.PAYNAME, decimal.Parse(tSalSalePay.ZFTOTAL).ToString("F2") });
                tbPayList.Text += strBuilder.ToString();
                strBuilder.Remove(0, strBuilder.Length);
                PubGlobal.Cur_TradeSucess = PubGlobal.Cur_Sale_YETotal - decimal.Parse(tSalSalePay.ZFTOTAL) <= 0;
                if (PubGlobal.Cur_TradeSucess)
                {
                    decimal charge;
                    if (PayTypeBox.PayType.ISCHANGE == "1")
                    {
                        charge = decimal.Parse(tSalSalePay.ZFTOTAL) - PubGlobal.Cur_Sale_YETotal;//找零金额
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
                PubGlobal.Cur_Sale_PayTotal += decimal.Parse(tSalSalePay.SSTOTAL);
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
                    foreach (TSalSalePay pay in PubGlobal.Cur_tSalSalePayList)
                    {
                        foreach (TSalPayType type in PubGlobal.sPayTypes)
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
            PubGlobal.Cur_tSalSalePayList = new List<TSalSalePay>();
            PubGlobal.Cur_Sale_PayTotal = 0;
            cEmvpbocBank.ExeFilePath = PubGlobal.ExeFilePath_Bank;
            cEmvpbocBank.InDataFilePath = PubGlobal.InFilePath_Bank;
            cEmvpbocBank.OutDataFilePath = PubGlobal.OutFilePath_Bank;

            cEmvpbocVip.ExeFilePath = PubGlobal.ExeFilePath_Vip;
            cEmvpbocVip.InDataFilePath = PubGlobal.InFilePath_Vip;
            cEmvpbocVip.OutDataFilePath = PubGlobal.OutFilePath_Vip;

            tbPayList.Text = string.Empty;
            ShowPayInfo();
        }

        /// <summary>
        /// 显示付款信息
        /// </summary>
        private void ShowPayInfo()
        {
            tbYfMoney.Text = PubGlobal.Cur_Sale_YFTotal.ToString("F2");
            tbNowMoney.Text = PubGlobal.Cur_Sale_PayTotal.ToString("F2");
            button_1.Enabled = PubGlobal.Cur_Sale_YETotal >0;
            button_3.Enabled = PubGlobal.Cur_Sale_YETotal <= 0;
        }
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_3_Click(object sender, EventArgs e)
        {
            ShowWait("正保存交易流水...请稍候...");
            #region 保存至服务器
            string msg;
            string ReturnMsg=string.Empty;
            if (!Comm.Comm.RecvPay(PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password,PubGlobal.Cur_tSalSalePayList,"0", ref ReturnMsg, out msg))
            {
                HideWait();
                MessageBox.Show(msg,"错误",MessageBoxButtons.OKCancel,MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                button_3.Enabled = false;
                button_4.Enabled = false;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                //打印小票
                cPrinter1.Init();
                StringBuilder stringBuilder = new StringBuilder();
                int l = PubGlobal.BillHead.Length / 2 + 10 - 4;
                stringBuilder.AppendFormat("{0}{1}\n", new string[] { PubGlobal.BillHead.PadLeft(l), "移动支付小票" });
                stringBuilder.AppendFormat("  流水号：{0}\n", PubGlobal.Cur_tSalSale[0].SALENO);
                if (!string.IsNullOrEmpty(PubGlobal.Cur_tSalSale[0].VIPCARDNO))
                {
                    stringBuilder.AppendFormat("会员卡号：{0}\n", PubGlobal.Cur_tSalSale[0].VIPCARDNO);
                }
                stringBuilder.AppendFormat("交易时间：{0}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                stringBuilder.AppendFormat("============================\n");
                stringBuilder.AppendFormat("应收金额：{0}\n", PubGlobal.Cur_Sale_YFTotal.ToString("F2"));
                stringBuilder.AppendFormat("实收金额：{0}\n", PubGlobal.Cur_Sale_PayTotal.ToString("F2"));

                foreach (Model.TransModel.TSalSalePay pay in PubGlobal.Cur_tSalSalePayList)
                {
                    stringBuilder.AppendFormat("{0}：{1}\n", PubGlobal.sPayTypes.Find(a=>a.PAYCODE==pay.ZFCODE).PAYNAME.PadLeft(8), pay.SSTOTAL);//支付方式
                }

                if (!string.IsNullOrEmpty(PubGlobal.BillFoot1.Trim()))
                {
                    stringBuilder.AppendFormat("{0}\n", PubGlobal.BillFoot1);
                }
                if (!string.IsNullOrEmpty(PubGlobal.BillFoot2.Trim()))
                {
                    stringBuilder.AppendFormat("{0}\n", PubGlobal.BillFoot2);
                }
                if (!string.IsNullOrEmpty(PubGlobal.BillFoot3.Trim()))
                {
                    stringBuilder.AppendFormat("{0}\n", PubGlobal.BillFoot3);
                }
                cPrinter1.Print(stringBuilder.ToString());
                cPrinter1.Feed(6);

                HideWait();
                button_3.Enabled = false;
                button_4.Enabled = false;
                tbPayList.Text = ReturnMsg=="NULL"?string.Empty:ReturnMsg;
                Thread.Sleep(2000);
                this.DialogResult = DialogResult.OK;

            }
            #endregion
        }

        /// <summary>
        /// 关闭交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSalePay_Closing(object sender, CancelEventArgs e)
        {
            PubGlobal.CloseCur_Trade();
            button_4.Enabled = true;
        }

        private void tbPayList_TextChanged(object sender, EventArgs e)
        {
            tbPayList.ScrollToCaret();
        }
    }
}