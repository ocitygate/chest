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
	public class TaxForm : System.Windows.Forms.Form
    {
		private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private Panel panel1;
        private Label label1;
        public TextBox txtDescription;
        private Label label6;
        public TextBox txtCode;
        public TextBox txtOriginalCode;
        private CS.Windows.Forms.TextBoxNum txtRate;
        private Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public TaxForm()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaxForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRate = new CS.Windows.Forms.TextBoxNum();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOriginalCode = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
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
            this.btnSave.Location = new System.Drawing.Point(178, 121);
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
            this.btnCancel.Location = new System.Drawing.Point(269, 121);
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
            this.panel1.Controls.Add(this.txtRate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtOriginalCode);
            this.panel1.Controls.Add(this.txtCode);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 104);
            this.panel1.TabIndex = 0;
            this.panel1.TabStop = true;
            // 
            // txtRate
            // 
            this.txtRate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRate.Format = "0.0000";
            this.txtRate.Location = new System.Drawing.Point(94, 64);
            this.txtRate.MaxValue = 9999.9999;
            this.txtRate.MinValue = 0;
            this.txtRate.Name = "txtRate";
            this.txtRate.Required = false;
            this.txtRate.Size = new System.Drawing.Size(80, 21);
            this.txtRate.TabIndex = 6;
            this.txtRate.Value = null;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "&Rate %";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOriginalCode
            // 
            this.txtOriginalCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOriginalCode.Location = new System.Drawing.Point(94, -12);
            this.txtOriginalCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOriginalCode.MaxLength = 10;
            this.txtOriginalCode.Name = "txtOriginalCode";
            this.txtOriginalCode.Size = new System.Drawing.Size(80, 21);
            this.txtOriginalCode.TabIndex = 0;
            this.txtOriginalCode.Visible = false;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(94, 13);
            this.txtCode.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(80, 21);
            this.txtCode.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Description";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(94, 38);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(230, 21);
            this.txtDescription.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 21);
            this.label6.TabIndex = 1;
            this.label6.Text = "C&ode";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TaxForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(365, 153);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaxForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Tax Rate";
            this.Load += new System.EventHandler(this.TaxForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private string selectSql =
            "SELECT Code, Description, Rate " +
            "FROM Tax " +
            "WHERE Code = ?;";

        private string insertSql =
            "INSERT INTO Tax (Code, Description, Rate) " +
            "VALUES (?, ?, ?);";

        private string updateSql =
            "UPDATE Tax " +
            "SET Code = ?, Description = ?, Rate = ? " +
            "WHERE Code = ?;";

        private void TaxForm_Load(object sender, EventArgs e)
        {
            if (txtOriginalCode.Text == "")
            {
                txtCode.Text = "";
                txtDescription.Text = "";
                txtRate.Value = 0;

                txtRate.ReadOnly = false;
                txtRate.TabStop = true;
            }
            else
            {
                OleDbDataReader reader = Common.Application.Database.ExecuteReader(selectSql, txtOriginalCode.Text);
                if (reader.Read())
                {
                    txtCode.Text = (string)reader["Code"];
                    txtDescription.Text = (string)reader["Description"];
                    txtRate.Value = (decimal)reader["Rate"];
                }
                reader.Close();

                if ((int)Common.Application.Database.ExecuteScalar("SELECT COUNT(*) FROM InvoiceLine WHERE Tax = ?;", txtOriginalCode.Text) != 0)
                {
                    txtRate.ReadOnly = true;
                    txtRate.TabStop = false;
                }
                else
                {
                    txtRate.ReadOnly = false;
                    txtRate.TabStop = true;
                }
            }
            txtCode.Select();
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

            if ((int)Common.Application.Database.ExecuteScalar("SELECT COUNT(*) FROM Tax WHERE Code = ? AND Code <> ?;",
                txtCode.Text, txtOriginalCode.Text) != 0)
            {
                MessageBox.Show("Code already exists.", "Unique Violation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCode.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (txtRate.Value == null)
            {
                MessageBox.Show("Rate is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRate.Select();
                DialogResult = DialogResult.None;
                return;
            }

            if (txtOriginalCode.Text == "")
            {
                Common.Application.Database.Execute(insertSql,
                    txtCode.Text,
                    txtDescription.Text,
                    txtRate.Value);
            }
            else
            {
                Common.Application.Database.Execute(updateSql,
                    txtCode.Text,
                    txtDescription.Text,
                    txtRate.Value,
                    txtOriginalCode.Text);
            }
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
