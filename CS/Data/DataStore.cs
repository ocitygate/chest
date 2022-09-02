using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Collections;

namespace CS.Data
{
    public class DataStore
    {
        private int fieldCount;
        private string[] fieldNames;
        private int rowCount;
        private object[,] data;

        public DataStore(OleDbDataReader reader)
        {
            ArrayList temp = new ArrayList();

            fieldCount = reader.FieldCount;
            fieldNames = new string[fieldCount];
            for (int i = 0; i < fieldCount; i++)
                fieldNames[i] = reader.GetName(i);

            while (reader.Read())
            {
                object[] rowData = new object[reader.FieldCount];
                reader.GetValues(rowData);
                temp.Add(rowData);
            }
            reader.Close();

            rowCount = temp.Count;

            data = new object[rowCount, fieldCount];
            for (int i = 0; i < rowCount; i++)
            {
                object[] rowData = (object[])temp[i];
                for (int j = 0; j < fieldCount; j++)
                {
                    data[i, j] = rowData[j];
                }
            }
        }

        public object GetValue(int rowIndex, int fieldIndex)
        {
            return data[rowIndex, fieldIndex];
        }

        public int GetFieldIndex(string fieldName)
        {
            for (int i = 0; i < fieldCount; i++)
                if (fieldNames[i] == fieldName)
                    return i;
            return -1;
        }

        public int GetRowCount()
        {
            return rowCount;
        }
    }
}
