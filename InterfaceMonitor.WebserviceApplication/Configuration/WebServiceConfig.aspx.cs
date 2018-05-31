using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InterfaceMonitor.Frameworks.Utility;
using InterfaceMonitor.Frameworks.Entity;

namespace InterfaceMonitor.WebserviceApplication
{
    public partial class WebServiceConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            if (settings.SysMySqlDB != null)
            {
                ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
                this.tbxServerAddress.Text = settings.SysMySqlDB.Server;
                this.tbxDatabaseName.Text = settings.SysMySqlDB.Database;
                this.tbxUser.Text = settings.SysMySqlDB.Uid;
                this.tbxPwd.Text = settings.SysMySqlDB.Password;
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            GetMySqlConfig(tbxServerAddress.Text, tbxDatabaseName.Text, tbxUser.Text, tbxPwd.Text);
            SystemSettingBase.CreateInstance().Save();
        }
        private void GetMySqlConfig(string server,string databaseName,string uid,string pwd)
        {
            if (!string.IsNullOrEmpty(server))
                SystemSettingBase.CreateInstance().SysMySqlDB.Server = server;
            if (!string.IsNullOrEmpty(databaseName))
                SystemSettingBase.CreateInstance().SysMySqlDB.Database = databaseName;
            if (!string.IsNullOrEmpty(uid))
                SystemSettingBase.CreateInstance().SysMySqlDB.Uid = uid;
            SystemSettingBase.CreateInstance().SysMySqlDB.CharSet = "utf8";
            if (!string.IsNullOrEmpty(pwd))
                SystemSettingBase.CreateInstance().SysMySqlDB.Password = pwd;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            return;
        }
    }
}