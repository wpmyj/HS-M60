namespace MobilePayment.Report
{
    partial class FrmSalSaleRpt
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
            this.DtPStart = new System.Windows.Forms.DateTimePicker();
            this.DtPEnd = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
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
            this.button_2.Text = "定位";
            this.button_2.Click += new System.EventHandler(this.button_2_Click);
            // 
            // button_3
            // 
            this.button_3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_3.Text = "明细";
            this.button_3.Click += new System.EventHandler(this.button_3_Click);
            // 
            // button_4
            // 
            this.button_4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_4.Click += new System.EventHandler(this.button_4_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.Text = "开始日期";
            // 
            // DtPStart
            // 
            this.DtPStart.CustomFormat = "yyyy-MM-dd";
            this.DtPStart.Location = new System.Drawing.Point(102, 3);
            this.DtPStart.Name = "DtPStart";
            this.DtPStart.Size = new System.Drawing.Size(125, 24);
            this.DtPStart.TabIndex = 8;
            // 
            // DtPEnd
            // 
            this.DtPEnd.CustomFormat = "yyyy-MM-dd";
            this.DtPEnd.Location = new System.Drawing.Point(102, 33);
            this.DtPEnd.Name = "DtPEnd";
            this.DtPEnd.Size = new System.Drawing.Size(125, 24);
            this.DtPEnd.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.Text = "结束日期";
            // 
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            this.bindingSource1.DataSource = typeof(Model.TSalSale);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.DataSource = this.bindingSource1;
            this.dataGrid1.Location = new System.Drawing.Point(0, 63);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(237, 200);
            this.dataGrid1.TabIndex = 12;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.MappingName = "TSalSale";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "流水号";
            this.dataGridTextBoxColumn1.MappingName = "SaleNo";
            this.dataGridTextBoxColumn1.Width = 85;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "F2";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "交易金额";
            this.dataGridTextBoxColumn2.MappingName = "SsTotal";
            this.dataGridTextBoxColumn2.Width = 55;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "操作员";
            this.dataGridTextBoxColumn3.MappingName = "Operator";
            this.dataGridTextBoxColumn3.Width = 40;
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "会员";
            this.dataGridTextBoxColumn4.MappingName = "VipCardno";
            // 
            // FrmSalSaleRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DtPEnd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DtPStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSalSaleRpt";
            this.Text = "FrmSalSaleRpt";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmSalSaleRpt_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSalSaleRpt_KeyDown);
            this.Controls.SetChildIndex(this.DtPStart, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.DtPEnd, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.dataGrid1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker DtPStart;
        private System.Windows.Forms.DateTimePicker DtPEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}