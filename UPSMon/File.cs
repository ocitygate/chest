using System;
using System.IO;
using System.Collections;
using System.Net;

namespace UPSMon
{
	/// <summary>
	/// Summary description for File.
	/// </summary>
	public class File
	{
		//Reads the file at [filePath] and returns the contents.
		//Returns null if an error occurs.
		public static string ReadFile(string filePath)
		{
			StreamReader sr = null;
			string       file;

			try 
			{
				sr = new StreamReader(filePath, System.Text.Encoding.GetEncoding(1252));
				file = sr.ReadToEnd();
			}
			catch
			{
				file = null;
			}
			finally
			{
				if (sr != null)
					sr.Close();
			}
			return file;
		}


		//Writes [file] to the file at [filePath].
		//Returns true if successful otherwise false
		public static bool   WriteFile(string filePath, string file)
		{
			StreamWriter sw = null;
			bool         success = true;

			try 
			{
				sw = new StreamWriter(filePath, false, System.Text.Encoding.GetEncoding(1252));
				sw.Write(file);
			}
			catch
			{
				success = false;
			}
			finally
			{
				if (sw != null)
					sw.Close();
			}
			return success;
		}

	}
}
