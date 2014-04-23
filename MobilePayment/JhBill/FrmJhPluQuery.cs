#define  HasDevice
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
using Model.DBModel;
using Model.TransModel;

namespace MobilePayment.JhBill
{
    public partial class FrmJhPluQuery : FrmBase
    {
        FrmJhBillInit frmJhBillInit = new FrmJhBillInit();
        FrmJhBillMx frmJhBillMx = new FrmJhBillMx();
        public FrmJhPluQuery()
        {
            InitializeComponent();
            dlgRecvData = new DlgRecvData(RecvData);
        }

        private void tbCode_GotFocus(object sender, EventArgs e)
        {
            tbCode.SelectAll();
        }

        private void FrmJhPluQuery_Load(object sender, EventArgs e)
        {
#if(HasDevice)
            cSideBtn1.Init();
            cSideBtn1.Open();
            cScanner1.Open();
#endif
            //显示验收单初始化窗口
            if (frmJhBillInit.ShowDialog() != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                ReFlush();
            }          
        }

        protected override void NextStep()
        {
            if (tbCode.Focused)
            {
                PluQuery(tbCode.Text);
            }
            else if (cbxPackSpec.Focused)
            {
                tbSsPackCount.Focus();
                tbSsPackCount.SelectAll();
            }
            else if (tbSsPackCount.Focused)
            {
                tbSsSglCount.Focus();
                tbSsSglCount.SelectAll();
            }
            else if (tbSsSglCount.Focused)
            {
                button_1.Focus();
            }
        }

        /// <summary>
        /// 查询商品信息及订单信息
        /// </summary>
        private void PluQuery(string code)
        {
            ShowWait("正在查询商品\r\n请稍候...");
            string msg;
            if (PubGlobal.JhBillInfo.IsCgJh)
            {
                //数据库中查询采购单明细
                if (!JhBillDAL.QueryPluFromBill(code,out PubGlobal.Cur_TRFQueryPlu,out msg))
                {
                    MessageBox.Show("查询商品错误："+msg);
                }
            }
            else
            {//从服务器获取商品信息
                if (!Comm.Comm.QeryPlu(code, PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, ref PubGlobal.Cur_TRFQueryPlu, out msg))
                {
                    //MessageBox.Show("查询商品错误：" + msg);
                }
            }
            HideWait();
            ReFlush();
            cbxPackSpec.Focus();
        }

