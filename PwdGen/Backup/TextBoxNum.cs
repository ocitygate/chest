using System;
using System.Windows.Forms;

namespace PwdGen
{

    public class TextBoxNum : System.Windows.Forms.TextBox
	{

		private string format = "0";
		public  string Format
		{
			get
			{
				return format;
			}
			set
			{
				format = value;
                this.Value = this.Value;
			}
		}


		private double minValue = double.MinValue;
		public  double MinValue
		{
			get
			{
				return minValue;
			}
			set
			{
				minValue = value;
			}
		}
	

		private double maxValue = double.MaxValue;
		public  double MaxValue
		{
			get
			{
				return maxValue;
			}
			set
			{
				maxValue = value;
			}
		}

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

		public object Value
		{
			get
			{
				if (this.Text == "")
					return null;
				else
					return Convert.ToDouble(this.Text);
			}
			set
			{
				try
				{
					if (value == null)
						this.Text = "";
					else
						this.Text = string.Format("{0:" + format + "}", Convert.ToDouble(value));
				}
				catch
				{
					this.Text = "";
				}
			}
		}


		protected override void OnValidating(System.ComponentModel.CancelEventArgs e)
		{
			try
			{
                if (this.Text != "")
                {
                    double value = Convert.ToDouble(this.Text);
                    if ((value < minValue) || (value > maxValue))
                    {
                        MessageBox.Show(this.FindForm(), string.Format("Field range is {0} - {1}.", minValue, maxValue), "Invalid Entry", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

			base.OnValidating (e);
		}


		protected override void OnValidated(EventArgs e)
		{
			if (this.Text != "")
				this.Value = this.Text;

			base.OnValidated (e);
		}
		

	}

}
