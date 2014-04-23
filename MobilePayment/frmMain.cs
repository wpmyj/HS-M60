using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Base;
using MobilePayment.CarPay;
using MobilePayment.SalePay;
using Model.TransModel;
using Pub;
using MobilePayment.CgBill;
using DAL;
using MobilePayment.JhBill;
using MobilePayment.PdBill;
namespace MobilePayment
{
    public partial class FrmMain : FrmBase
    {
        public FrmMain()
        {
            InitializeComponent();

        }


        #region 子窗口
        FrmLogin frmLogin = new FrmLogin();
        FrmTransSale frmPay = new FrmTransSale();
        FrmCarPark frmCarPay = new FrmCarPark();
        FrmKcQuery frmKcQuery = new FrmKcQuery();
        FrmCgBillSend frmCgBillSend = new FrmCgBillSend();
        FrmJhPluQuery frmJhPluQuery = new FrmJhPluQuery();
        FrmJhBillSend frmJhBillSend = new FrmJhBillSend();
        FrmPdPluQuery frmPdPluQuery = new FrmPdPluQuery();
        FrmPdBillSend frmPdBillSend = new FrmPdBillSend();
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            //分辨率
            //int i=Win32.GetSystemMetrics(0);
            //int y = Win32.GetSystemMetrics(1);

            //Console.WriteLine(i.ToString() + "|" + y.ToString());

            try
            {

                string msg;

                if (!BaseDAL.Open(PubGlobal.LocalDbConnection, out msg))
                {
                    MessageBox.Show("本地数据库打开失败。" + msg);
                }
                if (!ProvinceDAL.LoadProvince(out PubGlobal.ProvinceMap, out msg))
                {//读取省份
                    MessageBox.Show("省份读取错误：" + msg);
                }
                #region 读取本地参数

                StreamReader Sr = new StreamReader(PubGlobal.ConfigPath);

                while (!Sr.EndOfStream)
                {
                    string s=Sr.ReadLine();

                    if (string.IsNullOrEmpty(s))
                    {
                        continue;
                    }
                    else
                    {
                        string[] ss = s.Split('=');
                        switch (ss[0])
                        {
                            case "PosNo":
                                PubGlobal.PosNo = ss[1];
                                break;
                            case "ExeFilePath_Bank":
                                PubGlobal.ExeFilePath_Bank = ss[1];
                                break;
                            case "InFilePath_Bank":
                                PubGlobal.InFilePath_Bank = ss[1];
                                break;
                            case "OutFilePath_Bank":
                                PubGlobal.OutFilePath_Bank = ss[1];
                                break;
                            case "ExeFilePath_Vip":
                                PubGlobal.ExeFilePath_Vip = ss[1];
                                break;
                            case "InFilePath_Vip":
                                PubGlobal.InFilePath_Vip = ss[1];
                                break;
                            case "OutFilePath_Vip":
                                PubGlobal.OutFilePath_Vip = ss[1];
                                break;
                            case "WSURL":
                                Comm.Comm.URL = ss[1];
                                break;
                            case "ScanMode":
                                PubGlobal.ScanMode = int.Parse(ss[1]);
                                break;
                            case "OrgCode":
                                PubGlobal.OrgCode = ss[1];
                                break;
                            case "BillHead":
                                PubGlobal.BillHead = ss[1];
                                break;
                            case "BillFoot1":
                                PubGlobal.BillFoot1 = ss[1];
                                break;
                            case "BillFoot2":
                                PubGlobal.BillFoot2 = ss[1];
                                break;
                            case "BillFoot3":
                                PubGlobal.BillFoot3 = ss[1];
                                break;
                            case "DefaultProvince":
                                foreach (string key in PubGlobal.ProvinceMap.Keys)
                                {
                                    if (PubGlobal.ProvinceMap[key].Equals( ss[1]))
                                    {
                                        PubGlobal.DefaultProvince = key;
                                        break;
                                    }
                                }
                                break;
                            default:
                                continue;
                        }
                    }
                }
                Sr.Close();
                #endregion

                cEmvpbocBank.ExeFilePath = PubGlobal.ExeFilePath_Bank;
                cEmvpbocBank.InDataFilePath = PubGlobal.InFilePath_Bank;
                cEmvpbocBank.OutDataFilePath = PubGlobal.OutFilePath_Bank;

                cEmvpbocVip.ExeFilePath = PubGlobal.ExeFilePath_Vip;
                cEmvpbocVip.InDataFilePath = PubGlobal.InFilePath_Vip;
                cEmvpbocVip.OutDataFilePath = PubGlobal.OutFilePath_Vip;
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统参数错误！", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            try
            {
                ////初始化打印机
                //if (!Printer.Init(0, 0, 24, 24, 0))
                //{
                //    MessageBox.Show("打印机初始化失败");
                //}
                ////初始化扫描头
                //Scanner.Init(PubGlobal.ScanMode);
                //Scanner.Open();
                ////初始化侧键
                //SideBtn.Init();
                ////初始化蜂鸣器
                //Buzzer.Init();
                //if (!Buzzer.Open())
                //{
                //    MessageBox.Show("蜂鸣器打开失败");
                //}
            }
            catch 
            {
                MessageBox.Show("设备初始化失败");
            }
            Login();
        }

