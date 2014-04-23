using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Pub;
using DAL;
using Base;
namespace MobilePayment.JhBill
{
    public partial class FrmJhBillInit : FrmBase
    {
        bool ReadCgBillSuccess = false;
        public FrmJhBillInit()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            switch (rbIsCgJh.Checked)
            {
                case true://采购验收
                    lbRefBillNo.Text = "订单号";
                    tbPreRefBillNo.Text = PubGlobal.YwTypeRes[PubGlobal.CGYW_TYPE_CODE].ToString();
                    break;
                case false://无采购验收
                    lbRefBillNo.Text = "供应商号";
                    tbPreRefBillNo.Text = string.Empty;
                    break;
            }
            tbRefBillNo.Focus();
            tbRefBillNo.SelectAll();
        }
        private void FrmJhBillInit_Load(object sender, EventArgs e)
        {
            string msg;
            ReadCgBillSuccess=JhBillDAL.GetJhBillInfo(out PubGlobal.JhBillInfo, out msg);
            rbIsCgJh.Enabled = !ReadCgBillSuccess;
            rbIsNotCgJh.Enabled = !ReadCgBillSuccess;
            tbRefBillNo.Enabled = !ReadCgBillSuccess;
            tbCkCode.Enabled = !ReadCgBillSuccess;
            if (!ReadCgBillSuccess)
            {//读取单据失败。新建单据
                rbIsCgJh.Checked = true;
                tbPreRefBillNo.Text = PubGlobal.YwTypeRes[PubGlobal.CGYW_TYPE_CODE].ToString();
                tbCkCode.Text = string.Empty;
                tbRefBillNo.Text = string.Empty;
                tbRefBillNo.Focus();
                tbRefBillNo.SelectAll();
            }
            else
            {
                //读取单据成功，显示单据
                rbIsCgJh.Checked = PubGlobal.JhBillInfo.IsCgJh;
                rbIsNotCgJh.Checked = !rbIsCgJh.Checked;
                tbRefBillNo.Text = PubGlobal.JhBillInfo.RefBillNo;
                tbPreRefBillNo.Text = PubGlobal.JhBillInfo.PreRefBillNo;
                tbCkCode.Text = PubGlobal.JhBillInfo.CkCode;
                button_3.Focus();
            }
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (!ReadCgBillSuccess)
            {
                string msg;
                if (string.IsNullOrEmpty(tbRefBillNo.Text.Trim()) && string.IsNullOrEmpty(tbCkCode.Text.Trim()))
                {
                    MessageBox.Show(lbRefBillNo.Text + "、仓库编码不能为空");
                    return;
                }
                if (rbIsCgJh.Checked)
                {
                    ShowWait("正在查询采购单\r\n...请稍候...");
                    if (!Comm.Comm.QueryCgBill(tbPreRefBillNo.Text + tbRefBillNo.Text, PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, out msg))
                    {
                        MessageBox.Show("采购单查询失败：" + msg);
                        tbRefBillNo.Focus();
                        tbRefBillNo.SelectAll();
                        HideWait();
                        return;
                    }
                    HideWait();
                }

                if (PubGlobal.JhBillInfo == null)
                {
                    PubGlobal.JhBillInfo = new Model.DBModel.DBJhBillInfo();
                }
                PubGlobal.JhBillInfo.PreRefBillNo = tbPreRefBillNo.Text;
                PubGlobal.JhBillInfo.LrUser = PubGlobal.User.USERNAME;
                PubGlobal.JhBillInfo.RefBillNo = tbRefBillNo.Text;
                PubGlobal.JhBillInfo.CkCode = tbCkCode.Text;
                PubGlobal.JhBillInfo.IsCgJh = rbIsCgJh.Checked;
                if (!JhBillDAL.SaveJhBillInfo(PubGlobal.JhBillInfo, out msg))
                {
                    MessageBox.Show("保存单据信息失败：" + msg);
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        protected override void NextStep()
        {
            if (tbRefBillNo.Focused)
            {
                tbCkCode.Focus();
                tbCkCode.SelectAll();
            }
            else if (tbCkCode.Focused)
            {
                button_3.Focus();
            }
        }

        private void tbPreRefBillNo_GotFocus(object sender, EventArgs e)
        {
            tbRefBillNo.Focus();
            tbRefBillNo.SelectAll();
        }
    }
}