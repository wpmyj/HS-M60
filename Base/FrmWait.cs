using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;

namespace Base
{
    public partial class FrmWait : Form
    {
        /// <summary>
        /// 显示的消息
        /// </summary>
        public string Msg
        {
            get;
            set;
        }

        public FrmWait()
        {
            InitializeComponent();
            this.Height = 50;
            this.Width = 200;
            this.Location =
                new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void FrmWait_Activated(object sender, EventArgs e)
        {
            label1.Text = Msg;
        }

     
    }
}