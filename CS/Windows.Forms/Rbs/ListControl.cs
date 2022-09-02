using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace CS.Windows.Forms
{
	public class ListControl : System.Windows.Forms.UserControl
	{

		#region UI Control Fields

		private System.Windows.Forms.Panel pnlButtons;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.Label lblCaption;
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

		private void InitializeComponent()
		{
			this.pnlButtons = new System.Windows.Forms.Panel();
			this.listView = new System.Windows.Forms.ListView();
			this.lblCaption = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// pnlButtons
			// 
			this.pnlButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pnlButtons.Location = new System.Drawing.Point(0, 456);
			this.pnlButtons.Name = "pnlButtons";
			this.pnlButtons.Size = new System.Drawing.Size(640, 24);
			this.pnlButtons.TabIndex = 2;
			// 
			// listView
			// 
			this.listView.AllowColumnReorder = true;
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView.FullRowSelect = true;
			this.listView.HideSelection = false;
			this.listView.Location = new System.Drawing.Point(0, 28);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(640, 424);
			this.listView.TabIndex = 1;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
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
			this.lblCaption.Size = new System.Drawing.Size(640, 24);
			this.lblCaption.TabIndex = 0;
			this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ListControl
			// 
			this.Controls.Add(this.pnlButtons);
			this.Controls.Add(this.listView);
			this.Controls.Add(this.lblCaption);
			this.Name = "ListControl";
			this.Size = new System.Drawing.Size(640, 480);
			this.ResumeLayout(false);

		}

		#endregion


		private struct Column
		{
			public string ColumnKey;
			public string Caption;
			public int    Width;
			public string Alignment;
			public string DbColumn;
			public string Format;
			public bool   Primary;
		}


		private class Action
		{
			public ListControl ListControl;

			public string ActionKey;
			public string Caption;
			public int    Width;
			public bool   AppliesToList;
			public string InputKey;
			public bool   NewData;
			public string ActionSql;
			public string Response;
			public string CompletedCaption;
			public string CompletedMessage;

			public ActionValidation[] AActionValidation = new ActionValidation[255];
			public int ActionValidationCount = 0;

			public Button Button;

			public void Button_Click(object sender, EventArgs e)
			{
				try
				{
					InputForm inputForm = new InputForm();

					ListControl.cn.Open();

					for (int i = 0;i < this.ActionValidationCount;i++)
					{
						ActionValidation actionValidation = this.AActionValidation[i];

						MySqlCommand cm = new MySqlCommand();
						cm.Connection = ListControl.cn;
						cm.CommandText = actionValidation.ValidationSql;

						if (!this.AppliesToList)
						{
							for (int j = 0;j < ListControl.columnCount;j++)
							{
								Column column = ListControl.aColumn[j];
								if (column.Primary)
								{
									cm.Parameters.AddWithValue("@" + column.ColumnKey, ListControl.GetValue(ListControl.GetSelectedIndex(), j));
								}
							}
						}

						if ((int) cm.ExecuteScalar() != 0)
						{
							if (actionValidation.Warning)
							{
								if (MessageForm.Show(ListControl.FindForm(), actionValidation.ValidationCaption, actionValidation.ValidationMessage, true, true) != DialogResult.OK) return;
							}
							else
							{
								MessageForm.Show(ListControl.FindForm(), actionValidation.ValidationCaption, actionValidation.ValidationMessage, true, false);
								return;
							}
						}
					}

					if (this.InputKey != "")
					{
						inputForm.InputControl.InputKey = this.InputKey;
						if (!this.AppliesToList)
						{
							for (int i = 0;i < ListControl.columnCount;i++)
							{
								Column column = ListControl.aColumn[i];
								if (column.Primary)
								{
									int index = inputForm.InputControl.GetIndex(column.ColumnKey);
									if (index != -1)
										inputForm.InputControl.SetValue(index, ListControl.GetValue(ListControl.GetSelectedIndex(), i));
								}
							}
						}

						if (this.NewData)
						{
							inputForm.InputControl.NewData();
							if (inputForm.ShowDialog(ListControl.FindForm()) != DialogResult.OK) return;
							inputForm.InputControl.InsertData();
						}
						else
						{
							inputForm.InputControl.SelectData();
							if (inputForm.ShowDialog(ListControl.FindForm()) != DialogResult.OK) return;
							inputForm.InputControl.UpdateData();
						}
					}

					if (this.ActionSql != "")
					{
						MySqlCommand cm = new MySqlCommand();
						cm.Connection = ListControl.cn;
						cm.CommandText = this.ActionSql;

						if (!this.AppliesToList)
						{
							for (int j = 0;j < ListControl.columnCount;j++)
							{
								Column column = ListControl.aColumn[j];
								if (column.Primary)
								{
									cm.Parameters.AddWithValue("@" + column.ColumnKey, ListControl.GetValue(ListControl.GetSelectedIndex(), j));
								}
							}
						}

						cm.ExecuteNonQuery();
					}

					ListControl.OnProcessAction(this.ActionKey);

					switch (this.Response)
					{
						case "RefreshRow":
							int index = ListControl.GetSelectedIndex();
							ListControl.loadItem(ListControl.listView.Items[index], inputForm.InputControl);
							ListControl.RefreshItem(ListControl.GetSelectedIndex());
							break;
						case "RemoveRow":
							ListControl.RemoveRow(ListControl.GetSelectedIndex());
							break;
						case "GetNewRow":
							ListViewItem listViewItem = new ListViewItem();
							ListControl.loadItem(listViewItem, inputForm.InputControl);
							ListControl.listView.Items.Add(listViewItem);
							ListControl.RefreshItem(ListControl.listView.Items.Count - 1);
							break;
					}
				
					if ((this.CompletedCaption) != "" || (this.CompletedMessage != ""))
					{
						MessageForm.Show(ListControl.FindForm(), this.CompletedCaption, this.CompletedMessage, true, false);
					}

				}
				finally
				{
					ListControl.cn.Close();
				}
			}
		}


		private class ActionValidation
		{
			public string ValidationSql;
			public string ValidationCaption;
			public string ValidationMessage;
			public bool   Warning;
		}

		public MySqlConnection cn;

		private MySqlCommand cmGetList;
        private MySqlCommand cmGetColumn;
        private MySqlCommand cmGetAction;
        private MySqlCommand cmGetActionValidation;

		private string     listKey = "";
		private string     caption;
		private byte       visibleColumns;
		private byte       leftActions;
		private string     dbTable;

		private Column[]   aColumn;
		private int        columnCount;

		private int        primaryColumnIndex;

		private Action[]   aAction;
		private int        actionCount;


		public ListControl()
		{
			InitializeComponent();

			cmGetList = new MySqlCommand();
			cmGetList.Connection = cn;
			cmGetList.CommandText = @"select ""ListKey"", ""Caption"", ""VisibleColumns"", ""LeftActions"", ""DbTable"" from ""$List"" where ""ListKey"" = @ListKey";
			cmGetList.Parameters.AddWithValue("@ListKey", null);

            cmGetColumn = new MySqlCommand();
			cmGetColumn.Connection = cn;
			cmGetColumn.CommandText = @"select ""ColumnKey"", ""Caption"", ""Width"", ""Alignment"", ""Format"", ""DbColumn"", ""Primary"" from ""$Column"" where ""ListKey"" = @ListKey order by ""Index""";
            cmGetColumn.Parameters.AddWithValue("@ListKey", null);

            cmGetAction = new MySqlCommand();
			cmGetAction.Connection = cn;
			cmGetAction.CommandText = @"select ""ActionKey"", ""Caption"", ""Width"", ""AppliesToList"", ""InputKey"", ""NewData"", ""ActionSql"", ""Response"", ""CompletedCaption"", ""CompletedMessage"" from ""$Action"" where ""ListKey"" = @ListKey order by ""Index""";
            cmGetAction.Parameters.AddWithValue("@ListKey", null);

            cmGetActionValidation = new MySqlCommand();
			cmGetActionValidation.Connection = cn;
			cmGetActionValidation.CommandText = @"select ""ValidationSql"", ""ValidationCaption"", ""ValidationMessage"", ""Warning"" from ""$ActionValidation"" where ""ListKey"" = @ListKey and ""ActionKey"" = @ActionKey order by ""Index""";
            cmGetActionValidation.Parameters.AddWithValue("@ListKey", null);
            cmGetActionValidation.Parameters.AddWithValue("@ActionKey", null);
		}


		public  string ListKey
		{
			get
			{
				return listKey;
			}
			set
			{
				clearListControl();

				listKey = value;

				loadListData();

				loadListControl();

				loadList();

			}
		}


		private void clearListControl()
		{
			lblCaption.Text = "";
			listView.Clear();
			pnlButtons.Controls.Clear();
		}


		private void loadListData()
		{
			caption        = "";
			visibleColumns = 0;
			dbTable        = "";

			aColumn       = new Column[255];
			columnCount   = 0;

			primaryColumnIndex = -1;

			for(int i = 0;i < actionCount;i++)
			{
				Action action = this.aAction[i];
				action.Button.Click -= new EventHandler(action.Button_Click);
			}

			aAction       = new Action[255];
			actionCount   = 0;

			if (listKey == "") return;

			try
			{
				cn.Open();

				MySqlDataReader dr;

				cmGetList.Parameters["@ListKey"].Value = listKey;
				dr = cmGetList.ExecuteReader();
				if (!dr.Read())
				{
					dr.Close();
					MessageBox.Show(this, "List not found.");
					return;
				}
				listKey        = ((string) dr["ListKey"]).TrimEnd();
				caption        = (string) dr["Caption"];
				visibleColumns = (byte)  dr["VisibleColumns"];
				leftActions    = (byte)  dr["leftActions"];
				dbTable        = (string) dr["DbTable"];
				dr.Close();

				cmGetColumn.Parameters["@ListKey"].Value = listKey;
				dr = cmGetColumn.ExecuteReader();
				while (dr.Read())
				{
					Column column = new Column();
					
					column.ColumnKey = ((string) dr["ColumnKey"]).TrimEnd();
					column.Caption   = (string) dr["Caption"];
					column.Width     = (int)    dr["Width"];
					column.Alignment = (string) dr["Alignment"];
					column.DbColumn  = (string) dr["DbColumn"];
					column.Format    = (string) dr["Format"];
					column.Primary   = (bool)   dr["Primary"];

					if (column.Primary)
						primaryColumnIndex = columnCount;

					this.aColumn[columnCount] = column;

					columnCount += 1;
				}
				dr.Close();

				cmGetAction.Parameters["@ListKey"].Value = listKey;
				dr = cmGetAction.ExecuteReader();
				while (dr.Read())
				{
					Action action = new Action();

					action.ListControl   = this;
					action.ActionKey     = ((string) dr["ActionKey"]).TrimEnd();
					action.Caption       = (string)  dr["Caption"];
					action.Width         = (int)     dr["Width"];
					action.AppliesToList = (bool)    dr["AppliesToList"];
					action.InputKey      = ((string) dr["InputKey"]).TrimEnd();
					action.NewData       = (bool)    dr["NewData"];
					action.ActionSql     = (string)  dr["ActionSql"];
					action.Response      = ((string) dr["Response"]).TrimEnd();
					action.CompletedCaption = (string)  dr["CompletedCaption"];
					action.CompletedMessage = (string)  dr["CompletedMessage"];

					this.aAction[actionCount] = action;
					actionCount += 1;
				}
				dr.Close();

				for(int i = 0;i < this.actionCount;i++)
				{
					Action action = this.aAction[i];

					cmGetActionValidation.Parameters["@ListKey"].Value = listKey;
					cmGetActionValidation.Parameters["@ActionKey"].Value = action.ActionKey;
					dr = cmGetActionValidation.ExecuteReader();
					while (dr.Read())
					{
						ActionValidation actionValidation = new ActionValidation();

						actionValidation.ValidationSql     = (string) dr["ValidationSql"];
						actionValidation.ValidationCaption = (string) dr["ValidationCaption"];
						actionValidation.ValidationMessage = (string) dr["ValidationMessage"];
						actionValidation.Warning           = (bool)   dr["Warning"];

						action.AActionValidation[action.ActionValidationCount] = actionValidation;
						action.ActionValidationCount += 1;
					}
					dr.Close();
				}

			}
			finally
			{
				cn.Close();
			}
		}


		private void loadListControl()
		{

			// Load Caption

			lblCaption.Text = string.Format(" {0}", caption);

			// Load Column Headers

			for(int i = 0;i < columnCount && i < this.visibleColumns;i++)
			{
				Column column = this.aColumn[i];

				ColumnHeader columnHeader = new ColumnHeader();
				columnHeader.Text      = column.Caption;
				columnHeader.Width     = column.Width;

				switch (column.Alignment)
				{
					case "L":
						columnHeader.TextAlign = HorizontalAlignment.Left;
						break;
					case "R":
						columnHeader.TextAlign = HorizontalAlignment.Right;
						break;
					case "C":
						columnHeader.TextAlign = HorizontalAlignment.Center;
						break;
				}

				listView.Columns.Add(columnHeader);
			}

			// Load Action Buttons

			int leftOffset  = 0;
			for(int i = 0;i < actionCount;i++)
			{
				Action action = this.aAction[i];

				Button button = new Button();

				button.Tag    = action.ActionKey;
				button.Text   = action.Caption;
				button.Width  = action.Width;
				button.Height = pnlButtons.Height;
				
				button.Left = leftOffset;
				button.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom;

				button.Click += new EventHandler(action.Button_Click);

				this.aAction[i].Button = button;

				leftOffset  += action.Width + 4;

				pnlButtons.Controls.Add(button);
			}

			int rightOffset = pnlButtons.Width;
			for(int i = actionCount - 1;i >= leftActions;i--)
			{
				Action action = this.aAction[i];

				rightOffset -= action.Button.Width;

				action.Button.Left = rightOffset;
				action.Button.Anchor = AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;

				rightOffset -= 4;
			}

			refreshActionButtons();
		}


		private void loadItem(ListViewItem listViewItem, MySqlDataReader dr)
		{
			listViewItem.SubItems.Clear();

			for(int i = 0;i < columnCount;i++)
			{
				Column column = this.aColumn[i];

				ListViewItem.ListViewSubItem subItem;
				if (listViewItem.SubItems.Count < i + 1)
				{
					subItem = new ListViewItem.ListViewSubItem();
				}
				else
				{
					subItem = listViewItem.SubItems[i];
				}
				

				if (column.Format == "")
					subItem.Text = string.Format("{0}", dr[column.DbColumn]).TrimEnd();
				else
					subItem.Text = string.Format("{0:" + column.Format + "}", dr[column.DbColumn]).TrimEnd();

				if (listViewItem.SubItems.Count < i + 1)
					listViewItem.SubItems.Add(subItem);
			}
		}


		private void loadItem(ListViewItem listViewItem, InputControl inputControl)
		{
			listViewItem.SubItems.Clear();

			for(int i = 0;i < columnCount;i++)
			{
				Column column = this.aColumn[i];

				ListViewItem.ListViewSubItem subItem;
				if (listViewItem.SubItems.Count < i + 1)
				{
					subItem = new ListViewItem.ListViewSubItem();
				}
				else
				{
					subItem = listViewItem.SubItems[i];
				}

				if (column.Primary)
				{
					int index = inputControl.GetIndex(column.ColumnKey);
					if (index != -1)
					{
						if (column.Format == "")
							subItem.Text = string.Format("{0}", inputControl.GetValue(index));
						else
							subItem.Text = string.Format("{0:" + column.Format + "}", inputControl.GetValue(index)).TrimEnd();
					}
				}

				if (listViewItem.SubItems.Count < i + 1)
					listViewItem.SubItems.Add(subItem);
			}
		}


		private void loadList()
		{
			listView.Items.Clear();

			if (this.dbTable == "") return;

            MySqlCommand cm = new MySqlCommand();
			cm.Connection = cn;
			cm.CommandText = string.Format(@"select * from ""{0}""", this.dbTable);

			try
			{
				cn.Open();

				MySqlDataReader dr;

				dr = cm.ExecuteReader();
				while (dr.Read())
				{
					ListViewItem listViewItem = new ListViewItem();
					this.loadItem(listViewItem, dr);
					listView.Items.Add(listViewItem);
				}
				dr.Close();
			}
			finally
			{
				cn.Close();
			}

		}


		public int GetSelectedIndex()
		{
			if (listView.SelectedIndices.Count == 1)
				return listView.SelectedIndices[0];
			else
				return -1;
		}

		public bool RefreshItem(int index)
		{
			ListViewItem listViewItem = listView.Items[index];

            MySqlCommand cm = new MySqlCommand();
			cm.Connection = cn;

			string whereList = "";
			for (int j = 0;j < columnCount;j++)
			{
				Column column = aColumn[j];
				if (column.Primary)
				{
					if (whereList != "") whereList += " and ";
					whereList += string.Format("{0} = @{1}", column.DbColumn, column.ColumnKey);
					cm.Parameters.AddWithValue("@" + column.ColumnKey, GetValue(index, j));
				}
			}
			cm.CommandText = string.Format("select * from \"{0}\"", this.dbTable);
			if (whereList != "") cm.CommandText += " where " + whereList;

			try
			{
                //cn.Open();

				MySqlDataReader dr;

				dr = cm.ExecuteReader();
				if (!dr.Read())
				{
					dr.Close();
					return false;
				}
				this.loadItem(listViewItem, dr);
				dr.Close();

			}
			finally
			{
				//cn.Close();
			}

			return true;
		}


		private void refreshActionButtons()
		{
			for(int i = 0;i < actionCount;i++)
			{
				Action action = this.aAction[i];
				action.Button.Enabled = action.AppliesToList | (listView.SelectedIndices.Count == 1);
			}		
		}


		private void listView_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			refreshActionButtons();
		}


		public int    GetColumnIndex(string columnKey)
		{
			for(int i = 0;i < columnCount;i++)
			{
				Column column = aColumn[i];
				if (column.ColumnKey == columnKey)
					return i;
			}
			return -1;
		}


		public string GetValue(int row, int column)
		{
			return listView.Items[row].SubItems[column].Text;
		}


		public void   SetValue(int row, int column, string value)
		{
			listView.Items[row].SubItems[column].Text = value;
		}


		public void RemoveRow(int index)
		{
			listView.Items[index].Remove();
		}


		public delegate void ProcessActionEventHandler(string ActionKey);

		public event ProcessActionEventHandler ProcessAction;

		protected virtual void OnProcessAction(string ActionKey) 
		{
			if (ProcessAction != null)
				ProcessAction(ActionKey);
		}

	}
}
