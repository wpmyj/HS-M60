using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Devices;
using System.Threading;

namespace MobilePayment
{
    public partial class FrmBankPay : Form
    {
        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal PayTotal
        {
            get;
            set;
        }

        FrmPwdEnter PwdBox = new FrmPwdEnter();

        bool ReadCard = true;//是否读卡，false 表示取消读卡
        public FrmBankPay()
        {
            InitializeComponent();
            this.Location =
                new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);

            CancelCloseDelegate = new CloseDelegate(CancelClose);
            OKCloseDelegate = new CloseDelegate(OKClose);
            showMsgDelegate = new ShowMsgDelegate(ShowMsg);
            showPwdEnterDelegate = new ShowPwdEnterDelegate(ShowPwdEnter);
        }

        private void FrmBankPay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    ReadCard = false;
                    break;
            }
        }



        /// <summary>
        /// 读卡线程
        /// </summary>
        private void ReadCardFun()
        {
            string track1, track2, track3;
            track1 = string.Empty;
            track2 = string.Empty;
            track3 = string.Empty;
            string msg;
            //Mcr_606_Reader.Reset();
            Mcr_606_Reader.Open();
            Mcr_606_Reader.GetAuthor();
            while (ReadCard)
            {
                if (Mcr_606_Reader.Check())
                {
                    //读卡成功
                    if (Mcr_606_Reader.ReadTranck(ref track1, ref track2, ref track3, out msg))
                    {
                        if (string.IsNullOrEmpty(track2))
                        {
                            this.Invoke(CancelCloseDelegate);
                        }
                        PwdBox.CardNo = track2.Substring(0, track2.IndexOf('\0')).Split('=')[0];
                        PwdBox.Total = PayTotal;
                        this.Invoke(showPwdEnterDelegate);//显示密码输入
                        break;
                    }
                    //读卡成功

                    break;
                }
                else
                {
                    Thread.Sleep(200);
                }
            }
            Mcr_606_Reader.Reset();
            Mcr_606_Reader.Close();

            if (!ReadCard)
            {
                //刷卡被取消
                this.Invoke(CancelCloseDelegate);
            }

        }


        #region 关闭窗口委托
        delegate void CloseDelegate();//关闭窗口委托

        CloseDelegate CancelCloseDelegate;
        CloseDelegate OKCloseDelegate;

        /// <summary>
        /// 取消并关闭
        /// </summary>
        private void CancelClose()
        {
            //MessageBox.Show("银行卡支付被取消！");
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 成功并关闭
        /// </summary>
        private void OKClose()
        {
            //MessageBox.Show("支付成功！");
            this.DialogResult = DialogResult.OK;
        }
        #endregion


        #region 显示消息委托
        delegate void ShowMsgDelegate(string msg);
        ShowMsgDelegate showMsgDelegate;
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
        }
        #endregion


        #region 显示密码输入框委托
        delegate void ShowPwdEnterDelegate();
        ShowPwdEnterDelegate showPwdEnterDelegate;
        /// <summary>
        /// 显示密码输入框
        /// </summary>
        private void ShowPwdEnter()
        {     
            if (PwdBox.ShowDialog() == DialogResult.OK)
            {
                this.Invoke(OKCloseDelegate);
            }
            else
            {
                this.Invoke(CancelCloseDelegate);
            }
        }
        #endregion

        private void FrmBankPay_Load(object sender, EventArgs e)
        {
            Thread ReadCardThread = new Thread(ReadCardFun);
            ReadCardThread.IsBackground = true;
            ReadCard = true;
            tbYfMoney.Text = PayTotal.ToString("F2");
            ReadCardThread.Start();//开启读卡线程
        }

        private void FrmBankPay_Closing(object sender, CancelEventArgs e)
        {
            ReadCard = false;
        }
    }
}