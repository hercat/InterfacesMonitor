using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.Data;
using System.Reflection;
using System.Threading.Tasks;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;

namespace InterfaceMonitor.Frameworks.BizProcess
{
    public class StaticsBizprocess
    {
        private readonly static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public static List<DataStatics> GetDataStaics()
        {
            List<DataStatics> list = new List<DataStatics>();
            try
            {
                DataTable dt1 = ApplicationSysInfoLogical.GetApplicationInfoStatics();
                if (dt1.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt1.Rows)
                    {
                        DataStatics obj = new DataStatics();
                        obj.appId = dr.Field<Guid>("Id");
                        obj.appname = dr.Field<string>("name");
                        obj.server = dr.Field<string>("server");
                        obj.chargeman = dr.Field<string>("chargeman");
                        obj.level = dr.Field<int>("level");
                        obj.phone = dr.Field<string>("phone");
                        obj.userdep = dr.Field<string>("userdep");
                        obj.num = dr.Field<long>("num");
                        List<destinaappStatics> excplist = new List<destinaappStatics>();
                        DataTable dt2 = ApplicationSysInfoLogical.GetApplicationInfoStaticsDetails(obj.appId);
                        if (dt2.Rows.Count > 0)
                        {
                            foreach (DataRow dr2 in dt2.Rows)
                            {
                                destinaappStatics o = new destinaappStatics();
                                o.destinappid = dr2.Field<Guid>("destinappid");
                                o.destinappname = dr2.Field<string>("destinappname");
                                o.interfaceId = dr2.Field<Guid>("interfaceId");
                                o.interfacename = dr2.Field<string>("interfacename");
                                o.StateCode = dr2.Field<int>("StateCode");
                                o.updatetime = dr2.Field<DateTime>("UpdateTime");
                                o.ConnectedTimeout = dr2.Field<int>("ConnectedTimeout");
                                if (o != null)
                                {
                                    //double i = (DateTime.Now - o.updatetime).TotalMinutes;
                                    //接口状态码为0或上次更新时间与当前时间差大于超时时间间隔
                                    if (o.ConnectedTimeout < (DateTime.Now - o.updatetime).TotalMinutes || o.StateCode == 0)
                                        excplist.Add(o);
                                }
                            }
                        }
                        if (excplist.Count > 0)
                        {
                            obj.errorNum = excplist.Count;
                            obj.statu = 0;
                        }
                        else
                        {
                            obj.errorNum = 0;
                            obj.statu = 1;
                        }
                        if (obj != null)
                            list.Add(obj);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetDataStaics()发生错误,错误信息如下:{0}", ex));
            }
            return list;
        }

        public static List<destinaappStatics> GetDestinapplicationList(Guid appid)
        {
            List<destinaappStatics> dlist = new List<destinaappStatics>();
            try
            {
                
                DataTable dt2 = ApplicationSysInfoLogical.GetApplicationInfoStaticsDetails(appid);
                if (dt2.Rows.Count > 0)
                {
                    foreach (DataRow dr2 in dt2.Rows)
                    {
                        destinaappStatics o = new destinaappStatics();
                        o.destinappid = dr2.Field<Guid>("destinappid");
                        o.destinappname = dr2.Field<string>("destinappname");
                        o.interfaceId = dr2.Field<Guid>("interfaceId");
                        o.interfacename = dr2.Field<string>("interfacename");
                        o.StateCode = dr2.Field<int>("StateCode");
                        o.updatetime = dr2.Field<DateTime>("UpdateTime");
                        o.ConnectedTimeout = dr2.Field<int>("ConnectedTimeout");
                        if (o != null)
                        {
                            if ((DateTime.Now - o.updatetime).TotalMinutes > o.ConnectedTimeout)
                                o.StateCode = 0;
                            else
                                o.StateCode = 1;
                            dlist.Add(o);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetDestinapplicationList()发生错误,错误信息如下:{0}", ex));
            }
            return dlist;
        }
    }
}
