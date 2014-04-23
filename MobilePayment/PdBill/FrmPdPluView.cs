using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model.DBModel;
using Base;

namespace MobilePayment.PdBill
{
    public partial class FrmPdPluView : FrmBase
    {
        public DBPdData PdPlu
        {
            get;
            set;
        }
        public FrmPdPluView()
        {
            InitializeComponent();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            PdPlu = null;
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmPdPluView_Activated(object sender, EventArgs e)
        {
            if (PdPlu != null)
            {
                tbCode.Text = PdPlu.Barcode;
                tbPluName.Text = PdPlu.PluName;
                tbSpec.Text = PdPlu.Spec;
                tbUnit.Text = PdPlu.Unit;
                tbLastQty.Text = PdPlu.SjCount.ToString();
                tbPrice.Text =PdPlu.Price.ToString("F2");
            }

        }
    }
}