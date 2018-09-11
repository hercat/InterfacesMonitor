using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMVC;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.BizProcess;

namespace InterfaceMonitor.Frameworks.AjaxWebController.Ajax
{
    public class AjaxStatics
    {
        /// <summary>
        /// 系统实时情况数据获取
        /// </summary>
        /// <returns></returns>
        [Action]
        public object GetAppRealtimeStatics()
        {
            try
            {
                List<DataStatics> list = StaticsBizprocess.GetDataStaics();
                return new JsonResult(list);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        /// <summary>
        /// 获取某系统下游系统及接口信息
        /// </summary>
        /// <param name="appid"></param>
        /// <returns></returns>
        [Action]
        public object GetDestinappStatics(string appid)
        {
            try
            {
                List<destinaappStatics> list = StaticsBizprocess.GetDestinapplicationList(new Guid(appid));
                return new JsonResult(list);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
