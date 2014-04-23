namespace MobilePayment.CgBill
{
    partial class FrmKcQuery
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.tbPluName = new System.Windows.Forms.TextBox();
            this.tbSpec = new System.Windows.Forms.TextBox();
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.tbYhPrice = new System.Windows.Forms.TextBox();
            this.tbKcCount = new System.Windows.Forms.TextBox();
            this.cScanner1 = new Devices.CScanner(this.components);
            this.cSideBtn1 = new Devices.CSideBtn(this.components);
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_1.Text = "刷新";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_2.Text = "订货";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_3.Visible = false;
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "条码/编码";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "商品名称";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "规格";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(156, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "单位";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 232);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "库存数量";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(19, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "售价";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(19, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.Text = "促销价";
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbCode.ForeColor = System.Drawing.SystemColors.Window;
            this.tbCode.Location = new System.Drawing.Point(90, 6);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(138, 26);
            this.tbCode.TabIndex = 15;
            this.tbCode.Text = "1234567891234";
            // 
            // tbPluName
            // 
            this.tbPluName.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbPluName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPluName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPluName.ForeColor = System.Drawing.SystemColors.Window;
            this.tbPluName.Location = new System.Drawing.Point(90, 50);
            this.tbPluName.Name = "tbPluName";
            this.tbPluName.ReadOnly = true;
            this.tbPluName.Size = new System.Drawing.Size(138, 26);
            this.tbPluName.TabIndex = 17;
            this.tbPluName.Text = "商品名称";
            // 
            // tbSpec
            // 
            this.tbSpec.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSpec.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbSpec.ForeColor = System.Drawing.SystemColors.Window;
            this.tbSpec.Location = new System.Drawing.Point(90, 94);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.ReadOnly = true;
            this.tbSpec.Size = new System.Drawing.Size(60, 26);
            this.tbSpec.TabIndex = 18;
            this.tbSpec.Text = "100ml";
            // 
            // tbUnit
            // 
            this.tbUnit.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbUnit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbUnit.ForeColor = System.Drawing.SystemColors.Window;
            this.tbUnit.Location = new System.Drawing.Point(198, 94);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.ReadOnly = true;
            this.tbUnit.Size = new System.Drawing.Size(30, 26);
            this.tbUnit.TabIndex = 19;
            this.tbUnit.Text = "件";
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPrice.ForeColor = System.Drawing.SystemColors.Window;
            this.tbPrice.Location = new System.Drawing.Point(90, 138);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.ReadOnly = true;
            this.tbPrice.Size = new System.Drawing.Size(138, 26);
            this.tbPrice.TabIndex = 20;
            this.tbPrice.Text = "123456.00";
            // 
            // tbYhPrice
            // 
            this.tbYhPrice.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbYhPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbYhPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbYhPrice.ForeColor = System.Drawing.SystemColors.Window;
            this.tbYhPrice.Location = new System.Drawing.Point(90, 182);
            this.tbYhPrice.Name = "tbYhPrice";
            this.tbYhPrice.ReadOnly = true;
            this.tbYhPrice.Size = new System.Drawing.Size(138, 26);
            this.tbYhPrice.TabIndex = 21;
            this.tbYhPrice.Text = "123456.00";
            // 
            // tbKcCount
            // 
            this.tbKcCount.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbKcCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbKcCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbKcCount.ForeColor = System.Drawing.SystemColors.Window;
            this.tbKcCount.Location = new System.Drawing.Point(90, 226);
            this.tbKcCount.Name = "tbKcCount";
            this.tbKcCount.ReadOnly = true;
            this.tbKcCount.Size = new System.Drawing.Size(138, 26);
            this.tbKcCount.TabIndex = 22;
            this.tbKcCount.Text = "100ml";
            // 
            // cScanner1
            // 
            this.cScanner1.OnRecvData += new System.EventHandler<Devices.ScanRecvDataEventArgs>(this.cScanner1_OnRecvData);
            // 
            // cSideBtn1
            // 
            this.cSideBtn1.OnPressRightButton += new System.EventHandler(this.cSideBtn1_OnPressRightButton);
            // 
            // FrmKcQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbKcCount);
            this.Controls.Add(this.tbYhPrice);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.tbUnit);
            this.Controls.Add(this.tbSpec);
            this.Controls.Add(this.tbPluName);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmKcQuery";
            this.Text = "FrmStockSearch";
            this.Load += new System.EventHandler(this.FrmKcQuery_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmKcQuery_Closing);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.tbCode, 0);
            this.Controls.SetChildIndex(this.tbPluName, 0);
            this.Controls.SetChildIndex(this.tbSpec, 0);
            this.Controls.SetChildIndex(this.tbUnit, 0);
            this.Controls.SetChildIndex(this.tbPrice, 0);
            this.Controls.SetChildIndex(this.tbYhPrice, 0);
            this.Controls.SetChildIndex(this.tbKcCount, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.TextBox tbPluName;
        private System.Windows.Forms.TextBox tbSpec;
        private System.Windows.Forms.TextBox tbUnit;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.TextBox tbYhPrice;
        private System.Windows.Forms.TextBox tbKcCount;
        private Devices.CScanner cScanner1;
        private Devices.CSideBtn cSideBtn1;

    }
}