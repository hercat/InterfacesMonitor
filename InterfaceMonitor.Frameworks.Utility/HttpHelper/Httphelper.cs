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
        public static bool HttpGet(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.AllowAutoRedirect = true;
                request.Method = "GET";
                request.Timeout = 10000;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:62.0) Gecko/20100101 Firefox/62.0";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                HttpStatusCode code = response.StatusCode;
                if (code == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch (WebException ex)
            {
                return false;
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
        /// <summary>
        /// webservice状态监测
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpStatusCode httpWebServiceRequest(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                CookieContainer cookieContainer = new CookieContainer();
                request.AllowAutoRedirect = true;
                request.Method = "GET";
                request.Timeout = 10000;
                request.ContentType = "application/x-www-form-urlencoded";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64; rv:62.0) Gecko/20100101 Firefox/62.0";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                HttpStatusCode code = response.StatusCode;
                return code;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }        
    }
}
