namespace InvMngr
{
    partial class InvoiceSearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceSearchForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.txtReferenceTo = new System.Windows.Forms.TextBox();
            this.txtReferenceFrom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dteDateTo = new System.Windows.Forms.DateTimePicker();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.dteDateFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSearch.Image = global::InvMngr.Properties.Resources.search16x16;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(118, 214);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(84, 26);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "     &Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::InvMngr.Properties.Resources.cancel16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(207, 214);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "     &Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.btnCustomerSearch);
            this.panel1.Controls.Add(this.txtReferenceTo);
            this.panel1.Controls.Add(this.txtReferenceFrom);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dteDateTo);
            this.panel1.Controls.Add(this.cmbCustomer);
            this.panel1.Controls.Add(this.dteDateFrom);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 199);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 19);
            this.label5.TabIndex = 4;
            this.label5.Text = "&Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "&Reference";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(11, 154);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MaxLength = 10;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(251, 21);
            this.txtName.TabIndex = 11;
            this.txtName.TabStop = false;
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.Image = global::InvMngr.Properties.Resources.search16x16;
            this.btnCustomerSearch.Location = new System.Drawing.Point(238, 127);
            this.btnCustomerSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(24, 24);
            this.btnCustomerSearch.TabIndex = 10;
            this.btnCustomerSearch.TabStop = false;
            this.btnCustomerSearch.Text = "     &Open";
            this.btnCustomerSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.btnCustomerSearch, "Search (F3)");
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // txtReferenceTo
            // 
            this.txtReferenceTo.Location = new System.Drawing.Point(157, 35);
            this.txtReferenceTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReferenceTo.MaxLength = 10;
            this.txtReferenceTo.Name = "txtReferenceTo";
            this.txtReferenceTo.Size = new System.Drawing.Size(105, 21);
            this.txtReferenceTo.TabIndex = 3;
            // 
            // txtReferenceFrom
            // 
            this.txtReferenceFrom.Location = new System.Drawing.Point(11, 35);
            this.txtReferenceFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReferenceFrom.MaxLength = 10;
            this.txtReferenceFrom.Name = "txtReferenceFrom";
            this.txtReferenceFrom.Size = new System.Drawing.Size(105, 21);
            this.txtReferenceFrom.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(122, 35);
            this.label3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = ">>";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(122, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = ">>";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dteDateTo
            // 
            this.dteDateTo.Checked = false;
            this.dteDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDateTo.Location = new System.Drawing.Point(157, 85);
            this.dteDateTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dteDateTo.Name = "dteDateTo";
            this.dteDateTo.ShowCheckBox = true;
            this.dteDateTo.Size = new System.Drawing.Size(105, 21);
            this.dteDateTo.TabIndex = 7;
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(11, 129);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(221, 21);
            this.cmbCustomer.TabIndex = 9;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            this.cmbCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCustomer_KeyDown);
            // 
            // dteDateFrom
            // 
            this.dteDateFrom.Checked = false;
            this.dteDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDateFrom.Location = new System.Drawing.Point(11, 85);
            this.dteDateFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dteDateFrom.Name = "dteDateFrom";
            this.dteDateFrom.ShowCheckBox = true;
            this.dteDateFrom.Size = new System.Drawing.Size(105, 21);
            this.dteDateFrom.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 8;
            this.label6.Text = "C&ustomer";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            // 
            // InvoiceSearchForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(300, 247);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceSearchForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Invoices - Search";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker dteDateTo;
        public System.Windows.Forms.ComboBox cmbCustomer;
        public System.Windows.Forms.DateTimePicker dteDateFrom;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txtReferenceFrom;
        public System.Windows.Forms.TextBox txtReferenceTo;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip toolTip;
    }
}