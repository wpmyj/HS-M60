using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Pub;
using DAL;
using Model.DBModel;

namespace MobilePayment.PdBill
{
    public partial class FrmPdPluQuery : Base.FrmBase
    {
        private FrmPdBillInit frmPdBillInit=new FrmPdBillInit();
        private FrmPdBillMx frmPdBillMx=new FrmPdBillMx();

        public FrmPdPluQuery()
        {
            InitializeComponent();
            dlgRecvData = new DlgRecvData(RecvData);
        }

        protected override void NextStep()
        {
            if (this.tbCode.Focused)
            {
                if (!string.IsNullOrEmpty(this.tbCode.Text))
                {
                    this.PluQuery(this.tbCode.Text);
                }
            }
            else if (this.tbNowQty.Focused && !string.IsNullOrEmpty(this.tbNowQty.Text))
            {
                button_1.Focus();
            }

        }

        private void PluQuery(string code)
        {
            ShowWait("正在查询商品\r\n请稍候...");
            string msg;
            //从服务器获取商品信息
            if (!Comm.Comm.QeryPlu(code, PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, ref PubGlobal.Cur_TRFQueryPlu, out msg))
            {
                //MessageBox.Show("查询商品错误：" + msg);
            }
            HideWait();
            ReFlush();
            
        }

        private void ReFlush()
        {
            this.tbCode.Text = (PubGlobal.Cur_TRFQueryPlu == null) ? string.Empty : 
                (string.IsNullOrEmpty(PubGlobal.Cur_TRFQueryPlu[0].BARCODE) ? PubGlobal.Cur_TRFQueryPlu[0].PLUCODE : PubGlobal.Cur_TRFQueryPlu[0].BARCODE);
            this.tbPluName.Text = (PubGlobal.Cur_TRFQueryPlu == null) ? string.Empty : PubGlobal.Cur_TRFQueryPlu[0].PLUNAME;
            this.tbSpec.Text = (PubGlobal.Cur_TRFQueryPlu == null) ? string.Empty : PubGlobal.Cur_TRFQueryPlu[0].SPEC;
            this.tbUnit.Text = (PubGlobal.Cur_TRFQueryPlu == null) ? string.Empty : PubGlobal.Cur_TRFQueryPlu[0].UNIT;
            this.tbPrice.Text = (PubGlobal.Cur_TRFQueryPlu == null) ? "0" : PubGlobal.Cur_TRFQueryPlu[0].PRICE;
            this.tbNowQty.Text = "0";
            if (PubGlobal.Cur_TRFQueryPlu != null)
            {
                string str;
                if (!PdDataDAL.GetPdData(PubGlobal.Cur_TRFQueryPlu[0].PLUID, out PubGlobal.PdDataModel, out str))
                {
                    this.tbLastQty.Text = "0";
                    if (!NewModel())
                    {
                        MessageBox.Show("新建单据明细失败");
                        return;
                    }
                }
                this.tbLastQty.Text = PubGlobal.PdDataModel.SjCount.ToString("F2");
                this.tbNowQty.Focus();
                this.tbNowQty.SelectAll();
            }
            else
            {
                this.tbNowQty.Text = "0";
                this.tbLastQty.Text = "0";
                this.tbCode.Focus();
                this.tbCode.SelectAll();
            }
        }

        private bool NewModel()
        {
            if ((PubGlobal.Cur_TRFQueryPlu == null) || (PubGlobal.Cur_TRFQueryPlu.Count == 0))
            {
                return false;
            }
            PubGlobal.PdDataModel = new DBPdData();
            PubGlobal.PdDataModel.PluID = PubGlobal.Cur_TRFQueryPlu[0].PLUID;
            PubGlobal.PdDataModel.PluCode = PubGlobal.Cur_TRFQueryPlu[0].PLUCODE;
            PubGlobal.PdDataModel.PluName = PubGlobal.Cur_TRFQueryPlu[0].PLUNAME;
            PubGlobal.PdDataModel.Barcode=PubGlobal.Cur_TRFQueryPlu[0].BARCODE;
            PubGlobal.PdDataModel.Spec = PubGlobal.Cur_TRFQueryPlu[0].SPEC;
            PubGlobal.PdDataModel.Unit = PubGlobal.Cur_TRFQueryPlu[0].UNIT;
            PubGlobal.PdDataModel.Price = decimal.Parse(PubGlobal.Cur_TRFQueryPlu[0].PRICE);
            PubGlobal.PdDataModel.PdNo = string.Empty;
            PubGlobal.PdDataModel.SjCount = 0;
            return true;
        }

        private void FrmPdPluQuery_Load(object sender, EventArgs e)
        {
            cSideBtn1.Init();
            cSideBtn1.Open();
            cScanner1.Open();
            if (frmPdBillInit.ShowDialog() != DialogResult.OK)
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                ReFlush();
            }

        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (PubGlobal.PdDataModel != null)
            {
                string str;
                try
                {
                    PubGlobal.PdDataModel.SjCount+=decimal.Parse(this.tbNowQty.Text);
                }
                catch
                {
                    MessageBox.Show("数量非法");
                    this.tbNowQty.Focus();
                    this.tbNowQty.SelectAll();
                    return;
                }
                PubGlobal.PdDataModel.LrDate = DateTime.Now;
                PubGlobal.PdDataModel.LrUser = PubGlobal.User.UserCode;
                if (PdDataDAL.SavePdData(PubGlobal.PdDataModel, out str))
                {
                    PubGlobal.JhBillModel = null;
                    PubGlobal.Cur_TRFQueryPlu.Clear();
                    PubGlobal.Cur_TRFQueryPlu = null;
                    this.ReFlush();
                }
                else
                {
                    MessageBox.Show("保存失败：" + str);
                }
            }
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            frmPdBillMx.ShowDialog();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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

        private void FrmPdPluQuery_Closing(object sender, CancelEventArgs e)
        {
            cSideBtn1.Init();
            cSideBtn1.Open();
            cScanner1.Open();
        }
    }
}