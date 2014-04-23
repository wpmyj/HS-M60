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
using Model.TransModel;

namespace MobilePayment.CgBill
{
    public partial class FrmCgPlu : FrmBase
    {
        public FrmCgPlu()
        {
            InitializeComponent();
        }

        FrmCgBillMx frmCgBillMx = new FrmCgBillMx();//采购明细窗口

        private void button_4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            frmCgBillMx.ShowDialog();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            decimal packCount=0,SGLCount=0;
            try
            {
                packCount = decimal.Parse(tbPackCount.Text);
                SGLCount = decimal.Parse(tbSglCount.Text);
                if (packCount + SGLCount == 0)
                {
                    MessageBox.Show("请输入采购数量");
                    if (cbxPackSpec.Enabled)
                    {
                        tbPackCount.Focus();
                        tbPackCount.SelectAll();
                    }
                    else
                    {
                        tbSglCount.Focus();
                        tbSglCount.SelectAll();
                    }

                    return;
                }
            }
            catch
            {
                MessageBox.Show("数量输入非法");
                if (cbxPackSpec.Enabled)
                {
                    tbPackCount.Focus();
                    tbPackCount.SelectAll();
                }
                else
                {
                    tbSglCount.Focus();
                    tbSglCount.SelectAll();
                }
                return;
            }

            ShowWait("正在保存...请稍候...");
            DBCgBill cgBill = new DBCgBill();
            cgBill.Barcode = PubGlobal.Cur_TRFQueryKc[0].BARCODE;
            cgBill.ID = Guid.NewGuid();
            cgBill.Unit = PubGlobal.Cur_TRFQueryKc[0].UNIT;
            cgBill.PackCount = packCount;
            cgBill.LrUser = PubGlobal.User.USERNAME;
            cgBill.LrDate = DateTime.Now;
            cgBill.SerialNo = ++PubGlobal.CgSerialNo;
            if (cbxPackSpec.SelectedItem != null)
            {
                cgBill.PackQty = decimal.Parse(((Model.TransModel.TPacket)(cbxPackSpec.SelectedItem)).PACKQTY);
                cgBill.PackUnit = ((Model.TransModel.TPacket)(cbxPackSpec.SelectedItem)).PACKUNIT;
            }
            else
            {
                cgBill.PackQty = 0;
                cgBill.PackUnit = string.Empty;
            }
            cgBill.PluID = PubGlobal.Cur_TRFQueryKc[0].PLUID;
            cgBill.PluCode = PubGlobal.Cur_TRFQueryKc[0].PLUCODE;
            cgBill.PluName = PubGlobal.Cur_TRFQueryKc[0].PLUNAME;
            cgBill.SGLCount = SGLCount;
            cgBill.CgCount = cgBill.PackQty * cgBill.PackCount + cgBill.SGLCount;

            int i;
            string msg;
            if (!DAL.CgBillDAL.Insert(cgBill, out i, out msg))
            {
                HideWait();
                MessageBox.Show(msg);
            }
            else
            {
                HideWait();
                PubGlobal.Cur_TRFQueryKc[0].Packets = null;
                PubGlobal.Cur_TRFQueryKc = null;
                this.DialogResult = DialogResult.OK;
            }

        }

        private void BindingPackSpec()
        {
            cbxPackSpec.Items.Clear();
            if (PubGlobal.Cur_TRFQueryKc[0].Packets == null)
            {
                return;
            }
            foreach (TPacket p in PubGlobal.Cur_TRFQueryKc[0].Packets)
            {
                cbxPackSpec.Items.Add(p);
            }
            cbxPackSpec.SelectedIndex = 0;
        }
        private void FrmCgPlu_Load(object sender, EventArgs e)
        {
            tbBarcode.Text = PubGlobal.Cur_TRFQueryKc[0].BARCODE;
            tbPluCode.Text = PubGlobal.Cur_TRFQueryKc[0].PLUCODE;
            tbPluName.Text = PubGlobal.Cur_TRFQueryKc[0].PLUNAME;
            tbSpec.Text = PubGlobal.Cur_TRFQueryKc[0].SPEC;
            tbUnit.Text = PubGlobal.Cur_TRFQueryKc[0].UNIT;
            tbPackCount.Text = "0";
            tbSglCount.Text = "0";
            BindingPackSpec();
            if (PubGlobal.Cur_TRFQueryKc[0].Packets == null)
            {
                cbxPackSpec.Enabled = false;
                tbPackCount.Enabled = false;
                tbSglCount.Focus();
                tbSglCount.SelectAll();
            }
            else
            {
                cbxPackSpec.Enabled = true;
                tbPackCount.Enabled = true;
                cbxPackSpec.Focus();
            }
        }

        private void cbxPackSpec_SelectedValueChanged(object sender, EventArgs e)
        {
            //tbPackCount.Text = "0";
            //tbSglCount.Text = "0";
            tbPackCount.Focus();
            tbPackCount.SelectAll();
        }

        protected override void NextStep()
        {
            //base.NextStep();
            if (cbxPackSpec.Focused)
            {
                tbPackCount.Focus();
                tbPackCount.SelectAll();
                return;
            }
            if (tbPackCount.Focused)
            {
                tbSglCount.Focus();
                tbSglCount.SelectAll();
                return;
            }
            if (tbSglCount.Focused)
            {
                button_1.Focus();
                return;
            }
        }
    }
}