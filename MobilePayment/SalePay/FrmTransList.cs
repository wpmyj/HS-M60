using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment.SalePay
{
    public partial class FrmTransList : FrmBase
    {
        public FrmTransList()
        {
            InitializeComponent();
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTransList_Load(object sender, EventArgs e)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.AppendFormat("{0}{1}\r\n",new string[]{"商品编码".PadRight(10),"商品名称".PadRight(20)});
            sBuilder.AppendFormat("{0}{1}{2}\r\n", new string[] { "单价".PadLeft(10), "数量".PadLeft(10), "金额".PadLeft(10) });
            sBuilder.Append("------------------------------------------\r\n");
            foreach (Model.TSalSalePlu plu in PubGlobal.Cur_tSalSalePluList)
            {
                sBuilder.AppendFormat("{0}{1}\r\n", new string[] { plu.PLUCODE.PadRight(10), plu.PLUNAME.PadRight(10) });
                sBuilder.AppendFormat("{0}{1}{2}\r\n", new string[] { plu.PRICE.PadLeft(10), plu.XSCOUNT.PadLeft(10), (decimal.Parse(plu.PRICE) * decimal.Parse(plu.XSCOUNT)).ToString().PadLeft(10) });
            }
            sBuilder.Append("------------------------------------------\r\n");
            sBuilder.AppendFormat("应收金额：{0}", PubGlobal.Cur_tSalSale.YSTOTAL);
            tbTransList.Text = sBuilder.ToString();
            //stBar.Text = "操作员：" + PubGlobal.sUserCode + "        日期：" + DateTime.Now.Date.ToShortDateString();
            ////调用webserver接口，显示订单明细
            //tbTransList.Text += "商品编码 " + "商品名称 " + "单价 " + "数量 " + "金额 " + "\r\n";
            //tbTransList.Text += "10012001 " + "实木衣柜 " + "15000.00 " + "1 " + "15000.00 " + "\r\n";
            //tbTransList.Text += "10012021 " + "沙发 " + "8000.00 " + "1 " + "8000.00 " + "\r\n";
            //tbTransList.Text += "10012055 " + "海信电视 " + "5000.00 " + "1 " + "5000.00 " + "\r\n";
            //tbTransList.Text += "------------------------------" + "\r\n";
            //tbTransList.Text += "应收金额：28000.00" + "\r\n";
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}