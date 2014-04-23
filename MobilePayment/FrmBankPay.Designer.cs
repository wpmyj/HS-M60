namespace MobilePayment
{
    partial class FrmBankPay
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbYfMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 20);
            this.label1.Text = "支付金额";
            // 
            // tbYfMoney
            // 
            this.tbYfMoney.BackColor = System.Drawing.Color.Black;
            this.tbYfMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbYfMoney.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.tbYfMoney.ForeColor = System.Drawing.Color.White;
            this.tbYfMoney.Location = new System.Drawing.Point(83, 11);
            this.tbYfMoney.Name = "tbYfMoney";
            this.tbYfMoney.ReadOnly = true;
            this.tbYfMoney.Size = new System.Drawing.Size(128, 35);
            this.tbYfMoney.TabIndex = 26;
            this.tbYfMoney.Text = "630.00";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(83, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "请刷卡...";
            // 
            // FrmBankPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(228, 107);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbYfMoney);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBankPay";
            this.Text = "银行卡";
            this.Load += new System.EventHandler(this.FrmBankPay_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmBankPay_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmBankPay_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbYfMoney;
        private System.Windows.Forms.Label label2;
    }
}