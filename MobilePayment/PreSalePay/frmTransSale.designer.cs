namespace MobilePayment.PreSalePay
{
    partial class FrmTransSale
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
            this.tbSaleNo = new System.Windows.Forms.TextBox();
            this.tbSaleInfo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_1.Text = "查询";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_2.Text = "明细";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_3.Text = "结算";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.Text = "单号:";
            // 
            // tbSaleNo
            // 
            this.tbSaleNo.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbSaleNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSaleNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbSaleNo.ForeColor = System.Drawing.SystemColors.Window;
            this.tbSaleNo.Location = new System.Drawing.Point(54, 20);
            this.tbSaleNo.Name = "tbSaleNo";
            this.tbSaleNo.Size = new System.Drawing.Size(179, 26);
            this.tbSaleNo.TabIndex = 3;
            this.tbSaleNo.GotFocus += new System.EventHandler(this.tbSaleNo_GotFocus);
            // 
            // tbSaleInfo
            // 
            this.tbSaleInfo.BackColor = System.Drawing.Color.White;
            this.tbSaleInfo.Location = new System.Drawing.Point(3, 60);
            this.tbSaleInfo.Multiline = true;
            this.tbSaleInfo.Name = "tbSaleInfo";
            this.tbSaleInfo.ReadOnly = true;
            this.tbSaleInfo.Size = new System.Drawing.Size(234, 196);
            this.tbSaleInfo.TabIndex = 5;
            // 
            // FrmTransSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbSaleInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSaleNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmTransSale";
            this.Text = "TransSale";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.FrmTransSale_Load);
            this.Activated += new System.EventHandler(this.FrmTransSale_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmTransSale_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTransSale_KeyDown);
            this.Controls.SetChildIndex(this.tbSaleNo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.tbSaleInfo, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSaleNo;
        private System.Windows.Forms.TextBox tbSaleInfo;

    }
}