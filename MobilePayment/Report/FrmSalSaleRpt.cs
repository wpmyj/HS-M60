using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment.Report
{
    public partial class FrmSalSaleRpt : FrmBase
    {
        public FrmSalSaleRpt()
        {
            InitializeComponent();
            bindingSource1.DataSource = PubGlobal.SalSaleRpt;
        }

        FrmSalLocation locationWin = new FrmSalLocation();
        FrmSalDetail detailWin = new FrmSalDetail();

        private void button_4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        DataTable SalSaleDt=new DataTable();
        private void button_1_Click(object sender, EventArgs e)
        {
            string msg;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("Operator='{2}' and XsDate>='{0}' and XsDate<='{1}'",
                new string[] { DtPStart.Value.ToString("yyyy-MM-dd"), DtPEnd.Value.ToString("yyyy-MM-dd"), PubGlobal.Cur_User.UserCode });
            if (!DAL.DAL.SalSaleDAL.GetSalSale(stringBuilder.ToString(), ref PubGlobal.SalSaleRpt, out msg))
            {
                MessageBox.Show(msg);
            }

            bindingSource1.ResetBindings(true);
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (locationWin.ShowDialog() == DialogResult.OK)
            {
                int i = PubGlobal.SalSaleRpt.FindIndex(a => 
                    (string.IsNullOrEmpty(locationWin.FlowNo) ? true : (a.SaleNo == locationWin.FlowNo))
                    && (string.IsNullOrEmpty(locationWin.Operator)?true:(a.Operator==locationWin.Operator))
                    && (string.IsNullOrEmpty(locationWin.VipCardno)?true:(a.VipCardno==locationWin.VipCardno)));

                dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
                dataGrid1.Select(i);
                dataGrid1.CurrentRowIndex = i;
            }
        }

        private void FrmSalSaleRpt_Closing(object sender, CancelEventArgs e)
        {
            PubGlobal.SalSaleRpt.Clear();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (bindingSource1.Current != null)
            {
                detailWin.SalSale = ((Model.TSalSale)bindingSource1.Current);
                detailWin.ShowDialog();
            }
        }

        private void FrmSalSaleRpt_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                case Keys.F1://上:
                    PreSalePlu();
                    break;
                case Keys.F2://下
                    NextSalePlu();
                    break;
            }
        }

        /// <summary>
        /// 上一条
        /// </summary>
        private void PreSalePlu()
        {
            int rowNo = dataGrid1.CurrentRowIndex - 1;
            if (rowNo >= 0)
            {
                dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
                dataGrid1.Select(rowNo);
                dataGrid1.CurrentRowIndex = rowNo;
            }

        }
        /// <summary>
        /// 下一条
        /// </summary>
        private void NextSalePlu()
        {
            int rowNo = dataGrid1.CurrentRowIndex + 1;
            if (rowNo < PubGlobal.SalSaleRpt.Count)
            {
                dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
                dataGrid1.Select(rowNo);
                dataGrid1.CurrentRowIndex = rowNo;
            }
        }
    }
}