        /// <summary>
        /// 登陆操作
        /// </summary>
        private void Login()
        {
            string msg;
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                ShowWait("正获取系统信息\r\n请稍候...");
                if (!Comm.Comm.GetPayModeFunc(PubGlobal.OrgCode,PubGlobal.User.UserCode,PubGlobal.User.Password,ref PubGlobal.sPayTypes,out msg))//登陆成功，读取付款方式参数
                {
                    MessageBox.Show("付款方式列表获取失败："+msg);
                }
                if (!Comm.Comm.GetBillPre(PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, out msg))
                {
                    MessageBox.Show("业务类型编码获取失败：" + msg);
                }
                //清空功能列表
                listView1.Items.Clear();
                foreach (UserRight right in PubGlobal.User.Rights)
                {
                    if (right.ISENABLE == "1")
                    {
                        ListViewItem lvItem = new ListViewItem(right.FUNNAME);
                        lvItem.Tag = right.FUNCODE;
                        int index = int.Parse(right.FUNCODE);
                        if (index > imageList1.Images.Count-1)
                        {
                            lvItem.ImageIndex = 0;
                        }
                        else
                        {
                            lvItem.ImageIndex = int.Parse(right.FUNCODE);
                        }
                        listView1.Items.Add(lvItem);
                    }
                }
                HideWait();
            }
            else
            {
                Rectangle rectangle = Screen.PrimaryScreen.Bounds;
                PubGlobal.SetFullScreen(false, ref rectangle);//false为恢复状态栏
                this.Close();
            }
        }

        private  void button_4_Click(object sender, EventArgs e)
        {
            PubGlobal.User = null;
            this.Hide();
            Login();
            this.Show();
        }

        /// <summary>
        /// 点击菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_ItemActivate(object sender, EventArgs e)
        {
                switch (listView1.FocusedItem.Tag.ToString())
                {
                    case "01"://停车收费
                        frmCarPay.ShowDialog();
                        break;
                    case "02"://消费支付
                        frmPay.ShowDialog();
                        break;
                    case "03"://库存查询、订货
                        frmKcQuery.ShowDialog();
                        break;
                    case "04"://订货确认
                        frmCgBillSend.ShowDialog();
                        break;
                    case "05"://验收
                        frmJhPluQuery.ShowDialog();
                        break;
                    case "06"://验收确认
                        frmJhBillSend.ShowDialog();
                        break;
                    case "07"://盘点
                        frmPdPluQuery.ShowDialog();
                        break;
                    case "08"://盘点确认
                        frmPdBillSend.ShowDialog();
                        break;
                    case "09"://结账
                        Settle();
                        break;
                }
        }


        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        private void Settle()
        {
            if (MessageBox.Show("结账将发送未上传流水，银联流水结算清空，确认要进行结账？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
            {
                return;
            }
            string msg;
            string ReturnMsg=string.Empty;
            ShowWait("正在结算...请稍候");
            if (!SalSalePayDAL.GetSalSalePay(out PubGlobal.Cur_tSalSalePayList, out msg))
            {
                MessageBox.Show("获取流水失败：" + msg);
            }
            else
            {
                if(PubGlobal.Cur_tSalSalePayList.Count>0 && !Comm.Comm.RecvPay(PubGlobal.OrgCode, PubGlobal.User.UserCode, PubGlobal.User.Password, PubGlobal.Cur_tSalSalePayList, "1", ref ReturnMsg, out msg))
                {
                    MessageBox.Show(msg);
                }

                PubGlobal.Cur_tSalSalePayList.Clear();
            }
            if (!cEmvpbocBank.Action(Devices.CEmvpboc.ActionType.结算, out msg))
            {
                MessageBox.Show("银行结算失败：" + msg);
            }
            if (!cEmvpbocVip.Action(Devices.CEmvpboc.ActionType.结算, out msg))
            {
                MessageBox.Show("储值卡结算失败：" + msg);
            }
            HideWait();
        }

    }
}