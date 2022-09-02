using System;
using System.IO;
using System.Collections;
using System.Net;
using System.Text;

namespace CS.IO
{
	/// <summary>
	/// Summary description for File.
	/// </summary>
	public class FileHelper
	{
		//Reads the file at [filePath] and returns the contents.
		//Returns null if an error occurs.
		public static string ReadFile(string filePath)
		{
			StreamReader sr = null;
			string       file;

			try 
			{
				sr = new StreamReader(filePath, Encoding.GetEncoding(1252));
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
				sw = new StreamWriter(filePath, false, Encoding.ASCII);
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

        public static bool WriteFile(string filePath, byte[] data)
        {
            FileStream fs = null;
            bool success = true;

            try
            {

                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                fs.Write(data, 0, data.Length);
            }
            catch
            {
                success = false;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
            }
            return success;
        }

        public static bool WriteFile(string filePath, Stream stream)
        {
            FileStream fs = null;
            bool success = true;
            byte[] buffer = new byte[4096];

            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);

                int bytes;
                while ((bytes = stream.Read(buffer, 0, buffer.Length)) != 0)
                    fs.Write(buffer, 0, bytes);

            }
            catch
            {
                success = false;
            }
            finally
            {
                if (fs != null)
                    fs.Close();
                stream.Close();
            }
            return success;
        }


        private static string EncodeParameters(params string[] namevalue)
        {
            StringBuilder temp = new StringBuilder("");
            for (int i = 0; i < namevalue.Length; i+=2)
            {
                if (i != 0)
                {
                    temp.Append("&");
                }
                string name = namevalue[i + 0];
                string value = namevalue[i + 1];

                temp.Append(name);
                temp.Append("=");
                
                for(int j = 0; j < value.Length; j++)
                {
                    char c = value[j];
                    switch (c)
                    {
                        case ' ':
                            temp.Append('+');
                            break;
                        case '+':
                            temp.Append("%2B");
                            break;
                        case '&':
                            temp.Append("%26");
                            break;
                        default:
                            temp.Append(c);
                            break;
                    }
                }

                i++;
            }

            return temp.ToString();
        }

        public static string PostURL(string URL, string[] parameters, out string responseURL)
        {
            string file = null;

            try
            {
                WebRequest webRequest = WebRequest.Create(URL);
                webRequest.Timeout = 5000;

                webRequest.ContentType = "application/x-www-form-urlencoded";
                webRequest.Method = "POST";
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(EncodeParameters(parameters));
                webRequest.ContentLength = bytes.Length;
                System.IO.Stream requestStream = webRequest.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length); //Push it out there
                requestStream.Close();

                WebResponse webResponse = webRequest.GetResponse();

                responseURL = webResponse.ResponseUri.ToString();

                string[] cts = webResponse.ContentType.Split(';');
                string type = cts[0].Trim();
                if (type == "text/html")
                {
                    Stream stream = webResponse.GetResponseStream();

                    StreamReader reader;

                    if (cts.Length >= 2)
                    {
                        string codepage = cts[1].Trim().Split('=')[1];

                        reader = new StreamReader(stream, Encoding.GetEncoding(codepage));
                    }
                    else
                    {
                        reader = new StreamReader(stream, Encoding.UTF8);
                    }

                    file = reader.ReadToEnd();
                }
                else
                {
                    file = null;
                }
            }
            catch //(Exception ex)
            {
                responseURL = null;
                file = null;
            }

            return file;
        }
        
        public static string ReadURL(string URL, out string responseURL)
		{
			string file = null;

			try
			{
				WebRequest   webRequest  = WebRequest.Create(URL);
                webRequest.Timeout = 10000;

				WebResponse  webResponse = webRequest.GetResponse();

                responseURL = webResponse.ResponseUri.ToString();

                string[] cts = webResponse.ContentType.Split(';');
                string type = cts[0].Trim();
                if (type == "text/html")
                {
                    Stream stream = webResponse.GetResponseStream();

                    StreamReader reader;

                    if (cts.Length >= 2)
                    {
                        string codepage = cts[1].Trim().Split('=')[1];

                        reader = new StreamReader(stream, Encoding.GetEncoding(codepage));
                    }
                    else
                    {
                        reader = new StreamReader(stream, Encoding.UTF8);
                    }

                    file = reader.ReadToEnd();
                }
                else
                {
                    file = null;
                }
            }
			catch //(Exception ex)
			{
                responseURL = null;
				file = null;
			}

			return file;
		}

        public static Stream ReadURLStream(string URL, out string responseURL, out WebHeaderCollection headers)
        {
            Stream stream;

            try
            {
                WebRequest webRequest = WebRequest.Create(URL);
                webRequest.Timeout = 3000;

                WebResponse webResponse = webRequest.GetResponse();

                responseURL = webResponse.ResponseUri.ToString();
                headers = webResponse.Headers;

                stream = webResponse.GetResponseStream();

            }
            catch //(Exception ex)
            {
                responseURL = null;
                stream = null;
                headers = null;
            }

            return stream;
        }

        public static string ReadStream(Stream stream)
        {
            string file;

            try
            {
                StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(1252));

                file = reader.ReadToEnd();
            }
            catch
            {
                file = null;
            }

