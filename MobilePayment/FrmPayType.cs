using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePayment
{
    public partial class FrmPayType : FrmBase
    {
        public FrmPayType()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 付款方式结果
        /// </summary>
        public Model.CSalPayType PayType
        {
            get;
            set;
        }

        /// <summary>
        /// 初始化付款方式列表
        /// </summary>
        public void Init()
        {
            if (listView1.Items.Count == 0)
            {
                foreach (Model.CSalPayType type in PubGlobal.sPayTypes)
                {
                    ListViewItem li = new ListViewItem(type.PayName);
                    switch (type.PayType)
                    {
                        case "01":
                            //现金
                            li.ImageIndex = 0;
                            break;
                        case "03":
                            //银行卡
                            li.ImageIndex = 2;
                            break;
                        default:
                            li.ImageIndex = 1;
                            break;
                    }

                    li.Tag = type;
                    listView1.Items.Add(li);
                }
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            if (listView1.FocusedItem != null)
            {
                PayType = listView1.FocusedItem.Tag as Model.CSalPayType;
                this.DialogResult = DialogResult.OK;
            }
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}