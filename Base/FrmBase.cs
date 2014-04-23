using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pub;

namespace Base
{
    public partial class FrmBase : Form
    {
        public FrmBase()
        {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            //Cursor.Hide();
        }

        /// <summary>
        /// 显示状态栏
        /// </summary>
        private void SetStatusBar()
        {
            StringBuilder StrBuilder = new StringBuilder();
            if (PubGlobal.User != null)
            {
                StrBuilder.AppendFormat("操作员：{0}-{1}   时间：{2} ", new string[] { PubGlobal.User.UserCode, PubGlobal.User.USERNAME, DateTime.Now.ToString("HH:mm:ss") });
            }
            this.statusBar1.Text = StrBuilder.ToString();
        }


        #region 显示等待提示窗口
        public static FrmWait waitForm = new FrmWait();
        /// <summary>
        /// 显示等待提示窗口
        /// </summary>
        public void ShowWait()
        {
            waitForm.Msg = "请稍候...";
            waitForm.Show();
            Application.DoEvents();
        }

        /// <summary>
        /// 显示等待提示窗口
        /// </summary>
        /// <param name="msg">提示信息</param>
        public void ShowWait(string msg)
        {
            waitForm.Msg = msg;
            waitForm.Show();
            Application.DoEvents();
        }
        /// <summary>
        /// 关闭等待提示窗口
        /// </summary>
        public void HideWait()
        {
            waitForm.Hide();
            this.Focus();
            Application.DoEvents();
        }
        /// <summary>
        /// 显示等待光标
        /// </summary>
        public void ShowWaitCursor()
        {
            Cursor.Current = Cursors.WaitCursor;
            Cursor.Show();
            this.Enabled = false;
        }
        /// <summary>
        /// 隐藏等待光标
        /// </summary>
        public void HideWaitCursor()
        {
            Cursor.Current = Cursors.Default;
            Cursor.Hide();
            this.Enabled = true;
        }
        #endregion

        /// <summary>
        /// 下一步操作
        /// </summary>
        protected virtual void NextStep()
        {

        }
        /// <summary>
        /// 上一步
        /// </summary>
        protected virtual void PreStep()
        {
        }

        private void FrmBase_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;//启动计时器
            //Cursor.Hide();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            SetStatusBar();
        }

        private void FrmBase_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    NextStep();
                    break;
                case Keys.Escape:
                    PreStep();
                    break;
            }
        }

    }
}