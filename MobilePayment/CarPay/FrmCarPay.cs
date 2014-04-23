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

namespace MobilePayment.CarPay
{
    public partial class FrmCarPay : FrmBase
    {

        #region 定义窗口
        FrmPayType PayTypeBox = new FrmPayType();
        FrmMoneyInput EnterBox = new FrmMoneyInput();
        #endregion

        public FrmCarPay()
        {
            InitializeComponent();
        }

        protected override void NextStep()
        {
            base.NextStep();
        }

        protected override void PreStep()
        {
            button4_Click(null, null);
        }

        private void FrmPay_Load(object sender, EventArgs e)
        {
            PayTypeBox.Init();
            PubGlobal.Cur_tCarParkPay = new TCarParkPay();
            PubGlobal.Cur_tCarParkPay.ID = PubGlobal.Cur_tCarParkCharge[0].ID;
            PubGlobal.Cur_tCarParkPay.LISENCE = PubGlobal.Cur_License;
            PubGlobal.Cur_tCarParkPay.FEEYSJE = PubGlobal.Cur_tCarParkCharge[0].CHARGE;
            PubGlobal.Cur_tCarParkPay.VIPNO = PubGlobal.Cur_tCarParkCharge[0].VIPNO=="NULL"?"":PubGlobal.Cur_tCarParkCharge[0].VIPNO;
            serialno = 1;
            PubGlobal.Cur_tSalSalePayList = new List<TSalSalePay>();
            ShowPayInfo();
            tbPayList.Text = "停车积分余额："+PubGlobal.Cur_tCarParkCharge[0].JFYE+"\r\n";

        }

        /// <summary>
        /// 显示付款信息
        /// </summary>
        private void ShowPayInfo()
        {
            tbYfMoney.Text = PubGlobal.Cur_Car_YFTotal.ToString("f2");
            tbYEMoney.Text = PubGlobal.Cur_Car_YeTotal < 0 ? "0.00" : PubGlobal.Cur_Car_YeTotal.ToString("F2");
            tbMdModey.Text = PubGlobal.Cur_Car_MdTotal.ToString("f2");
            TxbJf.Text = PubGlobal.Cur_Car_JfTotal.ToString();
            TxbQuan.Text = PubGlobal.Cur_Car_QuanTotal.ToString();
            button_1.Enabled = PubGlobal.Cur_Car_YeTotal > 0;
            button_2.Enabled = PubGlobal.Cur_Car_YeTotal > 0;
            button_3.Enabled = PubGlobal.Cur_Car_YeTotal <= 0;
        }
        /// <summary>
        /// +积分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_Car_JfTotal+Convert.ToDecimal(0.5)> PubGlobal.Cur_Car_JfYe)
            {
                return;
            }
            if (PubGlobal.Cur_Car_YeTotal > PubGlobal.Cur_Car_JfRate)
            {
                PubGlobal.Cur_Car_JfTotal = PubGlobal.Cur_Car_JfTotal+Convert.ToDecimal(0.5);
                ShowPayInfo();
            }

        }

