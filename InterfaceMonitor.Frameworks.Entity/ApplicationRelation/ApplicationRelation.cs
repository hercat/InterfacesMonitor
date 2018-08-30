using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// 应用系统关系表
    /// </summary>
    public class ApplicationRelation
    {
        public Guid appId { get; set; }
        public string appName { get; set; }
        public Guid fatherId { get; set; }
        public string fatherName { get; set; }
        public Guid childId { get; set; }
        public string childName { get; set; }
        public DateTime createtime { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumApplicationRelation.appId.ToString()))
                appId = new Guid(dr[EnumApplicationRelation.appId.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationRelation.appName.ToString()))
                appName = dr[EnumApplicationRelation.appName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationRelation.fatherId.ToString()))
                fatherId = new Guid(dr[EnumApplicationRelation.fatherId.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationRelation.fatherName.ToString()))
                fatherName = dr[EnumApplicationRelation.fatherName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationRelation.childId.ToString()))
                childId = new Guid(dr[EnumApplicationRelation.childId.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumApplicationRelation.childName.ToString()))
                childName = dr[EnumApplicationRelation.childName.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumApplicationRelation.createtime.ToString()))
                createtime = DateTime.Parse(dr[EnumApplicationRelation.createtime.ToString()].ToString());
            return true;
        }
    }
    public enum EnumApplicationRelation
    {
        appId,
        appName,
        fatherId,
        fatherName,
        childId,
        childName,
        createtime
    }
}
