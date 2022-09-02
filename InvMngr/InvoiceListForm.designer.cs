namespace InvMngr
{
    partial class InvoiceListForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceListForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grid = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtBalance = new CS.Windows.Forms.TextBoxNum();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPaid = new CS.Windows.Forms.TextBoxNum();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotal = new CS.Windows.Forms.TextBoxNum();
            this.label2 = new System.Windows.Forms.Label();
            this.txtShipping = new CS.Windows.Forms.TextBoxNum();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTax = new CS.Windows.Forms.TextBoxNum();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSubTotal = new CS.Windows.Forms.TextBoxNum();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDiscount = new CS.Windows.Forms.TextBoxNum();
            this.label6 = new System.Windows.Forms.Label();
            this.txtValue = new CS.Windows.Forms.TextBoxNum();
            this.label7 = new System.Windows.Forms.Label();
            this.colReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colShipping = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPaid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.panel1.SuspendLayout();
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
            this.colReference,
            this.colDate,
            this.colCustomer,
            this.colValue,
            this.colDiscount,
            this.colSubTotal,
            this.colTax,
            this.colShipping,
            this.colTotal,
            this.colPaid,
            this.colBalance});
            this.grid.Location = new System.Drawing.Point(12, 12);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 24;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grid.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(770, 428);
            this.grid.TabIndex = 0;
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            this.grid.SelectionChanged += new System.EventHandler(this.grid_SelectionChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Enabled = false;
            this.btnPrint.Image = global::InvMngr.Properties.Resources.print16x16;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Location = new System.Drawing.Point(372, 501);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 26);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "     &Print";
            this.btnPrint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::InvMngr.Properties.Resources.close16x16;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(698, 501);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 26);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "     &Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtValue);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtSubTotal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTax);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtShipping);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPaid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBalance);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(12, 446);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 50);
            this.panel1.TabIndex = 7;
            // 
            // txtBalance
            // 
            this.txtBalance.Format = "N2";
            this.txtBalance.Location = new System.Drawing.Point(668, 23);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBalance.MaxValue = 1.7976931348623157E+308;
            this.txtBalance.MinValue = -1.7976931348623157E+308;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Required = false;
            this.txtBalance.Size = new System.Drawing.Size(72, 21);
            this.txtBalance.TabIndex = 24;
            this.txtBalance.TabStop = false;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalance.Value = ((object)(resources.GetObject("txtBalance.Value")));
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(668, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 21);
            this.label15.TabIndex = 23;
            this.label15.Text = "∑ Balance";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPaid
            // 
            this.txtPaid.Format = "N2";
            this.txtPaid.Location = new System.Drawing.Point(596, 23);
            this.txtPaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaid.MaxValue = 1.7976931348623157E+308;
            this.txtPaid.MinValue = -1.7976931348623157E+308;
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.ReadOnly = true;
            this.txtPaid.Required = false;
            this.txtPaid.Size = new System.Drawing.Size(72, 21);
            this.txtPaid.TabIndex = 26;
            this.txtPaid.TabStop = false;
            this.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaid.Value = ((object)(resources.GetObject("txtPaid.Value")));
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(596, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "∑ Paid";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotal
            // 
            this.txtTotal.Format = "N2";
            this.txtTotal.Location = new System.Drawing.Point(524, 23);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.MaxValue = 1.7976931348623157E+308;
            this.txtTotal.MinValue = -1.7976931348623157E+308;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Required = false;
            this.txtTotal.Size = new System.Drawing.Size(72, 21);
            this.txtTotal.TabIndex = 28;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.Value = ((object)(resources.GetObject("txtTotal.Value")));
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(524, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "∑ Total";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShipping
            // 
            this.txtShipping.Format = "N2";
            this.txtShipping.Location = new System.Drawing.Point(452, 23);
            this.txtShipping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtShipping.MaxValue = 1.7976931348623157E+308;
            this.txtShipping.MinValue = -1.7976931348623157E+308;
            this.txtShipping.Name = "txtShipping";
            this.txtShipping.ReadOnly = true;
            this.txtShipping.Required = false;
            this.txtShipping.Size = new System.Drawing.Size(72, 21);
            this.txtShipping.TabIndex = 30;
            this.txtShipping.TabStop = false;
            this.txtShipping.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShipping.Value = ((object)(resources.GetObject("txtShipping.Value")));
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(452, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 29;
            this.label3.Text = "∑ Shipping";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTax
            // 
            this.txtTax.Format = "N2";
            this.txtTax.Location = new System.Drawing.Point(380, 23);
            this.txtTax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTax.MaxValue = 1.7976931348623157E+308;
            this.txtTax.MinValue = -1.7976931348623157E+308;
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Required = false;
            this.txtTax.Size = new System.Drawing.Size(72, 21);
            this.txtTax.TabIndex = 32;
            this.txtTax.TabStop = false;
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTax.Value = ((object)(resources.GetObject("txtTax.Value")));
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(380, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 21);
            this.label4.TabIndex = 31;
            this.label4.Text = "∑ Tax";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Format = "N2";
            this.txtSubTotal.Location = new System.Drawing.Point(308, 23);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubTotal.MaxValue = 1.7976931348623157E+308;
            this.txtSubTotal.MinValue = -1.7976931348623157E+308;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Required = false;
            this.txtSubTotal.Size = new System.Drawing.Size(72, 21);
            this.txtSubTotal.TabIndex = 34;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.Value = ((object)(resources.GetObject("txtSubTotal.Value")));
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(308, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 21);
            this.label5.TabIndex = 33;
            this.label5.Text = "∑ SubTotal";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Format = "N2";
            this.txtDiscount.Location = new System.Drawing.Point(236, 23);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscount.MaxValue = 1.7976931348623157E+308;
            this.txtDiscount.MinValue = -1.7976931348623157E+308;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Required = false;
            this.txtDiscount.Size = new System.Drawing.Size(72, 21);
            this.txtDiscount.TabIndex = 36;
            this.txtDiscount.TabStop = false;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.Value = ((object)(resources.GetObject("txtDiscount.Value")));
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(236, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 21);
            this.label6.TabIndex = 35;
            this.label6.Text = "∑ Discount";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtValue
            // 
            this.txtValue.Format = "N2";
            this.txtValue.Location = new System.Drawing.Point(164, 23);
            this.txtValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValue.MaxValue = 1.7976931348623157E+308;
            this.txtValue.MinValue = -1.7976931348623157E+308;
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Required = false;
            this.txtValue.Size = new System.Drawing.Size(72, 21);
            this.txtValue.TabIndex = 38;
            this.txtValue.TabStop = false;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValue.Value = ((object)(resources.GetObject("txtValue.Value")));
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(164, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 21);
            this.label7.TabIndex = 37;
            this.label7.Text = "∑ Value";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // colReference
            // 
            this.colReference.HeaderText = "Reference";
            this.colReference.Name = "colReference";
            this.colReference.ReadOnly = true;
            this.colReference.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colReference.Width = 96;
            // 
            // colDate
            // 
            dataGridViewCellStyle2.Format = "d";
            this.colDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDate.HeaderText = "Date";
            this.colDate.Name = "colDate";
            this.colDate.ReadOnly = true;
            this.colDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDate.Width = 80;
            // 
            // colCustomer
            // 
            this.colCustomer.HeaderText = "Customer";
            this.colCustomer.Name = "colCustomer";
            this.colCustomer.ReadOnly = true;
            this.colCustomer.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colCustomer.Width = 96;
            // 
            // colValue
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "0.00";
            this.colValue.DefaultCellStyle = dataGridViewCellStyle3;
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.ReadOnly = true;
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 8;
            // 
            // colDiscount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "0.00";
            this.colDiscount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDiscount.HeaderText = "Discount";
            this.colDiscount.Name = "colDiscount";
            this.colDiscount.ReadOnly = true;
            this.colDiscount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDiscount.Width = 8;
            // 
            // colSubTotal
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "0.00";
            this.colSubTotal.DefaultCellStyle = dataGridViewCellStyle5;
            this.colSubTotal.HeaderText = "SubTotal";
            this.colSubTotal.Name = "colSubTotal";
            this.colSubTotal.ReadOnly = true;
            this.colSubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colSubTotal.Width = 72;
            // 
            // colTax
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "0.00";
            this.colTax.DefaultCellStyle = dataGridViewCellStyle6;
            this.colTax.HeaderText = "Tax";
            this.colTax.Name = "colTax";
            this.colTax.ReadOnly = true;
            this.colTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTax.Width = 72;
            // 
            // colShipping
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "0.00";
            this.colShipping.DefaultCellStyle = dataGridViewCellStyle7;
            this.colShipping.HeaderText = "Shipping";
            this.colShipping.Name = "colShipping";
            this.colShipping.ReadOnly = true;
            this.colShipping.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colShipping.Width = 72;
            // 
            // colTotal
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "0.00";
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle8;
            this.colTotal.HeaderText = "Total";
            this.colTotal.Name = "colTotal";
            this.colTotal.ReadOnly = true;
            this.colTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTotal.Width = 72;
            // 
            // colPaid
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "0.00";
            this.colPaid.DefaultCellStyle = dataGridViewCellStyle9;
            this.colPaid.HeaderText = "Paid";
            this.colPaid.Name = "colPaid";
            this.colPaid.ReadOnly = true;
            this.colPaid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPaid.Width = 72;
            // 
            // colBalance
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "0.00";
            this.colBalance.DefaultCellStyle = dataGridViewCellStyle10;
            this.colBalance.HeaderText = "Balance";
            this.colBalance.Name = "colBalance";
            this.colBalance.ReadOnly = true;
            this.colBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colBalance.Width = 72;
            // 
            // InvoiceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 538);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.grid);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Invoices";
            this.Load += new System.EventHandler(this.ListForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        public CS.Windows.Forms.TextBoxNum txtBalance;
        private System.Windows.Forms.Label label15;
        public CS.Windows.Forms.TextBoxNum txtValue;
        private System.Windows.Forms.Label label7;
        public CS.Windows.Forms.TextBoxNum txtDiscount;
        private System.Windows.Forms.Label label6;
        public CS.Windows.Forms.TextBoxNum txtSubTotal;
        private System.Windows.Forms.Label label5;
        public CS.Windows.Forms.TextBoxNum txtTax;
        private System.Windows.Forms.Label label4;
        public CS.Windows.Forms.TextBoxNum txtShipping;
        private System.Windows.Forms.Label label3;
        public CS.Windows.Forms.TextBoxNum txtTotal;
        private System.Windows.Forms.Label label2;
        public CS.Windows.Forms.TextBoxNum txtPaid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colShipping;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPaid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBalance;
    }
}