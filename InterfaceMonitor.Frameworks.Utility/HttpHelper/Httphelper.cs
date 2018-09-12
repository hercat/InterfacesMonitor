using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace InterfaceMonitor.Frameworks.Utility
{
    public class Httphelper
    {
        public static string HttpGet(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Credentials = CredentialCache.DefaultCredentials;
                byte[] data = client.DownloadData(url);
                return Encoding.UTF8.GetString(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string httpPost(string url, string postData)
        {
            Stream outStream = null;
            Stream inStream = null;
            StreamReader reader = null;
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            Encoding encoding = Encoding.UTF8;
            byte[] data = encoding.GetBytes(postData);
            try
            {
                request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.CookieContainer = cookieContainer;
                request.AllowAutoRedirect = true;
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;
                outStream = request.GetRequestStream();
                outStream.Write(data, 0, data.Length);
                outStream.Close();
                response = request.GetResponse() as HttpWebResponse;
                inStream = response.GetResponseStream();
                reader = new StreamReader(inStream, encoding);
                return reader.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
