using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base;
using Model.DBModel;
using DAL;

namespace MobilePayment.JhBill
{
    public partial class FrmJhBillMx : FrmBillMxBase
    {
        List<DBJhBill> jhBill;
        FrmJhPluView frmjhPluView = new FrmJhPluView();
        FrmLocateInput frmLocateInput = new FrmLocateInput();
        public FrmJhBillMx()
        {
            InitializeComponent();
        }

        private void FrmJhBillMx_Load(object sender, EventArgs e)
        {
            ShowWait("正在读取验收单信息\r\n请稍候...");
            string msg;
            if (!JhBillDAL.ListBill(out jhBill, out msg))
            {
                MessageBox.Show("读取验收单错误：" + msg);
                HideWait();
                return;
            }
            HideWait();
            dBJhBillBindingSource.DataSource = jhBill;
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            jhBill.Clear();
            jhBill = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (jhBill.Count == 0)
            {
                return;
            }
            frmjhPluView.JhPlu = jhBill[dgBillMx.CurrentRowIndex];
            frmjhPluView.ShowDialog();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (dgBillMx.CurrentRowIndex >= 0)
            {
                DBJhBill bill = (DBJhBill)dBJhBillBindingSource.Current;
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("是否删除【{0}】{1}", new string[] { bill.Barcode, bill.PluName });
                if (MessageBox.Show(strBuilder.ToString(), "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string msg;
                    if (!JhBillDAL.DeleteBill(bill, out msg))
                    {
                        MessageBox.Show("删除失败：" + msg);
                    }
                    else
                    {
                        jhBill.RemoveAt(jhBill.FindIndex(a => a.ID == bill.ID));
                        dBJhBillBindingSource.ResetBindings(true);
                    }
                }
            }
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (frmLocateInput.ShowDialog() == DialogResult.OK)
            {
                int l = jhBill.FindIndex(a => a.Barcode == frmLocateInput.Value || a.PluCode == frmLocateInput.Value);
                dgBillMx.UnSelect(dgBillMx.CurrentRowIndex);
                if (l >= 0)
                {
                    dgBillMx.Select(l);
                    dgBillMx.CurrentRowIndex = l;
                }
            }
        }
    }
}