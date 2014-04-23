namespace MobilePayment.PdBill
{
    partial class FrmPdBillInit
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
            this.dpPdDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCkCode = new System.Windows.Forms.TextBox();
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
            this.button_3.Text = "确定";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular);
            this.button_4.Text = "取消";
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // dpPdDate
            // 
            this.dpPdDate.Location = new System.Drawing.Point(91, 77);
            this.dpPdDate.Name = "dpPdDate";
            this.dpPdDate.Size = new System.Drawing.Size(134, 24);
            this.dpPdDate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "盘点日期";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "仓库编码";
            // 
            // tbCkCode
            // 
            this.tbCkCode.Location = new System.Drawing.Point(91, 141);
            this.tbCkCode.Name = "tbCkCode";
            this.tbCkCode.Size = new System.Drawing.Size(134, 23);
            this.tbCkCode.TabIndex = 10;
            // 
            // FrmPdBillInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbCkCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dpPdDate);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmPdBillInit";
            this.Text = "FrmPdBillInit";
            this.Load += new System.EventHandler(this.FrmPdBillInit_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.dpPdDate, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tbCkCode, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dpPdDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCkCode;
    }
}