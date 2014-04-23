using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Devices;
using System.Threading;

namespace MobilePayment
{
    public partial class FrmEnterVip : Form
    {

        #region 侧键操作
        delegate void SideBtnClick();//侧键点击委托
        /// <summary>
        /// 点击右键
        /// </summary>
        private void RightClick()
        {
            Scanner.Read(recvScanVipDelegate);
        }

        #endregion

        public string VipNo
        {
            get;
            set;
        }

        public FrmEnterVip()
        {
            InitializeComponent();
            recvScanVipDelegate = new RecvScanVipDelegate(RecvScanVip);
            this.Location =
                new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);

            CancelCloseDelegate = new CloseDelegate(CancelClose);
            OKCloseDelegate = new CloseDelegate(OKClose);
            showMsgDelegate = new ShowMsgDelegate(ShowMsg);
        }

        private void FrmEnterVip_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (!string.IsNullOrEmpty(TxbVipNo.Text.Trim()))
                    {
                        VipNo = TxbVipNo.Text.Trim();
                        OKClose();
                    }
                    break;
                case Keys.Escape:
                    ReadCard = false;
                    break;
            }
        }

        bool ReadCard = true;
        /// <summary>
        /// 读卡线程
        /// </summary>
        private void ReadCardFun()
        {
            string info;
            string msg;
            Mcr_606_Reader.Open();
            Mcr_606_Reader.GetAuthor();
            //Mcr_606_Reader.Open();
            string track1, track2, track3;
            track1 = string.Empty;
            track2 = string.Empty;
            track3 = string.Empty;
            while (ReadCard)
            {
                if (Mcr_606_Reader.Check())
                {
                    //读卡成功
                    if (Mcr_606_Reader.ReadTranck(ref track1, ref track2, ref track3, out msg))
                    {
                        if (string.IsNullOrEmpty(track2))
                        {
                            this.Invoke(CancelCloseDelegate);
                        }
                        VipNo = track2.Substring(0,track2.IndexOf('\0'));
                        this.Invoke(OKCloseDelegate);
                        break;
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(200);
                }
            }
            Mcr_606_Reader.Reset();
            Mcr_606_Reader.Close();


            if (!ReadCard)
            {
                if (string.IsNullOrEmpty(VipNo))
                {
                    //刷卡被取消
                    this.Invoke(CancelCloseDelegate);
                }
                else
                {
                    this.Invoke(OKCloseDelegate);
                }
            }

        }


        #region 扫描事件委托
        delegate void RecvScanVipDelegate(IntPtr ptr, int len);
        RecvScanVipDelegate recvScanVipDelegate;

        /// <summary>
        /// 扫描到会员信息
        /// </summary>
        /// <param name="ptr"></param>
        /// <param name="i"></param>
        public void RecvScanVip(IntPtr ptr, int i)
        {
            byte[] buff = new byte[i];
            Marshal.Copy(ptr, buff, 0, i);
            string str = Encoding.UTF8.GetString(buff, 0, i).Replace("\r", string.Empty).Replace("\n",string.Empty);
            VipNo = str;
            ReadCard = false;
        }
        #endregion


        #region 关闭窗口委托
        delegate void CloseDelegate();//关闭窗口委托

        CloseDelegate CancelCloseDelegate;
        CloseDelegate OKCloseDelegate;

        /// <summary>
        /// 取消并关闭
        /// </summary>
        private void CancelClose()
        {
            this.DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 成功并关闭
        /// </summary>
        private void OKClose()
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion


        #region 显示消息委托
        delegate void ShowMsgDelegate(string msg);
        ShowMsgDelegate showMsgDelegate;
        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="msg"></param>
        private void ShowMsg(string msg)
        {
            MessageBox.Show(msg);
        }
        #endregion



        private void FrmEnterVip_Closing(object sender, CancelEventArgs e)
        {
            SideBtn.EndWatch();
        }

        private void FrmEnterVip_Load(object sender, EventArgs e)
        {
            VipNo = string.Empty;
            TxbVipNo.Focus();
            ReadCard = true;
            SideBtn.StatWatch();
            SideBtn.SetLeftBtn(null);
            SideBtn.SetRightBtn(new SideBtnClick(RightClick));
            Thread ReadCardThread = new Thread(ReadCardFun);
            ReadCardThread.IsBackground = true;
            ReadCardThread.Start();//开启读卡线程
        }
    }
}