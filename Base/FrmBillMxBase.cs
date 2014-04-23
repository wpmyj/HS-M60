using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class FrmBillMxBase : FrmBase
    {
        public FrmBillMxBase()
        {
            InitializeComponent();
        }
        FrmBarcodeInput frmBarcodeInput = new FrmBarcodeInput();
        /// <summary>
        /// 定位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_1_Click(object sender, EventArgs e)
        {

        }
    }
}