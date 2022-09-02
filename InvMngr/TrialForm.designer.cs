namespace InvMngr
{
    partial class TrialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrialForm));
            this.btnEnterCodes = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnBuyOnline = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTrialPeriod = new System.Windows.Forms.TextBox();
            this.txtExpiresOn = new System.Windows.Forms.TextBox();
            this.txtDaysRemaining = new System.Windows.Forms.TextBox();
            this.txtInstallDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bgwkCheckPoint = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnterCodes
            // 
            this.btnEnterCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEnterCodes.Image = global::InvMngr.Properties.Resources.login16x16;
            this.btnEnterCodes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnterCodes.Location = new System.Drawing.Point(216, 137);
            this.btnEnterCodes.Name = "btnEnterCodes";
            this.btnEnterCodes.Size = new System.Drawing.Size(95, 26);
            this.btnEnterCodes.TabIndex = 3;
            this.btnEnterCodes.Text = "     &Enter Key";
            this.btnEnterCodes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnterCodes.UseVisualStyleBackColor = true;
            this.btnEnterCodes.Click += new System.EventHandler(this.btnEnterCodes_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Image = global::InvMngr.Properties.Resources.exit16x16;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Location = new System.Drawing.Point(317, 137);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(63, 26);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "     E&xit";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnBuyOnline
            // 
            this.btnBuyOnline.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBuyOnline.Image = global::InvMngr.Properties.Resources.buyonline16x16;
            this.btnBuyOnline.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuyOnline.Location = new System.Drawing.Point(109, 137);
            this.btnBuyOnline.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuyOnline.Name = "btnBuyOnline";
            this.btnBuyOnline.Size = new System.Drawing.Size(101, 26);
            this.btnBuyOnline.TabIndex = 2;
            this.btnBuyOnline.Text = "     &Buy Online";
            this.btnBuyOnline.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuyOnline.Click += new System.EventHandler(this.btnBuyOnline_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnContinue.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnContinue.Image = global::InvMngr.Properties.Resources.ok16x16;
            this.btnContinue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinue.Location = new System.Drawing.Point(12, 137);
            this.btnContinue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(91, 26);
            this.btnContinue.TabIndex = 1;
            this.btnContinue.Text = "     &Continue";
            this.btnContinue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtTrialPeriod);
            this.panel1.Controls.Add(this.txtExpiresOn);
            this.panel1.Controls.Add(this.txtDaysRemaining);
            this.panel1.Controls.Add(this.txtInstallDate);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 119);
            this.panel1.TabIndex = 0;
            // 
            // txtTrialPeriod
            // 
            this.txtTrialPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrialPeriod.Location = new System.Drawing.Point(134, 35);
            this.txtTrialPeriod.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTrialPeriod.MaxLength = 100;
            this.txtTrialPeriod.Name = "txtTrialPeriod";
            this.txtTrialPeriod.ReadOnly = true;
            this.txtTrialPeriod.Size = new System.Drawing.Size(213, 21);
            this.txtTrialPeriod.TabIndex = 3;
            this.txtTrialPeriod.TabStop = false;
            this.txtTrialPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtExpiresOn
            // 
            this.txtExpiresOn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpiresOn.Location = new System.Drawing.Point(134, 60);
            this.txtExpiresOn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtExpiresOn.MaxLength = 100;
            this.txtExpiresOn.Name = "txtExpiresOn";
            this.txtExpiresOn.ReadOnly = true;
            this.txtExpiresOn.Size = new System.Drawing.Size(213, 21);
            this.txtExpiresOn.TabIndex = 5;
            this.txtExpiresOn.TabStop = false;
            this.txtExpiresOn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDaysRemaining
            // 
            this.txtDaysRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDaysRemaining.Location = new System.Drawing.Point(134, 85);
            this.txtDaysRemaining.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDaysRemaining.MaxLength = 100;
            this.txtDaysRemaining.Name = "txtDaysRemaining";
            this.txtDaysRemaining.ReadOnly = true;
            this.txtDaysRemaining.Size = new System.Drawing.Size(213, 21);
            this.txtDaysRemaining.TabIndex = 7;
            this.txtDaysRemaining.TabStop = false;
            this.txtDaysRemaining.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtInstallDate
            // 
            this.txtInstallDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInstallDate.Location = new System.Drawing.Point(134, 10);
            this.txtInstallDate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtInstallDate.MaxLength = 100;
            this.txtInstallDate.Name = "txtInstallDate";
            this.txtInstallDate.ReadOnly = true;
            this.txtInstallDate.Size = new System.Drawing.Size(213, 21);
            this.txtInstallDate.TabIndex = 1;
            this.txtInstallDate.TabStop = false;
            this.txtInstallDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(13, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 19);
            this.label9.TabIndex = 2;
            this.label9.Text = "Trial Period";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Days Remaining";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Installation Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Expires On";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TrialForm
            // 
            this.AcceptButton = this.btnContinue;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(391, 174);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnBuyOnline);
            this.Controls.Add(this.btnContinue);
            this.Controls.Add(this.btnEnterCodes);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrialForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Software Trial";
            this.Load += new System.EventHandler(this.TrialForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnterCodes;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnBuyOnline;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox txtTrialPeriod;
        public System.Windows.Forms.TextBox txtExpiresOn;
        public System.Windows.Forms.TextBox txtDaysRemaining;
        public System.Windows.Forms.TextBox txtInstallDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgwkCheckPoint;
    }
}