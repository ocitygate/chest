using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace InvMngr
{
    public partial class TrialForm : Form
    {
        public TrialForm()
        {
            InitializeComponent();
        }

        private string selectSql = "SELECT InstallDate, CompanyName, [Key] FROM System;";
        private string updateInstallDateSql = "UPDATE System SET InstallDate = ?;";

        private void TrialForm_Load(object sender, EventArgs e)
        {
            if (Common.Application.Database.ExecuteScalar(selectSql) == Convert.DBNull)
                Common.Application.Database.Execute(updateInstallDateSql, DateTime.Now.Date);

            DateTime varInstallDate;
            int varTrialPeriod;
            DateTime varExpiresOn;
            int varDaysRemaining;
            string varCompanyName;
            string varKey;

            System.Data.OleDb.OleDbDataReader reader = Common.Application.Database.ExecuteReader(selectSql);
            reader.Read();

            varInstallDate    = (DateTime)reader["InstallDate"];
            varTrialPeriod    = 30;
            varExpiresOn      = varInstallDate.AddDays(varTrialPeriod);
            varDaysRemaining  = varExpiresOn.Subtract(DateTime.Now.Date).Days;

            varCompanyName    = (string)reader["CompanyName"];
            varKey            = (string)reader["Key"];

            reader.Close();

            if (validateKey(varCompanyName, varKey))
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            txtInstallDate.Text = string.Format("{0:dd-MMM-yyyy}", varInstallDate);
            txtTrialPeriod.Text = string.Format("{0} days", varTrialPeriod);
            txtExpiresOn.Text = string.Format("{0:dd-MMM-yyyy}", varExpiresOn);
            if (varDaysRemaining < 0)
            {
                txtDaysRemaining.Text = "Expired";
                txtDaysRemaining.ForeColor = Color.Red;
            }
            else
            {
                txtDaysRemaining.Text = string.Format("{0} days", varDaysRemaining);
                txtDaysRemaining.ForeColor = Color.Empty;
                btnContinue.Enabled = true;
            }
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {

        }

        private void btnBuyOnline_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://cscustomsoftware.com/invmngr/buyonline.php");
        }

        private void btnEnterCodes_Click(object sender, EventArgs e)
        {
            if (new KeyForm().ShowDialog() == DialogResult.OK)
                TrialForm_Load(null, null);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        public static bool validateKey(string CompanyName, string Key)
        {
            byte[] ascii = Encoding.ASCII.GetBytes(CompanyName);
            byte[] hash = new byte[8] {0xD8,0xEE,0x7D,0xF6,0xF6,0xF3,0x8F,0x96};
            for (int i = 0; i < ascii.Length; i++)
                hash[i % 8] ^= ascii[i];
            string keyx = BitConverter.ToString(hash);
            keyx = keyx.Replace("-", "");
            return (Key == keyx);
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
