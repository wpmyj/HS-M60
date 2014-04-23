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
using Pub;

namespace MobilePayment.PdBill
{
    public partial class FrmPdBillMx : FrmBillMxBase
    {
        private FrmLocateInput frmLocateInput=new FrmLocateInput();
        private FrmPdPluView frmPdPluView=new FrmPdPluView();
        private List<DBPdData> pdDatas;

        public FrmPdBillMx()
        {
            InitializeComponent();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (frmLocateInput.ShowDialog() == DialogResult.OK)
            {
                int l = pdDatas.FindIndex(a => a.Barcode == frmLocateInput.Value || a.PluCode == frmLocateInput.Value);
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
                DBPdData pdData = (DBPdData)dBPdDataBindingSource.Current;
                StringBuilder strBuilder = new StringBuilder();
                strBuilder.AppendFormat("是否删除【{0}】{1}", new string[] { pdData.Barcode, pdData.PluName });
                if (MessageBox.Show(strBuilder.ToString(), "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    string msg;
                    if (!PdDataDAL.DeletePdData(pdData, out msg))
                    {
                        MessageBox.Show("删除失败：" + msg);
                    }
                    else
                    {
                        pdDatas.RemoveAt(pdDatas.FindIndex(a => a.ID == pdData.ID));
                        dBPdDataBindingSource.ResetBindings(true);
                    }
                }
            }

        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (pdDatas.Count == 0)
            {
                return;
            }
            frmPdPluView.PdPlu = pdDatas[dgBillMx.CurrentRowIndex];
            frmPdPluView.ShowDialog();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            pdDatas.Clear();
            pdDatas = null;
            DialogResult = DialogResult.Cancel;
        }

        private void FrmPdBillMx_Load(object sender, EventArgs e)
        {
            string str;
            ShowWait("正在读取盘点单信息\r\n请稍候...");
            this.tbPdDate.Text = PubGlobal.PdDataInfo.PdDate.ToString("yyyy-MM-dd");
            this.tbCkCode.Text = PubGlobal.PdDataInfo.CkCode;
            if (!PdDataDAL.ListPdData(out this.pdDatas, out str))
            {
                MessageBox.Show("读取盘点单错误：" + str);
                HideWait();
            }
            else
            {
                HideWait();
                this.dBPdDataBindingSource.DataSource = this.pdDatas;
            }

        }
    }
}