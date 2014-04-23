namespace MobilePayment.JhBill
{
    partial class FrmJhPluQuery
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
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.tbSpec = new System.Windows.Forms.TextBox();
            this.tbPluName = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxPackSpec = new System.Windows.Forms.ComboBox();
            this.tbSsPackCount = new System.Windows.Forms.TextBox();
            this.tbCgPackCount = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSsSglCount = new System.Windows.Forms.TextBox();
            this.tbCgSglCount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbHasProductDate = new System.Windows.Forms.CheckBox();
            this.dpProductDate = new System.Windows.Forms.DateTimePicker();
            this.cSideBtn1 = new Devices.CSideBtn(this.components);
            this.cScanner1 = new Devices.CScanner(this.components);
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_1.Text = "添加";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_2.Text = "";
            this.button_2.Visible = false;
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_3.Text = "明细";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // tbUnit
            // 
            this.tbUnit.BackColor = System.Drawing.Color.Black;
            this.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbUnit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbUnit.ForeColor = System.Drawing.Color.Gray;
            this.tbUnit.Location = new System.Drawing.Point(198, 82);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.ReadOnly = true;
            this.tbUnit.Size = new System.Drawing.Size(30, 26);
            this.tbUnit.TabIndex = 27;
            this.tbUnit.Text = "件";
            // 
            // tbSpec
            // 
            this.tbSpec.BackColor = System.Drawing.Color.Black;
            this.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSpec.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbSpec.ForeColor = System.Drawing.Color.Gray;
            this.tbSpec.Location = new System.Drawing.Point(71, 82);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.ReadOnly = true;
            this.tbSpec.Size = new System.Drawing.Size(60, 26);
            this.tbSpec.TabIndex = 26;
            this.tbSpec.Text = "100ml";
            // 
            // tbPluName
            // 
            this.tbPluName.BackColor = System.Drawing.Color.Black;
            this.tbPluName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPluName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPluName.ForeColor = System.Drawing.Color.Gray;
            this.tbPluName.Location = new System.Drawing.Point(71, 44);
            this.tbPluName.Name = "tbPluName";
            this.tbPluName.ReadOnly = true;
            this.tbPluName.Size = new System.Drawing.Size(157, 26);
            this.tbPluName.TabIndex = 25;
            this.tbPluName.Text = "商品名称";
            // 
            // tbCode
            // 
            this.tbCode.BackColor = System.Drawing.Color.Black;
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbCode.ForeColor = System.Drawing.SystemColors.Window;
            this.tbCode.Location = new System.Drawing.Point(71, 6);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(157, 26);
            this.tbCode.TabIndex = 24;
            this.tbCode.Text = "1234567891234";
            this.tbCode.GotFocus += new System.EventHandler(this.tbCode_GotFocus);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(149, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "单位";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "规格";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "商品名称";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "条码/编码";
            // 
            // cbxPackSpec
            // 
            this.cbxPackSpec.BackColor = System.Drawing.Color.Black;
            this.cbxPackSpec.DisplayMember = "PackSpec";
            this.cbxPackSpec.ForeColor = System.Drawing.Color.White;
            this.cbxPackSpec.Location = new System.Drawing.Point(71, 123);
            this.cbxPackSpec.Name = "cbxPackSpec";
            this.cbxPackSpec.Size = new System.Drawing.Size(157, 23);
            this.cbxPackSpec.TabIndex = 58;
            this.cbxPackSpec.ValueMember = "PACKETID";
            this.cbxPackSpec.SelectedValueChanged += new System.EventHandler(this.cbxPackSpec_SelectedValueChanged);
            // 
            // tbSsPackCount
            // 
            this.tbSsPackCount.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbSsPackCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSsPackCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbSsPackCount.ForeColor = System.Drawing.Color.White;
            this.tbSsPackCount.Location = new System.Drawing.Point(86, 196);
            this.tbSsPackCount.Name = "tbSsPackCount";
            this.tbSsPackCount.Size = new System.Drawing.Size(45, 26);
            this.tbSsPackCount.TabIndex = 57;
            this.tbSsPackCount.Text = "0";
            // 
            // tbCgPackCount
            // 
            this.tbCgPackCount.BackColor = System.Drawing.Color.Black;
            this.tbCgPackCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbCgPackCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbCgPackCount.ForeColor = System.Drawing.Color.Gray;
            this.tbCgPackCount.Location = new System.Drawing.Point(86, 234);
            this.tbCgPackCount.Name = "tbCgPackCount";
            this.tbCgPackCount.ReadOnly = true;
            this.tbCgPackCount.Size = new System.Drawing.Size(45, 26);
            this.tbCgPackCount.TabIndex = 56;
            this.tbCgPackCount.Text = "0";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.Text = "实收包装数";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.Text = "采购包装数";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "包装单位";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 164);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.Text = "生产日期";
            // 
            // tbSsSglCount
            // 
            this.tbSsSglCount.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbSsSglCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSsSglCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbSsSglCount.ForeColor = System.Drawing.Color.White;
            this.tbSsSglCount.Location = new System.Drawing.Point(183, 196);
            this.tbSsSglCount.Name = "tbSsSglCount";
            this.tbSsSglCount.Size = new System.Drawing.Size(45, 26);
            this.tbSsSglCount.TabIndex = 68;
            this.tbSsSglCount.Text = "0";
            // 
            // tbCgSglCount
            // 
            this.tbCgSglCount.BackColor = System.Drawing.Color.Black;
            this.tbCgSglCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbCgSglCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbCgSglCount.ForeColor = System.Drawing.Color.Gray;
            this.tbCgSglCount.Location = new System.Drawing.Point(183, 234);
            this.tbCgSglCount.Name = "tbCgSglCount";
            this.tbCgSglCount.ReadOnly = true;
            this.tbCgSglCount.Size = new System.Drawing.Size(45, 26);
            this.tbCgSglCount.TabIndex = 69;
            this.tbCgSglCount.Text = "0";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(133, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 20);
            this.label8.Text = "单件数";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(133, 240);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 20);
            this.label10.Text = "单件数";
            // 
            // cbHasProductDate
            // 
            this.cbHasProductDate.Location = new System.Drawing.Point(71, 164);
            this.cbHasProductDate.Name = "cbHasProductDate";
            this.cbHasProductDate.Size = new System.Drawing.Size(100, 20);
            this.cbHasProductDate.TabIndex = 92;
            this.cbHasProductDate.CheckStateChanged += new System.EventHandler(this.cbHasProductDate_CheckStateChanged);
            // 
            // dpProductDate
            // 
            this.dpProductDate.Enabled = false;
            this.dpProductDate.Location = new System.Drawing.Point(95, 160);
            this.dpProductDate.Name = "dpProductDate";
            this.dpProductDate.Size = new System.Drawing.Size(133, 24);
            this.dpProductDate.TabIndex = 93;
            // 
            // cSideBtn1
            // 
            this.cSideBtn1.OnPressRightButton += new System.EventHandler(this.cSideBtn1_OnPressRightButton);
            // 
            // cScanner1
            // 
            this.cScanner1.OnRecvData += new System.EventHandler<Devices.ScanRecvDataEventArgs>(this.cScanner1_OnRecvData);
            // 
            // FrmJhPluQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.dpProductDate);
            this.Controls.Add(this.cbHasProductDate);
            this.Controls.Add(this.tbSsSglCount);
            this.Controls.Add(this.tbCgSglCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxPackSpec);
            this.Controls.Add(this.tbSsPackCount);
            this.Controls.Add(this.tbCgPackCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUnit);
            this.Controls.Add(this.tbSpec);
            this.Controls.Add(this.tbPluName);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmJhPluQuery";
            this.Text = "FrmPluQuery";
            this.Load += new System.EventHandler(this.FrmJhPluQuery_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmJhPluQuery_Closing);
            this.Controls.SetChildIndex(this.label10, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbCode, 0);
            this.Controls.SetChildIndex(this.tbPluName, 0);
            this.Controls.SetChildIndex(this.tbSpec, 0);
            this.Controls.SetChildIndex(this.tbUnit, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.tbCgPackCount, 0);
            this.Controls.SetChildIndex(this.tbSsPackCount, 0);
            this.Controls.SetChildIndex(this.cbxPackSpec, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tbCgSglCount, 0);
            this.Controls.SetChildIndex(this.tbSsSglCount, 0);
            this.Controls.SetChildIndex(this.cbHasProductDate, 0);
            this.Controls.SetChildIndex(this.dpProductDate, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbUnit;
        private System.Windows.Forms.TextBox tbSpec;
        private System.Windows.Forms.TextBox tbPluName;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxPackSpec;
        private System.Windows.Forms.TextBox tbSsPackCount;
        private System.Windows.Forms.TextBox tbCgPackCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbSsSglCount;
        private System.Windows.Forms.TextBox tbCgSglCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox cbHasProductDate;
        private System.Windows.Forms.DateTimePicker dpProductDate;
        private Devices.CSideBtn cSideBtn1;
        private Devices.CScanner cScanner1;
    }
}