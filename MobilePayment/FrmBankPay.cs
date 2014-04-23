using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
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
            tbYfMoney.Text = PayTotal.ToString("F2");
        }
    }
}