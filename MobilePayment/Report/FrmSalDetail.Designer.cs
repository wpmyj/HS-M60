namespace MobilePayment.Report
{
    partial class FrmSalDetail
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle1 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn3 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn4 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn5 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.dataGridTableStyle2 = new System.Windows.Forms.DataGridTableStyle();
            this.dataGridTextBoxColumn6 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn7 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TxbYfTotal = new System.Windows.Forms.TextBox();
            this.TxbSsTotal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TxbYhTotal = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxbDsc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // button_1
            // 
            this.button_1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.button_1.Visible = false;
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
            // bindingSource1
            // 
            this.bindingSource1.AllowNew = false;
            this.bindingSource1.DataSource = typeof(Model.TSalSalePlu);
            // 
            // dataGrid1
            // 
            this.dataGrid1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid1.DataSource = this.bindingSource1;
            this.dataGrid1.Location = new System.Drawing.Point(0, 3);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.RowHeadersVisible = false;
            this.dataGrid1.Size = new System.Drawing.Size(240, 140);
            this.dataGrid1.TabIndex = 7;
            this.dataGrid1.TableStyles.Add(this.dataGridTableStyle1);
            this.dataGrid1.TabStop = false;
            // 
            // dataGridTableStyle1
            // 
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn1);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn2);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn3);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn4);
            this.dataGridTableStyle1.GridColumnStyles.Add(this.dataGridTextBoxColumn5);
            this.dataGridTableStyle1.MappingName = "TSalSalePlu";
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "行";
            this.dataGridTextBoxColumn1.MappingName = "SerialNo";
            this.dataGridTextBoxColumn1.Width = 20;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "品名";
            this.dataGridTextBoxColumn2.MappingName = "PluName";
            this.dataGridTextBoxColumn2.Width = 80;
            // 
            // dataGridTextBoxColumn3
            // 
            this.dataGridTextBoxColumn3.Format = "F2";
            this.dataGridTextBoxColumn3.FormatInfo = null;
            this.dataGridTextBoxColumn3.HeaderText = "单价";
            this.dataGridTextBoxColumn3.MappingName = "Price";
            // 
            // dataGridTextBoxColumn4
            // 
            this.dataGridTextBoxColumn4.Format = "";
            this.dataGridTextBoxColumn4.FormatInfo = null;
            this.dataGridTextBoxColumn4.HeaderText = "数量";
            this.dataGridTextBoxColumn4.MappingName = "XsCount";
            // 
            // dataGridTextBoxColumn5
            // 
            this.dataGridTextBoxColumn5.Format = "F2";
            this.dataGridTextBoxColumn5.FormatInfo = null;
            this.dataGridTextBoxColumn5.HeaderText = "金额";
            this.dataGridTextBoxColumn5.MappingName = "FsPrice";
            // 
            // bindingSource2
            // 
            this.bindingSource2.AllowNew = false;
            this.bindingSource2.DataSource = typeof(Model.TSalSalePay);
            // 
            // dataGrid2
            // 
            this.dataGrid2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dataGrid2.DataSource = this.bindingSource2;
            this.dataGrid2.Location = new System.Drawing.Point(3, 197);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(234, 64);
            this.dataGrid2.TabIndex = 10;
            this.dataGrid2.TableStyles.Add(this.dataGridTableStyle2);
            // 
            // dataGridTableStyle2
            // 
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn6);
            this.dataGridTableStyle2.GridColumnStyles.Add(this.dataGridTextBoxColumn7);
            this.dataGridTableStyle2.MappingName = "TSalSalePay";
            // 
            // dataGridTextBoxColumn6
            // 
            this.dataGridTextBoxColumn6.Format = "";
            this.dataGridTextBoxColumn6.FormatInfo = null;
            this.dataGridTextBoxColumn6.HeaderText = "付款方式";
            this.dataGridTextBoxColumn6.MappingName = "ZfName";
            this.dataGridTextBoxColumn6.Width = 60;
            // 
            // dataGridTextBoxColumn7
            // 
            this.dataGridTextBoxColumn7.Format = "F2";
            this.dataGridTextBoxColumn7.FormatInfo = null;
            this.dataGridTextBoxColumn7.HeaderText = "金额";
            this.dataGridTextBoxColumn7.MappingName = "SsTotal";
            this.dataGridTextBoxColumn7.Width = 80;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.Text = "应付";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(126, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 20);
            this.label4.Text = "实收";
            // 
            // TxbYfTotal
            // 
            this.TxbYfTotal.Location = new System.Drawing.Point(45, 144);
            this.TxbYfTotal.Name = "TxbYfTotal";
            this.TxbYfTotal.ReadOnly = true;
            this.TxbYfTotal.Size = new System.Drawing.Size(75, 23);
            this.TxbYfTotal.TabIndex = 13;
            // 
            // TxbSsTotal
            // 
            this.TxbSsTotal.Location = new System.Drawing.Point(162, 144);
            this.TxbSsTotal.Name = "TxbSsTotal";
            this.TxbSsTotal.ReadOnly = true;
            this.TxbSsTotal.Size = new System.Drawing.Size(75, 23);
            this.TxbSsTotal.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(126, 175);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.Text = "优惠";
            // 
            // TxbYhTotal
            // 
            this.TxbYhTotal.Location = new System.Drawing.Point(162, 170);
            this.TxbYhTotal.Name = "TxbYhTotal";
            this.TxbYhTotal.ReadOnly = true;
            this.TxbYhTotal.Size = new System.Drawing.Size(75, 23);
            this.TxbYhTotal.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "折扣";
            // 
            // TxbDsc
            // 
            this.TxbDsc.Location = new System.Drawing.Point(45, 170);
            this.TxbDsc.Name = "TxbDsc";
            this.TxbDsc.ReadOnly = true;
            this.TxbDsc.Size = new System.Drawing.Size(75, 23);
            this.TxbDsc.TabIndex = 18;
            // 
            // FrmSalDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.TxbDsc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxbYhTotal);
            this.Controls.Add(this.dataGrid2);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.TxbYfTotal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxbSsTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSalDetail";
            this.Text = "FrmSalFilter";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.FrmSalDetail_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmSalDetail_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSalDetail_KeyDown);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.TxbSsTotal, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.TxbYfTotal, 0);
            this.Controls.SetChildIndex(this.dataGrid1, 0);
            this.Controls.SetChildIndex(this.dataGrid2, 0);
            this.Controls.SetChildIndex(this.button_1, 0);
            this.Controls.SetChildIndex(this.button_2, 0);
            this.Controls.SetChildIndex(this.button_3, 0);
            this.Controls.SetChildIndex(this.button_4, 0);
            this.Controls.SetChildIndex(this.TxbYhTotal, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.TxbDsc, 0);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxbYfTotal;
        private System.Windows.Forms.TextBox TxbSsTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxbYhTotal;
        private System.Windows.Forms.BindingSource bindingSource2;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle1;
        private System.Windows.Forms.DataGridTableStyle dataGridTableStyle2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn3;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn4;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn5;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn6;
        private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxbDsc;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}