using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace InterfaceMonitor.Frameworks.Entity
{
    /// <summary>
    /// Description:负责人基本信息类实体
    /// Author:WUWEI
    /// Date:2018/05/24
    /// </summary>
    public class ChargesInfo
    {
        /// <summary>
        /// 编号
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 负责人名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Cellphone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark { get; set; }
        public bool AllParse(DataRow dr)
        {
            if (dr.Table.Columns.Contains(EnumChargesInfo.Id.ToString()))
                Id = new Guid(dr[EnumChargesInfo.Id.ToString()].ToString());
            if (dr.Table.Columns.Contains(EnumChargesInfo.Name.ToString()))
                Name = dr[EnumChargesInfo.Name.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumChargesInfo.Telephone.ToString()))
                Telephone = dr[EnumChargesInfo.Telephone.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumChargesInfo.Cellphone.ToString()))
                Cellphone = dr[EnumChargesInfo.Cellphone.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumChargesInfo.Email.ToString()))
                Email = dr[EnumChargesInfo.Email.ToString()].ToString();
            if (dr.Table.Columns.Contains(EnumChargesInfo.Remark.ToString()))
                Remark = dr[EnumChargesInfo.Remark.ToString()].ToString();
            return true;
        }
    }
    public enum EnumChargesInfo
    {
        Id,
        Name,
        Telephone,
        Cellphone,
        Email,
        Remark
    }
}
