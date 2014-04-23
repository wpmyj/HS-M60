using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base;

namespace MobilePayment.CarPay
{
    public partial class FrmCarNoBox : FrmBase
    {
        public Button Value
        {
            get;
            set;
        }

        public FrmCarNoBox()
        {
            InitializeComponent();
            //this.Location =
            //    new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
            //    (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Value = sender as Button;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        protected override void NextStep()
        {
            base.NextStep();
        }
        protected override void PreStep()
        {
            Value = null;
            this.DialogResult = DialogResult.Cancel;
        }

    }
}