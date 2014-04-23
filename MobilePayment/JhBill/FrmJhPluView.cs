using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base;
using Model.DBModel;

namespace MobilePayment.JhBill
{
    public partial class FrmJhPluView : FrmBase
    {
        /// <summary>
        /// 进货单
        /// </summary>
        public DBJhBill JhPlu
        {
            get;
            set;
        }

        public FrmJhPluView()
        {
            InitializeComponent();
        }

        private void FrmJhPluView_Activated(object sender, EventArgs e)
        {
            if (JhPlu != null)
            {
                tbCode.Text = JhPlu.Barcode;
                tbPluName.Text = JhPlu.PluName;
                tbSpec.Text = JhPlu.Spec;
                tbUnit.Text = JhPlu.Unit;
                tbPackSpec.Text = JhPlu.PackQty.ToString() + "/" + JhPlu.PackUnit;
                //tbProductDate.Text=jhBill.
                tbSsPackCount.Text = JhPlu.SsPackCount.ToString();
                tbSsSglCount.Text = JhPlu.SsSGLCount.ToString();
                tbCgPackCount.Text = JhPlu.CgPackCount.ToString();
                tbCgSglCount.Text = JhPlu.CgSGLCount.ToString();
            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            JhPlu = null;
            this.DialogResult = DialogResult.OK;
        }
    }
}