using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvMngr
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        string password;

        private void LoginForm_Load(object sender, EventArgs e)
        {
            password = (string)Common.Application.Database.ExecuteScalar("SELECT Password FROM System;");
            if (password == "")
                txtOldPassword.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtOldPassword.Text != password)
            {
                MessageBox.Show(this, "Access denied.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOldPassword.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (txtPassword.Text != txtPassword2.Text)
            {
                MessageBox.Show("Password entries do not match.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Select();
                DialogResult = DialogResult.None;
                return;
            } 
            
            Common.Application.Database.Execute("UPDATE System SET `Password` = ?", txtPassword.Text);
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
