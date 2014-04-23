namespace MobilePayment.SalePay
{
    partial class FrmSalePay
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbYfMoney = new System.Windows.Forms.TextBox();
            this.tbNowMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPayList = new System.Windows.Forms.TextBox();
            this.cEmvpbocVip = new Devices.CEmvpboc(this.components);
            this.cPrinter1 = new Devices.CPrinter(this.components);
            this.cEmvpbocBank = new Devices.CEmvpboc(this.components);
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_1.Text = "支付";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_2.Visible = false;
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_3.Text = "完成";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Text = "取消";
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // tbYfMoney
            // 
            this.tbYfMoney.BackColor = System.Drawing.Color.Black;
            this.tbYfMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbYfMoney.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.tbYfMoney.ForeColor = System.Drawing.Color.White;
            this.tbYfMoney.Location = new System.Drawing.Point(90, 12);
            this.tbYfMoney.Name = "tbYfMoney";
            this.tbYfMoney.ReadOnly = true;
            this.tbYfMoney.Size = new System.Drawing.Size(128, 35);
            this.tbYfMoney.TabIndex = 25;
            this.tbYfMoney.Text = "630.00";
            // 
            // tbNowMoney
            // 
            this.tbNowMoney.BackColor = System.Drawing.Color.Black;
            this.tbNowMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNowMoney.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.tbNowMoney.ForeColor = System.Drawing.Color.White;
            this.tbNowMoney.Location = new System.Drawing.Point(90, 51);
            this.tbNowMoney.Name = "tbNowMoney";
            this.tbNowMoney.ReadOnly = true;
            this.tbNowMoney.Size = new System.Drawing.Size(128, 35);
            this.tbNowMoney.TabIndex = 26;
            this.tbNowMoney.Text = "0.00";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(17, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "已付";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "应付";
            // 
            // tbPayList
            // 
            this.tbPayList.BackColor = System.Drawing.Color.White;
            this.tbPayList.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPayList.Location = new System.Drawing.Point(6, 110);
            this.tbPayList.Multiline = true;
            this.tbPayList.Name = "tbPayList";
            this.tbPayList.ReadOnly = true;
            this.tbPayList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPayList.Size = new System.Drawing.Size(234, 151);
            this.tbPayList.TabIndex = 27;
            this.tbPayList.TextChanged += new System.EventHandler(this.tbPayList_TextChanged);
            // 
            // cPrinter1
            // 
            this.cPrinter1.AsciiFontHeight = ((byte)(24));
            this.cPrinter1.ExtendFontHeight = ((byte)(24));
            // 
            // FrmSalePay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbYfMoney);
            this.Controls.Add(this.tbNowMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPayList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSalePay";
            this.Text = "FrmPay";
            this.Load += new System.EventHandler(this.FrmPay_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmSalePay_Closing);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.tbPayList, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbNowMoney, 0);
            this.Controls.SetChildIndex(this.tbYfMoney, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbYfMoney;
        private System.Windows.Forms.TextBox tbNowMoney;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPayList;
        private Devices.CEmvpboc cEmvpbocVip;
        private Devices.CPrinter cPrinter1;
        private Devices.CEmvpboc cEmvpbocBank;
    }
}