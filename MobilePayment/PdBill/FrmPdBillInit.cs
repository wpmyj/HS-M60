using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base;
using Pub;
using Model.DBModel;
using DAL;

namespace MobilePayment.PdBill
{
    public partial class FrmPdBillInit : FrmBase
    {
        private bool ReadPdDataSuccess;


        public FrmPdBillInit()
        {
            InitializeComponent();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (!this.ReadPdDataSuccess)
            {
                string str;
                if (string.IsNullOrEmpty(this.tbCkCode.Text))
                {
                    MessageBox.Show("仓库编码不能为空");
                    return;
                }
                if (this.dpPdDate.Value.CompareTo(DateTime.Today) > 0)
                {
                    MessageBox.Show("盘点日期不能比当前日期晚");
                    return;
                }
                if (PubGlobal.PdDataInfo == null)
                {
                    PubGlobal.PdDataInfo = new DBPdDataInfo();
                }
                PubGlobal.PdDataInfo.PdDate = dpPdDate.Value.Date;
                PubGlobal.PdDataInfo.CkCode = tbCkCode.Text;
                PubGlobal.PdDataInfo.LrUser = PubGlobal.User.UserCode;
                PubGlobal.PdDataInfo.LrDate = DateTime.Now;
                if (!PdDataDAL.SavePdDataInfo(PubGlobal.PdDataInfo, out str))
                {
                    MessageBox.Show("保存盘点信息失败：" + str);
                    return;
                }
            }
            base.DialogResult = DialogResult.OK;

        }

        private void button_4_Click(object sender, EventArgs e)
        {
            PubGlobal.PdDataInfo = null;
            base.DialogResult = DialogResult.Cancel;
        }

        private void FrmPdBillInit_Load(object sender, EventArgs e)
        {
            string str;
            this.ReadPdDataSuccess = PdDataDAL.GetPdDataInfo(out PubGlobal.PdDataInfo, out str);
            this.dpPdDate.Enabled = !this.ReadPdDataSuccess;
            this.tbCkCode.Enabled = !this.ReadPdDataSuccess;
            if (this.ReadPdDataSuccess)
            {
                this.dpPdDate.Value = PubGlobal.PdDataInfo.PdDate;
                this.tbCkCode.Text = PubGlobal.PdDataInfo.CkCode;
                base.button_3.Focus();
            }
            else
            {
                this.dpPdDate.Value = DateTime.Today;
                this.tbCkCode.Text = string.Empty;
                this.tbCkCode.Focus();
                this.tbCkCode.SelectAll();
            }

        }

        protected override void NextStep()
        {
            if (this.dpPdDate.Focused)
            {
                this.tbCkCode.Focus();
                this.tbCkCode.SelectAll();
            }
            else if (this.tbCkCode.Focused && !string.IsNullOrEmpty(this.tbCkCode.Text))
            {
                base.button_3.Focus();
            }
        }

 

    }
}