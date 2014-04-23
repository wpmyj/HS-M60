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
    public partial class FrmPdBillSend : FrmBillSendBase
    {
        private FrmLocateInput frmLocateInput=new FrmLocateInput();
        private FrmPdPluView frmPdPluView=new FrmPdPluView();
        private List<DBPdData> pdDatas;

        public FrmPdBillSend()
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
            if (MessageBox.Show("发送当前盘点单数据到服务器？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) != DialogResult.Yes)
            {
                return;
            }
            DataSet ds;
            string msg;
            ShowWait("正读取盘点单...请稍候...");
            if (!PdDataDAL.GetSendPdData(out ds, out msg))
            {
                HideWait();
                MessageBox.Show("提取盘点单失败：" + msg);
                return;
            }
            //string ywType = PubGlobal.JhBillInfo.IsCgJh ? PubGlobal.JHYW_TYPE_CGJH : PubGlobal.JHYW_TYPE_NO_CGJH;
            ShowWait("正在发送盘点单数据...请稍候...");
            if (!Comm.Comm.RecvPdData(ds, PubGlobal.PdDataInfo.CkCode,PubGlobal.PdDataInfo.PdDate.ToString("yyyy-MM-dd"), PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, out msg))
            {
                HideWait();
                MessageBox.Show("发送盘点单失败：" + msg);
                return;
            }
            HideWait();
            MessageBox.Show("发送盘点单成功");
            if (!PdDataDAL.RemovePdData(out msg))
            {
                MessageBox.Show("删除盘点单失败");
            }
            pdDatas.Clear();
            PubGlobal.PdDataInfo = null;
            dBPdDataBindingSource.ResetBindings(true);
            button_4_Click(null, null);
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            if (PubGlobal.PdDataInfo != null)
            {
                if (MessageBox.Show("盘点单单未发送至后台。是否要删除此盘点单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    if (MessageBox.Show("盘点单清空后将无法恢复。确认清空盘点单？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                    {
                        return;
                    }
                    string msg;
                    if (!PdDataDAL.RemovePdData(out msg))
                    {
                        MessageBox.Show("清空失败：" + msg);
                        return;
                    }
                    pdDatas.Clear();
                    dBPdDataBindingSource.Clear();
                }
            }
            pdDatas = null;
            this.DialogResult = DialogResult.OK;
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

        private void FrmPdBillSend_Load(object sender, EventArgs e)
        {
            ShowWait("正在读取盘点明细...\r\n 请稍候...");
            string msg;
            if (!PdDataDAL.GetPdDataInfo(out PubGlobal.PdDataInfo, out msg))
            {
                MessageBox.Show("读取盘点单数据失败：" + msg);
                this.DialogResult = DialogResult.Cancel;
                HideWait();
                return;
            }
            if (!PdDataDAL.ListPdData(out pdDatas, out msg))
            {
                MessageBox.Show("查询盘点单明细失败：" + msg);
                this.DialogResult = DialogResult.Cancel;
                HideWait();
                return;
            }
            else
            {
                tbPdDate.Text = PubGlobal.PdDataInfo.PdDate.ToString("yyyy-MM-dd");
                tbCkCode.Text = PubGlobal.PdDataInfo.CkCode;
                dBPdDataBindingSource.DataSource = pdDatas;
            }
            HideWait();
        }
    }
}