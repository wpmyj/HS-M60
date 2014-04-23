using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment.ParkCarPay
{
    public partial class FrmCarNoBox : FrmBase
    {
        public string Value
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
            Value = (sender as Button).Text.Trim();
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        //protected override void NextStep()
        //{
        //    base.NextStep();
        //}
        protected  void PreStep()
        {
            Value = string.Empty;
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmCarNoBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

    }
}