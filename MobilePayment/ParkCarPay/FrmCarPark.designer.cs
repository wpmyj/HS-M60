namespace MobilePayment.ParkCarPay
{
    partial class FrmCarPark
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
            this.tbCarInfo = new System.Windows.Forms.TextBox();
            this.tbCarNo = new System.Windows.Forms.TextBox();
            this.btnCard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_1.Text = "停车";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_2.Text = "提车";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_3.Text = "支付";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // tbCarInfo
            // 
            this.tbCarInfo.Location = new System.Drawing.Point(3, 74);
            this.tbCarInfo.Multiline = true;
            this.tbCarInfo.Name = "tbCarInfo";
            this.tbCarInfo.Size = new System.Drawing.Size(231, 187);
            this.tbCarInfo.TabIndex = 6;
            // 
            // tbCarNo
            // 
            this.tbCarNo.BackColor = System.Drawing.Color.Black;
            this.tbCarNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbCarNo.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.tbCarNo.ForeColor = System.Drawing.SystemColors.Window;
            this.tbCarNo.Location = new System.Drawing.Point(56, 16);
            this.tbCarNo.Name = "tbCarNo";
            this.tbCarNo.Size = new System.Drawing.Size(178, 52);
            this.tbCarNo.TabIndex = 9;
            this.tbCarNo.TextChanged += new System.EventHandler(this.tbCarNo_TextChanged);
            this.tbCarNo.GotFocus += new System.EventHandler(this.tbCarNo_GotFocus);
            // 
            // btnCard
            // 
            this.btnCard.BackColor = System.Drawing.Color.Silver;
            this.btnCard.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.btnCard.ForeColor = System.Drawing.Color.Black;
            this.btnCard.Location = new System.Drawing.Point(3, 16);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(47, 52);
            this.btnCard.TabIndex = 12;
            this.btnCard.Text = "鲁";
            this.btnCard.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmCarPark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.tbCarNo);
            this.Controls.Add(this.tbCarInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCarPark";
            this.Text = "frmCarPay";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.FrmCarPark_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCarPark_KeyDown);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.tbCarInfo, 0);
            this.Controls.SetChildIndex(this.tbCarNo, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.btnCard, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbCarInfo;
        private System.Windows.Forms.TextBox tbCarNo;
        private System.Windows.Forms.Button btnCard;
    }
}