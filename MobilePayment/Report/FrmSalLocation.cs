using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment.Report
{
    public partial class FrmSalLocation : Form
    {
        public string FlowNo
        {
            get;
            set;
        }

        public string Operator
        {
            get;
            set;
        }

        public string VipCardno
        {
            get;
            set;
        }

        public FrmSalLocation()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            FlowNo = TxbFlowNo.Text;
            Operator = TxbOperator.Text;
            VipCardno = TxbVipCardno.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void FrmSalDetaiLocation_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (TxbFlowNo.Focused)
                    {
                        TxbOperator.Focus();
                    }
                    else if (TxbOperator.Focused)
                    {
                        TxbVipCardno.Focus();
                    }
                    else if (TxbVipCardno.Focus())
                    {
                        button1.Focus();
                    }
                    break;

                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void FrmSalDetaiLocation_Load(object sender, EventArgs e)
        {
            TxbFlowNo.Text = string.Empty;
            TxbOperator.Text = string.Empty;
            TxbVipCardno.Text = string.Empty;
            TxbFlowNo.Focus();
            TxbFlowNo.SelectAll();
        }
    }
}