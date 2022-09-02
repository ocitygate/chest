using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvMngr
{
    public partial class KeyForm : Form
    {
        public KeyForm()
        {
            InitializeComponent();
        }

        private void btnBuyOnline_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://software.cavetta.info/?page=invmngr/buyonline.html&source=InvMngr.exe!Key");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtCompanyName.Text == "")
            {
                MessageBox.Show("Company Name is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyName.Select();
                DialogResult = DialogResult.None;
                return;
            }

            /*
            if (txtKey.Text == "")
            {
                MessageBox.Show("Key is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtKey.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (!TrialForm.validateKey(txtCompanyName.Text, txtKey.Text))
            {
                MessageBox.Show("Incorrect Company Name and/or Key.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCompanyName.Select();
                this.DialogResult = DialogResult.None;
                return;
            }
            */

            Common.Application.Database.Execute("UPDATE System SET CompanyName = ?, [Key] = ?", txtCompanyName.Text, txtKey.Text);
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
