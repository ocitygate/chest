using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvMngr
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            password = (string)Common.Application.Database.ExecuteScalar("SELECT Password FROM System;");
            if (password == "")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != password)
            {
                MessageBox.Show(this, "Access denied.", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Select();
                DialogResult = DialogResult.None;
                return;
            }
        }
        string password;

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
