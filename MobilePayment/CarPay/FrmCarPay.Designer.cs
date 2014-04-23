namespace MobilePayment.CarPay
{
    partial class FrmCarPay
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbYfMoney = new System.Windows.Forms.TextBox();
            this.tbYEMoney = new System.Windows.Forms.TextBox();
            this.tbPayList = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMdModey = new System.Windows.Forms.TextBox();
            this.TxbJf = new System.Windows.Forms.TextBox();
            this.TxbQuan = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cPrinter1 = new Devices.CPrinter(this.components);
            this.cEmvpbocVip = new Devices.CEmvpboc(this.components);
            this.cEmvpbocBank = new Devices.CEmvpboc(this.components);
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_1.Text = "支付";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_2.Text = "免单";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_3.Text = "完成";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Text = "取消";
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "应付";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "余额";
            // 
            // tbYfMoney
            // 
            this.tbYfMoney.BackColor = System.Drawing.Color.Black;
            this.tbYfMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbYfMoney.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.tbYfMoney.ForeColor = System.Drawing.Color.White;
            this.tbYfMoney.Location = new System.Drawing.Point(90, 0);
            this.tbYfMoney.Name = "tbYfMoney";
            this.tbYfMoney.ReadOnly = true;
            this.tbYfMoney.Size = new System.Drawing.Size(128, 35);
            this.tbYfMoney.TabIndex = 5;
            this.tbYfMoney.Text = "630.00";
            // 
            // tbYEMoney
            // 
            this.tbYEMoney.BackColor = System.Drawing.Color.Black;
            this.tbYEMoney.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbYEMoney.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.tbYEMoney.ForeColor = System.Drawing.Color.White;
            this.tbYEMoney.Location = new System.Drawing.Point(90, 39);
            this.tbYEMoney.Name = "tbYEMoney";
            this.tbYEMoney.ReadOnly = true;
            this.tbYEMoney.Size = new System.Drawing.Size(128, 35);
            this.tbYEMoney.TabIndex = 6;
            this.tbYEMoney.Text = "630.00";
            // 
            // tbPayList
            // 
            this.tbPayList.BackColor = System.Drawing.Color.White;
            this.tbPayList.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPayList.Location = new System.Drawing.Point(3, 199);
            this.tbPayList.Multiline = true;
            this.tbPayList.Name = "tbPayList";
            this.tbPayList.ReadOnly = true;
            this.tbPayList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPayList.Size = new System.Drawing.Size(234, 62);
            this.tbPayList.TabIndex = 14;
            this.tbPayList.Text = "0-【银行卡】  10000元";
            this.tbPayList.TextChanged += new System.EventHandler(this.tbPayList_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(17, 164);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "    券";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(17, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "积分";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(17, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 20);
            this.label5.Text = "免单";
            // 
            // tbMdModey
            // 
            this.tbMdModey.BackColor = System.Drawing.Color.Black;
            this.tbMdModey.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbMdModey.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.tbMdModey.ForeColor = System.Drawing.Color.White;
            this.tbMdModey.Location = new System.Drawing.Point(90, 78);
            this.tbMdModey.Name = "tbMdModey";
            this.tbMdModey.ReadOnly = true;
            this.tbMdModey.Size = new System.Drawing.Size(128, 35);
            this.tbMdModey.TabIndex = 21;
            this.tbMdModey.Text = "0.00";
            // 
            // TxbJf
            // 
            this.TxbJf.BackColor = System.Drawing.Color.Black;
            this.TxbJf.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxbJf.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.TxbJf.ForeColor = System.Drawing.Color.White;
            this.TxbJf.Location = new System.Drawing.Point(90, 117);
            this.TxbJf.Name = "TxbJf";
            this.TxbJf.ReadOnly = true;
            this.TxbJf.Size = new System.Drawing.Size(43, 35);
            this.TxbJf.TabIndex = 22;
            this.TxbJf.Text = "0";
            // 
            // TxbQuan
            // 
            this.TxbQuan.BackColor = System.Drawing.Color.Black;
            this.TxbQuan.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxbQuan.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold);
            this.TxbQuan.ForeColor = System.Drawing.Color.White;
            this.TxbQuan.Location = new System.Drawing.Point(90, 156);
            this.TxbQuan.Name = "TxbQuan";
            this.TxbQuan.ReadOnly = true;
            this.TxbQuan.Size = new System.Drawing.Size(43, 35);
            this.TxbQuan.TabIndex = 23;
            this.TxbQuan.Text = "0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 24;
            this.button1.Text = "+";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 156);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 25;
            this.button2.Text = "+";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(183, 117);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(35, 35);
            this.button3.TabIndex = 26;
            this.button3.Text = "-";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(183, 156);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(35, 35);
            this.button4.TabIndex = 27;
            this.button4.Text = "-";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cPrinter1
            // 
            this.cPrinter1.AsciiFontHeight = ((byte)(24));
            this.cPrinter1.ExtendFontHeight = ((byte)(24));
            // 
            // cEmvpbocVip
            // 
            this.cEmvpbocVip.RefNoLength = 24;
            // 
            // cEmvpbocBank
            // 
            this.cEmvpbocBank.RefNoLength = 24;
            // 
            // FrmCarPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TxbQuan);
            this.Controls.Add(this.TxbJf);
            this.Controls.Add(this.tbMdModey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbYfMoney);
            this.Controls.Add(this.tbYEMoney);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbPayList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCarPay";
            this.Text = "frmPay";
            this.Load += new System.EventHandler(this.FrmPay_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmCarPay_Closing);
            this.Controls.SetChildIndex(this.tbPayList, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.tbYEMoney, 0);
            this.Controls.SetChildIndex(this.tbYfMoney, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.tbMdModey, 0);
            this.Controls.SetChildIndex(this.TxbJf, 0);
            this.Controls.SetChildIndex(this.TxbQuan, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbYfMoney;
        private System.Windows.Forms.TextBox tbYEMoney;
        private System.Windows.Forms.TextBox tbPayList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMdModey;
        private System.Windows.Forms.TextBox TxbJf;
        private System.Windows.Forms.TextBox TxbQuan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private Devices.CPrinter cPrinter1;
        private Devices.CEmvpboc cEmvpbocVip;
        private Devices.CEmvpboc cEmvpbocBank;
    }
}