//#define debug
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using Devices;

namespace MobilePayment.SalePay
{
    public partial class FrmSalePlu : FrmBase
    {

        public FrmSalePlu()
        {
            InitializeComponent();

            bindingSource1.DataSource = PubGlobal.Cur_tSalSalePluList;
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
                    if (PubGlobal.Cur_tSalSalePluList.Count > 0)
                    {
                        CleanSalePlu();//总清
                    }
                    else
                    {
                        this.Close();
                    }
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
                    if (TxbCount.Focused)
                    {
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
            #region 生成tSalSale
            PubGlobal.Cur_tSalSale = new Model.CSalSale();
            PubGlobal.Cur_tSalSale.Operator = PubGlobal.Cur_User.UserCode;
            PubGlobal.Cur_tSalSale.VipCardno = PubGlobal.Cur_Vip == null ? string.Empty : PubGlobal.Cur_Vip.VipCardNo;
            PubGlobal.Cur_tSalSale.XsTime = DateTime.Now.ToString("HH:mm:ss");
            PubGlobal.Cur_tSalSale.XsDate = DateTime.Now.Date;
            PubGlobal.Cur_tSalSale.PosNo = PubGlobal.PosNo;
            PubGlobal.Cur_tSalSale.TradeType = PubGlobal.SaleBack ? "D" : "B";

            foreach (Model.CSalSalePlu salePlu in PubGlobal.Cur_tSalSalePluList)
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
                if (PubGlobal.SaleBack)
                {
                    button_1_Click(null, null);//退出退货模式
                }
            }
        }

        /// <summary>
        /// 会员卡
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_1_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_tSalSalePluList.Count > 0)
            {
                MessageBox.Show("请先清除当前录入的商品");
                return;
            }
            PubGlobal.SaleBack = !PubGlobal.SaleBack;
            button_1.Text = PubGlobal.SaleBack ? "返回销售" : "退货";
            button_1.ForeColor = PubGlobal.SaleBack ? Color.Red : Color.Black;
            TxbBarcode.Focus();
            TxbBarcode.SelectAll();
            //SideBtn.EndWatch();
            //if (EnterVipWin.ShowDialog() == DialogResult.OK)
            //{
            //    string msg;
            //    if (!DAL.DAL.VipDAL.GetVip(EnterVipWin.VipNo, out PubGlobal.Cur_Vip, out msg))
            //    {
            //        Buzzer.FailedBeep();
            //        MessageBox.Show(msg);
            //        return;
            //    }
            //    else
            //    {
            //        Buzzer.SuccessBeep();
            //        ShowVip();
            //    }
            //}

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
#if !debug
            #region 设备初始化
            cSideBtn1.Init();
            cSideBtn1.Open();
            cScanner1.Open();
            cBuzzer1.Init();
            cBuzzer1.Open();
            #endregion
#endif
            #region 初始化委托

            ShowPluDelegate = new ShowInfoDelegate(ShowPlu);
            ShowSalePluDelegate = new ShowInfoDelegate(ShowSalePlu);

            ShowMsgD = new ShowMsgDelegate(ShowMsg);
            #endregion


            #region 界面初始化
            PubGlobal.CloseCur_Trade();
            PubGlobal.SaleBack = false;//初始为销售模式
            button_1.Text = PubGlobal.SaleBack ? "返回销售" : "退货";
            button_1.ForeColor = PubGlobal.SaleBack ? Color.Red : Color.Black;
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
            PubGlobal.Cur_Plu = null;
            if (!Comm.Comm.GetGoods(code, out PubGlobal.Cur_Plu, out msg))
            {
                //MessageBox.Show("未找到该商品！");
#if !debug
                cBuzzer1.Beep(200);
                Thread.Sleep(400);
                cBuzzer1.Beep(200);
#endif
                this.Invoke(ShowMsgD, new string[] { "未找到该商品！" });
            }
#if !debug
            cBuzzer1.Beep(200);
#endif
            this.Invoke(ShowPluDelegate);//显示商品信息
            if (PubGlobal.Cur_Plu != null)
            {
                AddSalePlu();//增加商品流水
            }
        }


        /// <summary>
        /// 扫描会员
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
                Model.CSalSalePlu salePlu = PubGlobal.Cur_tSalSalePluList.Find(a => a.PluCode == PubGlobal.Cur_Plu.PluCode);
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
        private void ShowSalePlu(Model.CSalSalePlu salePlu)
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
            Model.CSalSalePlu salePlu = PubGlobal.Cur_tSalSalePluList.Find(a => a.PluCode == PubGlobal.Cur_Plu.PluCode);
            #endregion
            if (salePlu == null)
            {
                salePlu = new Model.CSalSalePlu() { PluCode = PubGlobal.Cur_Plu.PluCode, PluName = PubGlobal.Cur_Plu.PluName };
                PubGlobal.Cur_tSalSalePluList.Add(salePlu);
                salePlu.SerialNo = ++PubGlobal.SalePluSerialNo;
                salePlu.Price = PubGlobal.Cur_Plu.Price;
                salePlu.Unit = PubGlobal.Cur_Plu.Unit;
                salePlu.BarCode = PubGlobal.Cur_Plu.BarCode;
                salePlu.PosNo = PubGlobal.PosNo;
                salePlu.Operater = PubGlobal.Cur_User.UserCode;
                
            }
            salePlu.XsCount += PubGlobal.Cur_XsCount*(PubGlobal.SaleBack?-1:1);
            salePlu.FsPrice += salePlu.Price * salePlu.XsCount;
            this.Invoke(ShowSalePluDelegate);//显示商品明细流水
        }

        /// <summary>
        /// 总清
        /// </summary>
        private void CleanSalePlu()
        {
#if !debug
            cBuzzer1.Beep(200);
#endif
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
#if !debug
            cBuzzer1.Beep(200);
#endif
            if (MessageBox.Show("删除该商品？", "确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                PubGlobal.Cur_tSalSalePluList.Remove((Model.CSalSalePlu)bindingSource1.Current);
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
                    return;
                }

            }
#if !debug
            cScanner1.Close();
            cSideBtn1.Close();
            cBuzzer1.Close();
#endif
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

        private void cSideBtn1_OnPressRightButton(object sender, EventArgs e)
        {
            cScanner1.Read();
        }

        private void cScanner1_OnRecvData(object sender, ScanRecvDataEventArgs e)
        {
            GetPlu(e.DataValue.Replace("\r", string.Empty).Replace("\n", string.Empty));
        }

    }
}