using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment.ParkCarPay
{
    public partial class FrmCarPark : FrmBase
    {
        public FrmCarPark()
        {
            InitializeComponent();
        }

        #region 窗口定义
        FrmCarPay PayWin = new FrmCarPay();
        FrmCarNoBox CarNoWin = new FrmCarNoBox();
        #endregion

        
        //protected override void NextStep()
        //{
        //    base.NextStep();
        //}

        private void button_1_Click(object sender, EventArgs e)
        {
            string msg;
            string returnMsg;
            ShowWait();
            if (Comm.Comm.RecvParkFunc(PubGlobal_hs.Cur_License, PubGlobal_hs.MobileIp, PubGlobal_hs.OrgCode, PubGlobal_hs.User.UserCode, PubGlobal_hs.User.USERNAME, PubGlobal_hs.User.Password, out returnMsg, out msg))
            {
                HideWait();
                tbCarInfo.Text = returnMsg;
            }
            else
            {
                HideWait();
                MessageBox.Show(msg);
            }
            tbCarNo.Focus();
            tbCarNo.SelectAll();
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            string msg;
            string returnMsg;
            ShowWait();
            if (Comm.Comm.GenParkChargeFunc(PubGlobal_hs.Cur_License, PubGlobal_hs.MobileIp, PubGlobal_hs.OrgCode, PubGlobal_hs.User.UserCode, PubGlobal_hs.User.USERNAME, PubGlobal_hs.User.Password, out PubGlobal_hs.Cur_tCarParkCharge, out msg))
            {
                HideWait();
                if (PubGlobal_hs.Cur_tCarParkCharge.ID != "0")
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
                MessageBox.Show(msg);
            }
            tbCarNo.Focus();
            tbCarNo.SelectAll();
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            if (PubGlobal_hs.Cur_tCarParkCharge != null)
            {
                PayWin.ShowDialog();

                tbCarNo.Focus();
                tbCarNo.SelectAll();

                ShowParkCharge();
            }


        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CarNoWin.ShowDialog() == DialogResult.OK)
            {
                btnCard.Text = CarNoWin.Value;
                PubGlobal_hs.Cur_License = btnCard.Text + tbCarNo.Text.ToUpper().Trim();
                tbCarNo.Focus();
            }
        }

        private void FrmCarPark_Load(object sender, EventArgs e)
        {
            tbCarNo.Text = string.Empty;
            ShowParkCharge();
            tbCarNo.Focus();
        }

        /// <summary>
        /// 显示当前停车信息
        /// </summary>
        private void ShowParkCharge()
        {
            if (PubGlobal_hs.Cur_tCarParkCharge != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.AppendFormat("会员卡号：{0}\r\n时长：{1}\r\n提车时间：{2}\r\n应付：{3}",
                    new string[] { PubGlobal_hs.Cur_tCarParkCharge.VIPNO,
                        PubGlobal_hs.Cur_tCarParkCharge.HOUR,
                        PubGlobal_hs.Cur_tCarParkCharge.OUTTIME,
                        PubGlobal_hs.Cur_tCarParkCharge.CHARGE });
                tbCarInfo.Text = stringBuilder.ToString();
            }
            else
            {
                tbCarInfo.Text = string.Empty;
            }
        }

        private void tbCarNo_TextChanged(object sender, EventArgs e)
        {
            PubGlobal_hs.Cur_License = btnCard.Text + tbCarNo.Text.ToUpper().Trim();
        }

        private void tbCarNo_GotFocus(object sender, EventArgs e)
        {
            tbCarNo.SelectAll();
        }

        private void FrmCarPark_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    button_4_Click(null, null);
                    break;
            }
        }
    }
}