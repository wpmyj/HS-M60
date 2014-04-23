using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Base
{
    public partial class FrmLocateInput : Form
    {

        public string Value
        {
            get;
            set;
        }

        public FrmLocateInput()
        {
            InitializeComponent();
            this.Location =
                new Point((Screen.PrimaryScreen.Bounds.Width - this.Width) / 2,
                (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Value = tbValue.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void FrmLocateInput_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.DialogResult = DialogResult.Cancel;
                    break;
                case Keys.Enter:
                    button1_Click(null, null);
                    break;
            }
        }

        private void FrmLocateInput_Load(object sender, EventArgs e)
        {
            Value = string.Empty;
            tbValue.Text = string.Empty;
            tbValue.Focus();
            tbValue.SelectAll();
        }
    }
}