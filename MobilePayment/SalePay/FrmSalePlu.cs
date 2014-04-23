using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Devices;
using System.Runtime.InteropServices;

namespace MobilePayment.SalePay
{
    public partial class FrmSalePlu : FrmBase
    {
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
                GetPlu(str);
            }
        }

        #endregion

        public FrmSalePlu()
        {
            InitializeComponent();

            bindingSource1.DataSource = PubGlobal.Cur_tSalSalePluList;

            #region 初始化委托
            RecvPluDelegate = new RecvScanDelegate(RecvScanPlu);

            ShowPluDelegate = new ShowInfoDelegate(ShowPlu);
            ShowSalePluDelegate = new ShowInfoDelegate(ShowSalePlu);

            ShowMsgD = new ShowMsgDelegate(ShowMsg);
            #endregion

            #region 初始化侧键按钮
            SideBtn.SetLeftBtn(null);
            #endregion
        }

        #region 窗口初始化
        FrmSalePay SalePayWin = new FrmSalePay();
        FrmEnterVip EnterVipWin = new FrmEnterVip();
        #endregion

        #region 按键操作
        private void FrmSalePlu_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape://退出
                    this.Close();
                    break;
                case Keys.Delete://总清
                    CleanSalePlu();
                    break;
                case Keys.F1://上
                    if (PubGlobal.Cur_tSalSalePluList.Count > 0)
                    {
                        PreSalePlu();
                    }
                    break;
                case Keys.F2://下
                    if (PubGlobal.Cur_tSalSalePluList.Count > 0)
                    {
                        NextSalePlu();
                    }
                    break;
                case Keys.Enter://点击确定
                    if (TxbBarcode.Focused)
                    {
                        GetPlu(TxbBarcode.Text);//检索商品
                        TxbBarcode.Focus();
                        TxbBarcode.SelectAll();
                    }
                    break;
            }
        }
        #endregion

        #region 按钮操作
        /// <summary>
        /// 数量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_3_Click(object sender, EventArgs e)
        {
            TxbCount.Focus();
            TxbCount.SelectAll();
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_4_Click(object sender, EventArgs e)
        {
            SideBtn.EndWatch();
            #region 生成tSalSale
            PubGlobal.Cur_tSalSale = new Model.TSalSale();
            PubGlobal.Cur_tSalSale.Operator = PubGlobal.Cur_User.UserCode;
            PubGlobal.Cur_tSalSale.VipCardno = PubGlobal.Cur_Vip == null ? string.Empty : PubGlobal.Cur_Vip.VipCardNo;
            PubGlobal.Cur_tSalSale.XsTime = DateTime.Now;
            PubGlobal.Cur_tSalSale.XsDate = DateTime.Now.ToString("yyyy-MM-dd");
            foreach (Model.TSalSalePlu salePlu in PubGlobal.Cur_tSalSalePluList)
            {
                PubGlobal.Cur_tSalSale.YsTotal += salePlu.FsPrice;
            }
            PubGlobal.Cur_tSalSale.VipDsc=PubGlobal.Cur_Vip == null ? 100:PubGlobal.Cur_Vip.VipDsc;
            PubGlobal.Cur_tSalSale.YhTotal = PubGlobal.Cur_tSalSale.YsTotal * (100-PubGlobal.Cur_tSalSale.VipDsc) / 100;
            PubGlobal.Cur_tSalSale.SsTotal = 0;
            #endregion

            if (SalePayWin.ShowDialog() == DialogResult.OK)
            {
                //交易成功
                PubGlobal.CloseCur_Trade();
                ShowPlu();
                ShowVip();
                ShowSalePlu();
            }
        }
        /// <summary>
        /// 会员卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_1_Click(object sender, EventArgs e)
        {
            SideBtn.EndWatch();
            if (EnterVipWin.ShowDialog() == DialogResult.OK)
            {
                string msg;
                if (!DAL.DAL.VipDAL.GetVip(EnterVipWin.VipNo, out PubGlobal.Cur_Vip, out msg))
                {
                    Buzzer.FailedBeep();
                    MessageBox.Show(msg);
                    return;
                }
                else
                {
                    Buzzer.SuccessBeep();
                    ShowVip();
                }
            }

        }
        /// <summary>
        /// 行清
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_2_Click(object sender, EventArgs e)
        {
            RemoveSalePlu();
        }

        #endregion

        #region 初始化
        private void FrmSalePlu_Load(object sender, EventArgs e)
        {

            #region 界面初始化
            PubGlobal.CloseCur_Trade();
            ShowPlu();
            ShowVip();
            #endregion
        }

        #endregion

        #region 获取信息
        /// <summary>
        /// 增加扫描的商品
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private void GetPlu(string code)
        {
            string msg;
            if (string.IsNullOrEmpty(code.Trim()))
            {
                //读取Code为空，返回false
                return ;
            }
            Model.TPlu plu;
            if (code.Length >= 13)
            {
                //条码
                if (!DAL.DAL.PluDAL.GetByBarcode(code, out plu))
                {
                    //MessageBox.Show("未找到该商品！");
                    Buzzer.FailedBeep();
                    this.Invoke(ShowMsgD, new string[] { "未找到该商品！" });
                    plu = null;
                }
            }
            else
            {
                //商品编码
                 plu= new Model.TPlu() { PluCode = code };
                 if (!DAL.DAL.PluDAL.Load(ref plu, out msg))
                {
                    //未找到对象,返回错误 
                    Buzzer.FailedBeep();
                    this.Invoke(ShowMsgD, new string[] { "未找到该商品！" });
                    plu = null;
                }
            }
            PubGlobal.Cur_Plu = plu;

            this.Invoke(ShowPluDelegate);//显示商品信息
            if (PubGlobal.Cur_Plu != null)
            {
                Buzzer.SuccessBeep();
                AddSalePlu();//增加商品流水
            }
        }


        /// <summary>
        /// 增加扫描商品
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        private void GetVip(string code)
        {

        }

        #endregion

        #region 显示信息

        delegate void ShowInfoDelegate();//显示信息委托
        delegate void ShowMsgDelegate(string msg);

        ShowInfoDelegate ShowPluDelegate;
        ShowInfoDelegate ShowSalePluDelegate;

        ShowMsgDelegate ShowMsgD;
        /// <summary>
        /// 显示商品信息
        /// </summary>
        private void ShowPlu()
        {
            if (PubGlobal.Cur_Plu != null)
            {
                TxbBarcode.Text = PubGlobal.Cur_Plu.BarCode;
                TxbPluName.Text = PubGlobal.Cur_Plu.PluName;
                TxbPrice.Text = PubGlobal.Cur_Plu.Price.ToString("F2");
            }
            else
            {
                TxbBarcode.Text = string.Empty;
                TxbPluName.Text = string.Empty;
                TxbPrice.Text = "0.00";
                TxbCount.Text = "1";
            }

            TxbBarcode.Focus();
            TxbBarcode.SelectAll();
        }

        /// <summary>
        /// 显示会员信息
        /// </summary>
        private void ShowVip()
        {
            if (PubGlobal.Cur_Vip != null)
            {
                TxbVipCardNo.Text = PubGlobal.Cur_Vip.VipCardNo;
                TxbVipName.Text = PubGlobal.Cur_Vip.VipName;
                TxbVipDsc.Text = PubGlobal.Cur_Vip.VipDsc.ToString();
            }
            else
            {
                TxbVipCardNo.Text = string.Empty;
                TxbVipName.Text = string.Empty;
                TxbVipDsc.Text = "100";
            }
        }

        /// <summary>
        /// 显示商品扫描记录
        /// </summary>
        private void ShowSalePlu()
        {
            bindingSource1.ResetBindings(true);
            if (PubGlobal.Cur_Plu != null)
            {
                Model.TSalSalePlu salePlu = PubGlobal.Cur_tSalSalePluList.Find(a => a.PluCode == PubGlobal.Cur_Plu.PluCode);
                if (salePlu != null)
                {
                    SelectSalePlu(salePlu.SerialNo - 1);
                }
            }
            TxbCount.Text = "1";
        }
        /// <summary>
        /// 显示选定的商品信息
        /// </summary>
        /// <param name="salePlu"></param>
        private void ShowSalePlu(Model.TSalSalePlu salePlu)
        {
            TxbCount.Text = salePlu.XsCount.ToString();
            TxbBarcode.Text = salePlu.BarCode;
            TxbPluName.Text = salePlu.PluName;
            TxbPrice.Text = salePlu.Price.ToString("F2");
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        private void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
        }
        #endregion
        
        #region 明细流水操作
        /// <summary>
        /// 增加商品流水
        /// </summary>
        private void AddSalePlu()
        {
            #region 检测是否已有该商品
            Model.TSalSalePlu salePlu = PubGlobal.Cur_tSalSalePluList.Find(a => a.PluCode == PubGlobal.Cur_Plu.PluCode);
            #endregion
            if (salePlu == null)
            {
                salePlu = new Model.TSalSalePlu() { PluCode = PubGlobal.Cur_Plu.PluCode, PluName = PubGlobal.Cur_Plu.PluName };
                PubGlobal.Cur_tSalSalePluList.Add(salePlu);
                salePlu.SerialNo = ++PubGlobal.SalePluSerialNo;
                salePlu.Price = PubGlobal.Cur_Plu.Price;
                salePlu.Unit = PubGlobal.Cur_Plu.Unit;
                salePlu.BarCode = PubGlobal.Cur_Plu.BarCode;
            }
            salePlu.XsCount += PubGlobal.Cur_XsCount;
            salePlu.FsPrice += salePlu.Price * salePlu.XsCount;
            this.Invoke(ShowSalePluDelegate);//显示商品明细流水
        }

        /// <summary>
        /// 总清
        /// </summary>
        private void CleanSalePlu()
        {
            if (MessageBox.Show("清除所有商品？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                PubGlobal.CloseCur_Trade();
                ShowPlu();
                ShowVip();
                ShowSalePlu();
            }
        }

        /// <summary>
        /// 行清
        /// </summary>
        private void RemoveSalePlu()
        {
            if (MessageBox.Show("删除该商品？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                PubGlobal.Cur_tSalSalePluList.Remove((Model.TSalSalePlu)bindingSource1.Current);
                for (int i = 0; i < PubGlobal.Cur_tSalSalePluList.Count; i++)
                {
                    PubGlobal.Cur_tSalSalePluList[i].SerialNo = i + 1;//重置行号
                }
                ShowSalePlu();
            }
        }

        /// <summary>
        /// 上一条
        /// </summary>
        private void PreSalePlu()
        {
            int rowNo = dataGrid1.CurrentRowIndex - 1;
            if (rowNo >= 0)
            {
                dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
                dataGrid1.Select(rowNo);
                dataGrid1.CurrentRowIndex = rowNo;

                ShowSalePlu(PubGlobal.Cur_tSalSalePluList[rowNo]);
            }

        }
        /// <summary>
        /// 下一条
        /// </summary>
        private void NextSalePlu()
        {
            int rowNo = dataGrid1.CurrentRowIndex + 1;
            if (rowNo <PubGlobal.Cur_tSalSalePluList.Count)
            {
                dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
                dataGrid1.Select(rowNo);
                dataGrid1.CurrentRowIndex = rowNo;

                ShowSalePlu(PubGlobal.Cur_tSalSalePluList[rowNo]);
            }
        }

        /// <summary>
        /// 选取指定列
        /// </summary>
        /// <param name="rowNo"></param>
        private void SelectSalePlu(int rowNo)
        {
            if (rowNo < PubGlobal.Cur_tSalSalePluList.Count && rowNo>=0)
            {
                dataGrid1.UnSelect(dataGrid1.CurrentRowIndex);
                dataGrid1.Select(rowNo);
                dataGrid1.CurrentRowIndex = rowNo;

                ShowSalePlu(PubGlobal.Cur_tSalSalePluList[rowNo]);
            }
        }

        /// <summary>
        /// 点击列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGrid1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_tSalSalePluList.Count > 0)
            {
                int rowNo = dataGrid1.CurrentCell.RowNumber;
                ShowSalePlu(PubGlobal.Cur_tSalSalePluList[rowNo]);
            }
        }



        #endregion

        private void FrmSalePlu_Closing(object sender, CancelEventArgs e)
        {
            if (PubGlobal.Cur_tSalSale != null)
            {
                if (MessageBox.Show("有未结算商品，确定退出销售界面?", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    PubGlobal.CloseCur_Trade();
                }
                else
                {
                    //放弃退出
                    e.Cancel = true;
                }

            }
            SideBtn.EndWatch();//停止侧键
        }

        private void TxbCount_TextChanged(object sender, EventArgs e)
        {
            if (TxbCount.Text == string.Empty)
            {
                TxbCount.Text = "1";
                TxbCount.Focus();
                TxbCount.SelectAll();
            }
            try
            {
                PubGlobal.Cur_XsCount = decimal.Parse(TxbCount.Text);
            }
            catch
            {
                MessageBox.Show("数量非法！");
                TxbCount.Text = "1";
            }
        }

        private void FrmSalePlu_Activated(object sender, EventArgs e)
        {
            SideBtn.SetLeftBtn(null);
            SideBtn.SetRightBtn(new SideBtnClick(RightClick));
            SideBtn.StatWatch();

        }

    }
}