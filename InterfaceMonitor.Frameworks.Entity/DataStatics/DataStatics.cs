using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// 展示大屏数据
    /// </summary>
    public class DataStatics
    {
        public Guid appId { get; set; }
        public string appname { get; set; }
        public int level { get; set; }
        public string server { get; set; }
        public string userdep { get; set; }
        public string chargeman { get; set; }
        public string phone { get; set; }
        public int statu { get; set; }
        public long num { get; set; }
        public int errorNum { get; set; }
    }
    public class destinaappStatics
    {
        public Guid destinappid { get; set; }
        public string destinappname { get; set; }
        public Guid interfaceId { get; set; }
        public string interfacename { get; set; }
        public int StateCode { get; set; }
        public DateTime updatetime { get; set; }
        public int ConnectedTimeout { get; set; }
    }    
}
