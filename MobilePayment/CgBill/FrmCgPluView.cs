using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Base;
using Model.DBModel;

namespace MobilePayment.CgBill
{
    public partial class FrmCgPluView : FrmBase
    {
        public DBCgBill cgPlu
        {
            get;
            set;
        }
        public FrmCgPluView()
        {
            InitializeComponent();
        }

        private void FrmCgPluView_Activated(object sender, EventArgs e)
        {
            if (cgPlu != null)
            {
                tbBarcode.Text = cgPlu.Barcode;
                tbPluCode.Text = cgPlu.PluCode;
                tbPluName.Text = cgPlu.PluName;
                tbSpec.Text = cgPlu.PluName;
                tbUnit.Text = cgPlu.Unit;
                tbPackSpec.Text = cgPlu.PackQty.ToString()+"/"+cgPlu.PackUnit;
                tbPackCount.Text = cgPlu.PackCount.ToString("F2");
                tbSglCount.Text = cgPlu.SGLCount.ToString("F2");
            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            cgPlu = null;
            this.DialogResult = DialogResult.OK;
        }
    }
}