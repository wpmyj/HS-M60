using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace MobilePayment
{
    public partial class FrmLogin : FrmBase
    {
        private const int MAX_LOGIN_COUNT = 3;
        public FrmLogin()
        {
            InitializeComponent();
            this.Location =
                new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
            Cursor.Hide();
        }

        
        
        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    tbUCode.Text = string.Empty;
                    tbUPassword.Text = string.Empty;
                    tbUCode.Focus();
                    break;
                case Keys.Enter:
                    NextStep();
                    break;
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            tbUPassword.Text = string.Empty;
            tbUCode.Focus();
            tbUCode.SelectAll();
        }

        private void NextStep()
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
            string msg  ;
            ShowWait();
            if (Comm.Comm.Logon(tbUCode.Text.Trim(),tbUPassword.Text,out PubGlobal.Cur_User,out msg))
            {                
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(msg);
            }
            HideWait();
        }
    }
}