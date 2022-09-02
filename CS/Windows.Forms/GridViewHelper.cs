using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

//using MySql.Data.MySqlClient;
//using CS.Data.MySql;
using System.Data.OleDb;
using CS.Data.OleDb;

namespace CS.Windows.Forms
{
    public class GridViewHelper
    {
        public static DataGridViewRow[] GetSelectedRowsA(DataGridView grid)
        {
            return GetSelectedRowsA(grid, false);
        }

        public static DataGridViewRow[] GetSelectedRowsA(DataGridView grid, bool includeNewRow)
        {
            System.Collections.ArrayList selectedRowsAL = new System.Collections.ArrayList();
            foreach (DataGridViewRow row in grid.Rows)
                if (row.Selected && (includeNewRow | !row.IsNewRow))
                    selectedRowsAL.Add(row);

            DataGridViewRow[] selectedRows = new DataGridViewRow[selectedRowsAL.Count];
            selectedRowsAL.CopyTo(selectedRows);

            return selectedRows;
        }

        public static void ClearSelectedRows(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.SelectedRows)
                row.Selected = false;
        }

        public static void ClearSelectedCells(DataGridView grid)
        {
            foreach (DataGridViewCell cell in grid.SelectedCells)
                cell.Selected = false;
        }

        #region "MySql"

        //public static void PopulateGridRow(DataGridViewRow row, MySqlDataReader reader)
        //{
        //    object[] value = new object[reader.FieldCount];
        //    for (int i = 0; i < reader.FieldCount; i++)
        //    {
        //        value[i] = reader[i];
        //    }
        //    row.SetValues(value);
        //}

        //public static bool PopulateGridRow(MySqlConnection cn, DataGridViewRow row, string sql, params object[] values)
        //{
        //    bool ret = false;
        //    MySqlDataReader dr = MySqlDataHelper.ExecuteReader(cn, sql, values);
        //    if (dr.Read())
        //    {
        //        PopulateGridRow(row, dr);
        //        ret = true;
        //    }
        //    dr.Close();
        //    return ret;
        //}

        //public static DataGridViewRow PopulateGridView(DataGridView grid, bool clear, bool reverse, bool clearSelected, bool select, MySqlDataReader reader)
        //{
        //    DataGridViewRow row = null;

        //    if (clearSelected | clear)
        //        ClearSelectedRows(grid);

        //    if (clear)
        //        grid.Rows.Clear();

        //    while (reader.Read())
        //    {
        //        object[] values = new object[reader.FieldCount];
        //        reader.GetValues(values);

        //        if (reverse)
        //        {
        //            grid.Rows.Insert(0, values);
        //            row = grid.Rows[0];
        //        }
        //        else
        //        {
        //            int ix = grid.Rows.Add(values);
        //            row = grid.Rows[ix];
        //        }

        //        if (select)
        //            row.Selected = true;
        //    }

        //    if (clear && !select && grid.Rows.Count > 0)
        //        grid.Rows[0].Selected = true;

        //    return row;
        //}

        //public static DataGridViewRow PopulateGridView(MySqlConnection cn, DataGridView grid, bool clear, bool reverse, bool clearSelected, bool select, string sql, params object[] parameters)
        //{
        //    MySqlDataReader reader = MySqlDataHelper.ExecuteReader(cn, sql, parameters);

        //    DataGridViewRow row = PopulateGridView(grid, clear, reverse, clearSelected, select, reader);

        //    reader.Close();

        //    return row;
        //}

        //public static void PopulateGridViewWithColumns(MySqlConnection cn, DataGridView grid, string sql, params object[] parameters)
        //{
        //    MySqlDataReader reader = MySqlDataHelper.ExecuteReader(cn, sql, parameters);

        //    grid.Columns.Clear();
        //    for (int i = 0; i < reader.FieldCount; i++)
        //        grid.Columns.Add(reader.GetName(i), reader.GetName(i));

        //    PopulateGridView(grid, true, false, false, false, reader);

        //    reader.Close();
        //}

        //public static void PopluateGridViewCombo(MySqlConnection cn, DataGridViewComboBoxColumn comboBox, bool clear, string sql, params object[] values)
        //{
        //    if (clear) comboBox.Items.Clear();
        //    MySqlDataReader dr = MySqlDataHelper.ExecuteReader(cn, sql, values);
        //    while (dr.Read())
        //        comboBox.Items.Add(dr[0]);
        //    dr.Close();
        //}

        #endregion

        #region "OleDb"

        public static void PopulateGridRow(DataGridViewRow row, OleDbDataReader reader)
        {
            object[] value = new object[reader.FieldCount];
            for (int i = 0; i < reader.FieldCount; i++)
            {
                value[i] = reader[i];
            }
            row.SetValues(value);
        }

        public static bool PopulateGridRow(OleDbConnection cn, DataGridViewRow row, string sql, params object[] values)
        {
            bool ret = false;
            OleDbDataReader dr = OleDbDataHelper.ExecuteReader(cn, sql, values);
            if (dr.Read())
            {
                PopulateGridRow(row, dr);
                ret = true;
            }
            dr.Close();
            return ret;
        }

        public static DataGridViewRow PopulateGridView(DataGridView grid, bool clear, bool reverse, bool clearSelected, bool select, OleDbDataReader reader)
        {
            DataGridViewRow row = null;

            if (clearSelected | clear)
                ClearSelectedRows(grid);

            if (clear)
                grid.Rows.Clear();

            while (reader.Read())
            {
                object[] values = new object[reader.FieldCount];
                reader.GetValues(values);

                if (reverse)
                {
                    grid.Rows.Insert(0, values);
                    row = grid.Rows[0];
                }
                else
                {
                    int ix = grid.Rows.Add(values);
                    row = grid.Rows[ix];
                }

                if (select)
                    row.Selected = true;
            }

            if (clear && !select && grid.Rows.Count > 0)
                grid.Rows[0].Selected = true;

            return row;
        }

        public static DataGridViewRow PopulateGridView(OleDbConnection cn, DataGridView grid, bool clear, bool reverse, bool clearSelected, bool select, string sql, params object[] parameters)
        {
            OleDbDataReader reader = OleDbDataHelper.ExecuteReader(cn, sql, parameters);

            DataGridViewRow row = PopulateGridView(grid, clear, reverse, clearSelected, select, reader);

            reader.Close();

            return row;
        }

        public static void PopulateGridViewWithColumns(OleDbConnection cn, DataGridView grid, string sql, params object[] parameters)
        {
            OleDbDataReader reader = OleDbDataHelper.ExecuteReader(cn, sql, parameters);

            grid.Columns.Clear();
            for (int i = 0; i < reader.FieldCount; i++)
                grid.Columns.Add(reader.GetName(i), reader.GetName(i));

            PopulateGridView(grid, true, false, false, false, reader);

            reader.Close();
        }

        public static void PopluateGridViewCombo(OleDbConnection cn, DataGridViewComboBoxColumn comboBox, bool clear, string sql, params object[] values)
        {
            if (clear) comboBox.Items.Clear();
            OleDbDataReader dr = OleDbDataHelper.ExecuteReader(cn, sql, values);
            while (dr.Read())
                comboBox.Items.Add(dr[0]);
            dr.Close();
        }

        #endregion

    }
}
