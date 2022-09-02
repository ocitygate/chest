namespace InvMngr
{
    partial class InvoiceForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.gridInvoiceLine = new System.Windows.Forms.DataGridView();
            this.colInvoiceLine_LineType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInvoiceLine_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceLine_UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceLine_Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceLine_Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceLine_LineDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceLine_LineSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceLine_Tax = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colInvoiceLine_LineTax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colInvoiceLine_LineTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOriginalReference = new System.Windows.Forms.TextBox();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.chkShipToSameAsBillTo = new System.Windows.Forms.CheckBox();
            this.txtShipTo4 = new System.Windows.Forms.TextBox();
            this.txtShipTo3 = new System.Windows.Forms.TextBox();
            this.txtShipTo2 = new System.Windows.Forms.TextBox();
            this.txtShipTo1 = new System.Windows.Forms.TextBox();
            this.btnCustomerSearch = new System.Windows.Forms.Button();
            this.btnCustomerOpen = new System.Windows.Forms.Button();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btnCustomerNew = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.dteDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDiscountRate = new CS.Windows.Forms.TextBoxNum();
            this.txtTotal = new CS.Windows.Forms.TextBoxNum();
            this.txtShipping = new CS.Windows.Forms.TextBoxNum();
            this.txtTax = new CS.Windows.Forms.TextBoxNum();
            this.txtSubTotal = new CS.Windows.Forms.TextBoxNum();
            this.txtDiscount = new CS.Windows.Forms.TextBoxNum();
            this.txtValue = new CS.Windows.Forms.TextBoxNum();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.txtPaid = new CS.Windows.Forms.TextBoxNum();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBalance = new CS.Windows.Forms.TextBoxNum();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceLine)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::InvMngr.Properties.Resources.save16x16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(612, 502);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 26;
            this.btnSave.Text = "     &Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::InvMngr.Properties.Resources.cancel16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(701, 502);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 26);
            this.btnCancel.TabIndex = 27;
            this.btnCancel.Text = "     &Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 496);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(773, 2);
            this.label2.TabIndex = 25;
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveUp.Enabled = false;
            this.btnMoveUp.Image = global::InvMngr.Properties.Resources.up16x16;
            this.btnMoveUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoveUp.Location = new System.Drawing.Point(121, 373);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(104, 26);
            this.btnMoveUp.TabIndex = 3;
            this.btnMoveUp.TabStop = false;
            this.btnMoveUp.Text = "     Move &Up";
            this.btnMoveUp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnMoveDown.Enabled = false;
            this.btnMoveDown.Image = global::InvMngr.Properties.Resources.down16x16;
            this.btnMoveDown.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoveDown.Location = new System.Drawing.Point(231, 373);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(104, 26);
            this.btnMoveDown.TabIndex = 4;
            this.btnMoveDown.TabStop = false;
            this.btnMoveDown.Text = "     Move D&own";
            this.btnMoveDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = global::InvMngr.Properties.Resources.delete16x16;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(11, 373);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 26);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "     &Delete";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // gridInvoiceLine
            // 
            this.gridInvoiceLine.AllowUserToDeleteRows = false;
            this.gridInvoiceLine.AllowUserToResizeColumns = false;
            this.gridInvoiceLine.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            this.gridInvoiceLine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridInvoiceLine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInvoiceLine.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.gridInvoiceLine.ColumnHeadersHeight = 24;
            this.gridInvoiceLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridInvoiceLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colInvoiceLine_LineType,
            this.colInvoiceLine_Description,
            this.colInvoiceLine_UnitPrice,
            this.colInvoiceLine_Quantity,
            this.colInvoiceLine_Amount,
            this.colInvoiceLine_LineDiscount,
            this.colInvoiceLine_LineSubTotal,
            this.colInvoiceLine_Tax,
            this.colInvoiceLine_LineTax,
            this.colInvoiceLine_LineTotal});
            this.gridInvoiceLine.Location = new System.Drawing.Point(10, 179);
            this.gridInvoiceLine.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridInvoiceLine.Name = "gridInvoiceLine";
            this.gridInvoiceLine.RowHeadersWidth = 24;
            this.gridInvoiceLine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Gainsboro;
            this.gridInvoiceLine.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.gridInvoiceLine.Size = new System.Drawing.Size(775, 190);
            this.gridInvoiceLine.TabIndex = 1;
            this.gridInvoiceLine.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridInvoiceLine_CellBeginEdit);
            this.gridInvoiceLine.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.gridInvoiceLine_RowValidating);
            this.gridInvoiceLine.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInvoiceLine_CellValidated);
            this.gridInvoiceLine.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.gridInvoiceLine_CellValidating);
            this.gridInvoiceLine.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInvoiceLine_CellEndEdit);
            this.gridInvoiceLine.RowValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInvoiceLine_RowValidated);
            this.gridInvoiceLine.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.gridInvoiceLine_DefaultValuesNeeded);
            this.gridInvoiceLine.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridInvoiceLine_CellValueChanged);
            this.gridInvoiceLine.SelectionChanged += new System.EventHandler(this.gridInvoiceLine_SelectionChanged);
            // 
            // colInvoiceLine_LineType
            // 
            this.colInvoiceLine_LineType.HeaderText = "Type";
            this.colInvoiceLine_LineType.Items.AddRange(new object[] {
            "B",
            "F"});
            this.colInvoiceLine_LineType.Name = "colInvoiceLine_LineType";
            this.colInvoiceLine_LineType.Width = 48;
            // 
            // colInvoiceLine_Description
            // 
            this.colInvoiceLine_Description.HeaderText = "Description";
            this.colInvoiceLine_Description.MaxInputLength = 50;
            this.colInvoiceLine_Description.Name = "colInvoiceLine_Description";
            this.colInvoiceLine_Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceLine_Description.Width = 392;
            // 
            // colInvoiceLine_UnitPrice
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.colInvoiceLine_UnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.colInvoiceLine_UnitPrice.HeaderText = "Unit Price";
            this.colInvoiceLine_UnitPrice.Name = "colInvoiceLine_UnitPrice";
            this.colInvoiceLine_UnitPrice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceLine_UnitPrice.Width = 96;
            // 
            // colInvoiceLine_Quantity
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.colInvoiceLine_Quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.colInvoiceLine_Quantity.HeaderText = "Qty";
            this.colInvoiceLine_Quantity.Name = "colInvoiceLine_Quantity";
            this.colInvoiceLine_Quantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceLine_Quantity.Width = 48;
            // 
            // colInvoiceLine_Amount
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.colInvoiceLine_Amount.DefaultCellStyle = dataGridViewCellStyle4;
            this.colInvoiceLine_Amount.HeaderText = "Amount";
            this.colInvoiceLine_Amount.Name = "colInvoiceLine_Amount";
            this.colInvoiceLine_Amount.ReadOnly = true;
            this.colInvoiceLine_Amount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceLine_Amount.Width = 96;
            // 
            // colInvoiceLine_LineDiscount
            // 
            this.colInvoiceLine_LineDiscount.HeaderText = "LineDiscount";
            this.colInvoiceLine_LineDiscount.Name = "colInvoiceLine_LineDiscount";
            this.colInvoiceLine_LineDiscount.ReadOnly = true;
            this.colInvoiceLine_LineDiscount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceLine_LineDiscount.Visible = false;
            // 
            // colInvoiceLine_LineSubTotal
            // 
            this.colInvoiceLine_LineSubTotal.HeaderText = "LineSubTotal";
            this.colInvoiceLine_LineSubTotal.Name = "colInvoiceLine_LineSubTotal";
            this.colInvoiceLine_LineSubTotal.ReadOnly = true;
            this.colInvoiceLine_LineSubTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceLine_LineSubTotal.Visible = false;
            // 
            // colInvoiceLine_Tax
            // 
            this.colInvoiceLine_Tax.HeaderText = "Tax";
            this.colInvoiceLine_Tax.Name = "colInvoiceLine_Tax";
            this.colInvoiceLine_Tax.Width = 48;
            // 
            // colInvoiceLine_LineTax
            // 
            this.colInvoiceLine_LineTax.HeaderText = "LineTax";
            this.colInvoiceLine_LineTax.Name = "colInvoiceLine_LineTax";
            this.colInvoiceLine_LineTax.ReadOnly = true;
            this.colInvoiceLine_LineTax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceLine_LineTax.Visible = false;
            // 
            // colInvoiceLine_LineTotal
            // 
            this.colInvoiceLine_LineTotal.HeaderText = "LineTotal";
            this.colInvoiceLine_LineTotal.Name = "colInvoiceLine_LineTotal";
            this.colInvoiceLine_LineTotal.ReadOnly = true;
            this.colInvoiceLine_LineTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colInvoiceLine_LineTotal.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtOriginalReference);
            this.panel1.Controls.Add(this.txtReference);
            this.panel1.Controls.Add(this.chkShipToSameAsBillTo);
            this.panel1.Controls.Add(this.txtShipTo4);
            this.panel1.Controls.Add(this.txtShipTo3);
            this.panel1.Controls.Add(this.txtShipTo2);
            this.panel1.Controls.Add(this.txtShipTo1);
            this.panel1.Controls.Add(this.btnCustomerSearch);
            this.panel1.Controls.Add(this.btnCustomerOpen);
            this.panel1.Controls.Add(this.txtAddress3);
            this.panel1.Controls.Add(this.txtAddress2);
            this.panel1.Controls.Add(this.txtAddress1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.btnCustomerNew);
            this.panel1.Controls.Add(this.cmbCustomer);
            this.panel1.Controls.Add(this.dteDate);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 164);
            this.panel1.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(407, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 21);
            this.label13.TabIndex = 19;
            this.label13.Text = "S&hip To";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOriginalReference
            // 
            this.txtOriginalReference.Location = new System.Drawing.Point(478, -9);
            this.txtOriginalReference.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOriginalReference.MaxLength = 10;
            this.txtOriginalReference.Name = "txtOriginalReference";
            this.txtOriginalReference.Size = new System.Drawing.Size(284, 21);
            this.txtOriginalReference.TabIndex = 0;
            this.txtOriginalReference.Visible = false;
            // 
            // txtReference
            // 
            this.txtReference.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtReference.Location = new System.Drawing.Point(478, 16);
            this.txtReference.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtReference.MaxLength = 10;
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(284, 21);
            this.txtReference.TabIndex = 4;
            // 
            // chkShipToSameAsBillTo
            // 
            this.chkShipToSameAsBillTo.Location = new System.Drawing.Point(637, 44);
            this.chkShipToSameAsBillTo.Name = "chkShipToSameAsBillTo";
            this.chkShipToSameAsBillTo.Size = new System.Drawing.Size(117, 21);
            this.chkShipToSameAsBillTo.TabIndex = 14;
            this.chkShipToSameAsBillTo.Text = "Same As Bill To";
            this.chkShipToSameAsBillTo.UseVisualStyleBackColor = true;
            this.chkShipToSameAsBillTo.CheckedChanged += new System.EventHandler(this.chkShipToSameAsBillTo_CheckedChanged);
            // 
            // txtShipTo4
            // 
            this.txtShipTo4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipTo4.Location = new System.Drawing.Point(410, 126);
            this.txtShipTo4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtShipTo4.MaxLength = 50;
            this.txtShipTo4.Name = "txtShipTo4";
            this.txtShipTo4.Size = new System.Drawing.Size(344, 21);
            this.txtShipTo4.TabIndex = 18;
            // 
            // txtShipTo3
            // 
            this.txtShipTo3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipTo3.Location = new System.Drawing.Point(410, 106);
            this.txtShipTo3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtShipTo3.MaxLength = 50;
            this.txtShipTo3.Name = "txtShipTo3";
            this.txtShipTo3.Size = new System.Drawing.Size(344, 21);
            this.txtShipTo3.TabIndex = 17;
            // 
            // txtShipTo2
            // 
            this.txtShipTo2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipTo2.Location = new System.Drawing.Point(410, 86);
            this.txtShipTo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtShipTo2.MaxLength = 50;
            this.txtShipTo2.Name = "txtShipTo2";
            this.txtShipTo2.Size = new System.Drawing.Size(344, 21);
            this.txtShipTo2.TabIndex = 16;
            // 
            // txtShipTo1
            // 
            this.txtShipTo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipTo1.Location = new System.Drawing.Point(410, 66);
            this.txtShipTo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtShipTo1.MaxLength = 50;
            this.txtShipTo1.Name = "txtShipTo1";
            this.txtShipTo1.Size = new System.Drawing.Size(344, 21);
            this.txtShipTo1.TabIndex = 15;
            // 
            // btnCustomerSearch
            // 
            this.btnCustomerSearch.Image = global::InvMngr.Properties.Resources.search16x16;
            this.btnCustomerSearch.Location = new System.Drawing.Point(348, 39);
            this.btnCustomerSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomerSearch.Name = "btnCustomerSearch";
            this.btnCustomerSearch.Size = new System.Drawing.Size(24, 24);
            this.btnCustomerSearch.TabIndex = 9;
            this.btnCustomerSearch.TabStop = false;
            this.btnCustomerSearch.Text = "     &Open";
            this.btnCustomerSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.btnCustomerSearch, "Search (F3)");
            this.btnCustomerSearch.UseVisualStyleBackColor = true;
            this.btnCustomerSearch.Click += new System.EventHandler(this.btnCustomerSearch_Click);
            // 
            // btnCustomerOpen
            // 
            this.btnCustomerOpen.Enabled = false;
            this.btnCustomerOpen.Image = global::InvMngr.Properties.Resources.open16x16;
            this.btnCustomerOpen.Location = new System.Drawing.Point(324, 39);
            this.btnCustomerOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomerOpen.Name = "btnCustomerOpen";
            this.btnCustomerOpen.Size = new System.Drawing.Size(24, 24);
            this.btnCustomerOpen.TabIndex = 8;
            this.btnCustomerOpen.TabStop = false;
            this.btnCustomerOpen.Text = "     &Open";
            this.btnCustomerOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.btnCustomerOpen, "Open (F2)");
            this.btnCustomerOpen.UseVisualStyleBackColor = true;
            this.btnCustomerOpen.Click += new System.EventHandler(this.btnCustomerOpen_Click);
            // 
            // txtAddress3
            // 
            this.txtAddress3.Location = new System.Drawing.Point(28, 126);
            this.txtAddress3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress3.MaxLength = 50;
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.ReadOnly = true;
            this.txtAddress3.Size = new System.Drawing.Size(344, 21);
            this.txtAddress3.TabIndex = 13;
            this.txtAddress3.TabStop = false;
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(28, 106);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress2.MaxLength = 50;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.ReadOnly = true;
            this.txtAddress2.Size = new System.Drawing.Size(344, 21);
            this.txtAddress2.TabIndex = 12;
            this.txtAddress2.TabStop = false;
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(28, 86);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress1.MaxLength = 50;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.ReadOnly = true;
            this.txtAddress1.Size = new System.Drawing.Size(344, 21);
            this.txtAddress1.TabIndex = 11;
            this.txtAddress1.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(28, 66);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(344, 21);
            this.txtName.TabIndex = 10;
            this.txtName.TabStop = false;
            // 
            // btnCustomerNew
            // 
            this.btnCustomerNew.Image = global::InvMngr.Properties.Resources.new16x16;
            this.btnCustomerNew.Location = new System.Drawing.Point(300, 39);
            this.btnCustomerNew.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCustomerNew.Name = "btnCustomerNew";
            this.btnCustomerNew.Size = new System.Drawing.Size(24, 24);
            this.btnCustomerNew.TabIndex = 7;
            this.btnCustomerNew.TabStop = false;
            this.btnCustomerNew.Text = "     &Open";
            this.btnCustomerNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip.SetToolTip(this.btnCustomerNew, "New (F1)");
            this.btnCustomerNew.UseVisualStyleBackColor = true;
            this.btnCustomerNew.Click += new System.EventHandler(this.btnCustomerNew_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCustomer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(73, 41);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(225, 21);
            this.cmbCustomer.Sorted = true;
            this.cmbCustomer.TabIndex = 6;
            this.cmbCustomer.SelectedIndexChanged += new System.EventHandler(this.cmbCustomer_SelectedIndexChanged);
            this.cmbCustomer.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCustomer_KeyDown);
            // 
            // dteDate
            // 
            this.dteDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dteDate.Location = new System.Drawing.Point(73, 16);
            this.dteDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dteDate.Name = "dteDate";
            this.dteDate.Size = new System.Drawing.Size(299, 21);
            this.dteDate.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(25, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "&Bill To";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "D&ate";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(407, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 19);
            this.label4.TabIndex = 3;
            this.label4.Text = "&Reference";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(612, 371);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Value";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(612, 391);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "Discount";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(436, 411);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 21);
            this.label7.TabIndex = 11;
            this.label7.Text = "Sub-Total";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(436, 431);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "Tax";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Location = new System.Drawing.Point(612, 411);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 21);
            this.label9.TabIndex = 15;
            this.label9.Text = "Shi&pping";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Location = new System.Drawing.Point(612, 431);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 21);
            this.label10.TabIndex = 17;
            this.label10.Text = "Total";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.Location = new System.Drawing.Point(12, 401);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 21);
            this.label11.TabIndex = 23;
            this.label11.Text = "&Notes";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNotes
            // 
            this.txtNotes.AcceptsReturn = true;
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNotes.Location = new System.Drawing.Point(15, 424);
            this.txtNotes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(347, 61);
            this.txtNotes.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(404, 390);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 21);
            this.label12.TabIndex = 7;
            this.label12.Text = "Discoun&t Rate %";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDiscountRate
            // 
            this.txtDiscountRate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscountRate.Format = "N2";
            this.txtDiscountRate.Location = new System.Drawing.Point(513, 391);
            this.txtDiscountRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscountRate.MaxValue = 100;
            this.txtDiscountRate.MinValue = 0;
            this.txtDiscountRate.Name = "txtDiscountRate";
            this.txtDiscountRate.Required = false;
            this.txtDiscountRate.Size = new System.Drawing.Size(96, 21);
            this.txtDiscountRate.TabIndex = 8;
            this.txtDiscountRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscountRate.Value = ((object)(resources.GetObject("txtDiscountRate.Value")));
            this.txtDiscountRate.Validated += new System.EventHandler(this.txtDiscountRate_Validated);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.Format = "N2";
            this.txtTotal.Location = new System.Drawing.Point(689, 431);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotal.MaxValue = 1.7976931348623157E+308;
            this.txtTotal.MinValue = -1.7976931348623157E+308;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Required = false;
            this.txtTotal.Size = new System.Drawing.Size(96, 21);
            this.txtTotal.TabIndex = 18;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTotal.Value = ((object)(resources.GetObject("txtTotal.Value")));
            // 
            // txtShipping
            // 
            this.txtShipping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShipping.Format = "N2";
            this.txtShipping.Location = new System.Drawing.Point(689, 411);
            this.txtShipping.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtShipping.MaxValue = 9999999999999.998;
            this.txtShipping.MinValue = 0;
            this.txtShipping.Name = "txtShipping";
            this.txtShipping.Required = false;
            this.txtShipping.Size = new System.Drawing.Size(96, 21);
            this.txtShipping.TabIndex = 16;
            this.txtShipping.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtShipping.Value = ((object)(resources.GetObject("txtShipping.Value")));
            this.txtShipping.Validated += new System.EventHandler(this.txtShipping_Validated);
            // 
            // txtTax
            // 
            this.txtTax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTax.Format = "N2";
            this.txtTax.Location = new System.Drawing.Point(513, 431);
            this.txtTax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTax.MaxValue = 1.7976931348623157E+308;
            this.txtTax.MinValue = -1.7976931348623157E+308;
            this.txtTax.Name = "txtTax";
            this.txtTax.ReadOnly = true;
            this.txtTax.Required = false;
            this.txtTax.Size = new System.Drawing.Size(96, 21);
            this.txtTax.TabIndex = 14;
            this.txtTax.TabStop = false;
            this.txtTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTax.Value = ((object)(resources.GetObject("txtTax.Value")));
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubTotal.Format = "N2";
            this.txtSubTotal.Location = new System.Drawing.Point(513, 411);
            this.txtSubTotal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSubTotal.MaxValue = 1.7976931348623157E+308;
            this.txtSubTotal.MinValue = -1.7976931348623157E+308;
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Required = false;
            this.txtSubTotal.Size = new System.Drawing.Size(96, 21);
            this.txtSubTotal.TabIndex = 12;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSubTotal.Value = ((object)(resources.GetObject("txtSubTotal.Value")));
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscount.Format = "N2";
            this.txtDiscount.Location = new System.Drawing.Point(689, 391);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDiscount.MaxValue = 1.7976931348623157E+308;
            this.txtDiscount.MinValue = -1.7976931348623157E+308;
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Required = false;
            this.txtDiscount.Size = new System.Drawing.Size(96, 21);
            this.txtDiscount.TabIndex = 10;
            this.txtDiscount.TabStop = false;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDiscount.Value = ((object)(resources.GetObject("txtDiscount.Value")));
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Format = "N2";
            this.txtValue.Location = new System.Drawing.Point(689, 371);
            this.txtValue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtValue.MaxValue = 1.7976931348623157E+308;
            this.txtValue.MinValue = -1.7976931348623157E+308;
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Required = false;
            this.txtValue.Size = new System.Drawing.Size(96, 21);
            this.txtValue.TabIndex = 6;
            this.txtValue.TabStop = false;
            this.txtValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValue.Value = ((object)(resources.GetObject("txtValue.Value")));
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            // 
            // txtPaid
            // 
            this.txtPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaid.Format = "N2";
            this.txtPaid.Location = new System.Drawing.Point(513, 451);
            this.txtPaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPaid.MaxValue = 9999999999999.998;
            this.txtPaid.MinValue = 0;
            this.txtPaid.Name = "txtPaid";
            this.txtPaid.Required = false;
            this.txtPaid.Size = new System.Drawing.Size(96, 21);
            this.txtPaid.TabIndex = 20;
            this.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPaid.Value = ((object)(resources.GetObject("txtPaid.Value")));
            this.txtPaid.Validated += new System.EventHandler(this.txtPaid_Validated);
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.Location = new System.Drawing.Point(436, 451);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 21);
            this.label14.TabIndex = 19;
            this.label14.Text = "Pa&id";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBalance
            // 
            this.txtBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBalance.Format = "N2";
            this.txtBalance.Location = new System.Drawing.Point(689, 451);
            this.txtBalance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBalance.MaxValue = 1.7976931348623157E+308;
            this.txtBalance.MinValue = -1.7976931348623157E+308;
            this.txtBalance.Name = "txtBalance";
            this.txtBalance.ReadOnly = true;
            this.txtBalance.Required = false;
            this.txtBalance.Size = new System.Drawing.Size(96, 21);
            this.txtBalance.TabIndex = 22;
            this.txtBalance.TabStop = false;
            this.txtBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtBalance.Value = ((object)(resources.GetObject("txtBalance.Value")));
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(612, 451);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 21);
            this.label15.TabIndex = 21;
            this.label15.Text = "Balance";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 538);
            this.Controls.Add(this.txtBalance);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtPaid);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtDiscountRate);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtShipping);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTax);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridInvoiceLine);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InvoiceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice";
            this.Load += new System.EventHandler(this.RowForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridInvoiceLine)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCustomerNew;
        public System.Windows.Forms.ComboBox cmbCustomer;
        public System.Windows.Forms.DateTimePicker dteDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtShipTo4;
        public System.Windows.Forms.TextBox txtShipTo3;
        public System.Windows.Forms.TextBox txtShipTo2;
        public System.Windows.Forms.TextBox txtShipTo1;
        private System.Windows.Forms.Button btnCustomerSearch;
        private System.Windows.Forms.Button btnCustomerOpen;
        public System.Windows.Forms.TextBox txtAddress3;
        public System.Windows.Forms.TextBox txtAddress2;
        public System.Windows.Forms.TextBox txtAddress1;
        public System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.CheckBox chkShipToSameAsBillTo;
        public CS.Windows.Forms.TextBoxNum txtValue;
        private System.Windows.Forms.Label label3;
        public CS.Windows.Forms.TextBoxNum txtDiscount;
        private System.Windows.Forms.Label label1;
        public CS.Windows.Forms.TextBoxNum txtSubTotal;
        private System.Windows.Forms.Label label7;
        public CS.Windows.Forms.TextBoxNum txtTax;
        private System.Windows.Forms.Label label8;
        public CS.Windows.Forms.TextBoxNum txtShipping;
        private System.Windows.Forms.Label label9;
        public CS.Windows.Forms.TextBoxNum txtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtNotes;
        public CS.Windows.Forms.TextBoxNum txtDiscountRate;
        private System.Windows.Forms.Label label12;
        public System.Windows.Forms.TextBox txtReference;
        public System.Windows.Forms.TextBox txtOriginalReference;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.DataGridView gridInvoiceLine;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInvoiceLine_LineType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLine_Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLine_UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLine_Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLine_Amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLine_LineDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLine_LineSubTotal;
        private System.Windows.Forms.DataGridViewComboBoxColumn colInvoiceLine_Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLine_LineTax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInvoiceLine_LineTotal;
        public CS.Windows.Forms.TextBoxNum txtPaid;
        private System.Windows.Forms.Label label14;
        public CS.Windows.Forms.TextBoxNum txtBalance;
        private System.Windows.Forms.Label label15;
    }
}