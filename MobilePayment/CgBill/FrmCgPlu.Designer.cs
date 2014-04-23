namespace MobilePayment.CgBill
{
    partial class FrmCgPlu
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
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.tbSpec = new System.Windows.Forms.TextBox();
            this.tbPluName = new System.Windows.Forms.TextBox();
            this.tbPluCode = new System.Windows.Forms.TextBox();
            this.tbBarcode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbSglCount = new System.Windows.Forms.TextBox();
            this.tbPackCount = new System.Windows.Forms.TextBox();
            this.cbxPackSpec = new System.Windows.Forms.ComboBox();
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
            this.tbUnit.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbUnit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbUnit.ForeColor = System.Drawing.SystemColors.Window;
            this.tbUnit.Location = new System.Drawing.Point(198, 117);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.ReadOnly = true;
            this.tbUnit.Size = new System.Drawing.Size(30, 26);
            this.tbUnit.TabIndex = 29;
            this.tbUnit.Text = "件";
            // 
            // tbSpec
            // 
            this.tbSpec.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSpec.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbSpec.ForeColor = System.Drawing.SystemColors.Window;
            this.tbSpec.Location = new System.Drawing.Point(90, 117);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.ReadOnly = true;
            this.tbSpec.Size = new System.Drawing.Size(60, 26);
            this.tbSpec.TabIndex = 28;
            this.tbSpec.Text = "100ml";
            // 
            // tbPluName
            // 
            this.tbPluName.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbPluName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPluName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPluName.ForeColor = System.Drawing.SystemColors.Window;
            this.tbPluName.Location = new System.Drawing.Point(90, 80);
            this.tbPluName.Name = "tbPluName";
            this.tbPluName.ReadOnly = true;
            this.tbPluName.Size = new System.Drawing.Size(138, 26);
            this.tbPluName.TabIndex = 27;
            this.tbPluName.Text = "商品名称";
            // 
            // tbPluCode
            // 
            this.tbPluCode.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbPluCode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPluCode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPluCode.ForeColor = System.Drawing.SystemColors.Window;
            this.tbPluCode.Location = new System.Drawing.Point(90, 43);
            this.tbPluCode.Name = "tbPluCode";
            this.tbPluCode.ReadOnly = true;
            this.tbPluCode.Size = new System.Drawing.Size(138, 26);
            this.tbPluCode.TabIndex = 26;
            this.tbPluCode.Text = "1234567891234";
            // 
            // tbBarcode
            // 
            this.tbBarcode.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbBarcode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbBarcode.ForeColor = System.Drawing.SystemColors.Window;
            this.tbBarcode.Location = new System.Drawing.Point(90, 6);
            this.tbBarcode.Name = "tbBarcode";
            this.tbBarcode.ReadOnly = true;
            this.tbBarcode.Size = new System.Drawing.Size(138, 26);
            this.tbBarcode.TabIndex = 25;
            this.tbBarcode.Text = "1234567891234";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(156, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "单位";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "规格";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(19, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 20);
            this.label8.Text = "商品编码";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "商品名称";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "条码";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "包装单位";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(19, 234);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 20);
            this.label7.Text = "单件数";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(19, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.Text = "包装数";
            // 
            // tbSglCount
            // 
            this.tbSglCount.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbSglCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSglCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbSglCount.ForeColor = System.Drawing.SystemColors.Window;
            this.tbSglCount.Location = new System.Drawing.Point(90, 228);
            this.tbSglCount.Name = "tbSglCount";
            this.tbSglCount.Size = new System.Drawing.Size(70, 26);
            this.tbSglCount.TabIndex = 41;
            this.tbSglCount.Text = "0";
            // 
            // tbPackCount
            // 
            this.tbPackCount.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbPackCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPackCount.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPackCount.ForeColor = System.Drawing.SystemColors.Window;
            this.tbPackCount.Location = new System.Drawing.Point(90, 191);
            this.tbPackCount.Name = "tbPackCount";
            this.tbPackCount.Size = new System.Drawing.Size(70, 26);
            this.tbPackCount.TabIndex = 42;
            this.tbPackCount.Text = "0";
            // 
            // cbxPackSpec
            // 
            this.cbxPackSpec.BackColor = System.Drawing.Color.Black;
            this.cbxPackSpec.DisplayMember = "PackSpec";
            this.cbxPackSpec.ForeColor = System.Drawing.Color.White;
            this.cbxPackSpec.Location = new System.Drawing.Point(90, 157);
            this.cbxPackSpec.Name = "cbxPackSpec";
            this.cbxPackSpec.Size = new System.Drawing.Size(138, 23);
            this.cbxPackSpec.TabIndex = 52;
            this.cbxPackSpec.ValueMember = "PACKETID";
            this.cbxPackSpec.SelectedValueChanged += new System.EventHandler(this.cbxPackSpec_SelectedValueChanged);
            // 
            // FrmCgPlu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.cbxPackSpec);
            this.Controls.Add(this.tbPackCount);
            this.Controls.Add(this.tbSglCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUnit);
            this.Controls.Add(this.tbSpec);
            this.Controls.Add(this.tbPluName);
            this.Controls.Add(this.tbPluCode);
            this.Controls.Add(this.tbBarcode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCgPlu";
            this.Text = "FrmCgBill";
            this.Load += new System.EventHandler(this.FrmCgPlu_Load);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.tbBarcode, 0);
            this.Controls.SetChildIndex(this.tbPluCode, 0);
            this.Controls.SetChildIndex(this.tbPluName, 0);
            this.Controls.SetChildIndex(this.tbSpec, 0);
            this.Controls.SetChildIndex(this.tbUnit, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.tbSglCount, 0);
            this.Controls.SetChildIndex(this.tbPackCount, 0);
            this.Controls.SetChildIndex(this.cbxPackSpec, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbUnit;
        private System.Windows.Forms.TextBox tbSpec;
        private System.Windows.Forms.TextBox tbPluName;
        private System.Windows.Forms.TextBox tbPluCode;
        private System.Windows.Forms.TextBox tbBarcode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSglCount;
        private System.Windows.Forms.TextBox tbPackCount;
        private System.Windows.Forms.ComboBox cbxPackSpec;
    }
}