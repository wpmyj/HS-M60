using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Comm;
using Pub;
using Base;
namespace MobilePayment
{
    public partial class FrmLogin : FrmBase
    {
        private const int MAX_LOGIN_COUNT = 3;

        public FrmLogin()
        {
            InitializeComponent();
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            PubGlobal.SetFullScreen(true, ref rectangle);//false为恢复状态栏
            this.Location =
                new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            Cursor.Hide();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            tbUCode.Focus();
            tbUCode.SelectAll();
        }

        protected override void NextStep()
        {
            if (tbUCode.Focused)
            {
                tbUPassword.Focus();
                tbUPassword.SelectAll();
                return;
            }
            if (tbUPassword.Focused)
            {
                button_4_Click(null,null);
                return;
            }
        }

        protected override void PreStep()
        {
            tbUCode.Text = string.Empty;
            tbUPassword.Text = string.Empty;
            tbUCode.Focus();
        }
        private void button_4_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(tbUCode.Text))
            {
                MessageBox.Show("编码不能为空！");
                return;
            }

            if (tbUCode.Text == "999" && tbUPassword.Text == "999")
            {
                //退出程序
                this.DialogResult = DialogResult.Cancel;

                return;
            }
            string msg;
            ShowWait("正在登陆...请稍候...");
            if (Comm.Comm.Logon(PubGlobal.OrgCode,tbUCode.Text,Hash.Hasher( tbUPassword.Text),ref PubGlobal.User, out msg))
            {
                HideWait();
                tbUPassword.Text = string.Empty;
                if (PubGlobal.User == null)
                {
                    MessageBox.Show("用户名或密码错误！");
                    return;
                }
                this.DialogResult = DialogResult.OK;
                return;
            }
            else
            {
                HideWait();
                MessageBox.Show(msg);
                //// Wrong username or password
                //nLoginCount++;

                //if (nLoginCount == MAX_LOGIN_COUNT)
                //// Over 3 times
                //{
                //    MessageBox.Show("登陆超过3次，不能再次登陆!");
                //    this.Enabled = false;
                //}
                //else
                //{
                tbUCode.Focus();
                tbUCode.SelectAll();
                //}
            }
        }
    }
}