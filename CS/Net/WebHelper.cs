using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;

namespace CS.Net
{
    public class WebHelper
    {

        public static WebResponse PostURL(string uri, string parameters, int timeout, CookieContainer cookies, string username, string password)
        {
            WebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            if (username != "" | password != "")
                webRequest.Credentials = new NetworkCredential(username, password);
            webRequest.Timeout = timeout;
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "POST";
            if (webRequest is HttpWebRequest)
            {
                ((HttpWebRequest)webRequest).CookieContainer = cookies;
                ((HttpWebRequest)webRequest).UserAgent = "*";
            }
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            Stream os = null;
            try
            { // send the Post
                webRequest.ContentLength = bytes.Length;   //Count bytes to send
                os = webRequest.GetRequestStream();
                os.Write(bytes, 0, bytes.Length);         //Send it
            }
            catch
            {
                return null;
            }
            finally
            {
                if (os != null)
                {
                    try { os.Close(); }
                    catch { }
                }
            }

            try
            {
                return webRequest.GetResponse();
            }
            catch
            {
                return null;
            }
        }

        public static WebResponse PostURL(string uri, string parameters, int timeout, CookieContainer cookies)
        {
            return PostURL(uri, parameters, timeout, cookies, "", "");
        }

        public static WebResponse GetURL(string uri, int timeout, CookieContainer cookies, string username, string password)
        {
            WebRequest webRequest = (HttpWebRequest)WebRequest.Create(uri);
            if (username != "" | password != "")
                webRequest.Credentials = new NetworkCredential(username, password);
            //string ProxyString = 
            //   System.Configuration.ConfigurationManager.AppSettings
            //   [GetConfigKey("proxy")];
            //webRequest.Proxy = new WebProxy (ProxyString, true);
            //Commenting out above required change to App.Config
            webRequest.Timeout = timeout;
            if (webRequest is HttpWebRequest)
            {
                ((HttpWebRequest)webRequest).CookieContainer = cookies;
                ((HttpWebRequest)webRequest).UserAgent = "*";
            }

            try
            {
                return webRequest.GetResponse();
            }
            catch
            {
                return null;
            }
        }

        public static WebResponse GetURL(string uri, int timeout, CookieContainer cookies)
        {
            return GetURL(uri, timeout, cookies, "", "");
        }
    }
}