        /// <summary>
        /// 刷新页面显示
        /// </summary>
        private void ReFlush()
        {
            string msg;
            tbCode.Text = PubGlobal.Cur_TRFQueryPlu == null ? string.Empty : 
                (string.IsNullOrEmpty(PubGlobal.Cur_TRFQueryPlu[0].BARCODE) ? PubGlobal.Cur_TRFQueryPlu[0].PLUCODE : PubGlobal.Cur_TRFQueryPlu[0].BARCODE);
            tbPluName.Text = PubGlobal.Cur_TRFQueryPlu == null ? string.Empty : PubGlobal.Cur_TRFQueryPlu[0].PLUNAME;
            tbSpec.Text = PubGlobal.Cur_TRFQueryPlu == null ? string.Empty : PubGlobal.Cur_TRFQueryPlu[0].SPEC;
            tbUnit.Text = PubGlobal.Cur_TRFQueryPlu == null ? string.Empty : PubGlobal.Cur_TRFQueryPlu[0].UNIT;
            if (PubGlobal.Cur_TRFQueryPlu != null)
            {
                if (PubGlobal.Cur_TRFQueryPlu[0].Packets == null || PubGlobal.Cur_TRFQueryPlu[0].Packets.Count==0)
                {
                    cbxPackSpec.Enabled = false;
                    tbSsPackCount.Enabled = false;
                    if (PubGlobal.JhBillInfo.IsCgJh)
                    {
                        //从本地数据库获取单据Model
                        if (!JhBillDAL.GetBill(PubGlobal.Cur_TRFQueryPlu[0].PLUID, out PubGlobal.JhBillModel, out msg))
                        {
                            MessageBox.Show("获取采购单明细失败：" + msg);
                            return;
                        }
                    }
                    else
                    {
                        //数据库读取Model
                        if (!JhBillDAL.GetBill(PubGlobal.Cur_TRFQueryPlu[0].PLUID, out PubGlobal.JhBillModel, out msg))
                        {
                            //新建Model
                            if (!NewModel())
                            {
                                MessageBox.Show("新建单据明细失败");
                                return;
                            }
                        }
                    }
                    tbCgPackCount.Text = PubGlobal.JhBillModel == null ? "0" : PubGlobal.JhBillModel.CgPackCount.ToString();
                    tbCgSglCount.Text = PubGlobal.JhBillModel == null ? "0" : PubGlobal.JhBillModel.CgSGLCount.ToString();
                    tbSsPackCount.Text = PubGlobal.JhBillModel == null ? "0" : PubGlobal.JhBillModel.SsPackCount.ToString();
                    tbSsSglCount.Text = PubGlobal.JhBillModel == null ? "0" : PubGlobal.JhBillModel.SsSGLCount.ToString();
                    tbSsSglCount.Focus();
                    tbSsSglCount.SelectAll();
                    BindingPackSpec();
                    return;
                }
                cbxPackSpec.Enabled = true;
                tbSsPackCount.Enabled = true;
                cbxPackSpec.DataSource = null;
                BindingPackSpec();

            }
            else
            {
                cbxPackSpec.Enabled = false;
                tbCgPackCount.Text = "0";
                tbCgSglCount.Text = "0";
                tbSsPackCount.Text = "0";
                tbSsSglCount.Text = "0";
            }
            tbCode.Focus();
            tbCode.SelectAll();
        }

        /// <summary>
        /// 绑定包装单位数据源
        /// </summary>
        private void BindingPackSpec()
        {
            cbxPackSpec.Items.Clear();
            if (PubGlobal.Cur_TRFQueryPlu[0].Packets == null)
            {
                return;
            }
            foreach (TPacket p in PubGlobal.Cur_TRFQueryPlu[0].Packets)
            {
                cbxPackSpec.Items.Add(p);
            }
            if (cbxPackSpec.Items.Count > 0)
            {
                cbxPackSpec.SelectedIndex = 0;
            }
        }
        protected override void PreStep()
        {
            if (!tbCode.Focused)
            {
                tbCode.Focus();
                tbCode.SelectAll();
            }
        }

        /// <summary>
        /// 新建Model
        /// </summary>
        private bool NewModel()
        {
            if (PubGlobal.Cur_TRFQueryPlu == null || PubGlobal.Cur_TRFQueryPlu.Count == 0)
            {
                return false;
            }
            PubGlobal.JhBillModel = new DBJhBill();
            PubGlobal.JhBillModel.BillNo = string.Empty;
            PubGlobal.JhBillModel.Barcode = PubGlobal.Cur_TRFQueryPlu[0].BARCODE;
            PubGlobal.JhBillModel.Checked = "N";
            PubGlobal.JhBillModel.LrDate = DateTime.Now;
            PubGlobal.JhBillModel.LrUser = PubGlobal.User.UserCode;
            TPacket packet=(TPacket)(cbxPackSpec.SelectedItem);
            PubGlobal.JhBillModel.PackQty = packet==null?0:decimal.Parse(packet.PACKQTY);
            PubGlobal.JhBillModel.PackUnit = packet==null?string.Empty:packet.PACKUNIT;
            PubGlobal.JhBillModel.PluCode = PubGlobal.Cur_TRFQueryPlu[0].PLUCODE;
            PubGlobal.JhBillModel.PluID = PubGlobal.Cur_TRFQueryPlu[0].PLUID;
            PubGlobal.JhBillModel.PluName = PubGlobal.Cur_TRFQueryPlu[0].PLUNAME;
            PubGlobal.JhBillModel.Spec = PubGlobal.Cur_TRFQueryPlu[0].SPEC;
            PubGlobal.JhBillModel.Unit = PubGlobal.Cur_TRFQueryPlu[0].UNIT;
            return true;
        }

