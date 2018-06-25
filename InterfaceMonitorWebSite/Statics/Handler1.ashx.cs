using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterfaceMonitorWebSite.Statics
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";            
            string number1 = context.Request.Form["num1"];
            string number2 = context.Request.Form["num2"];
            context.Response.Write(string.Format("地址栏参数内容为：{0}", number1));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}