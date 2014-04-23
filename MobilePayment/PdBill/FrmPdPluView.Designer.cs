namespace MobilePayment.PdBill
{
    partial class FrmPdPluView
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
            this.tbLastQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUnit = new System.Windows.Forms.TextBox();
            this.tbSpec = new System.Windows.Forms.TextBox();
            this.tbPluName = new System.Windows.Forms.TextBox();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_1.Visible = false;
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.button_2.Visible = false;
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
            // tbLastQty
            // 
            this.tbLastQty.BackColor = System.Drawing.Color.Black;
            this.tbLastQty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbLastQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbLastQty.ForeColor = System.Drawing.Color.Gray;
            this.tbLastQty.Location = new System.Drawing.Point(71, 178);
            this.tbLastQty.Name = "tbLastQty";
            this.tbLastQty.ReadOnly = true;
            this.tbLastQty.Size = new System.Drawing.Size(157, 26);
            this.tbLastQty.TabIndex = 56;
            this.tbLastQty.Text = "88888";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 184);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.Text = "已盘件数";
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.Black;
            this.tbPrice.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPrice.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPrice.ForeColor = System.Drawing.Color.Gray;
            this.tbPrice.Location = new System.Drawing.Point(71, 134);
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.ReadOnly = true;
            this.tbPrice.Size = new System.Drawing.Size(157, 26);
            this.tbPrice.TabIndex = 55;
            this.tbPrice.Text = "88888.88";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "售价";
            // 
            // tbUnit
            // 
            this.tbUnit.BackColor = System.Drawing.Color.Black;
            this.tbUnit.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbUnit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbUnit.ForeColor = System.Drawing.Color.Gray;
            this.tbUnit.Location = new System.Drawing.Point(198, 92);
            this.tbUnit.Name = "tbUnit";
            this.tbUnit.ReadOnly = true;
            this.tbUnit.Size = new System.Drawing.Size(30, 26);
            this.tbUnit.TabIndex = 54;
            this.tbUnit.Text = "件";
            // 
            // tbSpec
            // 
            this.tbSpec.BackColor = System.Drawing.Color.Black;
            this.tbSpec.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbSpec.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbSpec.ForeColor = System.Drawing.Color.Gray;
            this.tbSpec.Location = new System.Drawing.Point(71, 92);
            this.tbSpec.Name = "tbSpec";
            this.tbSpec.ReadOnly = true;
            this.tbSpec.Size = new System.Drawing.Size(60, 26);
            this.tbSpec.TabIndex = 53;
            this.tbSpec.Text = "100ml";
            // 
            // tbPluName
            // 
            this.tbPluName.BackColor = System.Drawing.Color.Black;
            this.tbPluName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tbPluName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.tbPluName.ForeColor = System.Drawing.Color.Gray;
            this.tbPluName.Location = new System.Drawing.Point(71, 50);
            this.tbPluName.Name = "tbPluName";
            this.tbPluName.ReadOnly = true;
            this.tbPluName.Size = new System.Drawing.Size(157, 26);
            this.tbPluName.TabIndex = 52;
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
            this.tbCode.TabIndex = 51;
            this.tbCode.Text = "1234567891234";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(149, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "单位";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "规格";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 55);
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
            // FrmPdPluView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbLastQty);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbUnit);
            this.Controls.Add(this.tbSpec);
            this.Controls.Add(this.tbPluName);
            this.Controls.Add(this.tbCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPdPluView";
            this.Text = "FrmPdPluView";
            this.Activated += new System.EventHandler(this.FrmPdPluView_Activated);
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
            this.Controls.SetChildIndex(this.tbPrice, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.tbLastQty, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbLastQty;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUnit;
        private System.Windows.Forms.TextBox tbSpec;
        private System.Windows.Forms.TextBox tbPluName;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}