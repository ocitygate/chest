using System;
using System.Windows.Forms;


namespace CS.Windows.Forms
{
    public class ComboBox : System.Windows.Forms.ComboBox
    {

        private bool required = false;
        public bool Required
        {
            get
            {
                return required;
            }
            set
            {
                required = value;
            }
        }

        private bool limitToList = false;
        public bool LimitToList
        {
            get
            {
                return limitToList;
            }
            set
            {
                limitToList = value;
            }
        }

        private string nullText = "(null)";
        public string NullText
        {
            get
            {
                return nullText;
            }
            set
            {
                nullText = value;
            }
        }

        protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (this.Text != nullText)
                {
                    this.Text = this.Text; //force update of selected index
                    if (this.SelectedIndex == -1)
                    {
                        MessageBox.Show(this.FindForm(), "Field is limited to list.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
                else
                {
                    if (required)
                    {
                        MessageBox.Show(this.FindForm(), "Field is required.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        e.Cancel = true;
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show(this.FindForm(), "Field is numeric.", "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            base.OnValidating(e);
        }


    }
}
