using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Devices;

namespace MobilePayment.ParkCarPay
{
    public partial class FrmCarPay : FrmBase
    {

        #region 定义窗口
        Frm_hs.FrmPayType PayTypeBox = new Frm_hs.FrmPayType();
        Frm_hs.FrmEnterBox EnterBox = new Frm_hs.FrmEnterBox();
        FrmBankPay BankPayBox = new FrmBankPay();
        #endregion

        public FrmCarPay()
        {
            InitializeComponent();
        }

        //protected  void NextStep()
        //{
        //    base.NextStep();
        //}

        protected  void PreStep()
        {
            button4_Click(null, null);
        }

        private void FrmPay_Load(object sender, EventArgs e)
        {
            PayTypeBox.Init();
            PubGlobal_hs.Cur_tCarParkPay = new Model_hs.TCarParkPay();
            PubGlobal_hs.Cur_tCarParkPay.ID = PubGlobal_hs.Cur_tCarParkCharge.ID;
            PubGlobal_hs.Cur_tCarParkPay.LISENCE = PubGlobal_hs.Cur_License;
            PubGlobal_hs.Cur_tCarParkPay.FEEYSJE = PubGlobal_hs.Cur_tCarParkCharge.CHARGE;
            serialno = 1;
            PubGlobal_hs.Cur_tSalSalePayList = new List<Model_hs.TSalSalePay>();
            ShowPayInfo();
            tbPayList.Text = string.Empty;

        }

