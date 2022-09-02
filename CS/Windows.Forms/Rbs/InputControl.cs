using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CS.Windows.Forms
{

	public class InputControl : System.Windows.Forms.UserControl
	{
		#region UI Control Fields

		private System.Windows.Forms.Label lblCaption;
		private System.Windows.Forms.GroupBox grbFields;
		private System.ComponentModel.Container components = null;

		#endregion

		#region Constructor / Dispose

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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblCaption = new System.Windows.Forms.Label();
			this.grbFields = new System.Windows.Forms.GroupBox();
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
			this.lblCaption.Location = new System.Drawing.Point(0, 0);
			this.lblCaption.Name = "lblCaption";
			this.lblCaption.Size = new System.Drawing.Size(320, 24);
			this.lblCaption.TabIndex = 3;
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grbFields
			// 
			this.grbFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grbFields.Location = new System.Drawing.Point(0, 23);
			this.grbFields.Name = "grbFields";
			this.grbFields.Size = new System.Drawing.Size(320, 217);
			this.grbFields.TabIndex = 5;
			this.grbFields.TabStop = false;
			// 
			// InputControl
			// 
			this.Controls.Add(this.lblCaption);
			this.Controls.Add(this.grbFields);
			this.Name = "InputControl";
			this.Size = new System.Drawing.Size(320, 240);
			this.ResumeLayout(false);

		}
		#endregion

		private class Field
		{
			public string   FieldKey;
			public string   Caption;
			public int      CaptionWidth;
			public int      FieldWidth;
			public int      LocationX;
			public int      LocationY;
			public string   Type;
			public string   Alignment;
			public int      MaxLength;
			public char     PasswordChar;
			public double   NumberMin;
			public double   NumberMax;
			public string   Format;
			public DateTime DateMin;
			public DateTime DateMax;
			public string   DropDownDbTable;
			public string   DropDownDbColumn;
			public bool     Hidden;
			public bool     ReadOnly;
			public bool     Required;
			public Control  Control;
		}

		private class InputValidation
		{
			public string ValidationSql;
			public string ValidationCaption;
			public string ValidationMessage;
			public bool   Warning;
			public string FieldKey;
		}

		public  SqlConnection cn;

		private SqlCommand    cmGetInput;
		private SqlCommand    cmGetField;
		private SqlCommand    cmGetInputValidation;

		private string inputKey   = "";
		private string caption    = "";
		private int    width      = 320;
		private int    height     = 217;
		private string newDataSql = "";
		private string insertSql  = "";
		private string selectSql  = "";
		private string updateSql  = "";

		private Field[]    aField;
		private int        fieldCount;

		private InputValidation[] aInputValidation;
		private int inputValidationCount;

		public InputControl()
		{
			InitializeComponent();

			cmGetInput = new SqlCommand();
			cmGetInput.Connection = cn;
			cmGetInput.CommandText = "select \"InputKey\", \"Caption\", \"Width\", \"Height\", \"NewDataSql\", \"InsertSql\", \"SelectSql\", \"UpdateSql\" from \"$Input\" where \"InputKey\" = @InputKey";
			cmGetInput.Parameters.Add("@InputKey", SqlDbType.Char);

			cmGetField = new SqlCommand();
			cmGetField.Connection = cn;
			cmGetField.CommandText = "select \"FieldKey\", \"Caption\", \"CaptionWidth\", \"FieldWidth\", \"LocationX\", \"LocationY\", \"Type\", \"Alignment\", \"MaxLength\", \"PasswordChar\", \"NumberMin\", \"NumberMax\", \"Format\", \"DateMin\", \"DateMax\", \"DropDownDbTable\", \"DropDownDbColumn\", \"Hidden\", \"ReadOnly\", \"Required\" from \"$Field\" where \"InputKey\" = @InputKey order by \"Index\"";
			cmGetField.Parameters.Add("@InputKey", SqlDbType.Char);

			cmGetInputValidation = new SqlCommand();
			cmGetInputValidation.Connection = cn;
			cmGetInputValidation.CommandText = "select \"ValidationSql\", \"ValidationCaption\", \"ValidationMessage\", \"Warning\", \"FieldKey\" from \"$InputValidation\" where \"InputKey\" = @InputKey order by \"Index\"";
			cmGetInputValidation.Parameters.Add("@InputKey", SqlDbType.Char);
		}


		public string InputKey
		{
			get
			{
				return inputKey;
			}
			set
			{
				clearInputControl();

				inputKey = value;

				loadInputData();

				loadInputControl();

				loadDropDowns();
			}
		}


		private void clearInputControl()
		{
			lblCaption.Text = "";
			grbFields.Controls.Clear();
		}


		private void loadInputData()
		{
			caption        = "";
			newDataSql     = "";
			width          = 320;
			height         = 217;
			insertSql      = "";
			selectSql      = "";
			updateSql      = "";

			aField       = new Field[255];
			fieldCount   = 0;

			aInputValidation = new InputValidation[255];
			inputValidationCount  = 0;

			if (inputKey == "") return;

			try
			{
				cn.Open();

				SqlDataReader dr;

				cmGetInput.Parameters["@InputKey"].Value = inputKey;
				dr = cmGetInput.ExecuteReader();
				if (dr.Read())
				{
					inputKey       = ((string) dr["InputKey"]).TrimEnd();
					caption        = (string) dr["Caption"];
					width          = (int)    dr["Width"];
					height         = (int)    dr["Height"];
					newDataSql     = (string) dr["NewDataSql"];
					insertSql      = (string) dr["InsertSql"];
					selectSql      = (string) dr["SelectSql"];
					updateSql      = (string) dr["UpdateSql"];
				}
				dr.Close();

				cmGetField.Parameters["@InputKey"].Value = inputKey;
				dr = cmGetField.ExecuteReader();
				while (dr.Read())
				{
					Field field = new Field();

					field.FieldKey          = ((string)  dr["FieldKey"]).TrimEnd();
					field.Caption           = (string)   dr["Caption"];
					field.CaptionWidth      = (int)      dr["CaptionWidth"];
					field.FieldWidth        = (int)      dr["FieldWidth"];
					field.LocationX         = (int)      dr["LocationX"];
					field.LocationY         = (int)      dr["LocationY"];
					field.Type              = ((string)  dr["Type"]).TrimEnd();
					field.Alignment         = (string)   dr["Alignment"];
					field.MaxLength         = (int)      dr["MaxLength"];
					field.PasswordChar      =((string)   dr["PasswordChar"]).ToCharArray()[0];
					field.NumberMin         = (double)   dr["NumberMin"];
					field.NumberMax         = (double)   dr["NumberMax"];
					field.Format            = (string)   dr["Format"];
					field.DateMin           = (DateTime) dr["DateMin"];
					field.DateMax           = (DateTime) dr["DateMax"];
					field.DropDownDbTable   = (string)   dr["DropDownDbTable"];
					field.DropDownDbColumn  = (string)   dr["DropDownDbColumn"];
					field.Hidden            = (bool)     dr["Hidden"];
					field.ReadOnly          = (bool)     dr["ReadOnly"];
					field.Required          = (bool)     dr["Required"];

					this.aField[fieldCount] = field;
					fieldCount += 1;
				}
				dr.Close();

				cmGetInputValidation.Parameters["@InputKey"].Value = inputKey;
				dr = cmGetInputValidation.ExecuteReader();
				while (dr.Read())
				{
					InputValidation inputValidation = new InputValidation();

					inputValidation.ValidationSql     =  (string) dr["ValidationSql"];
					inputValidation.ValidationCaption =  (string) dr["ValidationCaption"];
					inputValidation.ValidationMessage =  (string) dr["ValidationMessage"];
					inputValidation.Warning           =  (bool)   dr["Warning"];
					inputValidation.FieldKey          = ((string) dr["FieldKey"]).TrimEnd();

					aInputValidation[inputValidationCount] = inputValidation;
					inputValidationCount += 1;
				}
				dr.Close();
			}
			finally
			{
				cn.Close();
			}
		}


		private void loadInputControl()
		{
			// Load Caption

			lblCaption.Text = string.Format(" {0}", caption);

			// Load Width and Height

			this.Width =  this.width;
			this.Height = this.height + 23;

			// Load Fields

			for(int i = 0;i < fieldCount ;i++)
			{
				Field field = this.aField[i];

				Label label = new Label();
				label.TextAlign = ContentAlignment.MiddleLeft;
				label.Text = field.Caption;
				label.Width = field.CaptionWidth;
				label.Height = 21;
				label.Left = field.LocationX;
				label.Top = field.LocationY;
				label.Visible = !field.Hidden;

				grbFields.Controls.Add(label);

				switch (field.Type)
				{
					case "Text":
						TextBox textBox = new TextBox();

						textBox.Width = field.FieldWidth;
						textBox.Left = field.LocationX + field.CaptionWidth;
						textBox.Top = field.LocationY;
						switch (field.Alignment) 
						{
							case "L": textBox.TextAlign = HorizontalAlignment.Left;   break;
							case "R": textBox.TextAlign = HorizontalAlignment.Right;  break;
							case "C": textBox.TextAlign = HorizontalAlignment.Center; break;
						}
						textBox.MaxLength = field.MaxLength;
						textBox.PasswordChar = field.PasswordChar;
						textBox.Visible = !field.Hidden;
						textBox.Enabled = !field.ReadOnly;

						grbFields.Controls.Add(textBox);

						field.Control = textBox;
						break;
					case "Numeric":
						TextBoxNum textBoxNum = new TextBoxNum();

						textBoxNum.Width = field.FieldWidth;
						textBoxNum.Left = field.LocationX + field.CaptionWidth;
						textBoxNum.Top = field.LocationY;
						switch (field.Alignment) 
						{
							case "L": textBoxNum.TextAlign = HorizontalAlignment.Left;   break;
							case "R": textBoxNum.TextAlign = HorizontalAlignment.Right;  break;
							case "C": textBoxNum.TextAlign = HorizontalAlignment.Center; break;
						}
						textBoxNum.MinValue = field.NumberMin;
						textBoxNum.MaxValue = field.NumberMax;
						textBoxNum.Format   = field.Format;
						textBoxNum.Visible = !field.Hidden;
						textBoxNum.Enabled = !field.ReadOnly;

						grbFields.Controls.Add(textBoxNum);

						field.Control = textBoxNum;
						break;
					case "Date":
						DateTimePicker dateTimePicker = new DateTimePicker();

						dateTimePicker.Width = field.FieldWidth;
						dateTimePicker.Left = field.LocationX + field.CaptionWidth;
						dateTimePicker.Top = field.LocationY;
						dateTimePicker.Format = DateTimePickerFormat.Short;
						dateTimePicker.MinDate = field.DateMin;
						dateTimePicker.MaxDate = field.DateMax;
						dateTimePicker.Visible = !field.Hidden;
						dateTimePicker.Enabled = !field.ReadOnly;

						grbFields.Controls.Add(dateTimePicker);

						field.Control = dateTimePicker;
						break;
					case "DropDown":
                        ComboBox comboBoxAuto = new ComboBox();

						comboBoxAuto.Width = field.FieldWidth;
						comboBoxAuto.Left = field.LocationX + field.CaptionWidth;
						comboBoxAuto.Top = field.LocationY;
						comboBoxAuto.MaxLength = field.MaxLength;
						comboBoxAuto.Visible = !field.Hidden;
						comboBoxAuto.Enabled = !field.ReadOnly;

						grbFields.Controls.Add(comboBoxAuto);
						field.Control = comboBoxAuto;
						break;
				}

			}
		}


		private void loadDropDowns()
		{
			try
			{
				cn.Open();
				for(int i = 0;i < fieldCount;i++)
				{
					Field field = aField[i];
				
					if (field.Type == "DropDown")
					{
						SqlCommand cm = new SqlCommand();
						cm.Connection = cn;
						cm.CommandText = string.Format("select \"{0}\" from \"{1}\" order by \"{0}\"", field.DropDownDbColumn, field.DropDownDbTable);
						SqlDataReader dr = cm.ExecuteReader();
						while (dr.Read())
						{
							((ComboBox) field.Control).Items.Add(dr[0]);
						}
						dr.Close();
					}
				}
			}
			finally
			{
				cn.Close();
			}
		}


		private void loadParameters(SqlCommand cm)
		{
			for (int i = 0;i < fieldCount;i++)
			{
				Field field = aField[i];
				SqlParameter pm = new SqlParameter();
				pm.ParameterName = string.Format("@{0}", field.FieldKey);
				switch (field.Type)
				{
					case "DropDown":
						goto case "Text";
					case "Text":
						pm.SqlDbType = SqlDbType.VarChar;
						if (field.Control.Text == "")
							pm.Value = Convert.DBNull;
						else
							pm.Value = field.Control.Text;
						break;
					case "Numeric":
						pm.SqlDbType = SqlDbType.Float;
						if (((TextBoxNum) field.Control).Value == null)
							pm.Value = Convert.DBNull;
						else
							pm.Value = ((TextBoxNum) field.Control).Value;
						break;
					case "Date":
						pm.SqlDbType = SqlDbType.DateTime;
						pm.Value = ((DateTimePicker) field.Control).Value;
						break;
				}
				cm.Parameters.Add(pm);
			}
		}


		private void loadData(SqlDataReader dr)
		{
			for (int i = 0;i < fieldCount;i++)
			{
				Field field = aField[i];

				int columnNo;
				try
				{
					columnNo = dr.GetOrdinal(field.FieldKey);
				}
				catch
				{
					columnNo = -1;
				}

				if (columnNo != -1)
				{
					switch (field.Type)
					{
						case "DropDown":
							goto case "Text";
						case "Text":
							if (dr[columnNo] == Convert.DBNull)
								field.Control.Text = "";
							else
								field.Control.Text = (string) dr[columnNo];
							break;
						case "Numeric":
							if (dr[columnNo] == Convert.DBNull)
								((TextBoxNum) field.Control).Value = null;
							else
								((TextBoxNum) field.Control).Value = dr[columnNo];
							break;
						case "Date":
							if (dr[columnNo] == Convert.DBNull)
							{} //((DateTimePicker) field.Control).Value = null;
							else
								((DateTimePicker) field.Control).Value = (DateTime) dr[columnNo];
							break;
					}
				}
			}
		}


		private void executeSql(string sql)
		{
			if (sql == "") return;

			try
			{
				cn.Open();

				SqlCommand cm = new SqlCommand();
				cm.Connection = cn;
				cm.CommandText = sql;

				loadParameters(cm);
				SqlDataReader dr = cm.ExecuteReader();
				if (dr.Read())
				{
					loadData(dr);
				}
				dr.Close();
			}
			finally
			{
				cn.Close();
			}
		}


		public void NewData()
		{
			this.executeSql(newDataSql);
		}


		public void InsertData()
		{
			this.executeSql(insertSql);
		}


		public void SelectData()
		{
			this.executeSql(selectSql);
		}


		public void UpdateData()
		{
			this.executeSql(updateSql);
		}


		public int    GetIndex(string fieldKey)
		{
			for(int i = 0;i < fieldCount;i++)
			{
				Field field = aField[i];
				if (field.FieldKey == fieldKey)
					return i;
			}
			return -1;
		}


		public object GetValue(int index)
		{
			Field field = aField[index];
			switch (field.Type)
			{
				case "DropDown":
					goto case "Text";
				case "Text":
					if (field.Control.Text == "")
						return Convert.DBNull;
					else
						return field.Control.Text;
				case "Numeric":
					if (((TextBoxNum) field.Control).Value == null)
						return Convert.DBNull;
					else
						return ((TextBoxNum) field.Control).Value;
				case "Date":
					return ((DateTimePicker) field.Control).Value;
				default:
					return null;
			}
		}


		public void   SetValue(int index, object value)
		{
			Field field = aField[index];
			switch (field.Type)
			{
				case "DropDown":
					goto case "Text";
				case "Text":
					if (value == Convert.DBNull)
						field.Control.Text = "";
					else
						field.Control.Text = (string) value;
					break;
				case "Numeric":
					if (value == Convert.DBNull)
						((TextBoxNum) field.Control).Value = null;
					else
						((TextBoxNum) field.Control).Value = value;
					break;
				case "Date":
					if (value == Convert.DBNull)
					{} //((DateTimePicker) field.Control).Value = null;
					else
						((DateTimePicker) field.Control).Value = (DateTime) value;
					break;
			}
		}


		public void   SetFocus(int index)
		{
			Field field = aField[index];
			field.Control.Focus();
		}

		public bool   ValidateData()
		{
			for (int i = 0;i < this.fieldCount;i++)
			{
				Field field = this.aField[i];
				if ((field.Required) & (this.GetValue(i) == Convert.DBNull))
				{
					this.SetFocus(i);
					MessageForm.Show(FindForm(), "Required Field", string.Format("{0} is required.", field.Caption), true, false);
					return false;
				}
			}

			try
			{
				cn.Open();

				for (int i = 0;i < this.inputValidationCount;i++)
				{
					InputValidation inputValidation = aInputValidation[i];

					SqlCommand cm = new SqlCommand();
					cm.Connection = cn;
					cm.CommandText = inputValidation.ValidationSql;

					loadParameters(cm);

					if ((int) cm.ExecuteScalar() != 0)
					{
						if (inputValidation.FieldKey != "")
							this.SetFocus(this.GetIndex(inputValidation.FieldKey));

						if (inputValidation.Warning)
						{
							if (MessageForm.Show(FindForm(), inputValidation.ValidationCaption, inputValidation.ValidationMessage, true, true) != DialogResult.OK) return false;
						}
						else
						{
							MessageForm.Show(FindForm(), inputValidation.ValidationCaption, inputValidation.ValidationMessage, true, false);
							return false;
						}
					}
				}

				return true;
			}
			finally
			{
				cn.Close();
			}
		}

	}
}
