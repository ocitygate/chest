using System;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Common
{
	/// <summary>
	/// Summary description for Database.
	/// </summary>
	public class Database
	{
		public Database()
		{
			//
			// TODO: Add constructor logic here
			//
		}

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string provider;
        public string Provider
        {
            get
            {
                return provider;
            }
            set
            {
                provider = value;
            }
        }

        private string dataSource;
        public string DataSource
        {
            get
            {
                return dataSource;
            }
            set
            {
                dataSource = value;
            }
        }

        private string initialCatalog;
        public string InitialCatalog
        {
            get
            {
                return initialCatalog;
            }
            set
            {
                initialCatalog = value;
            }
        }

        private string userID;
        public string UserID
        {
            get
            {
                return userID;
            }
            set
            {
                userID = value;
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        private string databasePassword;
        public string DatabasePassword
        {
            get
            {
                return databasePassword;
            }
            set
            {
                databasePassword = value;
            }
        }

        public SqlConnection GetSqlConnection()
        {
            // build and return connection
            return new SqlConnection(
                string.Format(
                    "Data Source={0};Initial Catalog={1};User ID={2};Password={3}",
                    dataSource,
                    initialCatalog,
                    userID,
                    password));
        }

        public string GetOleDbConnectionString()
        {
            return string.Format("Provider={0};Data Source={1};User ID={2};Password={3};Jet OLEDB:Database Password={4};",
                        provider,
                        dataSource,
                        userID,
                        password,
                        databasePassword);
        }

        private OleDbConnection oleDbConnection = null;
        public OleDbConnection GetOleDbConnection()
        {
            // build and return connection
            if (oleDbConnection == null)
            {
                //oleDbConnection = new OleDbConnection(string.Format("Provider={0};Data Source={1};Initial Catalog={2};User ID={3};Password={4}",
                oleDbConnection = new OleDbConnection(GetOleDbConnectionString());

                oleDbConnection.Open();
            }

            return oleDbConnection;
        }

        public void RefreshOleDbConnection()
        {
            oleDbConnection = null;
        }

        public override string ToString()
        {
            return name;
        }


		private OleDbCommand buildCommand(string sql, params object[] values)
		{
			OleDbCommand cm = new OleDbCommand(sql, this.GetOleDbConnection());
			for(int i=0;i<values.Length;i++)
				cm.Parameters.AddWithValue(i.ToString(), values[i]);
			return cm;
		}

		public object ExecuteScalar(string sql, params object[] values)
		{
			OleDbCommand cm = buildCommand(sql, values);
			return cm.ExecuteScalar();
		}

		public OleDbDataReader ExecuteReader(string sql, params object[] values)
		{
			OleDbCommand cm = buildCommand(sql, values);
			return cm.ExecuteReader();
		}

		public void Execute(string sql, params object[] values)
		{
			OleDbCommand cm = buildCommand(sql, values);
			cm.ExecuteNonQuery();
		}

		public void PopulateComboBox(System.Windows.Forms.ComboBox comboBox, bool clear, string sql, params object[] values)
		{
			if (clear) comboBox.Items.Clear();
			OleDbDataReader dr = ExecuteReader(sql, values);
			while(dr.Read())
				comboBox.Items.Add(dr[0]);
			dr.Close();
		}

		private void PopulateListViewItem(ListViewItem listViewItem, OleDbDataReader reader)
		{
			for(int i=0;i<reader.FieldCount;i++)
			{
				if (i==0)
					listViewItem.Text = reader[i].ToString();
				else
				{
					if (i >= listViewItem.SubItems.Count)
					{
						listViewItem.SubItems.Add(reader[i].ToString());
					}
					else
						listViewItem.SubItems[i].Text = reader[i].ToString();
				}
			}
		}

		public void PopulateListView(ListView listView, bool clear, bool reverse, bool clearSelected, bool select, string sql, params object[] values)
		{

            if (clearSelected | clear)
                listView.SelectedIndices.Clear();

            if (clear)
                listView.Items.Clear();

			OleDbDataReader dr = ExecuteReader(sql, values);
			while(dr.Read())
			{
				ListViewItem listViewItem = new ListViewItem();

				PopulateListViewItem(listViewItem, dr);

				if (select)
					listViewItem.Selected = true;

				if (reverse)
					listView.Items.Insert(0, listViewItem);
				else
					listView.Items.Add(listViewItem);
			}
			dr.Close();

            if (clear && !select && listView.Items.Count > 0)
                listView.Items[0].Selected = true;
		}

		public bool PopulateListViewItem(ListViewItem listViewItem, string sql, params object[] values)
		{
			bool ret = false;
			OleDbDataReader dr = ExecuteReader(sql, values);
			if (dr.Read())
			{
				PopulateListViewItem(listViewItem, dr);
				ret = true;
			}
			dr.Close();
			return ret;
		}

        public static object NullToDbNull(object value)
        {
            if (value == null)
                return Convert.DBNull;
            else
                return value;
        }

        public static object DbNullToNull(object value)
        {
            if (value == Convert.DBNull)
                return null;
            else
                return value;
        }

	}
}
