using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment.Report
{
    public partial class FrmSalDetail : FrmBase
    {
        public FrmSalDetail()
        {
            InitializeComponent();
            bindingSource1.DataSource = PubGlobal.SalSalePluRpt;
            bindingSource2.DataSource = PubGlobal.SalSalePayRpt;
        }

        /// <summary>
        /// 流水号
        /// </summary>
        public Model.TSalSale SalSale
        {
            get;
            set;
        }

        private void FrmSalDetail_Load(object sender, EventArgs e)
        {
            StringBuilder stringBuilder=new StringBuilder();
            string msg;
            stringBuilder.AppendFormat("SaleNo='{0}'", SalSale.SaleNo);
            if (!DAL.DAL.SalSalePayDAL.GetSalSalePay(stringBuilder.ToString(), ref PubGlobal.SalSalePayRpt, out msg))
            {
                MessageBox.Show(msg);
            }
            if (!DAL.DAL.SalSalePluDAL.GetSalSalePlu(stringBuilder.ToString(), ref PubGlobal.SalSalePluRpt, out msg))
            {
                MessageBox.Show(msg);
            }
            bindingSource1.ResetBindings(true);
            bindingSource2.ResetBindings(true);
            TxbYfTotal.Text = SalSale.YsTotal.ToString("F2");
            TxbSsTotal.Text = SalSale.SsTotal.ToString("F2");
            TxbYhTotal.Text = SalSale.YhTotal.ToString("F2");
            TxbDsc.Text = SalSale.VipDsc.ToString();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmSalDetail_Closing(object sender, CancelEventArgs e)
        {
            PubGlobal.SalSalePayRpt.Clear();
            PubGlobal.SalSalePluRpt.Clear();
        }

        private void FrmSalDetail_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
            }
        }
    }
}