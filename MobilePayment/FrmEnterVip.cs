using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace MobilePayment
{
    public partial class FrmEnterVip : Form
    {
        public string VipNo
        {
            get;
            set;
        }

        public FrmEnterVip()
        {
            InitializeComponent();
            this.Location =
                new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);

            CancelCloseDelegate = new CloseDelegate(CancelClose);
            OKCloseDelegate = new CloseDelegate(OKClose);
            showMsgDelegate = new ShowMsgDelegate(ShowMsg);
        }

        private void FrmEnterVip_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (!string.IsNullOrEmpty(TxbVipNo.Text.Trim()))
                    {
                        VipNo = TxbVipNo.Text.Trim();
                        OKClose();
                    }
                    break;
                case Keys.Escape:
                    break;
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
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 成功并关闭
        /// </summary>
        private void OKClose()
        {
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


        private void FrmEnterVip_Load(object sender, EventArgs e)
        {
            VipNo = string.Empty;
            TxbVipNo.Focus();
        }
    }
}