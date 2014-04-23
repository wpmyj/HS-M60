namespace MobilePayment.CarPay
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
            this.components = new System.ComponentModel.Container();
            this.tbCarInfo = new System.Windows.Forms.TextBox();
            this.btnCard = new System.Windows.Forms.Button();
            this.cSideBtn1 = new Devices.CSideBtn(this.components);
            this.cScanner1 = new Devices.CScanner(this.components);
            this.cPrinter1 = new Devices.CPrinter(this.components);
            this.lbInputType = new System.Windows.Forms.Label();
            this.cBuzzer1 = new Devices.CBuzzer(this.components);
            this.tbCarNo = new IME.TextBoxWithIMET9();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVipNo = new System.Windows.Forms.TextBox();
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
            this.tbCarInfo.Location = new System.Drawing.Point(3, 113);
            this.tbCarInfo.Multiline = true;
            this.tbCarInfo.Name = "tbCarInfo";
            this.tbCarInfo.ReadOnly = true;
            this.tbCarInfo.Size = new System.Drawing.Size(231, 148);
            this.tbCarInfo.TabIndex = 6;
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
            // cSideBtn1
            // 
            this.cSideBtn1.OnPressRightButton += new System.EventHandler(this.cSideBtn1_OnPressRightButton);
            // 
            // cScanner1
            // 
            this.cScanner1.OnRecvData += new System.EventHandler<Devices.ScanRecvDataEventArgs>(this.cScanner1_OnRecvData);
            // 
            // cPrinter1
            // 
            this.cPrinter1.AsciiFontHeight = ((byte)(24));
            this.cPrinter1.ExtendFontHeight = ((byte)(24));
            // 
            // lbInputType
            // 
            this.lbInputType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbInputType.ForeColor = System.Drawing.Color.White;
            this.lbInputType.Location = new System.Drawing.Point(202, 40);
            this.lbInputType.Name = "lbInputType";
            this.lbInputType.Size = new System.Drawing.Size(30, 26);
            this.lbInputType.Text = "ABC";
            this.lbInputType.Visible = false;
            // 
            // cBuzzer1
            // 
            this.cBuzzer1.BeepFrequency = 8;
            // 
            // tbCarNo
            // 
            this.tbCarNo.BackColor = System.Drawing.Color.Black;
            this.tbCarNo.ForeColor = System.Drawing.Color.White;
            this.tbCarNo.IMESatus = IME.IMEName.数字;
            this.tbCarNo.Location = new System.Drawing.Point(56, 16);
            this.tbCarNo.Multiline = false;
            this.tbCarNo.Name = "tbCarNo";
            this.tbCarNo.PasswordChar = '\0';
            this.tbCarNo.ReadOnly = false;
            this.tbCarNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.tbCarNo.ShowIMEName = true;
            this.tbCarNo.Size = new System.Drawing.Size(178, 52);
            this.tbCarNo.SwitchIMEKey = System.Windows.Forms.Keys.F9;
            this.tbCarNo.TabIndex = 13;
            this.tbCarNo.Value = "";
            this.tbCarNo.ValueFont = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.tbCarNo.ValueChanged += new System.EventHandler<System.EventArgs>(this.tbCarNo_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "会员卡";
            // 
            // tbVipNo
            // 
            this.tbVipNo.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.tbVipNo.Location = new System.Drawing.Point(56, 78);
            this.tbVipNo.Name = "tbVipNo";
            this.tbVipNo.Size = new System.Drawing.Size(176, 29);
            this.tbVipNo.TabIndex = 16;
            // 
            // FrmCarPark
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbVipNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbCarNo);
            this.Controls.Add(this.lbInputType);
            this.Controls.Add(this.btnCard);
            this.Controls.Add(this.tbCarInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCarPark";
            this.Text = "frmCarPay";
            this.Load += new System.EventHandler(this.FrmCarPark_Load);
            this.Activated += new System.EventHandler(this.FrmCarPark_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmCarPark_Closing);
            this.Controls.SetChildIndex(this.tbCarInfo, 0);
            this.Controls.SetChildIndex(this.btnCard, 0);
            this.Controls.SetChildIndex(this.lbInputType, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.tbCarNo, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.tbVipNo, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbCarInfo;
        private System.Windows.Forms.Button btnCard;
        private Devices.CSideBtn cSideBtn1;
        private Devices.CScanner cScanner1;
        private Devices.CPrinter cPrinter1;
        private System.Windows.Forms.Label lbInputType;
        private Devices.CBuzzer cBuzzer1;
        private IME.TextBoxWithIMET9 tbCarNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbVipNo;
    }
}