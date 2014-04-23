using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment.Report
{
    /// <summary>
    /// 收款员报表
    /// </summary>
    public partial class FrmCasherRpt : FrmBase
    {
        public FrmCasherRpt()
        {
            InitializeComponent();
            bindingSource1.DataSource = PubGlobal.CashRpt;
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmCasherRpt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    button_4_Click(null, null);
                    break;
            }
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Operator='{0}' And XsDate>='{1}' And XsDate<='{2}'",
                new string []{ PubGlobal.Cur_User.UserCode,
                    DtPStart.Value.ToString("yyyy-MM-dd"),
                    DtPEnd.Value.ToString("yyyy-MM-dd")});
            string msg;
            if (!DAL.DAL.CashRptDAL.GetCashRpt(stringBuilder.ToString(), ref PubGlobal.CashRpt, out msg))
            {
                MessageBox.Show(msg);
            }
            bindingSource1.ResetBindings(true);
        }

        private void FrmCasherRpt_Closing(object sender, CancelEventArgs e)
        {
            PubGlobal.CashRpt.Clear();
        }
    }
}