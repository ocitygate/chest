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
	public class CustomerForm : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Panel panel1;
        private Label label7;
        public TextBox txtEmail;
        private Label label5;
        public TextBox txtFax;
        private Label label4;
        public TextBox txtPhone;
        private Label label3;
        public TextBox txtContact;
        private Label label2;
        private Label label1;
        private Label label13;
        private CheckBox chkDefShipToSameAsBillTo;
        public TextBox txtDefShipTo4;
        public TextBox txtDefShipTo3;
        public TextBox txtDefShipTo2;
        public TextBox txtDefShipTo1;
        public TextBox txtAddress3;
        public TextBox txtAddress2;
        public TextBox txtAddress1;
        public TextBox txtName;
        private Label label6;
        public TextBox txtCode;
        public TextBox txtOriginalCode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public CustomerForm()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtOriginalCode = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDefShipToSameAsBillTo = new System.Windows.Forms.CheckBox();
            this.txtDefShipTo4 = new System.Windows.Forms.TextBox();
            this.txtDefShipTo3 = new System.Windows.Forms.TextBox();
            this.txtDefShipTo2 = new System.Windows.Forms.TextBox();
            this.txtDefShipTo1 = new System.Windows.Forms.TextBox();
            this.txtAddress3 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Image = global::InvMngr.Properties.Resources.save16x16;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(596, 209);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 1;
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
            this.btnCancel.Location = new System.Drawing.Point(687, 209);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 26);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "     &Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtOriginalCode);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtFax);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPhone);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtContact);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.chkDefShipToSameAsBillTo);
            this.panel1.Controls.Add(this.txtDefShipTo4);
            this.panel1.Controls.Add(this.txtDefShipTo3);
            this.panel1.Controls.Add(this.txtDefShipTo2);
            this.panel1.Controls.Add(this.txtDefShipTo1);
            this.panel1.Controls.Add(this.txtAddress3);
            this.panel1.Controls.Add(this.txtAddress2);
            this.panel1.Controls.Add(this.txtAddress1);
            this.panel1.Controls.Add(this.txtName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 192);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txtOriginalCode
            // 
            this.txtOriginalCode.Location = new System.Drawing.Point(94, -12);
            this.txtOriginalCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOriginalCode.MaxLength = 10;
            this.txtOriginalCode.Name = "txtOriginalCode";
            this.txtOriginalCode.Size = new System.Drawing.Size(266, 21);
            this.txtOriginalCode.TabIndex = 0;
            this.txtOriginalCode.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCode.Location = new System.Drawing.Point(94, 13);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(266, 21);
            this.txtCode.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(395, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 21);
            this.label7.TabIndex = 21;
            this.label7.Text = "&Email";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(476, 148);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(266, 21);
            this.txtEmail.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(395, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 21);
            this.label5.TabIndex = 19;
            this.label5.Text = "&Fax";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(476, 123);
            this.txtFax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFax.MaxLength = 50;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(266, 21);
            this.txtFax.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 21);
            this.label4.TabIndex = 17;
            this.label4.Text = "&Phone";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(94, 148);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhone.MaxLength = 50;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(266, 21);
            this.txtPhone.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "Con&tact";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtContact
            // 
            this.txtContact.Location = new System.Drawing.Point(94, 123);
            this.txtContact.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContact.MaxLength = 50;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(266, 21);
            this.txtContact.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "&Address";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(395, 15);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(151, 21);
            this.label13.TabIndex = 9;
            this.label13.Text = "Default S&hip To";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkDefShipToSameAsBillTo
            // 
            this.chkDefShipToSameAsBillTo.Location = new System.Drawing.Point(625, 16);
            this.chkDefShipToSameAsBillTo.Name = "chkDefShipToSameAsBillTo";
            this.chkDefShipToSameAsBillTo.Size = new System.Drawing.Size(117, 21);
            this.chkDefShipToSameAsBillTo.TabIndex = 10;
            this.chkDefShipToSameAsBillTo.Text = "Same As Bill To";
            this.chkDefShipToSameAsBillTo.UseVisualStyleBackColor = true;
            this.chkDefShipToSameAsBillTo.CheckedChanged += new System.EventHandler(this.chkDefShipToSameAsBillTo_CheckedChanged);
            // 
            // txtDefShipTo4
            // 
            this.txtDefShipTo4.Location = new System.Drawing.Point(398, 98);
            this.txtDefShipTo4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDefShipTo4.MaxLength = 50;
            this.txtDefShipTo4.Name = "txtDefShipTo4";
            this.txtDefShipTo4.Size = new System.Drawing.Size(344, 21);
            this.txtDefShipTo4.TabIndex = 14;
            // 
            // txtDefShipTo3
            // 
            this.txtDefShipTo3.Location = new System.Drawing.Point(398, 78);
            this.txtDefShipTo3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDefShipTo3.MaxLength = 50;
            this.txtDefShipTo3.Name = "txtDefShipTo3";
            this.txtDefShipTo3.Size = new System.Drawing.Size(344, 21);
            this.txtDefShipTo3.TabIndex = 13;
            // 
            // txtDefShipTo2
            // 
            this.txtDefShipTo2.Location = new System.Drawing.Point(398, 58);
            this.txtDefShipTo2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDefShipTo2.MaxLength = 50;
            this.txtDefShipTo2.Name = "txtDefShipTo2";
            this.txtDefShipTo2.Size = new System.Drawing.Size(344, 21);
            this.txtDefShipTo2.TabIndex = 12;
            // 
            // txtDefShipTo1
            // 
            this.txtDefShipTo1.Location = new System.Drawing.Point(398, 38);
            this.txtDefShipTo1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDefShipTo1.MaxLength = 50;
            this.txtDefShipTo1.Name = "txtDefShipTo1";
            this.txtDefShipTo1.Size = new System.Drawing.Size(344, 21);
            this.txtDefShipTo1.TabIndex = 11;
            // 
            // txtAddress3
            // 
            this.txtAddress3.Location = new System.Drawing.Point(94, 98);
            this.txtAddress3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress3.MaxLength = 50;
            this.txtAddress3.Name = "txtAddress3";
            this.txtAddress3.Size = new System.Drawing.Size(266, 21);
            this.txtAddress3.TabIndex = 8;
            this.txtAddress3.Validated += new System.EventHandler(this.txtAddress3_Validated);
            // 
            // txtAddress2
            // 
            this.txtAddress2.Location = new System.Drawing.Point(94, 78);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress2.MaxLength = 50;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(266, 21);
            this.txtAddress2.TabIndex = 7;
            this.txtAddress2.Validated += new System.EventHandler(this.txtAddress2_Validated);
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(94, 58);
            this.txtAddress1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAddress1.MaxLength = 50;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(266, 21);
            this.txtAddress1.TabIndex = 6;
            this.txtAddress1.Validated += new System.EventHandler(this.txtAddress1_Validated);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(94, 38);
            this.txtName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(266, 21);
            this.txtName.TabIndex = 4;
            this.txtName.Validated += new System.EventHandler(this.txtName_Validated);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "C&ode";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CustomerForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(783, 241);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Customer";
            this.Load += new System.EventHandler(this.CustomerForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private string selectSql =
            "SELECT Code, Name, Address1, Address2, Address3, DefShipToSameAsBillTo, DefShipTo1, DefShipTo2, DefShipTo3, DefShipTo4, Contact, Phone, Fax, Email " +
            "FROM Customer " +
            "WHERE Code = ?;";

        private string insertSql =
            "INSERT INTO Customer (Code, Name, Address1, Address2, Address3, DefShipToSameAsBillTo, DefShipTo1, DefShipTo2, DefShipTo3, DefShipTo4, Contact, Phone, Fax, Email) " +
            "VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?);";

        private string updateSql =
            "UPDATE Customer " +
            "SET Code = ?, Name = ?, Address1 = ?, Address2 = ?, Address3 = ?, DefShipToSameAsBillTo = ?, DefShipTo1 = ?, DefShipTo2 = ?, DefShipTo3 = ?, DefShipTo4 = ?, Contact = ?, Phone = ?, Fax = ?, Email = ? " +
            "WHERE Code = ?;";

        private bool loadingData;

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            loadingData = true;

            if (txtOriginalCode.Text == "")
            {
                txtCode.Text = "";
                txtName.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                chkDefShipToSameAsBillTo.Checked = true;
                txtDefShipTo1.Text = "";
                txtDefShipTo2.Text = "";
                txtDefShipTo3.Text = "";
                txtDefShipTo4.Text = "";
                txtContact.Text = "";
                txtPhone.Text = "";
                txtFax.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                OleDbDataReader reader = Common.Application.Database.ExecuteReader(selectSql, txtOriginalCode.Text);
                if (reader.Read())
                {
                    txtCode.Text = (string)reader["Code"];
                    txtName.Text = (string)reader["Name"];
                    txtAddress1.Text = (string)reader["Address1"];
                    txtAddress2.Text = (string)reader["Address2"];
                    txtAddress3.Text = (string)reader["Address3"];
                    chkDefShipToSameAsBillTo.Checked = (bool)reader["DefShipToSameAsBillTo"];
                    txtDefShipTo1.Text = (string)reader["DefShipTo1"];
                    txtDefShipTo2.Text = (string)reader["DefShipTo2"];
                    txtDefShipTo3.Text = (string)reader["DefShipTo3"];
                    txtContact.Text = (string)reader["Contact"];
                    txtPhone.Text = (string)reader["Phone"];
                    txtFax.Text = (string)reader["Fax"];
                    txtEmail.Text = (string)reader["Email"];
                }
                reader.Close();
            }
            txtCode.Select();

            updateShipToEditable();
            updateShipToText();

            loadingData = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCode.Text == "")
            {
                MessageBox.Show("Code is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if ((int)Common.Application.Database.ExecuteScalar("SELECT COUNT(*) FROM Customer WHERE Code = ? AND Code <> ?;",
                txtCode.Text, txtOriginalCode.Text) != 0)
            {
                MessageBox.Show("Code already exists.", "Unique Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (txtOriginalCode.Text == "")
            {
                Common.Application.Database.Execute(insertSql,
                    txtCode.Text,
                    txtName.Text,
                    txtAddress1.Text,
                    txtAddress2.Text,
                    txtAddress3.Text,
                    chkDefShipToSameAsBillTo.Checked,
                    chkDefShipToSameAsBillTo.Checked ? "" : txtDefShipTo1.Text,
                    chkDefShipToSameAsBillTo.Checked ? "" : txtDefShipTo2.Text,
                    chkDefShipToSameAsBillTo.Checked ? "" : txtDefShipTo3.Text,
                    chkDefShipToSameAsBillTo.Checked ? "" : txtDefShipTo4.Text,
                    txtContact.Text,
                    txtPhone.Text,
                    txtFax.Text,
                    txtEmail.Text);
            }
            else
            {
                Common.Application.Database.Execute(updateSql,
                    txtCode.Text,
                    txtName.Text,
                    txtAddress1.Text,
                    txtAddress2.Text,
                    txtAddress3.Text,
                    chkDefShipToSameAsBillTo.Checked,
                    chkDefShipToSameAsBillTo.Checked ? "" : txtDefShipTo1.Text,
                    chkDefShipToSameAsBillTo.Checked ? "" : txtDefShipTo2.Text,
                    chkDefShipToSameAsBillTo.Checked ? "" : txtDefShipTo3.Text,
                    chkDefShipToSameAsBillTo.Checked ? "" : txtDefShipTo4.Text,
                    txtContact.Text,
                    txtPhone.Text,
                    txtFax.Text,
                    txtEmail.Text,
                    txtOriginalCode.Text);
            }
        }

        private void updateShipToEditable()
        {
            if (chkDefShipToSameAsBillTo.Checked)
            {
                txtDefShipTo1.ReadOnly = true;
                txtDefShipTo1.TabStop = false;

                txtDefShipTo2.ReadOnly = true;
                txtDefShipTo2.TabStop = false;

                txtDefShipTo3.ReadOnly = true;
                txtDefShipTo3.TabStop = false;

                txtDefShipTo4.ReadOnly = true;
                txtDefShipTo4.TabStop = false;
            }
            else
            {
                txtDefShipTo1.ReadOnly = false;
                txtDefShipTo1.TabStop = true;

                txtDefShipTo2.ReadOnly = false;
                txtDefShipTo2.TabStop = true;

                txtDefShipTo3.ReadOnly = false;
                txtDefShipTo3.TabStop = true;

                txtDefShipTo4.ReadOnly = false;
                txtDefShipTo4.TabStop = true;
            }
        }

        private void updateShipToText()
        {
            if (chkDefShipToSameAsBillTo.Checked)
            {
                txtDefShipTo1.Text = txtName.Text;
                txtDefShipTo2.Text = txtAddress1.Text;
                txtDefShipTo3.Text = txtAddress2.Text;
                txtDefShipTo4.Text = txtAddress3.Text;
            }
        }

        private void chkDefShipToSameAsBillTo_CheckedChanged(object sender, EventArgs e)
        {
            if (!loadingData)
            {
                updateShipToEditable();
                updateShipToText();
            }
        }

        private void txtName_Validated(object sender, EventArgs e)
        {
            updateShipToText();
        }

        private void txtAddress1_Validated(object sender, EventArgs e)
        {
            updateShipToText();
        }

        private void txtAddress2_Validated(object sender, EventArgs e)
        {
            updateShipToText();
        }

        private void txtAddress3_Validated(object sender, EventArgs e)
        {
            updateShipToText();
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
