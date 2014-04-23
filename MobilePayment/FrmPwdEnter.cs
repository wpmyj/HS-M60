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
    public partial class FrmPwdEnter : Form
    {
        /// <summary>
        /// 卡号
        /// </summary>
        public string CardNo
        {
            get;
            set;
        }

        /// <summary>
        /// 金额
        /// </summary>
        public decimal Total
        {
            get;
            set;
        }

        public FrmPwdEnter()
        {
            InitializeComponent();
            this.Location =
               new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
               (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void FrmPwdEnter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    this.Text = "正在通讯...";
                    Application.DoEvents();
                    Thread.Sleep(2000);
                    DialogResult = DialogResult.OK;
                    break;
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void FrmPwdEnter_Activated(object sender, EventArgs e)
        {
            tbTotal.Text = Total.ToString("F2");
            tbCardNo.Text = CardNo.ToString();
            tbPassword.Text = string.Empty;
            tbPassword.Focus();
            tbPassword.SelectAll();
        }
    }
}