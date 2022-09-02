using System;
using System.Collections.Generic;
using System.Text;

namespace InvMngr
{
    class Global
    {
        public static string InstallID;

        private static Random random = new Random();

        public static int Random(int min, int max)
        {
            return Convert.ToInt32(Math.Floor(random.NextDouble() * (max - min + 1))) + min;
        }

        public static string RandomString(int length, string chars)
        {
            StringBuilder builder = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                builder.Append(chars[Random(0, chars.Length - 1)]);
            }
            return builder.ToString();
        }
    }
}
