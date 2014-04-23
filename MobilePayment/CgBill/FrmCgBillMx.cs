using System;
using System.Data;
using System.Windows.Forms;
using Model.DBModel;
using DAL;
using System.Collections;
using System.Collections.Generic;
using Base;
using System.Text;

namespace MobilePayment.CgBill
{
    public partial class FrmCgBillMx : Base.FrmBillMxBase
    {
        List<DBCgBill> cgBill ;
        FrmCgPluView frmCgPluView = new FrmCgPluView();
        FrmLocateInput frmLocateInput = new FrmLocateInput();
        public FrmCgBillMx()
        {
            InitializeComponent();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (cgBill.Count==0)
            {
                return;
            }
            frmCgPluView.cgPlu = cgBill[dgBillMx.CurrentRowIndex];
            frmCgPluView.ShowDialog();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (frmLocateInput.ShowDialog() == DialogResult.OK)
            {
                int l = cgBill.FindIndex(a=>a.Barcode==frmLocateInput.Value|| a.PluCode==frmLocateInput.Value);
                dgBillMx.UnSelect(dgBillMx.CurrentRowIndex);
                if (l >= 0)
                {
                    dgBillMx.Select(l);
                    dgBillMx.CurrentRowIndex = l;
                }
            }
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (dgBillMx.CurrentRowIndex >= 0)
            {
                DBCgBill bill = (DBCgBill)cgBillBindingSource.Current;
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("是否删除【{0}】{1}", new string[] { bill.Barcode, bill.PluName });
                if (MessageBox.Show(strBuilder.ToString(),"确认",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string msg;
                    if (!CgBillDAL.DeleteBill(bill, out msg))
                    {
                        MessageBox.Show("删除失败：" + msg);
                    }
                    else
                    {
                        cgBill.RemoveAt(cgBill.FindIndex(a => a.ID == bill.ID));
                        cgBillBindingSource.ResetBindings(true);
                    }
                }
            }
        }

        private void FrmCgBill_Load(object sender, EventArgs e)
        {
            ShowWait("正在读取采购明细...\r\n请稍候...");
            string msg;
            if (!CgBillDAL.ListBill(out cgBill, out msg))
            {
                MessageBox.Show("查询采购单明细失败：" + msg);
                HideWait();
                return;
            }
            HideWait();
            cgBillBindingSource.DataSource = cgBill;
        }
    }
}