        private void cbxPackSpec_SelectedValueChanged(object sender, EventArgs e)
        {
            string msg;
            TPacket packet = (TPacket)cbxPackSpec.SelectedItem;
            if (PubGlobal.JhBillInfo.IsCgJh)
            {
                //数据库读取Model
                if (!JhBillDAL.GetBill(PubGlobal.Cur_TRFQueryPlu[0].PLUCODE,packet, out PubGlobal.JhBillModel, out msg))
                {
                    MessageBox.Show(msg);
                }
            }
            else
            {
                //数据库读取Model
                if (!JhBillDAL.GetBill(PubGlobal.Cur_TRFQueryPlu[0].PLUCODE,packet, out PubGlobal.JhBillModel, out msg))
                {
                    //新建Model
                    if (!NewModel())
                    {
                        MessageBox.Show("新建单据明细失败");
                        return;
                    }
                }
              
            }
            //tbCgPackCount.Text = jhBillModel.CgPackCount.ToString();
            //tbCgSglCount.Text = jhBillModel.CgSGLCount.ToString();
            tbCgPackCount.Text = PubGlobal.JhBillModel == null ? "0" : PubGlobal.JhBillModel.CgPackCount.ToString();
            tbCgSglCount.Text = PubGlobal.JhBillModel == null ? "0" : PubGlobal.JhBillModel.CgSGLCount.ToString();
            tbSsPackCount.Text = PubGlobal.JhBillModel == null ? "0" : PubGlobal.JhBillModel.SsPackCount.ToString();
            tbSsSglCount.Text = PubGlobal.JhBillModel == null ? "0" : PubGlobal.JhBillModel.SsSGLCount.ToString();
            if (string.IsNullOrEmpty(PubGlobal.JhBillModel.ScDate))
            {
                cbHasProductDate.Checked = false;
            }
            else
            {
                cbHasProductDate.Checked = true;
                dpProductDate.Value = DateTime.Parse(PubGlobal.JhBillModel.ScDate);
            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void cbHasProductDate_CheckStateChanged(object sender, EventArgs e)
        {
            dpProductDate.Enabled = cbHasProductDate.Checked;
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            if (PubGlobal.JhBillModel == null)
            {
                MessageBox.Show("错误：该商品未列入采购单。");
                return;
            }

            PubGlobal.JhBillModel.SsPackCount = decimal.Parse(tbSsPackCount.Text);
            PubGlobal.JhBillModel.SsSGLCount = decimal.Parse(tbSsSglCount.Text);
            PubGlobal.JhBillModel.ScDate=cbHasProductDate.Checked?dpProductDate.Value.ToString("yyyy-MM-dd"):string.Empty;
            PubGlobal.JhBillModel.SsCount =PubGlobal.JhBillModel.PackQty * PubGlobal.JhBillModel.SsPackCount
                + PubGlobal.JhBillModel.SsSGLCount;
            PubGlobal.JhBillModel.Checked = "Y";
            string msg;
       
            if (!JhBillDAL.SaveBill(PubGlobal.JhBillModel, out msg))
            {
                MessageBox.Show("保存验收明细错误：" + msg);
                return;
            }
            PubGlobal.JhBillModel = null;
            PubGlobal.Cur_TRFQueryPlu.Clear();
            PubGlobal.Cur_TRFQueryPlu = null;
            ReFlush();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            frmJhBillMx.ShowDialog();
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

        private void cSideBtn1_OnPressRightButton(object sender, EventArgs e)
        {
            cScanner1.Read();
        }

        private void FrmJhPluQuery_Closing(object sender, CancelEventArgs e)
        {
            #if (HasDevice)
            cSideBtn1.Close();
            cScanner1.Close();
            #endif

        }

    }
}