using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base;
using Pub;
using DAL;
using MobilePayment.CgBill;

namespace MobilePayment.CgBill
{
    public partial class FrmKcQuery : FrmBase
    {
        public FrmKcQuery()
        {
            InitializeComponent();
            dlgRecvData = new DlgRecvData(RecvData);
        }

        FrmCgPlu frmCgBill = new FrmCgPlu();
        private void button_1_Click(object sender, EventArgs e)
        {
            ShowWait("正在查询...请稍候...");
            KcQuery(tbCode.Text);
            HideWait();

        }

        /// <summary>
        /// 查询库存
        /// </summary>
        private void KcQuery(string code)
        {
            string msg;
            if (!Comm.Comm.QeryKc(code, PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, ref PubGlobal.Cur_TRFQueryKc, out msg))
            {
                MessageBox.Show(msg);
            }
            ReFlush();
        }

        /// <summary>
        /// 刷新页面信息
        /// </summary>
        private void ReFlush()
        {
            tbCode.Text = PubGlobal.Cur_TRFQueryKc == null ? string.Empty : PubGlobal.Cur_TRFQueryKc[0].BARCODE;
            tbPluName.Text = PubGlobal.Cur_TRFQueryKc == null ? string.Empty : PubGlobal.Cur_TRFQueryKc[0].PLUNAME;
            tbSpec.Text = PubGlobal.Cur_TRFQueryKc == null ? string.Empty : PubGlobal.Cur_TRFQueryKc[0].SPEC;
            tbUnit.Text = PubGlobal.Cur_TRFQueryKc == null ? string.Empty : PubGlobal.Cur_TRFQueryKc[0].UNIT;
            tbPrice.Text = PubGlobal.Cur_TRFQueryKc == null ? string.Empty : PubGlobal.Cur_TRFQueryKc[0].PRICE;
            tbYhPrice.Text = PubGlobal.Cur_TRFQueryKc == null ? string.Empty : PubGlobal.Cur_TRFQueryKc[0].YHPRICE;
            tbKcCount.Text = PubGlobal.Cur_TRFQueryKc == null ? string.Empty : PubGlobal.Cur_TRFQueryKc[0].KCCOOUNT;
            tbCode.Focus();
            tbCode.SelectAll();
        }

        private void FrmKcQuery_Load(object sender, EventArgs e)
        {
            cSideBtn1.Init();
            cSideBtn1.Open();
            cScanner1.Open();
            string msg;
            if (!CgBillDAL.GetMasSerialNo(out PubGlobal.CgSerialNo, out msg))
            {
                MessageBox.Show("当前明细序号读取失败：" + msg);
                PubGlobal.CgSerialNo = 0;
            }
            ReFlush();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_TRFQueryKc == null)
            {
                return;
            }
            else
            {
                frmCgBill.ShowDialog();
            }
            ReFlush();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            PubGlobal.Cur_TRFQueryKc = null;
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// 重写NextStep
        /// </summary>
        protected override void NextStep()
        {
            //base.NextStep();
            if (!string.IsNullOrEmpty(tbCode.Text))
            {
                button_1_Click(null, null);
            }
        }

        private void FrmKcQuery_Closing(object sender, CancelEventArgs e)
        {
            cScanner1.Close();
            cSideBtn1.Close();
        }

        private void cSideBtn1_OnPressRightButton(object sender, EventArgs e)
        {
            cScanner1.Read();
        }


        delegate void DlgRecvData(string code);
        DlgRecvData dlgRecvData;
        private void RecvData(string code)
        {
            tbCode.Text = code.Replace("\r", string.Empty).Replace("\n", string.Empty);
            button_1_Click(null, null);
        }

        private void cScanner1_OnRecvData(object sender, Devices.ScanRecvDataEventArgs e)
        {
            this.Invoke(dlgRecvData, e.DataValue);
        }

    }
}