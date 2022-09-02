using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvMngr
{
    public partial class InvoiceSearchForm : Form
    {
        private CustomerListForm frmCustomerList = new CustomerListForm();

        public InvoiceSearchForm()
        {
            InitializeComponent();

            frmCustomerList.lookup = true;
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            Common.Application.Database.PopulateComboBox(cmbCustomer, true, "SELECT Code FROM Customer ORDER BY Code;");
            cmbCustomer.Items.Insert(0, "");

            txtReferenceFrom.Text = "";
            txtReferenceTo.Text = "";

            dteDateFrom.Value = DateTime.Today;
            dteDateFrom.Checked = false;

            dteDateTo.Value = DateTime.Today;
            dteDateTo.Checked = false;

            cmbCustomer.Text = "";

            refreshCustomer();

            txtReferenceFrom.Select();
        }

        private void cmbCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F3:
                    if (btnCustomerSearch.Enabled)
                    {
                        btnCustomerSearch.PerformClick();
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (frmCustomerList.ShowDialog(this) == DialogResult.OK)
            {
                cmbCustomer.Text = frmCustomerList.lookupCode;
                refreshCustomer();
            }
        }

        private void refreshCustomer()
        {
            if (cmbCustomer.Text == "")
            {
                txtName.Text = "";
            }
            else
            {
                System.Data.OleDb.OleDbDataReader reader = Common.Application.Database.ExecuteReader("SELECT Name FROM Customer WHERE Code = ?;", cmbCustomer.Text);
                if (reader.Read())
                {
                    txtName.Text = (string)reader["Name"];
                }
                reader.Close();
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshCustomer();
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
