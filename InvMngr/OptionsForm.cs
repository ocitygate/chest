using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;

namespace InvMngr
{
	/// <summary>
	/// Summary description for IncomingCallForm.
	/// </summary>
	public class OptionsForm : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private OpenFileDialog ofdLogo;
        private GroupBox groupBox1;
        private Button btnLogoBrowse;
        private PictureBox picLogo;
        public TextBox txtCompanyLine1;
        public TextBox txtCompanyLine2;
        public TextBox txtCompanyLine4;
        public TextBox txtCompanyLine3;
        public TextBox txtCompanyName;
        private GroupBox groupBox2;
        public ComboBox cmbCurrencySymbol;
        private Label label3;
        public ComboBox cmbDefTax;
        private Label label6;
        private GroupBox groupBox3;
        public TextBox txtInvoiceFooter;
        private GroupBox groupBox4;
        private CheckBox chkInvoiceReferenceAuto;
        private CheckBox chkInvoiceReferenceAllowChange;
        private Label label4;
        private CS.Windows.Forms.TextBoxNum txtInvoiceReferenceAutoDigits;
        private Label label1;
        private CS.Windows.Forms.TextBoxNum txtInvoiceReferenceAutoSeed;
        private Label label2;
        public TextBox txtInvoiceReferenceAutoPrefix;
        private Button btnLogoDelete;
        private Button btnEnterCodes;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public OptionsForm()
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
				if(components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OptionsForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ofdLogo = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEnterCodes = new System.Windows.Forms.Button();
            this.btnLogoDelete = new System.Windows.Forms.Button();
            this.btnLogoBrowse = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.txtCompanyLine1 = new System.Windows.Forms.TextBox();
            this.txtCompanyLine2 = new System.Windows.Forms.TextBox();
            this.txtCompanyLine4 = new System.Windows.Forms.TextBox();
            this.txtCompanyLine3 = new System.Windows.Forms.TextBox();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbCurrencySymbol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDefTax = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInvoiceFooter = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtInvoiceReferenceAutoPrefix = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtInvoiceReferenceAutoDigits = new CS.Windows.Forms.TextBoxNum();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInvoiceReferenceAutoSeed = new CS.Windows.Forms.TextBoxNum();
            this.label2 = new System.Windows.Forms.Label();
            this.chkInvoiceReferenceAllowChange = new System.Windows.Forms.CheckBox();
            this.chkInvoiceReferenceAuto = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::InvMngr.Properties.Resources.save16x16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(359, 440);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "     &Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Image = global::InvMngr.Properties.Resources.cancel16x16;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.Location = new System.Drawing.Point(450, 440);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 26);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "     &Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ofdLogo
            // 
            this.ofdLogo.Filter = resources.GetString("ofdLogo.Filter");
            this.ofdLogo.Title = "Browse";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnterCodes);
            this.groupBox1.Controls.Add(this.btnLogoDelete);
            this.groupBox1.Controls.Add(this.btnLogoBrowse);
            this.groupBox1.Controls.Add(this.picLogo);
            this.groupBox1.Controls.Add(this.txtCompanyLine1);
            this.groupBox1.Controls.Add(this.txtCompanyLine2);
            this.groupBox1.Controls.Add(this.txtCompanyLine4);
            this.groupBox1.Controls.Add(this.txtCompanyLine3);
            this.groupBox1.Controls.Add(this.txtCompanyName);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(522, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice &Header";
            // 
            // btnEnterCodes
            // 
            this.btnEnterCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnterCodes.Image = global::InvMngr.Properties.Resources.login16x16;
            this.btnEnterCodes.Location = new System.Drawing.Point(481, 22);
            this.btnEnterCodes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEnterCodes.Name = "btnEnterCodes";
            this.btnEnterCodes.Size = new System.Drawing.Size(24, 24);
            this.btnEnterCodes.TabIndex = 3;
            this.btnEnterCodes.TabStop = false;
            this.btnEnterCodes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnterCodes.UseVisualStyleBackColor = true;
            this.btnEnterCodes.Click += new System.EventHandler(this.btnEnterCodes_Click);
            // 
            // btnLogoDelete
            // 
            this.btnLogoDelete.Image = global::InvMngr.Properties.Resources.delete16x16;
            this.btnLogoDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoDelete.Location = new System.Drawing.Point(38, 121);
            this.btnLogoDelete.Name = "btnLogoDelete";
            this.btnLogoDelete.Size = new System.Drawing.Size(24, 24);
            this.btnLogoDelete.TabIndex = 1;
            this.btnLogoDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoDelete.UseVisualStyleBackColor = true;
            this.btnLogoDelete.Click += new System.EventHandler(this.btnLogoDelete_Click);
            // 
            // btnLogoBrowse
            // 
            this.btnLogoBrowse.Image = global::InvMngr.Properties.Resources.open16x16;
            this.btnLogoBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoBrowse.Location = new System.Drawing.Point(14, 121);
            this.btnLogoBrowse.Name = "btnLogoBrowse";
            this.btnLogoBrowse.Size = new System.Drawing.Size(24, 24);
            this.btnLogoBrowse.TabIndex = 0;
            this.btnLogoBrowse.Text = "     &Browse...";
            this.btnLogoBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogoBrowse.UseVisualStyleBackColor = true;
            this.btnLogoBrowse.Click += new System.EventHandler(this.btnLogoBrowse_Click);
            // 
            // picLogo
            // 
            this.picLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLogo.Location = new System.Drawing.Point(14, 24);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(91, 91);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLogo.TabIndex = 28;
            this.picLogo.TabStop = false;
            // 
            // txtCompanyLine1
            // 
            this.txtCompanyLine1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyLine1.Location = new System.Drawing.Point(111, 49);
            this.txtCompanyLine1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompanyLine1.MaxLength = 100;
            this.txtCompanyLine1.Name = "txtCompanyLine1";
            this.txtCompanyLine1.Size = new System.Drawing.Size(394, 21);
            this.txtCompanyLine1.TabIndex = 4;
            // 
            // txtCompanyLine2
            // 
            this.txtCompanyLine2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyLine2.Location = new System.Drawing.Point(111, 74);
            this.txtCompanyLine2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompanyLine2.MaxLength = 100;
            this.txtCompanyLine2.Name = "txtCompanyLine2";
            this.txtCompanyLine2.Size = new System.Drawing.Size(394, 21);
            this.txtCompanyLine2.TabIndex = 5;
            // 
            // txtCompanyLine4
            // 
            this.txtCompanyLine4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyLine4.Location = new System.Drawing.Point(111, 124);
            this.txtCompanyLine4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompanyLine4.MaxLength = 100;
            this.txtCompanyLine4.Name = "txtCompanyLine4";
            this.txtCompanyLine4.Size = new System.Drawing.Size(394, 21);
            this.txtCompanyLine4.TabIndex = 7;
            // 
            // txtCompanyLine3
            // 
            this.txtCompanyLine3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyLine3.Location = new System.Drawing.Point(111, 99);
            this.txtCompanyLine3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompanyLine3.MaxLength = 100;
            this.txtCompanyLine3.Name = "txtCompanyLine3";
            this.txtCompanyLine3.Size = new System.Drawing.Size(394, 21);
            this.txtCompanyLine3.TabIndex = 6;
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompanyName.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyName.Location = new System.Drawing.Point(111, 24);
            this.txtCompanyName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompanyName.MaxLength = 100;
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.ReadOnly = true;
            this.txtCompanyName.Size = new System.Drawing.Size(367, 21);
            this.txtCompanyName.TabIndex = 2;
            this.txtCompanyName.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbCurrencySymbol);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbDefTax);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(12, 368);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 64);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "&Other Options";
            // 
            // cmbCurrencySymbol
            // 
            this.cmbCurrencySymbol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbCurrencySymbol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCurrencySymbol.FormattingEnabled = true;
            this.cmbCurrencySymbol.Items.AddRange(new object[] {
            "$",
            "£",
            "€"});
            this.cmbCurrencySymbol.Location = new System.Drawing.Point(131, 22);
            this.cmbCurrencySymbol.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCurrencySymbol.MaxLength = 3;
            this.cmbCurrencySymbol.Name = "cmbCurrencySymbol";
            this.cmbCurrencySymbol.Size = new System.Drawing.Size(105, 21);
            this.cmbCurrencySymbol.Sorted = true;
            this.cmbCurrencySymbol.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(11, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "C&urrency Symbol";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDefTax
            // 
            this.cmbDefTax.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cmbDefTax.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDefTax.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefTax.FormattingEnabled = true;
            this.cmbDefTax.Location = new System.Drawing.Point(400, 22);
            this.cmbDefTax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDefTax.MaxLength = 10;
            this.cmbDefTax.Name = "cmbDefTax";
            this.cmbDefTax.Size = new System.Drawing.Size(105, 21);
            this.cmbDefTax.Sorted = true;
            this.cmbDefTax.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(280, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "Default &Tax Rate";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtInvoiceFooter);
            this.groupBox3.Location = new System.Drawing.Point(12, 299);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 63);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Invoice &Footer";
            // 
            // txtInvoiceFooter
            // 
            this.txtInvoiceFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceFooter.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInvoiceFooter.Location = new System.Drawing.Point(14, 23);
            this.txtInvoiceFooter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInvoiceFooter.MaxLength = 100;
            this.txtInvoiceFooter.Name = "txtInvoiceFooter";
            this.txtInvoiceFooter.Size = new System.Drawing.Size(491, 21);
            this.txtInvoiceFooter.TabIndex = 0;
            this.txtInvoiceFooter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtInvoiceReferenceAutoPrefix);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtInvoiceReferenceAutoDigits);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.txtInvoiceReferenceAutoSeed);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.chkInvoiceReferenceAllowChange);
            this.groupBox4.Controls.Add(this.chkInvoiceReferenceAuto);
            this.groupBox4.Location = new System.Drawing.Point(12, 179);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(522, 114);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Invoice &Reference";
            // 
            // txtInvoiceReferenceAutoPrefix
            // 
            this.txtInvoiceReferenceAutoPrefix.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceReferenceAutoPrefix.Location = new System.Drawing.Point(321, 25);
            this.txtInvoiceReferenceAutoPrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInvoiceReferenceAutoPrefix.MaxLength = 10;
            this.txtInvoiceReferenceAutoPrefix.Name = "txtInvoiceReferenceAutoPrefix";
            this.txtInvoiceReferenceAutoPrefix.Size = new System.Drawing.Size(184, 21);
            this.txtInvoiceReferenceAutoPrefix.TabIndex = 3;
            this.txtInvoiceReferenceAutoPrefix.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(202, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "Prefix";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoiceReferenceAutoDigits
            // 
            this.txtInvoiceReferenceAutoDigits.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceReferenceAutoDigits.Format = "0";
            this.txtInvoiceReferenceAutoDigits.Location = new System.Drawing.Point(321, 51);
            this.txtInvoiceReferenceAutoDigits.MaxValue = 10;
            this.txtInvoiceReferenceAutoDigits.MinValue = 0;
            this.txtInvoiceReferenceAutoDigits.Name = "txtInvoiceReferenceAutoDigits";
            this.txtInvoiceReferenceAutoDigits.Required = false;
            this.txtInvoiceReferenceAutoDigits.Size = new System.Drawing.Size(184, 21);
            this.txtInvoiceReferenceAutoDigits.TabIndex = 5;
            this.txtInvoiceReferenceAutoDigits.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInvoiceReferenceAutoDigits.Value = null;
            this.txtInvoiceReferenceAutoDigits.Validated += new System.EventHandler(this.txtInvoiceReferenceAutoDigits_Validated);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(202, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Number Of Digits";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInvoiceReferenceAutoSeed
            // 
            this.txtInvoiceReferenceAutoSeed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInvoiceReferenceAutoSeed.Format = "0";
            this.txtInvoiceReferenceAutoSeed.Location = new System.Drawing.Point(321, 78);
            this.txtInvoiceReferenceAutoSeed.MaxValue = 999999;
            this.txtInvoiceReferenceAutoSeed.MinValue = 0;
            this.txtInvoiceReferenceAutoSeed.Name = "txtInvoiceReferenceAutoSeed";
            this.txtInvoiceReferenceAutoSeed.Required = false;
            this.txtInvoiceReferenceAutoSeed.Size = new System.Drawing.Size(184, 21);
            this.txtInvoiceReferenceAutoSeed.TabIndex = 7;
            this.txtInvoiceReferenceAutoSeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtInvoiceReferenceAutoSeed.Value = null;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(205, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Starting From";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkInvoiceReferenceAllowChange
            // 
            this.chkInvoiceReferenceAllowChange.Location = new System.Drawing.Point(14, 51);
            this.chkInvoiceReferenceAllowChange.Name = "chkInvoiceReferenceAllowChange";
            this.chkInvoiceReferenceAllowChange.Size = new System.Drawing.Size(175, 21);
            this.chkInvoiceReferenceAllowChange.TabIndex = 1;
            this.chkInvoiceReferenceAllowChange.Text = "Allow User To Change";
            this.chkInvoiceReferenceAllowChange.UseVisualStyleBackColor = true;
            // 
            // chkInvoiceReferenceAuto
            // 
            this.chkInvoiceReferenceAuto.Location = new System.Drawing.Point(14, 24);
            this.chkInvoiceReferenceAuto.Name = "chkInvoiceReferenceAuto";
            this.chkInvoiceReferenceAuto.Size = new System.Drawing.Size(175, 21);
            this.chkInvoiceReferenceAuto.TabIndex = 0;
            this.chkInvoiceReferenceAuto.Text = "Auto Generate";
            this.chkInvoiceReferenceAuto.UseVisualStyleBackColor = true;
            this.chkInvoiceReferenceAuto.CheckedChanged += new System.EventHandler(this.chkInvoiceReferenceAuto_CheckedChanged);
            // 
            // OptionsForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(546, 477);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private KeyForm frmKey = new KeyForm();

        private string selectSql = "SELECT Logo, CompanyName, CompanyLine1, CompanyLine2, CompanyLine3, CompanyLine4, InvoiceFooter, InvoiceReferenceAuto, InvoiceReferenceAllowChange, InvoiceReferenceAutoPrefix, InvoiceReferenceAutoDigits, InvoiceReferenceAutoSeed, CurrencySymbol, DefTax FROM System;";
        private string updateSql = "UPDATE `System` SET Logo = ?, CompanyLine1 = ?, CompanyLine2 = ?, CompanyLine3 = ?, CompanyLine4 = ?, InvoiceReferenceAuto = ?, InvoiceReferenceAllowChange = ?, InvoiceReferenceAutoPrefix = ?, InvoiceReferenceAutoDigits = ?, InvoiceReferenceAutoSeed = ?, InvoiceFooter = ?, CurrencySymbol = ?, DefTax = ?;";

        private bool loadingData = false;

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            loadingData = true;

            Common.Application.Database.PopulateComboBox(cmbDefTax, true, "SELECT Code FROM Tax ORDER BY Code;");

            OleDbDataReader reader = Common.Application.Database.ExecuteReader(selectSql);
            if (reader.Read())
            {
                if (reader["Logo"] == Convert.DBNull)
                {
                    picLogo.Image = null;
                }
                else
                {
                    byte[] imgLogo = (byte[])reader["Logo"];
                    System.IO.MemoryStream strLogo = new System.IO.MemoryStream(imgLogo);
                    picLogo.Image = Image.FromStream(strLogo);
                }

                txtCompanyName.Text    = (string)reader["CompanyName"];
                txtCompanyLine1.Text   = (string)reader["CompanyLine1"];
                txtCompanyLine2.Text   = (string)reader["CompanyLine2"];
                txtCompanyLine3.Text   = (string)reader["CompanyLine3"];
                txtCompanyLine4.Text   = (string)reader["CompanyLine4"];
                chkInvoiceReferenceAuto.Checked = (bool)reader["InvoiceReferenceAuto"];
                chkInvoiceReferenceAllowChange.Checked = (bool)reader["InvoiceReferenceAllowChange"];
                txtInvoiceReferenceAutoPrefix.Text = (string) reader["InvoiceReferenceAutoPrefix"];
                txtInvoiceReferenceAutoDigits.Value = (byte) reader["InvoiceReferenceAutoDigits"];
                txtInvoiceReferenceAutoSeed.Value = (decimal)reader["InvoiceReferenceAutoSeed"];
                txtInvoiceFooter.Text = (string)reader["InvoiceFooter"];
                cmbCurrencySymbol.Text = (string)reader["CurrencySymbol"];
                cmbDefTax.Text         = (string)reader["DefTax"];
            }
            reader.Close();

            updateInvoiceReferenceAutoEditable();
            updateInvoiceReferenceAutoSeedFormat();

            loadingData = false;

            txtCompanyName.Select();
        }

        private void btnLogoBrowse_Click(object sender, EventArgs e)
        {
            if (ofdLogo.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picLogo.Image = Image.FromFile(ofdLogo.FileName);
                }
                catch
                {
                    MessageBox.Show("Invalid image file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLogoDelete_Click(object sender, EventArgs e)
        {
            picLogo.Image = null;
        }

        private void btnEnterCodes_Click(object sender, EventArgs e)
        {
            frmKey.txtCompanyName.Text = txtCompanyName.Text;

            if (frmKey.ShowDialog(this) == DialogResult.OK)
            {
                txtCompanyName.Text = frmKey.txtCompanyName.Text;
            }
        }

        private void chkInvoiceReferenceAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (!loadingData)
            {
                updateInvoiceReferenceAutoEditable();
            }
        }

        private void txtInvoiceReferenceAutoDigits_Validated(object sender, EventArgs e)
        {
            updateInvoiceReferenceAutoSeedFormat();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkInvoiceReferenceAuto.Checked)
            {
                if (txtInvoiceReferenceAutoDigits.Value == null)
                {
                    MessageBox.Show("Number of Digits is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInvoiceReferenceAutoDigits.Select();
                    DialogResult = DialogResult.None;
                    return;
                }

                if (txtInvoiceReferenceAutoSeed.Value == null)
                {
                    MessageBox.Show("Starting From is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInvoiceReferenceAutoSeed.Select();
                    DialogResult = DialogResult.None;
                    return;
                }

                if (txtInvoiceReferenceAutoPrefix.Text.Length + (double)txtInvoiceReferenceAutoDigits.Value > 10)
                {
                    MessageBox.Show("Prefix length plus number of digits must not exceed 10.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtInvoiceReferenceAutoPrefix.Select();
                    DialogResult = DialogResult.None;
                    return;
                }
            }

            object imgLogo;
            if (picLogo.Image == null)
            {
                imgLogo = Convert.DBNull;
            }
            else
            {
                System.IO.MemoryStream strLogo = new System.IO.MemoryStream();
                picLogo.Image.Save(strLogo, System.Drawing.Imaging.ImageFormat.Bmp);
                imgLogo = strLogo.ToArray();
            }

            Common.Application.Database.Execute(updateSql,
                imgLogo,
                txtCompanyLine1.Text,
                txtCompanyLine2.Text,
                txtCompanyLine3.Text,
                txtCompanyLine4.Text,
                chkInvoiceReferenceAuto.Checked,
                chkInvoiceReferenceAuto.Checked ? chkInvoiceReferenceAllowChange.Checked : false,
                chkInvoiceReferenceAuto.Checked ? txtInvoiceReferenceAutoPrefix.Text : "",
                chkInvoiceReferenceAuto.Checked ? txtInvoiceReferenceAutoDigits.Value : 6,
                chkInvoiceReferenceAuto.Checked ? txtInvoiceReferenceAutoSeed.Value : 100001,
                txtInvoiceFooter.Text,
                cmbCurrencySymbol.Text,
                cmbDefTax.Text);
        }

        private void updateInvoiceReferenceAutoEditable()
        {
            if (chkInvoiceReferenceAuto.Checked)
            {
                txtInvoiceReferenceAutoPrefix.ReadOnly = false;
                txtInvoiceReferenceAutoPrefix.TabStop = true;

                txtInvoiceReferenceAutoDigits.ReadOnly = false;
                txtInvoiceReferenceAutoDigits.TabStop = true;

                txtInvoiceReferenceAutoSeed.ReadOnly = false;
                txtInvoiceReferenceAutoSeed.TabStop = true;
            }
            else
            {
                txtInvoiceReferenceAutoPrefix.ReadOnly = true;
                txtInvoiceReferenceAutoPrefix.TabStop = false;

                txtInvoiceReferenceAutoDigits.ReadOnly = true;
                txtInvoiceReferenceAutoDigits.TabStop = false;

                txtInvoiceReferenceAutoSeed.ReadOnly = true;
                txtInvoiceReferenceAutoSeed.TabStop = false;
            }
        }

        private void updateInvoiceReferenceAutoSeedFormat()
        {
            txtInvoiceReferenceAutoSeed.Format = new string('0', Convert.ToInt32(txtInvoiceReferenceAutoDigits.Value));
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
