using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace CS.Windows.Forms
{
	public class MessageForm : System.Windows.Forms.Form
	{
		#region UI Control Fields

		private System.Windows.Forms.Label lblCaption;
		private System.Windows.Forms.GroupBox grbMessage;
		private System.Windows.Forms.Label lblMessage;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Panel pnlCancel;
		private System.Windows.Forms.Panel pnlOK;

		private System.ComponentModel.Container components = null;

		#endregion

		#region Contructor / Dispose

		public MessageForm()
		{
			InitializeComponent();
		}

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

		#endregion

		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.lblCaption = new System.Windows.Forms.Label();
			this.grbMessage = new System.Windows.Forms.GroupBox();
			this.lblMessage = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pnlOK = new System.Windows.Forms.Panel();
			this.btnOK = new System.Windows.Forms.Button();
			this.pnlCancel = new System.Windows.Forms.Panel();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grbMessage.SuspendLayout();
			this.panel1.SuspendLayout();
			this.pnlOK.SuspendLayout();
			this.pnlCancel.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblCaption
			// 
			this.lblCaption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblCaption.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.lblCaption.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblCaption.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblCaption.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lblCaption.Location = new System.Drawing.Point(4, 4);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(320, 24);
			this.lblCaption.TabIndex = 0;
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grbMessage
			// 
			this.grbMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grbMessage.Controls.Add(this.lblMessage);
			this.grbMessage.Location = new System.Drawing.Point(4, 27);
			this.grbMessage.Name = "grbMessage";
			this.grbMessage.Size = new System.Drawing.Size(320, 73);
			this.grbMessage.TabIndex = 1;
			this.grbMessage.TabStop = false;
			// 
			// lblMessage
			// 
			this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMessage.Location = new System.Drawing.Point(16, 29);
			this.lblMessage.Name = "lblMessage";
			this.lblMessage.Size = new System.Drawing.Size(288, 27);
			this.lblMessage.TabIndex = 0;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.Controls.Add(this.pnlOK);
			this.panel1.Controls.Add(this.pnlCancel);
			this.panel1.Location = new System.Drawing.Point(4, 104);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(320, 24);
			this.panel1.TabIndex = 4;
			// 
			// pnlOK
			// 
			this.pnlOK.Controls.Add(this.btnOK);
			this.pnlOK.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlOK.Location = new System.Drawing.Point(152, 0);
			this.pnlOK.Name = "pnlOK";
			this.pnlOK.Size = new System.Drawing.Size(84, 24);
			this.pnlOK.TabIndex = 5;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(4, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 3;
			this.btnOK.Text = "OK";
			// 
			// pnlCancel
			// 
			this.pnlCancel.Controls.Add(this.btnCancel);
			this.pnlCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnlCancel.Location = new System.Drawing.Point(236, 0);
			this.pnlCancel.Name = "pnlCancel";
			this.pnlCancel.Size = new System.Drawing.Size(84, 24);
			this.pnlCancel.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(4, 0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			// 
			// MessageForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(328, 132);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lblCaption);
			this.Controls.Add(this.grbMessage);
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "MessageForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.grbMessage.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.pnlOK.ResumeLayout(false);
			this.pnlCancel.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public static DialogResult Show(Form owner, string caption, string message, bool showOK, bool showCancel)
		{
			MessageForm messageForm = new MessageForm();
			messageForm.lblCaption.Text = string.Format(" {0}", caption);
			messageForm.lblMessage.Text = message;
			messageForm.pnlOK.Visible = showOK;
			messageForm.pnlCancel.Visible = showCancel;
			return messageForm.ShowDialog(owner);
		}

	}
}
