namespace MobilePayment.JhBill
{
    partial class FrmJhBillInit
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
            this.rbIsCgJh = new System.Windows.Forms.RadioButton();
            this.rbIsNotCgJh = new System.Windows.Forms.RadioButton();
            this.tbRefBillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbRefBillNo = new System.Windows.Forms.Label();
            this.tbCkCode = new System.Windows.Forms.TextBox();
            this.tbPreRefBillNo = new System.Windows.Forms.TextBox();
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
            // rbIsCgJh
            // 
            this.rbIsCgJh.Checked = true;
            this.rbIsCgJh.Location = new System.Drawing.Point(27, 85);
            this.rbIsCgJh.Name = "rbIsCgJh";
            this.rbIsCgJh.Size = new System.Drawing.Size(100, 20);
            this.rbIsCgJh.TabIndex = 0;
            this.rbIsCgJh.Text = "采购验收";
            this.rbIsCgJh.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbIsNotCgJh
            // 
            this.rbIsNotCgJh.Location = new System.Drawing.Point(122, 85);
            this.rbIsNotCgJh.Name = "rbIsNotCgJh";
            this.rbIsNotCgJh.Size = new System.Drawing.Size(100, 20);
            this.rbIsNotCgJh.TabIndex = 1;
            this.rbIsNotCgJh.TabStop = false;
            this.rbIsNotCgJh.Text = "无采购验收";
            // 
            // tbRefBillNo
            // 
            this.tbRefBillNo.BackColor = System.Drawing.Color.Black;
            this.tbRefBillNo.ForeColor = System.Drawing.Color.White;
            this.tbRefBillNo.Location = new System.Drawing.Point(132, 129);
            this.tbRefBillNo.Name = "tbRefBillNo";
            this.tbRefBillNo.Size = new System.Drawing.Size(97, 23);
            this.tbRefBillNo.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "仓库编码";
            // 
            // lbRefBillNo
            // 
            this.lbRefBillNo.Location = new System.Drawing.Point(6, 132);
            this.lbRefBillNo.Name = "lbRefBillNo";
            this.lbRefBillNo.Size = new System.Drawing.Size(100, 20);
            this.lbRefBillNo.Text = "订 单 号";
            // 
            // tbCkCode
            // 
            this.tbCkCode.BackColor = System.Drawing.Color.Black;
            this.tbCkCode.ForeColor = System.Drawing.Color.White;
            this.tbCkCode.Location = new System.Drawing.Point(75, 167);
            this.tbCkCode.Name = "tbCkCode";
            this.tbCkCode.Size = new System.Drawing.Size(154, 23);
            this.tbCkCode.TabIndex = 4;
            // 
            // tbPreRefBillNo
            // 
            this.tbPreRefBillNo.BackColor = System.Drawing.Color.Black;
            this.tbPreRefBillNo.ForeColor = System.Drawing.Color.Gray;
            this.tbPreRefBillNo.Location = new System.Drawing.Point(75, 129);
            this.tbPreRefBillNo.Name = "tbPreRefBillNo";
            this.tbPreRefBillNo.ReadOnly = true;
            this.tbPreRefBillNo.Size = new System.Drawing.Size(57, 23);
            this.tbPreRefBillNo.TabIndex = 9;
            this.tbPreRefBillNo.GotFocus += new System.EventHandler(this.tbPreRefBillNo_GotFocus);
            // 
            // FrmJhBillInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.tbPreRefBillNo);
            this.Controls.Add(this.tbCkCode);
            this.Controls.Add(this.rbIsNotCgJh);
            this.Controls.Add(this.tbRefBillNo);
            this.Controls.Add(this.rbIsCgJh);
            this.Controls.Add(this.lbRefBillNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmJhBillInit";
            this.Text = "新建验收单";
            this.Load += new System.EventHandler(this.FrmJhBillInit_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lbRefBillNo, 0);
            this.Controls.SetChildIndex(this.rbIsCgJh, 0);
            this.Controls.SetChildIndex(this.tbRefBillNo, 0);
            this.Controls.SetChildIndex(this.rbIsNotCgJh, 0);
            this.Controls.SetChildIndex(this.tbCkCode, 0);
            this.Controls.SetChildIndex(this.tbPreRefBillNo, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbIsCgJh;
        private System.Windows.Forms.RadioButton rbIsNotCgJh;
        private System.Windows.Forms.TextBox tbRefBillNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbRefBillNo;
        private System.Windows.Forms.TextBox tbCkCode;
        private System.Windows.Forms.TextBox tbPreRefBillNo;
    }
}