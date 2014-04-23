namespace MobilePayment.Report
{
    partial class FrmCasherRpt
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
            this.DtPStart = new System.Windows.Forms.DateTimePicker();
            this.DtPEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_1.Text = "刷新";
            this.button_1.Click += new System.EventHandler(this.button_1_Click);
            // 
            // button_2
            // 
            this.button_2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_2.Visible = false;
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_3.Visible = false;
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // DtPStart
            // 
            this.DtPStart.Location = new System.Drawing.Point(98, 16);
            this.DtPStart.Name = "DtPStart";
            this.DtPStart.Size = new System.Drawing.Size(129, 24);
            this.DtPStart.TabIndex = 7;
            // 
            // DtPEnd
            // 
            this.DtPEnd.Location = new System.Drawing.Point(98, 46);
            this.DtPEnd.Name = "DtPEnd";
            this.DtPEnd.Size = new System.Drawing.Size(129, 24);
            this.DtPEnd.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.Text = "开始时间";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(20, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "结束时间";
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            this.bindingSource1.DataSource = typeof(Model.VCashRpt);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.DataSource = this.bindingSource1;
            this.dataGrid1.Location = new System.Drawing.Point(3, 90);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(234, 171);
            this.dataGrid1.TabIndex = 13;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.MappingName = "VCashRpt";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "支付方式";
            this.dataGridTextBoxColumn1.MappingName = "ZfName";
            this.dataGridTextBoxColumn1.Width = 100;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "F2";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "金额";
            this.dataGridTextBoxColumn2.MappingName = "total";
            this.dataGridTextBoxColumn2.Width = 100;
            // 
            // FrmCasherRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.DtPEnd);
            this.Controls.Add(this.DtPStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCasherRpt";
            this.Text = "FrmCasherRpt";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmCasherRpt_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCasherRpt_KeyDown);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.DtPStart, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.DtPEnd, 0);
            this.Controls.SetChildIndex(this.dataGrid1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker DtPStart;
        private System.Windows.Forms.DateTimePicker DtPEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
    }
}