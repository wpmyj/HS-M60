using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base;
using DAL;
using Model.TransModel;
using Model.DBModel;
using Pub;

namespace MobilePayment.CgBill
{
    public partial class FrmCgBillSend : FrmBillSendBase
    {
        List<DBCgBill> cgBill;
        FrmCgPluView frmCgPluView = new FrmCgPluView();
        FrmLocateInput frmLocateInput = new FrmLocateInput();

        public FrmCgBillSend()
        {
            InitializeComponent();
        }


        private void button_3_Click(object sender, EventArgs e)
        {
            if (cgBill.Count == 0)
            {
                return;
            }
            frmCgPluView.cgPlu = cgBill[dgBillMx.CurrentRowIndex];
            frmCgPluView.ShowDialog();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("发送当前采购单数据到服务器？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }
            DataSet ds;
            string msg;
            ShowWait("正读取采购单...请稍候...");
            if (!CgBillDAL.GetSendCgBill(out ds, out msg))
            {
                HideWait();
                MessageBox.Show("提取采购单失败：" + msg);
                return;
            }
            if (!Comm.Comm.RecvCgBill(ds, PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, out msg))
            {
                HideWait();
                MessageBox.Show("发送采购单失败：" + msg);
                return;
            }
            HideWait();
            MessageBox.Show("发送采购单成功");
            if (!CgBillDAL.RemoveCgBill(out msg))
            {
                MessageBox.Show("删除采购单失败");
            }
            cgBill.Clear();
            cgBillBindingSource.ResetBindings(true);
            button_4_Click(null, null);
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (cgBill.Count > 0)
            {
                if (MessageBox.Show("采购单未发送至后台。是否要删除此采购单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)==DialogResult.Yes)
                {
                    if (MessageBox.Show("采购单清空后将无法恢复。确认清空采购单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        return;
                    }
                    string msg;
                    if (!CgBillDAL.RemoveCgBill(out msg))
                    {
                        MessageBox.Show("清空失败：" + msg);
                        return;
                    }
                    cgBill.Clear();
                    cgBillBindingSource.Clear();
                }
            }
            cgBill = null;
            this.DialogResult = DialogResult.OK;
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (frmLocateInput.ShowDialog() == DialogResult.OK)
            {
                int l = cgBill.FindIndex(a => a.Barcode == frmLocateInput.Value || a.PluCode == frmLocateInput.Value);
                dgBillMx.UnSelect(dgBillMx.CurrentRowIndex);
                if (l >= 0)
                {
                    dgBillMx.Select(l);
                    dgBillMx.CurrentRowIndex = l;
                }
            }
        }

        private void FrmCgBillSend_Load(object sender, EventArgs e)
        {
            ShowWait("正在读取采购商品...\r\n 请稍候...");
            string msg;
            if (!CgBillDAL.ListBill(out cgBill, out msg))
            {
                MessageBox.Show("查询采购单明细失败：" + msg);
                this.DialogResult = DialogResult.Cancel;
                HideWait();
                return;
            }
            HideWait();
            cgBillBindingSource.DataSource = cgBill;
        }
    }
}