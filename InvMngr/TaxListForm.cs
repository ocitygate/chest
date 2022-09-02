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
	public class TaxListForm : System.Windows.Forms.Form
    {
        private DataGridView grid;
        private Button btnNew;
        private Button btnOpen;
        private Button btnDelete;
        private Button btnCancel;
        private Button btnOK;
        private DataGridViewTextBoxColumn Code;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private Button btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public TaxListForm()
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxListForm));
            this.grid = new System.Windows.Forms.DataGridView();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.Column1,
            this.Column2});
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 24;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(370, 214);
            this.grid.TabIndex = 0;
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // Code
            // 
            this.Code.HeaderText = "Code";
            this.Code.MaxInputLength = 3;
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Width = 80;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Description";
            this.Column1.MaxInputLength = 50;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 160;
            // 
            // Column2
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "0.0000";
            this.Column2.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column2.HeaderText = "Rate %";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 80;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Image = global::InvMngr.Properties.Resources.new16x16;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(12, 231);
            this.btnNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 26);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "     &New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOpen.Enabled = false;
            this.btnOpen.Image = global::InvMngr.Properties.Resources.open16x16;
            this.btnOpen.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Location = new System.Drawing.Point(102, 231);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(84, 26);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "     &Open";
            this.btnOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::InvMngr.Properties.Resources.delete16x16;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(192, 231);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 26);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "     &Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::InvMngr.Properties.Resources.cancel16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(298, 231);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 26);
            this.btnCancel.TabIndex = 6;
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
            this.btnOK.Location = new System.Drawing.Point(208, 231);
            this.btnOK.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 26);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "     &OK";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::InvMngr.Properties.Resources.close16x16;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(298, 231);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 26);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "     &Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TaxListForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 268);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaxListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tax Rates";
            this.Load += new System.EventHandler(this.CustomerListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        public static string selectSql =
            "SELECT Code, Description, Rate " +
            "FROM Tax " +
            "ORDER BY Code;";

        public static string selectByKeySql =
            "SELECT Code, Description, Rate " +
            "FROM Tax " +
            "WHERE (Code = ?);";

        private TaxForm frmTax = new TaxForm();

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

            CS.Windows.Forms.GridViewHelper.PopulateGridView(Common.Application.Database.GetOleDbConnection(), grid, true, false, false, false, selectSql);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmTax.txtOriginalCode.Text = "";

            if (frmTax.ShowDialog(this) == DialogResult.OK)
            {
                CS.Windows.Forms.GridViewHelper.PopulateGridView(Common.Application.Database.GetOleDbConnection(), grid, false, false, true, true,
                    selectByKeySql, frmTax.txtCode.Text);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid)[0];

            frmTax.txtOriginalCode.Text = (string)row.Cells["Code"].Value;

            if (frmTax.ShowDialog(this) == DialogResult.OK)
            {
                CS.Windows.Forms.GridViewHelper.PopulateGridRow(Common.Application.Database.GetOleDbConnection(), row,
                    selectByKeySql, frmTax.txtCode.Text);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewRow[] selectedRows = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid);

            if (MessageBox.Show(this, string.Format("Are you sure you want to delete {0} tax rate(s)?", selectedRows.GetUpperBound(0) + 1), "Attention!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in selectedRows)
                {
                    if ((int)Common.Application.Database.ExecuteScalar("SELECT COUNT(*) FROM InvoiceLine WHERE Tax = ?;", row.Cells[0].Value) != 0)
                    {
                        MessageBox.Show(this, string.Format("Cannot delete '{0}'.\r\nTax Rate is in use.", row.Cells[0].Value), "Related Records", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Common.Application.Database.Execute("DELETE FROM Tax WHERE Code = ?", row.Cells[0].Value);
                        grid.Rows.Remove(row);
                    }
                }
            }
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow[] selectedRows = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid);
            btnOpen.Enabled = (selectedRows.GetUpperBound(0) == 0);
            btnDelete.Enabled = (selectedRows.GetUpperBound(0) != -1);
            btnOK.Enabled = (selectedRows.GetUpperBound(0) == 0);
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                if (btnOK.Visible & btnOK.Enabled)
                    btnOK.PerformClick();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = CS.Windows.Forms.GridViewHelper.GetSelectedRowsA(grid)[0];

            lookupCode = (string)row.Cells["Code"].Value;
        }

	}
}
