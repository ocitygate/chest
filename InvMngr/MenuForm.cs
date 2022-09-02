using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace InvMngr
{
	/// <summary>
	/// Summary description for MenuForm.
	/// </summary>
	public class MenuForm : System.Windows.Forms.Form
    {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MenuForm()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tsbInvoice = new System.Windows.Forms.ToolStripButton();
            this.tsbCustomers = new System.Windows.Forms.ToolStripButton();
            this.tsbSystem = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsTax = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbAbout = new System.Windows.Forms.ToolStripButton();
            this.bgwkCheckPoint = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExit,
            this.tsbInvoice,
            this.tsbCustomers,
            this.tsbSystem,
            this.tsbAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(794, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbExit
            // 
            this.tsbExit.Image = global::InvMngr.Properties.Resources.exit16x16;
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(45, 22);
            this.tsbExit.Text = "E&xit";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tsbInvoice
            // 
            this.tsbInvoice.Image = global::InvMngr.Properties.Resources.invoice16x16;
            this.tsbInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInvoice.Name = "tsbInvoice";
            this.tsbInvoice.Size = new System.Drawing.Size(67, 22);
            this.tsbInvoice.Text = "&Invoices";
            this.tsbInvoice.Click += new System.EventHandler(this.tsbInvoice_Click);
            // 
            // tsbCustomers
            // 
            this.tsbCustomers.Image = global::InvMngr.Properties.Resources.customer16x16;
            this.tsbCustomers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCustomers.Name = "tsbCustomers";
            this.tsbCustomers.Size = new System.Drawing.Size(78, 22);
            this.tsbCustomers.Text = "&Customers";
            this.tsbCustomers.Click += new System.EventHandler(this.tsbCustomers_Click);
            // 
            // tsbSystem
            // 
            this.tsbSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsTax,
            this.tsOptions,
            this.toolStripSeparator1,
            this.tsChangePassword});
            this.tsbSystem.Image = global::InvMngr.Properties.Resources.system16x16;
            this.tsbSystem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSystem.Name = "tsbSystem";
            this.tsbSystem.Size = new System.Drawing.Size(71, 22);
            this.tsbSystem.Text = "&System";
            // 
            // tsTax
            // 
            this.tsTax.Image = global::InvMngr.Properties.Resources.tax16x16;
            this.tsTax.Name = "tsTax";
            this.tsTax.Size = new System.Drawing.Size(160, 22);
            this.tsTax.Text = "&Tax Rates";
            this.tsTax.Click += new System.EventHandler(this.tsTax_Click);
            // 
            // tsOptions
            // 
            this.tsOptions.Image = global::InvMngr.Properties.Resources.options16x16;
            this.tsOptions.Name = "tsOptions";
            this.tsOptions.Size = new System.Drawing.Size(160, 22);
            this.tsOptions.Text = "&Options";
            this.tsOptions.Click += new System.EventHandler(this.tsOptions_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
            // 
            // tsChangePassword
            // 
            this.tsChangePassword.Image = global::InvMngr.Properties.Resources.login16x16;
            this.tsChangePassword.Name = "tsChangePassword";
            this.tsChangePassword.Size = new System.Drawing.Size(160, 22);
            this.tsChangePassword.Text = "Change &Password";
            this.tsChangePassword.Click += new System.EventHandler(this.tsChangePassword_Click);
            // 
            // tsbAbout
            // 
            this.tsbAbout.Image = global::InvMngr.Properties.Resources.about16x16;
            this.tsbAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbout.Name = "tsbAbout";
            this.tsbAbout.Size = new System.Drawing.Size(56, 22);
            this.tsbAbout.Text = "&About";
            this.tsbAbout.Click += new System.EventHandler(this.tsbAbout_Click);
            // 
            // bgwkCheckPoint
            // 
            this.bgwkCheckPoint.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwkCheckPoint_DoWork);
            // 
            // MenuForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(794, 538);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CS Invoice Manager";
            this.Shown += new System.EventHandler(this.MenuForm_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private ToolStrip toolStrip1;
        private ToolStripButton tsbExit;
        private ToolStripButton tsbInvoice;
        private ToolStripButton tsbCustomers;
        private ToolStripDropDownButton tsbSystem;
        private ToolStripMenuItem tsOptions;
        private ToolStripMenuItem tsChangePassword;
        private ToolStripMenuItem tsTax;
        private ToolStripSeparator toolStripSeparator1;
        private BackgroundWorker bgwkCheckPoint;
        private ToolStripButton tsbAbout;

        private void MenuForm_Shown(object sender, EventArgs e)
        {
            secure();
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbInvoice_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            (new InvoiceListForm()).ShowDialog(this);

            this.Cursor = Cursors.Default;
        }

        private void tsbCustomers_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            (new CustomerListForm()).ShowDialog(this);

            this.Cursor = Cursors.Default;
        }

        private void tsbAbout_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            (new AboutForm()).ShowDialog(this);

            this.Cursor = Cursors.Default;
        }

        private void tsOptions_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            (new OptionsForm()).ShowDialog(this);

            this.Cursor = Cursors.Default;
        }

        private void tsChangePassword_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            (new ChangePasswordForm()).ShowDialog(this);

            this.Cursor = Cursors.Default;
        }

        private void tsTax_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            (new TaxListForm()).ShowDialog(this);

            this.Cursor = Cursors.Default;
        }

        private void secure()
        {
            try
            {
                Common.Application.Database.GetOleDbConnection();
            }
            catch
            {
                MessageBox.Show(this,
                    "There was an error when attemping to connect to the database.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            string dbVersion = (string)Common.Application.Database.ExecuteScalar("SELECT DbVersion FROM System;");
            if (dbVersion != Common.Application.Version)
            {
                MessageBox.Show(this,
                    string.Format(
                        "Application and database versions do not match.\n" +
                        "Application version is {0}.\n" +
                        "Database version is {1}.\n",
                        Common.Application.Version, dbVersion),
                    "Incorrect Version", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            bgwkCheckPoint.RunWorkerAsync();

            if ((new LoginForm()).ShowDialog() != DialogResult.OK)
            {
                this.Close();
                return;
            }

            /*
            if ((new TrialForm()).ShowDialog() != DialogResult.OK)
            {
                this.Close();
                return;
            }
            */
        }

        private void bgwkCheckPoint_DoWork(object sender, DoWorkEventArgs e)
        {
            string responseURL;
            CS.IO.FileHelper.ReadURL("http://cscustomsoftware.com/invmngr/checkpoint.php?installid=" + Global.InstallID, out responseURL);
        }

	}
}