        /// <summary>
        /// 显示付款信息
        /// </summary>
        private void ShowPayInfo()
        {
            tbYfMoney.Text = PubGlobal_hs.Cur_Car_YFTotal.ToString("f2");
            tbYEMoney.Text = PubGlobal_hs.Cur_Car_YeTotal < 0 ? "0.00" : PubGlobal_hs.Cur_Car_YeTotal.ToString("F2");
            tbMdModey.Text = PubGlobal_hs.Cur_Car_MdTotal.ToString("f2");
            TxbJf.Text = PubGlobal_hs.Cur_Car_JfTotal.ToString();
            TxbQuan.Text = PubGlobal_hs.Cur_Car_QuanTotal.ToString();
            button_1.Enabled = PubGlobal_hs.Cur_Car_YeTotal > 0;
            button_2.Enabled = PubGlobal_hs.Cur_Car_YeTotal > 0;
            button_3.Enabled = PubGlobal_hs.Cur_Car_YeTotal <= 0;
        }
        /// <summary>
        /// +积分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (PubGlobal_hs.Cur_Car_JfTotal + 1 > decimal.Parse(PubGlobal_hs.Cur_tCarParkCharge.VipParkPoints))
            {
                return;
            }
            if (PubGlobal_hs.Cur_Car_YeTotal > PubGlobal_hs.Cur_Car_JfRate)
            {
                PubGlobal_hs.Cur_Car_JfTotal++;
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
            if (PubGlobal_hs.Cur_Car_JfTotal > 0)
            {
                PubGlobal_hs.Cur_Car_JfTotal--;
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
            if (PubGlobal_hs.Cur_Car_YeTotal >= PubGlobal_hs.Cur_Car_QuanRate)
            {
                PubGlobal_hs.Cur_Car_QuanTotal++;
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
            if (PubGlobal_hs.Cur_Car_QuanTotal > 0)
            {
                PubGlobal_hs.Cur_Car_QuanTotal--;
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
            string ReturnMsg, msg;
            ShowWait();
            if (!Comm.Comm.RecvParkPayFunc(PubGlobal_hs.Cur_License, PubGlobal_hs.MobileIp, PubGlobal_hs.OrgCode, PubGlobal_hs.User.UserCode, PubGlobal_hs.User.USERNAME,
                 PubGlobal_hs.User.Password, PubGlobal_hs.Cur_tCarParkPay, PubGlobal_hs.Cur_tSalSalePayList, out ReturnMsg, out msg))
            {
                HideWait();
                MessageBox.Show(msg); ;
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
        }

        /// <summary>
        /// 返回
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        int serialno = 1;
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_1_Click(object sender, EventArgs e)
        {
            if (PayTypeBox.ShowDialog() == DialogResult.OK)
            {

                //选定付款方式
                Model_hs.TSalSalePay tSalSalePay = new Model_hs.TSalSalePay();
                tSalSalePay.ZFCODE = PayTypeBox.PayType.PAYCODE;
                tSalSalePay.ZfName = PayTypeBox.PayType.PAYNAME;
                if (PayTypeBox.PayType.PAYTYPE == "2")
                {
                    //银行卡
                    BankPayBox.PayTotal = PubGlobal_hs.Cur_Car_YeTotal;
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
                //tSalSalePay.SALENO = PubGlobal_hs.Cur_tSalSale.SALENO;
                tSalSalePay.SERIALNO = (serialno++).ToString();
                tSalSalePay.ORGCODE = PubGlobal_hs.OrgCode;
                PubGlobal_hs.Cur_tSalSalePayList.Add(tSalSalePay);//输入完毕，加入付款流水
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("{0}-【{1}】  {2}元 \r\n", new string[] { tSalSalePay.SERIALNO, PayTypeBox.PayType.PAYNAME, decimal.Parse(tSalSalePay.ZFTOTAL).ToString("F2") });
                tbPayList.Text += strBuilder.ToString();
                strBuilder.Remove(0, strBuilder.Length);
                PubGlobal_hs.Cur_TradeSucess = PubGlobal_hs.Cur_Car_YeTotal-decimal.Parse(tSalSalePay.ZFTOTAL) <= 0;
                if (PubGlobal_hs.Cur_TradeSucess)
                {
                    decimal charge;
                    if (PayTypeBox.PayType.ISCHANGE == "1")
                    {
                        charge =decimal.Parse(tSalSalePay.ZFTOTAL)- PubGlobal_hs.Cur_Car_YeTotal;//找零金额
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
                PubGlobal_hs.Cur_Car_PayTotal += decimal.Parse(tSalSalePay.SSTOTAL);
                ShowPayInfo();

                if (PubGlobal_hs.Cur_TradeSucess)
                {
                    #region 打印小票
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append("海信M60手持设备演示小票\n");
                    stringBuilder.Append("——停车场支付功能\n");
                    stringBuilder.AppendFormat("收款人：{0}-{1}\n", new string[] { PubGlobal_hs.User.UserCode, PubGlobal_hs.User.USERNAME });
                    stringBuilder.AppendFormat("收款时间：{0}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    if (!string.IsNullOrEmpty(PubGlobal_hs.Cur_tCarParkCharge.VIPNO))
                    {
                        stringBuilder.AppendFormat("会员卡号:{0}\n", PubGlobal_hs.Cur_tCarParkCharge.VIPNO);
                    }
                    stringBuilder.Append("******************************\n");
                    stringBuilder.AppendFormat("车号：{0}\n", PubGlobal_hs.Cur_tCarParkPay.LISENCE);
                    stringBuilder.AppendFormat("出场时间：{0}\n", PubGlobal_hs.Cur_tCarParkCharge.OUTTIME);
                    stringBuilder.AppendFormat("停车时长：{0}小时\n",PubGlobal_hs.Cur_tCarParkCharge.HOUR);
                    stringBuilder.AppendFormat("应付金额：{0}元\n", PubGlobal_hs.Cur_tCarParkCharge.CHARGE);
                    Printer.Feed(3);
                    stringBuilder.AppendFormat("免单金额：{0}元\n", string.IsNullOrEmpty(PubGlobal_hs.Cur_tCarParkPay.FEEMDJE)?"0":PubGlobal_hs.Cur_tCarParkPay.FEEMDJE);
                    stringBuilder.AppendFormat("  停车券：{0}\n", string.IsNullOrEmpty(PubGlobal_hs.Cur_tCarParkPay.FEEHOU)?"0":PubGlobal_hs.Cur_tCarParkPay.FEEHOU);
                    stringBuilder.AppendFormat("停车积分：{0}\n", string.IsNullOrEmpty(PubGlobal_hs.Cur_tCarParkPay.FEECOST)?"0":PubGlobal_hs.Cur_tCarParkPay.FEECOST);
                    stringBuilder.AppendFormat("实付金额：{0}元\n", PubGlobal_hs.Cur_tCarParkPay.FEESSJE);
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
                }
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
                    MianDan(PubGlobal_hs.Cur_Car_YeTotal);
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
                    break;
            }
        }

        /// <summary>
        /// 免单
        /// </summary>
        /// <param name="MdMoney"></param>
        /// <returns></returns>
        private void MianDan(decimal MdMoney)
        {
            if (MdMoney > PubGlobal_hs.Cur_Car_YeTotal)
            {
                //免单金额大于余额，免单失败
                MessageBox.Show("免单金额过大！");
            }
            else
            {
                PubGlobal_hs.Cur_Car_MdTotal = MdMoney;
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
            PubGlobal_hs.CloseCur_Trade();
            button_4.Enabled = true;
        }

        private void tbPayList_TextChanged(object sender, EventArgs e)
        {
            tbPayList.SelectionStart = tbPayList.Text.Length;
            tbPayList.ScrollToCaret();
        }

        private void FrmCarPay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    button_4_Click(null, null);
                    break;
            }
        }
    }
}