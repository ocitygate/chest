using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace CS.Data.OleDb
{
    public class OleDbDataHelper
    {
        private static OleDbCommand buildCommand(OleDbConnection cn, string sql, params object[] values)
        {
            OleDbCommand cm = new OleDbCommand(sql, cn);
            for (int i = 0; i < values.Length; i++)
                cm.Parameters.AddWithValue(i.ToString(), values[i]);
            return cm;
        }

        public static object ExecuteScalar(OleDbConnection cn, string sql, params object[] values)
        {
            OleDbCommand cm = buildCommand(cn, sql, values);
            return cm.ExecuteScalar();
        }

        public static OleDbDataReader ExecuteReader(OleDbConnection cn, string sql, params object[] values)
        {
            OleDbCommand cm = buildCommand(cn, sql, values);
            return cm.ExecuteReader();
        }

        public static void Execute(OleDbConnection cn, string sql, params object[] values)
        {
            OleDbCommand cm = buildCommand(cn, sql, values);
            cm.ExecuteNonQuery();
        }
    }
}
