using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PwdGen
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        GenerateForm frmGenerate = new GenerateForm();

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (frmGenerate.ShowDialog(this) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;

                grid.Rows.Clear();

                Random random = new Random();
                for (int i = 0; i < Convert.ToInt32(frmGenerate.txtQuantity.Value); i++)
                {
                    string password = "";
                    for (int j = 0; j < Convert.ToInt32(frmGenerate.txtLength.Value); j++)
                    {
                        char digit = ' ';
                        do
                        {
                            int digitcode = random.Next(0, 61);
                            if (digitcode >= 0 & digitcode <= 9)
                                digit = Convert.ToChar((digitcode + 48));
                            if (digitcode >= 10 & digitcode <= 35)
                                digit = Convert.ToChar((digitcode + 55));
                            if (digitcode >= 36 & digitcode <= 61)
                                digit = Convert.ToChar((digitcode + 61));

                        }
                        while (
                            digit == '0' | digit == '1' | digit == '2' | digit == '5' | digit == '6' | digit == '8' | digit == '9' | 
                            digit == 'b' | digit == 'l' | 
                            digit == 'B' | digit == 'D' | digit == 'I' | digit == 'O' | digit == 'S' | digit == 'Z');
                        password += digit;
                    }

                    object[] values = new object[] { password };

                    int ix = grid.Rows.Add(values);
                    grid.Rows[ix].Selected = true;
                }

                this.Cursor = Cursors.Default;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            string text = "";

            foreach (DataGridViewRow row in grid.SelectedRows)
            {
                if (text != "")
                    text += "\r\n";
                text += string.Format("{0:00000000}", row.Cells[0].Value);
            }

            Clipboard.SetText(text);
        }

    }
}
