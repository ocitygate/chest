using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InvMngr
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }

        private CustomerForm frmCustomer = new CustomerForm();
        private CustomerListForm frmCustomerList = new CustomerListForm();
        private TaxListForm frmTaxList = new TaxListForm();

        private string selectSql =
            "SELECT Invoice.Reference, Date, Customer, ShipToSameAsBillTo, ShipTo1, ShipTo2, ShipTo3, ShipTo4,DiscountRate, Shipping, Notes, Paid " + 
            "FROM Invoice " + 
            "WHERE Invoice.Reference = ?;";
        private string insertSql = "INSERT INTO Invoice(Reference, `Date`, Customer, ShipToSameAsBillTo, ShipTo1, ShipTo2, ShipTo3, ShipTo4, DiscountRate, Shipping, Notes, Paid) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";
        private string updateSql = "UPDATE Invoice SET Reference = ?, `Date` = ?, Customer = ?, ShipToSameAsBillTo = ?, ShipTo1 = ?, ShipTo2 = ?, ShipTo3 = ?, ShipTo4 = ?, DiscountRate = ?, Shipping = ?, Notes = ?, Paid = ? WHERE Reference = ?;";

        private bool loadingData = false;

        private bool    sysInvoiceReferenceAuto;
        private bool    sysInvoiceReferenceAllowChange;
        private string  sysInvoiceReferenceAutoPrefix;
        private byte    sysInvoiceReferenceAutoDigits;
        private decimal sysInvoiceReferenceAutoSeed;
        private string  sysDefTax;

        private void RowForm_Load(object sender, EventArgs e)
        {
            this.Left = this.Owner.Left;
            this.Top = this.Owner.Top;
            this.Width = this.Owner.Width;
            this.Height = this.Owner.Height;

            frmCustomerList.lookup = true;
            frmTaxList.lookup = true;

            loadingData = true;

            Common.Application.Database.PopulateComboBox(cmbCustomer, true, "SELECT Code FROM Customer ORDER BY Code;");
            cmbCustomer.Items.Add("");

            CS.Windows.Forms.GridViewHelper.PopluateGridViewCombo(Common.Application.Database.GetOleDbConnection(), (DataGridViewComboBoxColumn)gridInvoiceLine.Columns["colInvoiceLine_Tax"], true, "SELECT Code FROM Tax ORDER BY Code;");
            ((DataGridViewComboBoxColumn)gridInvoiceLine.Columns["colInvoiceLine_Tax"]).Items.Insert(0, "");

            OleDbDataReader reader = Common.Application.Database.ExecuteReader("SELECT InvoiceReferenceAuto, InvoiceReferenceAllowChange, InvoiceReferenceAutoPrefix, InvoiceReferenceAutoDigits, InvoiceReferenceAutoSeed, DefTax FROM System;");
            if (reader.Read())
            {
                sysInvoiceReferenceAuto       = (bool) reader["InvoiceReferenceAuto"];
                sysInvoiceReferenceAllowChange = (bool)reader["InvoiceReferenceAllowChange"];
                sysInvoiceReferenceAutoPrefix = (string)reader["InvoiceReferenceAutoPrefix"];
                sysInvoiceReferenceAutoDigits = (byte)reader["InvoiceReferenceAutoDigits"];
                sysInvoiceReferenceAutoSeed = (decimal)reader["InvoiceReferenceAutoSeed"];
                sysDefTax = (string)reader["DefTax"];
            }
            reader.Close();

            gridInvoiceLine.CancelEdit();
            gridInvoiceLine.Rows.Clear();

            if (txtOriginalReference.Text == "")
            {

                if (sysInvoiceReferenceAuto)
                {
                    string pattern = sysInvoiceReferenceAutoPrefix;
                    for (int i = 1; i <= sysInvoiceReferenceAutoDigits; i++)
                        pattern += "[0-9]";

                    string lastReference = (string) Common.Application.Database.ExecuteScalar("SELECT TOP 1 Reference FROM Invoice WHERE Reference LIKE ? ORDER BY Reference DESC;",
                        pattern);

                    decimal nextDigits;
                    if (lastReference == null)
                        nextDigits = sysInvoiceReferenceAutoSeed;
                    else
                    {
                        nextDigits = Convert.ToDecimal(lastReference.Substring(lastReference.Length - sysInvoiceReferenceAutoDigits, sysInvoiceReferenceAutoDigits)) + 1M;
                        if (nextDigits < sysInvoiceReferenceAutoSeed)
                            nextDigits = sysInvoiceReferenceAutoSeed;
                    }

                    txtReference.Text = string.Format("{0}{1:" + new string('0', sysInvoiceReferenceAutoDigits) + "}",
                        sysInvoiceReferenceAutoPrefix, nextDigits);

                    txtReference.ReadOnly = !sysInvoiceReferenceAllowChange;
                    txtReference.TabStop = sysInvoiceReferenceAllowChange;
                }
                else
                {
                    txtReference.Text = "";
                    txtReference.ReadOnly = false;
                    txtReference.TabStop = true;
                }

                dteDate.Value = DateTime.Now.Date;
                cmbCustomer.Text = "";
                chkShipToSameAsBillTo.Checked = true;
                txtShipTo1.Text = "";
                txtShipTo2.Text = "";
                txtShipTo3.Text = "";
                txtShipTo4.Text = "";
                txtDiscountRate.Value = 0.0M;
                txtShipping.Value = 0.0M;
                txtNotes.Text = "";
                txtPaid.Value = 0.0M;
            }
            else
            {
                txtReference.ReadOnly = !sysInvoiceReferenceAllowChange;
                txtReference.TabStop = sysInvoiceReferenceAllowChange;
                reader = Common.Application.Database.ExecuteReader(selectSql, txtOriginalReference.Text);
                if (reader.Read())
                {
                    txtReference.Text     = (string)reader["Reference"];
                    dteDate.Value         = (DateTime)reader["Date"];
                    cmbCustomer.Text      = (string)reader["Customer"];
                    chkShipToSameAsBillTo.Checked     = (bool)reader["ShipToSameAsBillTo"];
                    txtShipTo1.Text       = (string)reader["ShipTo1"];
                    txtShipTo2.Text       = (string)reader["ShipTo2"];
                    txtShipTo3.Text       = (string)reader["ShipTo3"];
                    txtShipTo4.Text       = (string)reader["ShipTo4"];
                    txtDiscountRate.Value = (decimal)reader["DiscountRate"];
                    txtShipping.Value     = (decimal)reader["Shipping"];
                    txtNotes.Text         = (string)reader["Notes"];
                    txtPaid.Value         = (decimal)reader["Paid"];
                }
                reader.Close();

                CS.Windows.Forms.GridViewHelper.PopulateGridView(Common.Application.Database.GetOleDbConnection(), 
                    gridInvoiceLine, false, false, false, false,
                    "SELECT LineType, Description, UnitPrice, Quantity, NULL, NULL, NULL, Tax, NULL, NULL " +
                    "FROM InvoiceLine " +
                    "WHERE InvoiceLine.Invoice = ? " + 
                    "ORDER BY InvoiceLine.LineNo",
                    txtOriginalReference.Text);

            }
            refreshCustomer();
            updateShipToEditable();
            updateAllInvoiceLines();
            updateInvoice();
            dteDate.Select();
            this.CancelButton = btnCancel;

            loadingData = false;
        }

        #region Control Event Handlers

        private void cmbCustomer_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F1:
                    if (btnCustomerNew.Enabled)
                    {
                        btnCustomerNew.PerformClick();
                        e.Handled = true;
                    }
                    break;
                case Keys.F2:
                    if (btnCustomerOpen.Enabled)
                    {
                        btnCustomerOpen.PerformClick();
                        e.Handled = true;
                    }
                    break;
                case Keys.F3:
                    if (btnCustomerSearch.Enabled)
                    {
                        btnCustomerSearch.PerformClick();
                        e.Handled = true;
                    }
                    break;
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnCustomerOpen.Enabled = (cmbCustomer.Text != "");
            if (!loadingData) getCustomer();
        }
        
        private void btnCustomerNew_Click(object sender, EventArgs e)
        {
            frmCustomer.txtOriginalCode.Text = "";
            if (frmCustomer.ShowDialog(this) == DialogResult.OK)
            {
                cmbCustomer.Items.Add(frmCustomer.txtCode.Text);
                cmbCustomer.Text = frmCustomer.txtCode.Text;
            }

            getCustomer();
        }

        private void btnCustomerOpen_Click(object sender, EventArgs e)
        {
            int i = cmbCustomer.SelectedIndex;
            if (i == -1) return;

            frmCustomer.txtOriginalCode.Text = cmbCustomer.Text;

            if (frmCustomer.ShowDialog(this) == DialogResult.OK)
            {
                bool loadingDataX = loadingData;
                loadingData = true;

                cmbCustomer.Items.RemoveAt(i);
                cmbCustomer.Items.Insert(i, frmCustomer.txtCode.Text);

                cmbCustomer.Text = frmCustomer.txtCode.Text;

                refreshCustomer();

                loadingData = loadingDataX;
            }
        }

        private void btnCustomerSearch_Click(object sender, EventArgs e)
        {
            if (frmCustomerList.ShowDialog(this) == DialogResult.OK)
            {
                cmbCustomer.Text = frmCustomerList.lookupCode;
                getCustomer();
            }
        }

        private void chkShipToSameAsBillTo_CheckedChanged(object sender, EventArgs e)
        {
            if (!loadingData)
            {
                updateShipToEditable();
                updateShipToText();
            }
        }

        private void txtDiscountRate_Validated(object sender, EventArgs e)
        {
            updateAllInvoiceLines();
            updateInvoice();
        }

        private void txtShipping_Validated(object sender, EventArgs e)
        {
            updateInvoice();
        }

        private void txtPaid_Validated(object sender, EventArgs e)
        {
            updateInvoice();
        }

        #endregion

        #region gridInvoiceLine Event Handlers

        private void gridInvoiceLine_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow[] selectedRows = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(gridInvoiceLine);

            btnDelete.Enabled = (selectedRows.GetUpperBound(0) != -1);
            btnMoveUp.Enabled = (selectedRows.GetUpperBound(0) != -1);
            btnMoveDown.Enabled = (selectedRows.GetUpperBound(0) != -1);
        }

        private void gridInvoiceLine_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["colInvoiceLine_LineType"].Value = "F";
            e.Row.Cells["colInvoiceLine_Description"].Value = "";
            e.Row.Cells["colInvoiceLine_UnitPrice"].Value = Convert.DBNull;
            e.Row.Cells["colInvoiceLine_Quantity"].Value = Convert.DBNull;
            e.Row.Cells["colInvoiceLine_Tax"].Value = sysDefTax;
            updateInvoiceLine(e.Row);
        }

        private void gridInvoiceLine_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            this.CancelButton = null;
        }

        private void gridInvoiceLine_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            this.CancelButton = btnCancel;
        }

        private void gridInvoiceLine_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            DataGridViewColumn column = ((DataGridView)sender).Columns[e.ColumnIndex];
            DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[e.ColumnIndex];

            switch (column.Name)
            {
                case "colInvoiceLine_UnitPrice":
                    try
                    {
                        if ((string)e.FormattedValue != "")
                        {
                            decimal value = Convert.ToDecimal(e.FormattedValue);
                            if ((value < 0) || (value > 99999999999999.9999M))
                            {
                                MessageBox.Show(this.FindForm(), string.Format("Field range is {0} - {1}.", 0, 99999999999999.9999), "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this.FindForm(), "Field is decimal.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                    break;
                case "colInvoiceLine_Quantity":
                    try
                    {
                        if ((string)e.FormattedValue != "")
                        {
                            decimal value = Convert.ToInt32(e.FormattedValue);
                            if ((value < -2147483648) || (value > 2147483647))
                            {
                                MessageBox.Show(this.FindForm(), string.Format("Field range is {0} - {1}.", 0, 2147483647), "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                e.Cancel = true;
                                return;
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show(this.FindForm(), "Field is interger.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                    break;
            }
        }

        private void gridInvoiceLine_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (loadingData) return;

            DataGridViewColumn column = ((DataGridView)sender).Columns[e.ColumnIndex];
            DataGridViewRow    row    = ((DataGridView)sender).Rows[e.RowIndex];
            DataGridViewCell   cell   = row.Cells[e.ColumnIndex];

            switch (column.Name)
            {
                case "colInvoiceLine_LineType":
                    updateInvoiceLine(row);
                    break;

                case "colInvoiceLine_Description":
                    if (cell.Value == null)
                        cell.Value = "";
                    break;

                case "colInvoiceLine_UnitPrice":
                    if ((string)cell.FormattedValue == "")
                        cell.Value = Convert.DBNull;
                    else
                        cell.Value = Convert.ToDecimal(cell.FormattedValue);
                    updateInvoiceLine(row);
                    updateInvoice();
                    break;

                case "colInvoiceLine_Quantity":
                    if ((string)cell.FormattedValue == "")
                        cell.Value = Convert.DBNull;
                    else
                        cell.Value = Convert.ToInt32(cell.FormattedValue);

                    updateInvoiceLine(row);
                    updateInvoice();
                    break;

                case "colInvoiceLine_Tax":
                    if ((string) cell.FormattedValue == "")
                        cell.Value = Convert.DBNull;

                    updateInvoiceLine(row);
                    updateInvoice();
                    break;

            }
        }

        private void gridInvoiceLine_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (loadingData) return;

            DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];

            if ((row.Cells["colInvoiceLine_UnitPrice"].Value != Convert.DBNull & row.Cells["colInvoiceLine_Quantity"].Value == Convert.DBNull))
            {
                row.Cells["colInvoiceLine_Quantity"].Value = 1;
            }

            if ((row.Cells["colInvoiceLine_UnitPrice"].Value == Convert.DBNull & row.Cells["colInvoiceLine_Quantity"].Value != Convert.DBNull))
            {
                row.Cells["colInvoiceLine_UnitPrice"].Value = 0M;
            }

            if ((row.Cells["colInvoiceLine_UnitPrice"].Value == Convert.DBNull & row.Cells["colInvoiceLine_Quantity"].Value == Convert.DBNull & row.Cells["colInvoiceLine_Tax"].Value != Convert.DBNull))
            {
                row.Cells["colInvoiceLine_Tax"].Value = Convert.DBNull;
            }

            if ((row.Cells["colInvoiceLine_UnitPrice"].Value != Convert.DBNull & row.Cells["colInvoiceLine_Quantity"].Value != Convert.DBNull & row.Cells["colInvoiceLine_Tax"].Value == Convert.DBNull))
            {
                row.Cells["colInvoiceLine_Tax"].Value = sysDefTax;
            }
        }

        private void gridInvoiceLine_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (loadingData) return;

            DataGridViewRow row = ((DataGridView)sender).Rows[e.RowIndex];

            updateInvoiceLine(row);
            updateInvoice();
        }

        #endregion

        #region Action Buttons Event Handlers

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow[] rowSelected = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(gridInvoiceLine);


            if (MessageBox.Show(this, string.Format("Are you sure you want to delete {0} line(s)?", rowSelected.GetUpperBound(0) + 1), "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in rowSelected)
                    gridInvoiceLine.Rows.Remove(row);
            }

            updateInvoice();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            DataGridViewRow[] rowSelected = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(gridInvoiceLine);

            foreach (DataGridViewRow row in rowSelected)
            {
                int ix;
                for (ix = row.Index - 1; ; ix--)
                {
                    if (ix == -1)
                        return;
                    if (gridInvoiceLine.Rows[ix].Visible)
                        break;
                }
                gridInvoiceLine.Rows.Remove(row);
                gridInvoiceLine.Rows.Insert(ix, row);
                row.Selected = true;
            }
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            DataGridViewRow[] rowSelected = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(gridInvoiceLine);

            for (int i = rowSelected.GetUpperBound(0); i >= 0; i--)
            {
                DataGridViewRow row = rowSelected[i];

                int ix;
                for (ix = row.Index + 1; ; ix++)
                {
                    if (ix == gridInvoiceLine.Rows.Count || gridInvoiceLine.Rows[ix].IsNewRow)
                        return;
                    if (gridInvoiceLine.Rows[ix].Visible)
                        break;
                }
                gridInvoiceLine.Rows.Remove(row);
                gridInvoiceLine.Rows.Insert(ix, row);
                row.Selected = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtReference.Text == "")
            {
                MessageBox.Show("Reference is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReference.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if ((int)Common.Application.Database.ExecuteScalar("SELECT COUNT(*) FROM Invoice WHERE Reference = ? AND Reference <> ?;",
                txtReference.Text, txtOriginalReference.Text) != 0)
            {
                MessageBox.Show("Reference already exists.", "Unique Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtReference.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (cmbCustomer.Text == "")
            {
                MessageBox.Show("Customer is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbCustomer.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (txtDiscountRate.Value == null)
            {
                MessageBox.Show("Discount Rate is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDiscountRate.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (txtShipping.Value == null)
            {
                MessageBox.Show("Shipping is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtShipping.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (txtOriginalReference.Text == "") // check if new row otherwise open
            {
                Common.Application.Database.Execute(insertSql,
                    txtReference.Text,
                    dteDate.Value,
                    cmbCustomer.Text,
                    chkShipToSameAsBillTo.Checked,
                    chkShipToSameAsBillTo.Checked ? "" : txtShipTo1.Text,
                    chkShipToSameAsBillTo.Checked ? "" : txtShipTo2.Text,
                    chkShipToSameAsBillTo.Checked ? "" : txtShipTo3.Text,
                    chkShipToSameAsBillTo.Checked ? "" : txtShipTo4.Text,
                    txtDiscountRate.Value,
                    txtShipping.Value,
                    txtNotes.Text,
                    txtPaid.Value
                    );
            }
            else
            {
                Common.Application.Database.Execute("DELETE FROM InvoiceLine WHERE Invoice = ?;", txtOriginalReference.Text);

                Common.Application.Database.Execute(updateSql,
                    txtReference.Text,
                    dteDate.Value,
                    cmbCustomer.Text,
                    chkShipToSameAsBillTo.Checked,
                    chkShipToSameAsBillTo.Checked ? "" : txtShipTo1.Text,
                    chkShipToSameAsBillTo.Checked ? "" : txtShipTo2.Text,
                    chkShipToSameAsBillTo.Checked ? "" : txtShipTo3.Text,
                    chkShipToSameAsBillTo.Checked ? "" : txtShipTo4.Text,
                    txtDiscountRate.Value,
                    txtShipping.Value,
                    txtNotes.Text,
                    txtPaid.Value,
                    txtOriginalReference.Text
                    );
            }

            foreach (DataGridViewRow row in gridInvoiceLine.Rows)
                if (!row.IsNewRow)
                    Common.Application.Database.Execute("INSERT INTO InvoiceLine(Invoice, LineNo, LineType, Description, UnitPrice, Quantity, Tax) VALUES(?, ?, ?, ?, ?, ?, ?);",
                        txtReference.Text,
                        row.Index,
                        row.Cells["colInvoiceLine_LineType"].Value,
                        row.Cells["colInvoiceLine_Description"].Value,
                        row.Cells["colInvoiceLine_UnitPrice"].Value,
                        row.Cells["colInvoiceLine_Quantity"].Value,
                        row.Cells["colInvoiceLine_Tax"].Value);
        }

        #endregion

        #region Calculation and Control Update Routines

        private void getCustomer()
        {
            bool loadingDataX = loadingData;
            loadingData = true;

            if (cmbCustomer.Text == "")
            {
                txtName.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                chkShipToSameAsBillTo.Checked = true;
                txtShipTo1.Text = "";
                txtShipTo2.Text = "";
                txtShipTo3.Text = "";
                txtShipTo4.Text = "";
            }
            else
            {
                OleDbDataReader reader = Common.Application.Database.ExecuteReader("SELECT Name, Address1, Address2, Address3, DefShipToSameAsBillTo, DefShipTo1, DefShipTo2, DefShipTo3, DefShipTo4 FROM Customer WHERE Code = ?;", cmbCustomer.Text);
                if (reader.Read())
                {
                    txtName.Text = (string)reader["Name"];
                    txtAddress1.Text = (string)reader["Address1"];
                    txtAddress2.Text = (string)reader["Address2"];
                    txtAddress3.Text = (string)reader["Address3"];
                    chkShipToSameAsBillTo.Checked = (bool)reader["DefShipToSameAsBillTo"];
                    txtShipTo1.Text = (string)reader["DefShipTo1"];
                    txtShipTo2.Text = (string)reader["DefShipTo2"];
                    txtShipTo3.Text = (string)reader["DefShipTo3"];
                    txtShipTo4.Text = (string)reader["DefShipTo4"];
                }
                reader.Close();
            }

            updateShipToEditable();
            updateShipToText();

            loadingData = loadingDataX;
        }

        private void refreshCustomer()
        {
            bool loadingDataX = loadingData;
            loadingData = true;

            if (cmbCustomer.Text == "")
            {
                txtName.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
            }
            else
            {
                OleDbDataReader reader = Common.Application.Database.ExecuteReader("SELECT Name, Address1, Address2, Address3 FROM Customer WHERE Code = ?;", cmbCustomer.Text);
                if (reader.Read())
                {
                    txtName.Text = (string)reader["Name"];
                    txtAddress1.Text = (string)reader["Address1"];
                    txtAddress2.Text = (string)reader["Address2"];
                    txtAddress3.Text = (string)reader["Address3"];
                }
                reader.Close();
            }

            updateShipToText();

            loadingData = loadingDataX;
        }

        private void updateShipToEditable()
        {
            if (chkShipToSameAsBillTo.Checked)
            {
                txtShipTo1.ReadOnly = true;
                txtShipTo1.TabStop = false;

                txtShipTo2.ReadOnly = true;
                txtShipTo2.TabStop = false;

                txtShipTo3.ReadOnly = true;
                txtShipTo3.TabStop = false;

                txtShipTo4.ReadOnly = true;
                txtShipTo4.TabStop = false;
            }
            else
            {
                txtShipTo1.ReadOnly = false;
                txtShipTo1.TabStop = true;

                txtShipTo2.ReadOnly = false;
                txtShipTo2.TabStop = true;

                txtShipTo3.ReadOnly = false;
                txtShipTo3.TabStop = true;

                txtShipTo4.ReadOnly = false;
                txtShipTo4.TabStop = true;
            }
        }

        private void updateShipToText()
        {
            if (chkShipToSameAsBillTo.Checked)
            {
                txtShipTo1.Text = txtName.Text;
                txtShipTo2.Text = txtAddress1.Text;
                txtShipTo3.Text = txtAddress2.Text;
                txtShipTo4.Text = txtAddress3.Text;
            }
        }

        private void updateInvoiceLine(DataGridViewRow row)
        {
            row.DefaultCellStyle.Font = new Font(gridInvoiceLine.Font, (string)row.Cells["colInvoiceLine_LineType"].Value == "B" ? FontStyle.Bold : FontStyle.Regular);

            if (row.Cells["colInvoiceLine_UnitPrice"].Value == Convert.DBNull | row.Cells["colInvoiceLine_Quantity"].Value == Convert.DBNull)
                row.Cells["colInvoiceLine_Amount"].Value = Convert.DBNull;
            else
                row.Cells["colInvoiceLine_Amount"].Value = (decimal)row.Cells["colInvoiceLine_UnitPrice"].Value * (int)row.Cells["colInvoiceLine_Quantity"].Value;

            if (row.Cells["colInvoiceLine_Amount"].Value == Convert.DBNull | txtDiscountRate.Value == null)
                row.Cells["colInvoiceLine_LineDiscount"].Value = Convert.DBNull;
            else
                row.Cells["colInvoiceLine_LineDiscount"].Value = (decimal)row.Cells["colInvoiceLine_Amount"].Value * Convert.ToDecimal(txtDiscountRate.Value) / 100M;

            if (row.Cells["colInvoiceLine_Amount"].Value == Convert.DBNull | row.Cells["colInvoiceLine_LineDiscount"].Value == Convert.DBNull)
                row.Cells["colInvoiceLine_LineSubTotal"].Value = Convert.DBNull;
            else
                row.Cells["colInvoiceLine_LineSubTotal"].Value = (decimal)row.Cells["colInvoiceLine_Amount"].Value - (decimal)row.Cells["colInvoiceLine_LineDiscount"].Value;

            if (row.Cells["colInvoiceLine_LineSubTotal"].Value == Convert.DBNull | row.Cells["colInvoiceLine_Tax"].Value == Convert.DBNull)
                row.Cells["colInvoiceLine_LineTax"].Value = Convert.DBNull;
            else
                row.Cells["colInvoiceLine_LineTax"].Value = (decimal)row.Cells["colInvoiceLine_LineSubTotal"].Value * (decimal)Common.Application.Database.ExecuteScalar("SELECT Rate FROM Tax WHERE Code = ?", row.Cells["colInvoiceLine_Tax"].Value) / 100;

            if (row.Cells["colInvoiceLine_LineSubTotal"].Value == Convert.DBNull | row.Cells["colInvoiceLine_LineTax"].Value == Convert.DBNull)
                row.Cells["colInvoiceLine_LineTotal"].Value = Convert.DBNull;
            else
                row.Cells["colInvoiceLine_LineTotal"].Value = (decimal)row.Cells["colInvoiceLine_LineSubTotal"].Value + (decimal)row.Cells["colInvoiceLine_LineTax"].Value;
        }

        private void updateAllInvoiceLines()
        {
            foreach (DataGridViewRow row in gridInvoiceLine.Rows)
                if (!row.IsNewRow)
                    updateInvoiceLine(row);
        }

        private void updateInvoice()
        {
            decimal value = 0;
            decimal discount = 0;
            decimal subTotal = 0;
            decimal tax = 0;
            decimal total = 0;
            decimal balance = 0;

            foreach (DataGridViewRow row in gridInvoiceLine.Rows)
                if (!row.IsNewRow)
                {
                    if (row.Cells["colInvoiceLine_Amount"].Value != Convert.DBNull) value += (decimal) row.Cells["colInvoiceLine_Amount"].Value;
                    if (row.Cells["colInvoiceLine_LineDiscount"].Value != Convert.DBNull) discount += (decimal)row.Cells["colInvoiceLine_LineDiscount"].Value;
                    if (row.Cells["colInvoiceLine_LineSubTotal"].Value != Convert.DBNull) subTotal += (decimal)row.Cells["colInvoiceLine_LineSubTotal"].Value;
                    if (row.Cells["colInvoiceLine_LineTax"].Value != Convert.DBNull) tax += (decimal)row.Cells["colInvoiceLine_LineTax"].Value;
                    if (row.Cells["colInvoiceLine_LineTotal"].Value != Convert.DBNull) total += (decimal)row.Cells["colInvoiceLine_LineTotal"].Value;
                }

            if (txtShipping.Value != null)
                total += Convert.ToDecimal(txtShipping.Value);

            if (txtPaid.Value != null)
                balance += total - Convert.ToDecimal(txtPaid.Value);

            txtValue.Value = value;
            txtDiscount.Value = discount;
            txtSubTotal.Value = subTotal;
            txtTax.Value = tax;
            txtTotal.Value = total;
            txtBalance.Value = balance;
        }

        #endregion

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x200; //CS_NOCLOSE = 0x200
                return cp;
            }
        }

        private void gridInvoiceLine_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (loadingData) return;


        }

    }
}
