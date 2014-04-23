using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Pub;
using Base;

namespace MobilePayment.CarPay
{
    public partial class FrmCarPark : FrmBase
    {

        #region 显示车号委托
        delegate void DlgShowRecvCarNo(string Province,string carNo);
        DlgShowRecvCarNo dlgShowRecvCarNo;

        /// <summary>
        /// 从条码解析车号，并显示
        /// </summary>
        /// <param name="Province"></param>
        /// <param name="No"></param>
        private void ShowRecvCarNo(string Province,string No)
        {
            btnCard.Tag = Province;
            btnCard.Text = PubGlobal.ProvinceMap[Province].ToString();
            tbCarNo.Value = No;
            button_2_Click(null, null);
        }
        #endregion

        public FrmCarPark()
        {
            InitializeComponent();
            dlgShowRecvCarNo = new DlgShowRecvCarNo(ShowRecvCarNo);
        }

        #region 窗口定义
        FrmCarPay PayWin = new FrmCarPay();
        FrmCarNoBox CarNoWin = new FrmCarNoBox();
        #endregion

        
        protected override void NextStep()
        {
            base.NextStep();
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            string msg;
            string returnMsg=string.Empty;
            ShowWait("正保存停车记录...请稍候...");
            if (Comm.Comm.RecvParkFunc(PubGlobal.Cur_License, PubGlobal.MobileIp, PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.USERNAME, PubGlobal.User.Password, ref returnMsg, out msg))
            {
                //停车成功，打印停车小票
                cPrinter1.Init();
                cPrinter1.PrintCode128(btnCard.Tag.ToString() + tbCarNo.Value.Trim(), Devices.Code128.Encode.Code128B, 2, 80);
                cPrinter1.Feed(3);

                StringBuilder stringBuilder = new StringBuilder();
                int l = PubGlobal.BillHead.Length / 2 + 15 - 4;
                stringBuilder.AppendFormat("{0}{1}\n", new string[] { PubGlobal.BillHead.PadLeft(l), "停车小票" });
                stringBuilder.AppendFormat("    车号：{0}\n", PubGlobal.Cur_License);
                stringBuilder.AppendFormat("停车时间：{0}\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                if (!string.IsNullOrEmpty(PubGlobal.BillFoot1.Trim()))
                {
                    stringBuilder.AppendFormat("{0}\n", PubGlobal.BillFoot1);
                }
                if (!string.IsNullOrEmpty(PubGlobal.BillFoot2.Trim()))
                {
                    stringBuilder.AppendFormat("{0}\n", PubGlobal.BillFoot2);
                }
                if (!string.IsNullOrEmpty(PubGlobal.BillFoot3.Trim()))
                {
                    stringBuilder.AppendFormat("{0}\n", PubGlobal.BillFoot3);
                }
                cPrinter1.Print(stringBuilder.ToString());
                cPrinter1.Feed(6);
            }
            HideWait();
            tbCarInfo.Text = "【"+PubGlobal.Cur_License+"】"+msg;
            btnCard.Tag = PubGlobal.DefaultProvince;
            btnCard.Text = PubGlobal.ProvinceMap[PubGlobal.DefaultProvince].ToString();
            tbCarNo.Text = string.Empty;
            tbCarNo.Focus();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            string msg;
            ShowWait("正获取停车记录...请稍候...");
            if (Comm.Comm.GenParkChargeFunc(PubGlobal.Cur_License, PubGlobal.MobileIp,tbVipNo.Text.Trim(), PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.USERNAME, PubGlobal.User.Password, ref PubGlobal.Cur_tCarParkCharge, out msg))
            {
                HideWait();
                if (PubGlobal.Cur_tCarParkCharge[0].ID != "0")
                {
                    ShowParkCharge();
                }
                else
                {
                    tbCarInfo.Text = "停车数据不存在！";
                }
            }
            else
            {
                HideWait();
                tbCarInfo.Text = msg;
            }
            tbCarNo.Focus();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (PubGlobal.Cur_tCarParkCharge != null)
            {
                
                PayWin.ShowDialog();
            }
            btnCard.Tag = PubGlobal.DefaultProvince;
            btnCard.Text = PubGlobal.ProvinceMap[PubGlobal.DefaultProvince].ToString();
            tbCarNo.Text = string.Empty;
            tbCarNo.Focus();

            ShowParkCharge();

        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CarNoWin.ShowDialog() == DialogResult.OK)
            {
                btnCard.Text = CarNoWin.Value.Text=="无"?string.Empty:CarNoWin.Value.Text;
                btnCard.Tag = CarNoWin.Value.Tag;
                PubGlobal.Cur_License = btnCard.Text + tbCarNo.Text.ToUpper().Trim();
                tbCarNo.Focus();
            }
        }

        private void FrmCarPark_Load(object sender, EventArgs e)
        {
            btnCard.Tag = PubGlobal.DefaultProvince;
            btnCard.Text = PubGlobal.ProvinceMap[PubGlobal.DefaultProvince].ToString();
            tbCarNo.Text = string.Empty;
            tbVipNo.Text = string.Empty;
            ShowParkCharge();
            tbCarNo.Focus();
        }

        /// <summary>
        /// 显示当前停车信息
        /// </summary>
        private void ShowParkCharge()
        {
            if (PubGlobal.Cur_tCarParkCharge != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat("会员卡号：{0}\r\n停车积分余额：{1}\r\n车号：{2}\r\n时长：{3}\r\n提车时间：{4}\r\n应付：{5}",
                    new string[] { PubGlobal.Cur_tCarParkCharge[0].VIPNO,
                        PubGlobal.Cur_tCarParkCharge[0].JFYE,
                        PubGlobal.Cur_License,
                        PubGlobal.Cur_tCarParkCharge[0].HOUR,
                        PubGlobal.Cur_tCarParkCharge[0].OUTTIME,
                        PubGlobal.Cur_tCarParkCharge[0].CHARGE });
                tbCarInfo.Text = stringBuilder.ToString();
            }
            else
            {
                tbCarInfo.Text = string.Empty;
            }
        }

        private void tbCarNo_TextChanged(object sender, EventArgs e)
        {
            //tbCarNo.Text = tbCarNo.Text.ToUpper();
            //tbCarNo.Select(tbCarNo.Text.Length, 0);
            PubGlobal.Cur_License = btnCard.Text + tbCarNo.Value.Trim().ToUpper();
        }

        private void FrmCarPark_Activated(object sender, EventArgs e)
        {
            cSideBtn1.Init();
            cSideBtn1.Open();
            cScanner1.Open();
            cBuzzer1.Init();
            cBuzzer1.Open();
        }

        private void FrmCarPark_Closing(object sender, CancelEventArgs e)
        {
            cSideBtn1.Close();
            cScanner1.Close();
            cBuzzer1.Close();
        }

        private void cSideBtn1_OnPressRightButton(object sender, EventArgs e)
        {
            cScanner1.Read();
        }

        private void cScanner1_OnRecvData(object sender, Devices.ScanRecvDataEventArgs e)
        {
            string data=e.DataValue.Replace("\r",string.Empty).Replace("\n",string.Empty);
            if(data[0]=='X')
            {
                data=data.Substring(1);
            }
            cBuzzer1.Beep(500);
            this.Invoke(dlgShowRecvCarNo, data.Substring(0, 2), data.Substring(2));
        }
    }
}