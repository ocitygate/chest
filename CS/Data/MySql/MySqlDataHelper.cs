using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CS.Data.MySql
{
    public class MySqlDataHelper
    {

        const int tries = 2;

        private static MySqlCommand buildCommand(MySqlConnection cn, string sql, params object[] namesvalues)
        {
            MySqlCommand cm = new MySqlCommand(sql, cn);
            if (namesvalues.Length % 2 != 0)
                return null;
            for (int i = 0; i < namesvalues.Length; i += 2)
                cm.Parameters.AddWithValue(namesvalues[i].ToString(), namesvalues[i + 1]);
            return cm;
        }

        public static object ExecuteScalar(MySqlConnection cn, string sql, params object[] namesvalues)
        {
            for(int i = 0; i < tries; i++)
            {
                try
                {
                    MySqlCommand cm = buildCommand(cn, sql, namesvalues);
                    return cm.ExecuteScalar();
                }
                catch
                {
                    cn.Close();
                    cn.Open();
                }
            }
            return null;
        }

        public static MySqlDataReader ExecuteReader(MySqlConnection cn, string sql, params object[] namesvalues)
        {
            for (int i = 0; i < tries; i++)
            {
                try
                {
                    MySqlCommand cm = buildCommand(cn, sql, namesvalues);
                    return cm.ExecuteReader();
                }
                catch
                {
                    cn.Close();
                    cn.Open();
                }
            }
            return null;
        }

        public static void Execute(MySqlConnection cn, string sql, params object[] namesvalues)
        {
            for (int i = 0; i < tries; i++)
            {
                try
                {
                    MySqlCommand cm = buildCommand(cn, sql, namesvalues);
                    cm.ExecuteNonQuery();

                    return;
                }
                catch
                {
                    cn.Close();
                    cn.Open();
                }
            }
        }
    }
}
