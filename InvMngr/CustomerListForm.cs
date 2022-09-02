using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace InvMngr
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class CustomerListForm : System.Windows.Forms.Form
    {
        private DataGridView grid;
        private Button btnSearch;
        private Button btnNew;
        private Button btnOpen;
        private Button btnDelete;
        private Button btnCancel;
        private Button btnOK;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn cName;
        private DataGridViewTextBoxColumn Contact;
        private Button btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CustomerListForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerListForm));
            this.grid = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Code,
            this.cName,
            this.Contact});
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 24;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(770, 484);
            this.grid.TabIndex = 0;
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 96;
            // 
            // cName
            // 
            this.cName.HeaderText = "Name";
            this.cName.Name = "cName";
            this.cName.ReadOnly = true;
            this.cName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.cName.Width = 312;
            // 
            // Contact
            // 
            this.Contact.HeaderText = "Contact";
            this.Contact.Name = "Contact";
            this.Contact.ReadOnly = true;
            this.Contact.Width = 312;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Image = global::InvMngr.Properties.Resources.search16x16;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(12, 501);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "     &Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Image = global::InvMngr.Properties.Resources.new16x16;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(102, 501);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 26);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "     &New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Enabled = false;
            this.btnOpen.Image = global::InvMngr.Properties.Resources.open16x16;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(192, 501);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(84, 26);
            this.btnOpen.TabIndex = 3;
            this.btnOpen.Text = "     &Open";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::InvMngr.Properties.Resources.delete16x16;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(282, 501);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 26);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "     &Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::InvMngr.Properties.Resources.cancel16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(698, 501);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 26);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "     &Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Image = global::InvMngr.Properties.Resources.ok16x16;
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(608, 501);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 26);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "     &OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = global::InvMngr.Properties.Resources.close16x16;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(698, 501);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 26);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "     &Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // CustomerListForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(794, 538);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customers";
            this.Load += new System.EventHandler(this.CustomerListForm_Load);
            this.Shown += new System.EventHandler(this.CustomerListForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        public static string selectSql =
            "SELECT Code, Name, Contact " +
            "FROM Customer " +
            "WHERE (? = '' OR Code = ?) " +
            "AND (? = '' OR Name LIKE '%' + ? + '%') " +
            "AND (? = '' OR Address1 LIKE '%' + ? + '%' OR Address2 LIKE '%' + ? + '%' OR Address3 LIKE '%' + ? + '%') " +
            "AND (? = '' OR DefShipTo1 LIKE '%' + ? + '%' OR DefShipTo2 LIKE '%' + ? + '%' OR DefShipTo3 LIKE '%' + ? + '%' OR DefShipTo4 LIKE '%' + ? + '%') " +
            "AND (? = '' OR Contact LIKE '%' + ? + '%') " +
            "AND (? = '' OR Phone LIKE '%' + ? + '%') " +
            "AND (? = '' OR Fax LIKE '%' + ? + '%') " +
            "AND (? = '' OR Email LIKE '%' + ? + '%') " +
            "ORDER BY Code;";

        public static string selectByKeySql =
            "SELECT Code, Name, Contact " +
            "FROM Customer " +
            "WHERE (Code = ?);";

        private CustomerForm frmCustomer = new CustomerForm();
		private CustomerSearchForm frmCustomerSearch = new CustomerSearchForm();

        public bool   lookup = false;
        public string lookupCode = "";

        private void CustomerListForm_Load(object sender, EventArgs e)
        {
            if (lookup)
            {
                btnNew.Visible = false;
                btnOpen.Visible = false;
                btnDelete.Visible = false;
                btnClose.Visible = false;

                btnOK.Visible = true;
                btnCancel.Visible = true;

                this.AcceptButton = btnOK;
                this.CancelButton = btnCancel;
            }
            else
            {
                btnNew.Visible = true;
                btnOpen.Visible = true;
                btnDelete.Visible = true;
                btnClose.Visible = true;

                btnOK.Visible = false;
                btnCancel.Visible = false;

                this.AcceptButton = btnOpen;
                this.CancelButton = btnClose;
            }
        }

        private void CustomerListForm_Shown(object sender, EventArgs e)
        {
            if (lookup)
                btnSearch.PerformClick();
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

            if (frmCustomerSearch.ShowDialog(this) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                this.Refresh();

                CS.Windows.Forms.GridViewHelper.PopulateGridView(Common.Application.Database.GetOleDbConnection(), grid, true, false, false, false,
                    selectSql,
                    frmCustomerSearch.txtCode.Text,
                    frmCustomerSearch.txtCode.Text,
                    frmCustomerSearch.txtName.Text,
                    frmCustomerSearch.txtName.Text,
                    frmCustomerSearch.txtAddress.Text,
                    frmCustomerSearch.txtAddress.Text,
                    frmCustomerSearch.txtAddress.Text,
                    frmCustomerSearch.txtAddress.Text,
                    frmCustomerSearch.txtShipTo.Text,
                    frmCustomerSearch.txtShipTo.Text,
                    frmCustomerSearch.txtShipTo.Text,
                    frmCustomerSearch.txtShipTo.Text,
                    frmCustomerSearch.txtShipTo.Text,
                    frmCustomerSearch.txtContact.Text,
                    frmCustomerSearch.txtContact.Text,
                    frmCustomerSearch.txtPhone.Text,
                    frmCustomerSearch.txtPhone.Text,
                    frmCustomerSearch.txtFax.Text,
                    frmCustomerSearch.txtFax.Text,
                    frmCustomerSearch.txtEmail.Text,
                    frmCustomerSearch.txtEmail.Text);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            frmCustomer.txtOriginalCode.Text = "";

            if (frmCustomer.ShowDialog(this) == DialogResult.OK)
            {
                CS.Windows.Forms.GridViewHelper.PopulateGridView(Common.Application.Database.GetOleDbConnection(), grid, false, false, true, true,
                    selectByKeySql, frmCustomer.txtCode.Text);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DataGridViewRow row = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid)[0];

            frmCustomer.txtOriginalCode.Text = (string)row.Cells["Code"].Value;

            if (frmCustomer.ShowDialog(this) == DialogResult.OK)
            {
                CS.Windows.Forms.GridViewHelper.PopulateGridRow(Common.Application.Database.GetOleDbConnection(), row,
                    selectByKeySql, frmCustomer.txtCode.Text);
            }

            this.Cursor = Cursors.Default;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            DataGridViewRow[] selectedRows = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid);

            if (MessageBox.Show(this, string.Format("Are you sure you want to delete {0} customer(s)?", selectedRows.GetUpperBound(0) + 1), "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Refresh();

                foreach (DataGridViewRow row in selectedRows)
                {
                    if ((int)Common.Application.Database.ExecuteScalar("SELECT COUNT(*) FROM Invoice WHERE Customer = ?;", row.Cells[0].Value) != 0)
                    {
                        MessageBox.Show(this, string.Format("Cannot delete '{0}'.\r\nInvoices exist for this customer.", row.Cells[0].Value), "Related Records", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Common.Application.Database.Execute("DELETE FROM Customer WHERE Code = ?", row.Cells[0].Value);
                        grid.Rows.Remove(row);
                    }
                }
            }

            this.Cursor = Cursors.Default;
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow[] selectedRows = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid);
            btnOpen.Enabled = (selectedRows.GetUpperBound(0) == 0);
            btnDelete.Enabled = (selectedRows.GetUpperBound(0) != -1);
            btnOK.Enabled = (selectedRows.GetUpperBound(0) == 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid)[0];

            lookupCode = (string)row.Cells["Code"].Value;
        }

    }
}
