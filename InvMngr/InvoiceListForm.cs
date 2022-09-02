using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvMngr
{
    public partial class InvoiceListForm : Form
    {

        public InvoiceListForm()
        {
            InitializeComponent();
        }

        InvoiceSearchForm frmSearch = new InvoiceSearchForm();
        InvoiceForm frmRow = new InvoiceForm();
        InvoicePrintForm frmPrint = new InvoicePrintForm();

        string selectSql =
            "SELECT Invoice.Reference, Invoice.Date, Invoice.Customer, Value, Discount, SubTotal, Tax, Shipping, Total, Paid, Balance " + 
            "FROM Invoice " +
            "INNER JOIN InvoiceB ON InvoiceB.Reference = Invoice.Reference " +
            "WHERE " +
                "(? = '' OR Invoice.Reference >= ?) AND " +
                "(? = '' OR Invoice.Reference <= ?) AND " +
                "(? = 0  OR Invoice.Date >= ?) AND " +
                "(? = 0  OR Invoice.Date <= ?) AND " +
                "(? = '' OR Invoice.Customer = ?) " +
            "ORDER BY Invoice.Reference;";

        string selectByKeySql =
            "SELECT Invoice.Reference, Invoice.Date, Invoice.Customer, Value, Discount, SubTotal, Tax, Shipping, Total, Paid, Balance " +
            "FROM Invoice " +
            "INNER JOIN InvoiceB ON InvoiceB.Reference = Invoice.Reference " +
            "WHERE Invoice.Reference = ?;";

        string deleteSql = "DELETE FROM Invoice WHERE Reference = ?";

        private void ListForm_Load(object sender, EventArgs e)
        {
            this.Left = this.Owner.Left;
            this.Top  = this.Owner.Top;
            this.Width = this.Owner.Width;
            this.Height = this.Owner.Height;

            updateSummary();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow[] selectedRows = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid);
            btnOpen.Enabled = (selectedRows.GetUpperBound(0) == 0);
            btnDelete.Enabled = (selectedRows.GetUpperBound(0) != -1);
            btnPrint.Enabled = (selectedRows.GetUpperBound(0) != -1);
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (this.AcceptButton != null && (((Button)this.AcceptButton).Visible & ((Button)this.AcceptButton).Enabled))
                {
                    this.AcceptButton.PerformClick();
                    e.Handled = true;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            grid.Rows.Clear();

            if (frmSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();

                CS.Windows.Forms.GridViewHelper.PopulateGridView(Common.Application.Database.GetOleDbConnection(), grid, true, false, false, false, selectSql,
                    Common.Database.NullToDbNull(frmSearch.txtReferenceFrom.Text),
                    Common.Database.NullToDbNull(frmSearch.txtReferenceFrom.Text),
                    Common.Database.NullToDbNull(frmSearch.txtReferenceTo.Text),
                    Common.Database.NullToDbNull(frmSearch.txtReferenceTo.Text),
                    frmSearch.dteDateFrom.Checked,
                    frmSearch.dteDateFrom.Value,
                    frmSearch.dteDateTo.Checked,
                    frmSearch.dteDateTo.Value,
                    frmSearch.cmbCustomer.Text,
                    frmSearch.cmbCustomer.Text
                    );

                updateSummary();
            }

            this.Cursor = Cursors.Default;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            frmRow.txtOriginalReference.Text = "";

            if (frmRow.ShowDialog(this) == DialogResult.OK)
            {
                CS.Windows.Forms.GridViewHelper.PopulateGridView(Common.Application.Database.GetOleDbConnection(), grid, false, false, true, true,
                    selectByKeySql,
                    frmRow.txtReference.Text
                    );

                updateSummary();
            }

            this.Cursor = Cursors.Default;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DataGridViewRow row = grid.SelectedRows[0];

            frmRow.txtOriginalReference.Text = (string)row.Cells["colReference"].Value;

            if (frmRow.ShowDialog(this) == DialogResult.OK)
            {
                CS.Windows.Forms.GridViewHelper.PopulateGridRow(Common.Application.Database.GetOleDbConnection(), row,
                    selectByKeySql,
                    frmRow.txtReference.Text
                    );

                updateSummary();
            }

            this.Cursor = Cursors.Default;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DataGridViewRow[] selectedRows = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid);

            if (MessageBox.Show(this, string.Format("Are you sure you want to delete {0} invoice(s)?", selectedRows.GetUpperBound(0) + 1), "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Refresh();

                foreach (DataGridViewRow row in selectedRows)
                {
                    Common.Application.Database.Execute(deleteSql,
                        row.Cells["colReference"].Value
                        );
                    grid.Rows.Remove(row);
                
                    updateSummary();
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            System.Collections.ArrayList aReferecence = new System.Collections.ArrayList();
            foreach (DataGridViewRow row in CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid))
                aReferecence.Add(row.Cells["colReference"].Value);

            frmPrint.Reference = aReferecence.ToArray();

            frmPrint.ShowDialog(this);

            this.Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateSummary()
        {
            decimal value = 0;
            decimal discount = 0;
            decimal subTotal = 0;
            decimal tax = 0;
            decimal shipping = 0;
            decimal total = 0;
            decimal paid = 0;
            decimal balance = 0;

            foreach (DataGridViewRow row in grid.Rows)
                if (!row.IsNewRow) //for editable grids
                {
                    if (row.Cells["colValue"].Value != Convert.DBNull) value += Convert.ToDecimal(row.Cells["colValue"].Value);
                    if (row.Cells["colDiscount"].Value != Convert.DBNull) discount += Convert.ToDecimal(row.Cells["colDiscount"].Value);
                    if (row.Cells["colSubTotal"].Value != Convert.DBNull) subTotal += Convert.ToDecimal(row.Cells["colSubTotal"].Value);
                    if (row.Cells["colTax"].Value != Convert.DBNull) tax += Convert.ToDecimal(row.Cells["colTax"].Value);
                    if (row.Cells["colShipping"].Value != Convert.DBNull) shipping += Convert.ToDecimal(row.Cells["colShipping"].Value);
                    if (row.Cells["colTotal"].Value != Convert.DBNull) total += Convert.ToDecimal(row.Cells["colTotal"].Value);
                    if (row.Cells["colPaid"].Value != Convert.DBNull) paid += Convert.ToDecimal(row.Cells["colPaid"].Value);
                    if (row.Cells["colBalance"].Value != Convert.DBNull) balance += Convert.ToDecimal(row.Cells["colBalance"].Value);
                }

            txtValue.Value = value;
            txtDiscount.Value = discount;
            txtSubTotal.Value = subTotal;
            txtTax.Value = tax;
            txtShipping.Value = shipping;
            txtTotal.Value = total;
            txtPaid.Value = paid;
            txtBalance.Value = balance;
        }

    }
}
