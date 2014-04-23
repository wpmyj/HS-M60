using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using Devices;

namespace MobilePayment.PreSalePay
{
    public partial class FrmTransSale : FrmBase
    {
        public FrmTransSale()
        {
            InitializeComponent();

            #region 初始化委托
            RecvPluDelegate = new RecvScanDelegate(RecvScanPlu);
            showScanDlegate = new ShowScanDelegate(ShowScan);
            #endregion

            #region 初始化侧键按钮
            SideBtn.SetLeftBtn(null);
            #endregion
        }

        #region 侧键操作
        delegate void SideBtnClick();//侧键点击委托
        /// <summary>
        /// 点击右键
        /// </summary>
        private void RightClick()
        {
            Scanner.Read(RecvPluDelegate);
        }

        #endregion

        #region 扫描器委托
        delegate void RecvScanDelegate(IntPtr ptr, int i);//扫描回调委托 
        RecvScanDelegate RecvPluDelegate;
        /// <summary>
        /// 扫描到商品信息
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="i"></param>
        public void RecvScanPlu(IntPtr ptr, int i)
        {
            // M60API.SCAN_AWAKE_CONTROL(false);//休眠扫描头
            byte[] buff = new byte[i];
            Marshal.Copy(ptr, buff, 0, i);
            string str = Encoding.UTF8.GetString(buff, 0, i).Replace("\r", string.Empty).Replace("\n", string.Empty);
            if (string.IsNullOrEmpty(str))
            {
                return;
            }
            else
            {
                this.Invoke(showScanDlegate, str);
            }
        }


        delegate void ShowScanDelegate(string str);
        ShowScanDelegate showScanDlegate;
        /// <summary>
        /// 显示扫描信息
        /// </summary>
        /// <param name="str"></param>
        private void ShowScan(string str)
        {
            tbSaleNo.Text = str;
            tbSaleNo.Focus();
            tbSaleNo.SelectAll();
            button_1_Click(null, null);
        }
        #endregion



        /// <summary>
        /// 下一步
        /// </summary>
        protected  void NextStep()
        {
            if (tbSaleNo.Focused && !string.IsNullOrEmpty(tbSaleNo.Text.Trim()))
            {
                //输入焦点在流水框
                //点击确定进行查询流水
                button_1_Click(null, null);
            }
        }

        /// <summary>
        /// 上一步
        /// </summary>
        protected  void PreStep()
        {
            button_4_Click(null, null);
        }

        #region 窗口定义
        FrmSalePay PayWin = new FrmSalePay();
        FrmTransList TransListWin = new FrmTransList();
        #endregion

        private void button_1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSaleNo.Text))
            {
                return;
            }
            ShowWait();
            #region 服务器查询
            string msg;
            if (!Comm.Comm.ScanSale(PubGlobal_hs.OrgCode, PubGlobal_hs.User.UserCode, PubGlobal_hs.User.Password, tbSaleNo.Text.Trim(), out PubGlobal_hs.Cur_tSalSale, out msg))
            {
                MessageBox.Show(msg);
            }
            #endregion
            HideWait();
            ShowTrade();
            tbSaleNo.Focus();
            tbSaleNo.SelectAll();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (PubGlobal_hs.Cur_tSalSale != null)
            {
                PayWin.ShowDialog() ;
                
                tbSaleNo.Focus();
                
                ShowTrade();
            }
            else
            {
                MessageBox.Show("请先查询流水！");
            }
            tbSaleNo.Focus();
            tbSaleNo.SelectAll();
        }

        /// <summary>
        /// 显示交易信息
        /// </summary>
        public void ShowTrade()
        {
            if (PubGlobal_hs.Cur_tSalSale != null)
            {
                tbSaleNo.Text = PubGlobal_hs.Cur_tSalSale.SALENO;
                StringBuilder Sbuilder = new StringBuilder();
                Sbuilder.AppendFormat("会员卡号：{0}\r\n", PubGlobal_hs.Cur_tSalSale.VIPCARDNO);
                Sbuilder.Append("------------------------------------------\r\n");
                Sbuilder.AppendFormat("应收金额：{0}\r\n", decimal.Parse(PubGlobal_hs.Cur_tSalSale.YSTOTAL).ToString("F2"));
                Sbuilder.AppendFormat("优惠金额：{0}\r\n", decimal.Parse(PubGlobal_hs.Cur_tSalSale.YHTOTAL).ToString("F2"));
                Sbuilder.AppendFormat("应付金额：{0}\r\n", PubGlobal_hs.Cur_Sale_YFTotal.ToString("F2"));
                tbSaleInfo.Text = Sbuilder.ToString();
            }
            else
            {
                tbSaleInfo.Text = string.Empty;
            }

            tbSaleNo.Focus();
            tbSaleNo.SelectAll();
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            PubGlobal_hs.CloseCur_Trade();
            ShowTrade();
            this.Close();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            if (PubGlobal_hs.Cur_tSalSale == null)
            {
                return;
            }
            ShowWait();
            #region 获取明细
            string msg;
            if(!Comm.Comm.ViewPlu(PubGlobal_hs.OrgCode,PubGlobal_hs.User.UserCode,PubGlobal_hs.User.Password,PubGlobal_hs.Cur_tSalSale.SALENO,out PubGlobal_hs.Cur_tSalSalePluList, out msg))
            {
                MessageBox.Show(msg);
            }
            #endregion
            HideWait();
            if (PubGlobal_hs.Cur_tSalSalePluList != null)
            {
                TransListWin.ShowDialog();
            }
            tbSaleNo.Focus();
            tbSaleNo.SelectAll();
        }

        private void FrmTransSale_Load(object sender, EventArgs e)
        {
            tbSaleNo.Text = string.Empty;
            ShowTrade();
        }

        private void tbSaleNo_GotFocus(object sender, EventArgs e)
        {
            tbSaleNo.SelectAll();
        }

        private void FrmTransSale_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    button_4_Click(null, null);
                    break;
                case Keys.Enter:
                    if (!string.IsNullOrEmpty(tbSaleNo.Text))
                    {
                        button_1_Click(null, null);
                    }
                    break;
            }
        }

        private void FrmTransSale_Activated(object sender, EventArgs e)
        {
            SideBtn.SetLeftBtn(null);
            SideBtn.SetRightBtn(new SideBtnClick(RightClick));
            SideBtn.StatWatch();
        }

        private void FrmTransSale_Closing(object sender, CancelEventArgs e)
        {
            SideBtn.EndWatch();//停止侧键
        }
    }
}