        /// <summary>
        /// -积分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_Car_JfTotal > 0)
            {
                PubGlobal.Cur_Car_JfTotal = PubGlobal.Cur_Car_JfTotal-Convert.ToDecimal(0.5);
                ShowPayInfo();
            }
        }

        /// <summary>
        /// +券
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_Car_YeTotal >= PubGlobal.Cur_Car_QuanRate)
            {
                PubGlobal.Cur_Car_QuanTotal++;
                ShowPayInfo();
            }

        }

        /// <summary>
        /// -券
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_Car_QuanTotal > 0)
            {
                PubGlobal.Cur_Car_QuanTotal--;
                ShowPayInfo();
            }
        }

        /// <summary>
        /// 完成交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_3_Click(object sender, EventArgs e)
        {
            string ReturnMsg=string.Empty, msg;
            ShowWait("正保存交易流水...请稍候...");
            if (!Comm.Comm.RecvParkPayFunc(PubGlobal.Cur_License, PubGlobal.MobileIp, PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.USERNAME,
                 PubGlobal.User.Password, PubGlobal.Cur_tCarParkPay, PubGlobal.Cur_tSalSalePayList, ref ReturnMsg, out msg))
            {
                HideWait();
                tbPayList.Text = msg;
            }
            else
            {
                //打印小票
                cPrinter1.Init();
                StringBuilder stringBuilder = new StringBuilder();
                int l = PubGlobal.BillHead.Length / 2 + 15 - 4;
                stringBuilder.AppendFormat("{0}{1}\n", new string[] { PubGlobal.BillHead.PadLeft(l), "停车付款小票" });
                stringBuilder.AppendFormat("    车号：{0}\n", PubGlobal.Cur_License);
                stringBuilder.AppendFormat("提车时间：{0}\n", PubGlobal.Cur_tCarParkCharge[0].OUTTIME);
                stringBuilder.AppendFormat("    时长：{0}\n", PubGlobal.Cur_tCarParkCharge[0].HOUR);
                stringBuilder.AppendFormat("============================\n");

                stringBuilder.AppendFormat("应收金额：{0}\n", PubGlobal.Cur_tCarParkPay.FEEYSJE);
                stringBuilder.AppendFormat("实收金额：{0}\n", PubGlobal.Cur_tCarParkPay.FEESSJE);
                stringBuilder.AppendFormat("免单金额：{0}\n", PubGlobal.Cur_tCarParkPay.FEEMDJE);
                stringBuilder.AppendFormat("使用积分：{0}\n", PubGlobal.Cur_tCarParkPay.FEECOST);
                stringBuilder.AppendFormat("  停车券：{0}\n", PubGlobal.Cur_tCarParkPay.FEEHOU);
                foreach (Model.TransModel.TSalSalePay pay in PubGlobal.Cur_tSalSalePayList)
                {
                    stringBuilder.AppendFormat("{0}：{1}\n", PubGlobal.sPayTypes.Find(a => a.PAYCODE == pay.ZFCODE).PAYNAME, pay.ZFTOTAL);//支付方式
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
                tbPayList.Text = ReturnMsg;
                Thread.Sleep(2000);
                this.DialogResult = DialogResult.OK;
            }
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        int serialno = 1;
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_1_Click(object sender, EventArgs e)
        {
            string msg;
            string refNo;
            decimal SsMoney = 0;
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
                //tSalSalePay.SALENO = PubGlobal.Cur_tSalSale.SALENO;
                tSalSalePay.SERIALNO = (serialno++).ToString();
                tSalSalePay.ORGCODE = PubGlobal.OrgCode;
                PubGlobal.Cur_tSalSalePayList.Add(tSalSalePay);//输入完毕，加入付款流水
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("{0}-【{1}】  {2}元 \r\n", new string[] { tSalSalePay.SERIALNO, PayTypeBox.PayType.PAYNAME, decimal.Parse(tSalSalePay.ZFTOTAL).ToString("F2") });
                tbPayList.Text += strBuilder.ToString();
                strBuilder.Remove(0, strBuilder.Length);
                PubGlobal.Cur_TradeSucess = PubGlobal.Cur_Car_YeTotal-decimal.Parse(tSalSalePay.ZFTOTAL) <= 0;
                if (PubGlobal.Cur_TradeSucess)
                {
                    decimal charge;
                    if (PayTypeBox.PayType.ISCHANGE == "1")
                    {
                        charge =decimal.Parse(tSalSalePay.ZFTOTAL)- PubGlobal.Cur_Car_YeTotal;//找零金额
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
                PubGlobal.Cur_Car_PayTotal += decimal.Parse(tSalSalePay.SSTOTAL);
                ShowPayInfo();
            }
        }

        /// <summary>
        /// 全免
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_2_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("点击【是】免余额。\r\n点击【否】手动输入金额。", "是否全免余额？", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
            {
                case DialogResult.Yes:
                    //免余额
                    MianDan(PubGlobal.Cur_Car_YeTotal);
                    break;
                case DialogResult.No:
                    if (EnterBox.ShowDialog() == DialogResult.OK)
                    {
                        MianDan(decimal.Parse(EnterBox.Value));
                    }
                    //免指定金额
                    break;
                case DialogResult.Cancel:
                    //取消
                    return;
            }
        }

        /// <summary>
        /// 免单
        /// </summary>
        /// <param name="MdMoney"></param>
        /// <returns></returns>
        private void MianDan(decimal MdMoney)
        {
            if (MdMoney > PubGlobal.Cur_Car_YeTotal)
            {
                //免单金额大于余额，免单失败
                MessageBox.Show("免单金额过大！");
            }
            else
            {
                PubGlobal.Cur_Car_MdTotal = MdMoney;
                ShowPayInfo();
            }
        }

        /// <summary>
        /// 关闭交易
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCarPay_Closing(object sender, CancelEventArgs e)
        {
            PubGlobal.CloseCur_Trade();
            button_4.Enabled = true;
        }

        private void tbPayList_TextChanged(object sender, EventArgs e)
        {
            tbPayList.SelectionStart = tbPayList.Text.Length;
            tbPayList.ScrollToCaret();
        }
    }
}