            return file;
        }



		//Reads a csv value [file] starting from position [pos].
		//This function also accepts value that are enclosed in ".
		//If value is enclosed in ", "" within the value indicates a single ".
		//pos is set to the next value.
		//eof is set to true when end of file is reached otherwise false.
		//eol is set to true when end of line is reached otherwise false.
		public static string GetCsvValue(string file, ref int pos, out bool eof, out bool eol)
		{
            StringBuilder val = new StringBuilder(""); // stores the current value
			char   chr;          // stores the current character
			bool   frst = true;  // indicates that current character is first character
			bool   del  = false; // indicates that value is delimited with "
			bool   dcl  = false; // indicates that last character of delimited value was "
			bool   crlf = false; // indicates that previous character was a cr or a lf
			bool   eov  = false; // indicates end of value

			eof = false;
			eol = false;

			for(;!eov;pos++)
			{
				// if posistion is at end of file
				if (pos == file.Length)
				{
					eof = true;
					eol = true;
					eov = true;
					break;
				}

				// store the current character
				chr = file[pos];

				// if first character is "
				if (frst)
				{
					frst = false;
					if (chr == '"')
					{
						del = true;
						continue;
					}
				}

				// if field is not delimited or last character was "
				if (!del || dcl)
				{
					// if previous character was CR or LF
					if (crlf)
					{
						// if this character is not CR or LF
						if ((chr != (char) 13) && (chr != (char) 10))
						{
							// indicate EOL and EOV and return value
							eol = true;
							eov = true;
							break;
						}
					}

					// if character is CR or LF
					if ((chr == (char) 13) || (chr == (char) 10))
					{
						crlf = true;
						continue;
					}

					// if character is comma
					if (chr == ',')
					{
						eov = true;
						continue;
					}

					// if text is delimited and closed and this point is reached
					if (del)
					{
						// if chr is " ie. double delimiter
						if (chr == '"')
						{
							dcl = false;
							val.Append('"');
							continue;
						}

						// this should be an error because either " or , or CR or LF should follow " in del. value
						// but we are going to handle last " as a normal character and add this character
						dcl = false;
                        val.Append("\"");
                        val.Append(chr);
						continue;
					}
				}

				// if text is delimited and character is "
				if (del && (chr == '"'))
				{
					dcl = true;
					continue;
				}

				// append character
				val.Append(chr);
			}

			return val.ToString();
		}


		//Similar to GetCsvValue
		//This function reads the whole line and returns the values in an string array
		public static string[] GetCsvValues(string file, ref int pos, out bool eof)
		{
			ArrayList temp = new ArrayList();

			eof = false;

			bool eol = false;
			while(!eol)
			{
				string val = GetCsvValue(file, ref pos, out eof, out eol);
				temp.Add(val);
			}

			string[] ret = new string[temp.Count];
			temp.CopyTo(ret);
			return ret;
		}

		//Converts [val] to a csv value enclosed with "".
		public static string ToCsvValue(object val)
		{
            string str;
            if (val is DateTime)
                str = string.Format("{0:yyyy-MM-dd}", val);
            else if (val is Enum)
                str = Convert.ToInt32(val).ToString();
            else if (val == null)
                str = "";
            else
                str = val.ToString();

			StringBuilder ret = new StringBuilder("", Convert.ToInt32(str.Length * 1.1));
            ret.Append("\"");
            for (int i = 0; i < str.Length; i++)
			{
				char chr = str[i];
				if (chr == '"')
					ret.Append("\"\"");
				else
					ret.Append(chr);
			}
			ret.Append("\"");
			return ret.ToString();
		}

		public static bool GetData(string source, string dataStart, string dataEnd, out string data)
		{
			data = "";

			int posDataStart = source.IndexOf(dataStart);
			if (posDataStart == -1) return false;

			int posDataEnd;
            if (dataEnd == "")
                posDataEnd = source.Length;
            else
                posDataEnd =  source.LastIndexOf(dataEnd);
			if (posDataEnd == -1) return false;

			data = source.Substring(posDataStart + dataStart.Length, posDataEnd - posDataStart - dataStart.Length);
			return true;
		}

		public static string[] SplitData(string data, string seperator)
		{
			ArrayList temp = new ArrayList();

			int posStart = 0;
			while(posStart < data.Length)
			{
				int posEnd = data.IndexOf(seperator, posStart);
				if (posEnd == -1)
					posEnd = data.Length;
				temp.Add(data.Substring(posStart, posEnd - posStart));
				posStart = posEnd + seperator.Length;
			}

			string[] ret = new string[temp.Count];
			temp.CopyTo(ret);
			return ret;
		}

		public static bool CleanValue(ref string value, string charCodeStart, string charCodeEnd)
		{
			string value2 = "";

			int    pos = 0;
			while (pos < value.Length)
			{
				int posCharCodeStart = value.IndexOf(charCodeStart, pos);
				if (posCharCodeStart == -1)
				{
					value2 += value.Substring(pos, value.Length - pos);
					pos = value.Length;
					break;
				}

				value2 += value.Substring(pos, posCharCodeStart - pos);
				pos = posCharCodeStart + charCodeStart.Length;

				// ---------------------------------------------------------

				int posCharCodeEnd = value.IndexOf(charCodeEnd, pos);
				if (posCharCodeEnd == -1) return false;

				string charCode = value.Substring(pos, posCharCodeEnd - pos);

				try
				{
					value2 += (char) Convert.ToUInt16(charCode);
				}
				catch
				{
					return false;
				}

				pos = posCharCodeEnd + charCodeEnd.Length;
			}

			value = value2.TrimEnd(' ');
			return true;
		}

        public static string[] GetLines(string data)
        {
            ArrayList temp = new ArrayList();

            if (data != null)
            {
                System.IO.StringReader sr = new System.IO.StringReader(data);
                string line = sr.ReadLine();
                while (line != null)
                {
                    temp.Add(line);

                    line = sr.ReadLine();
                }
                sr.Close();
            }

            string[] ret = new string[temp.Count];
			temp.CopyTo(ret);
			return ret;
        }

	}
}
