﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfaceMonitor.Frameworks.Utility;
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;

namespace WindowsFormsTest
{
    public partial class Form1 : Form
    {       
        private static string _connectionString;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 数据库连接测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlOperation db = new MySqlOperation(_connectionString);
            db.Open();
            db.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _connectionString = "server=localhost;Database=test;Uid=root;Pwd=*******";
            SystemSettingBase settings = SystemSettingBase.CreateInstance();
            ConnString.MySqldb = settings.SysMySqlDB.ConnectionString;
        }
        /// <summary>
        /// 系统配置生成测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            GetMySqlConfig();
            SystemSettingBase.CreateInstance().Save();
        }
        /// <summary>
        /// 
        /// </summary>
        private void GetMySqlConfig()
        {
            SystemSettingBase.CreateInstance().SysMySqlDB.Server = "localhost";
            SystemSettingBase.CreateInstance().SysMySqlDB.Database = "InterfaceMonitorDB";
            SystemSettingBase.CreateInstance().SysMySqlDB.Uid = "root";
            SystemSettingBase.CreateInstance().SysMySqlDB.CharSet = "utf8";
            SystemSettingBase.CreateInstance().SysMySqlDB.Password = "jianglin";
        }
        /// <summary>
        /// 加载配置文件测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SystemSettingBase sysSettings = SystemSettingBase.CreateInstance();
            string server = sysSettings.SysMySqlDB.Server;
            string database = sysSettings.SysMySqlDB.Database;
            string uid = sysSettings.SysMySqlDB.Uid;
            string pwd = sysSettings.SysMySqlDB.Password;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IDbConnection conn = DbConnOperation.CreateConnection();
        }
        /// <summary>
        /// 接口配置信息添加测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            #region 接口配置添加测试
            //InterfaceConfigInfo entity = new InterfaceConfigInfo();
            //entity.Id = Guid.NewGuid();
            //entity.InterfaceName = "InterfaceMonitor.Frameworks.Logical.InterfaceConfigInfoOperation";
            //entity.ApplicationName = "测试接口";
            //entity.ServerAddress = "192.168.1.100";
            //entity.ServerUser = "test";
            //entity.UserPwd = "test123";
            //entity.PersonOfChargeName = "json";
            //entity.PersonOfChargePhone = "13812345678";
            //entity.ConnectedTimeout = 200;
            //entity.DocumentHelpPath = "../root/test.pdf";
            //entity.Description = "不拉不拉不拉";
            //InterfaceConfigInfoOperation.AddOrUpdateInterfaceConfigInfo(entity, ModifierType.Add);
            #endregion

            #region 接口配置更新测试
            //InterfaceConfigInfo entity2 = new InterfaceConfigInfo();
            //entity2.Id = new Guid("BB71F8EB-1C7C-4E88-8FA5-EC76FF9F5189");
            //entity2.InterfaceName = "InterfaceMonitor.Frameworks.Dal.InterfaceConfigInfoDal";
            //entity2.ApplicationName = "测试接口2";
            //entity2.ServerAddress = "192.168.1.80";
            //entity2.ServerUser = "test";
            //entity2.UserPwd = "test123";
            //entity2.PersonOfChargeName = "json";
            //entity2.PersonOfChargePhone = "13812345678";
            //entity2.ConnectedTimeout = 200;
            //entity2.DocumentHelpPath = "../root/test2.pdf";
            //entity2.Description = "不拉不拉不拉呜呜呜呜";
            //InterfaceConfigInfoOperation.AddOrUpdateInterfaceConfigInfo(entity2, ModifierType.Update);
            #endregion
        }
    }
}
