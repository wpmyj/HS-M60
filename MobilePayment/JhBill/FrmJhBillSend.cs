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

namespace MobilePayment.JhBill
{
    public partial class FrmJhBillSend : FrmBillSendBase
    {
        List<DBJhBill> jhBill;
        FrmJhPluView frmjhPluView = new FrmJhPluView();
        FrmLocateInput frmLocateInput = new FrmLocateInput();

        public FrmJhBillSend()
        {
            InitializeComponent();
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

        private void button_3_Click(object sender, EventArgs e)
        {
            if (jhBill.Count == 0)
            {
                return;
            }
            frmjhPluView.JhPlu = jhBill[dgBillMx.CurrentRowIndex];
            frmjhPluView.ShowDialog();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (PubGlobal.JhBillInfo!=null)
            {
                if (MessageBox.Show("采购单未发送至后台。是否要删除此采购单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (MessageBox.Show("采购单清空后将无法恢复。确认清空采购单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        return;
                    }
                    string msg;
                    if (!JhBillDAL.RemoveJhBill(out msg))
                    {
                        MessageBox.Show("清空失败：" + msg);
                        return;
                    }
                    jhBill.Clear();
                    dBJhBillBindingSource.Clear();
                }
            }
            jhBill = null;
            this.DialogResult = DialogResult.OK;
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("发送当前验收单数据到服务器？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }
            DataSet ds;
            string msg;
            ShowWait("正读取验收单...请稍候...");
            if (!JhBillDAL.GetSendJhBill(out ds, out msg))
            {
                HideWait();
                MessageBox.Show("提取验收单失败：" + msg);
                return;
            }
            string ywType=PubGlobal.JhBillInfo.IsCgJh?PubGlobal.JHYW_TYPE_CGJH:PubGlobal.JHYW_TYPE_NO_CGJH;
            if (!Comm.Comm.RecvJhBill(ds,ywType,PubGlobal.JhBillInfo.PreRefBillNo+PubGlobal.JhBillInfo.RefBillNo,PubGlobal.JhBillInfo.CkCode,PubGlobal.OrgCode,PubGlobal.User.UserCode,PubGlobal.User.Password,out msg))
            {
                HideWait();
                MessageBox.Show("发送验收单失败：" + msg);
                return;
            }
            HideWait();
            MessageBox.Show("发送验收单成功");
            if (!JhBillDAL.RemoveJhBill(out msg))
            {
                MessageBox.Show("删除验收单失败");
            }
            jhBill.Clear();
            PubGlobal.JhBillInfo = null;
            dBJhBillBindingSource.ResetBindings(true);
            button_4_Click(null, null);
        }

        private void FrmJhBillSend_Load(object sender, EventArgs e)
        {
            ShowWait("正在读取验收明细...\r\n 请稍候...");
            string msg;
            if (!JhBillDAL.GetJhBillInfo(out PubGlobal.JhBillInfo, out msg))
            {
                MessageBox.Show("读取验收单数据失败：" + msg);
                this.DialogResult = DialogResult.Cancel;
                HideWait();
                return;
            }
            if (!JhBillDAL.ListBill(out jhBill, out msg))
            {
                MessageBox.Show("查询验收单明细失败：" + msg);
                this.DialogResult = DialogResult.Cancel;
                HideWait();
                return;
            }
            else
            {
                tbLrUser.Text = PubGlobal.JhBillInfo.LrUser;
                tbCheckUser.Text = PubGlobal.User.USERNAME;
                dBJhBillBindingSource.DataSource = jhBill;
            }
            HideWait();

        }
    }
}