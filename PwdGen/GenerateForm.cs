using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PwdGen
{
    public partial class GenerateForm : Form
    {
        public GenerateForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Value == null)
            {
                MessageBox.Show("Quantity is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtQuantity.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (txtLength.Value == null)
            {
                MessageBox.Show("Length is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLength.Select();
                DialogResult = DialogResult.None;
                return;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x200; //CS_NOCLOSE = 0x200
                return cp;
            }
        }

    }
}
