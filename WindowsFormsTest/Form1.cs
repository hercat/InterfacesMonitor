using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InterfaceMonitor.Frameworks.Utility;

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
            SystemSettingBase.CreateInstance().SysMySqlDB.Database = "test";
            SystemSettingBase.CreateInstance().SysMySqlDB.Uid = "root";
            SystemSettingBase.CreateInstance().SysMySqlDB.Password = "1qazxsw2";
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
    }
}
