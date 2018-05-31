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
using InterfaceMonitor.Frameworks.Entity;
using InterfaceMonitor.Frameworks.Logical;
using InterfaceMonitor.Frameworks.BizProcess;
using MySql.Data.MySqlClient;
using System.IO;
using WindowsFormsTest.ServiceReference1;

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
            InterfaceConfigInfo entity = new InterfaceConfigInfo();
            entity.Id = new Guid("ad6fb4e4-96c0-4e15-a072-dd921bcac243");
            entity.InterfaceName = "InterfaceMonitor.Frameworks.Logical.InterfaceConfigInfoOperation";
            entity.ApplicationName = "测试接口";
            entity.ServerAddress = "192.168.1.100";
            entity.ServerUser = "test";
            entity.UserPwd = "test123";
            entity.PersonOfChargeName = "json";
            entity.PersonOfChargePhone = "13812345678";
            entity.ConnectedTimeout = 200;
            entity.DocumentHelpPath = "../root/test.pdf";
            entity.Description = "不拉不拉不拉";
            entity.CreateTime = DateTime.Now;
            InterfaceConfigInfoOperation.AddOrUpdateInterfaceConfigInfo(entity, ModifierType.Add);
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
            //entity.CreateTime = DateTime.Now;
            //InterfaceConfigInfoOperation.AddOrUpdateInterfaceConfigInfo(entity2, ModifierType.Update);
            #endregion
        }
        /// <summary>
        /// 接口配置信息删除测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            Guid id = new Guid("ad6fb4e4-96c0-4e15-a072-dd921bcac243");
            InterfaceConfigInfoOperation.DeleteInterfaceConfigInfoById(id);
        }
        /// <summary>
        /// 根据Id编号获取接口配置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            #region 根据Id获取接口配置信息
            Guid id = new Guid("ad6fb4e4-96c0-4e15-a072-dd921bcac243");
            InterfaceConfigInfo info = InterfaceConfigInfoOperation.GetInterfaceConfigInfoById(id);
            #endregion
            //根据接口名、应用系统名和服务器地址获取接口配置信息
            InterfaceConfigInfo info2 = InterfaceConfigInfoOperation.GetInterfaceConfigInfo("InterfaceMonitor.Frameworks.Dal.InterfaceConfigInfoDal", "测试接口2", "192.168.1.80");
        }
        /// <summary>
        /// 获取接口配置信息列表测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            string fields = "Id,InterfaceName,ApplicationName,ServerAddress";
            string whereCondition = "where PersonInChargePhone = '13812345678'";
            List<InterfaceConfigInfo> list = InterfaceConfigInfoOperation.GetInterfaceConfigInfoList(fields, whereCondition);
        }
        /// <summary>
        /// 接口实时状态添加测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            InterfaceRealtimeInfo entity = new InterfaceRealtimeInfo();
            entity.Id = new Guid("ad6fb4e4-96c0-4e15-a072-dd921bcac243");
            entity.InterfaceName = "InterfaceMonitor.Frameworks.Logical.InterfaceConfigInfoOperation";
            entity.ApplicationName = "测试接口";
            entity.ServerAddress = "192.168.1.100";
            entity.StateCode = 200;
            entity.UpdateTime = DateTime.Now;
            InterfaceRealtimeInfoOperation.AddOrUpdateInterceRealtimeInfo(entity, ModifierType.Add);
        }
        /// <summary>
        /// 获取接口实时状态列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            string field = "Id,InterfaceName,ApplicationName,ServerAddress";
            string whereCondition = "where StateCode = 200";
            List<InterfaceRealtimeInfo> list = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfoList(field, whereCondition);
        }
        /// <summary>
        /// 删除接口实时状态测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            Guid id = new Guid("ad6fb4e4-96c0-4e15-a072-dd921bcac243");
            InterfaceRealtimeInfoOperation.DeleteInterfaceRealtimeInfoById(id);
        }
        /// <summary>
        /// 根据Id获取
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            Guid id = new Guid("ad6fb4e4-96c0-4e15-a072-dd921bcac243");
            InterfaceRealtimeInfo info = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfo(id);
        }
        /// <summary>
        /// 新增接口异常日志信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            InterfaceExceptionlog log = new InterfaceExceptionlog();
            log.ConfigId = new Guid("ad6fb4e4-96c0-4e15-a072-dd921bcac243");
            log.StateCode = 500;
            log.ExceptionInfo = "接口连接异常，尝试连接多次超时，不拉不拉不拉不拉";
            log.CreateTime = DateTime.Now;
            InterfaceExceptionlogOperation.AddInterfaceExceptionlogInfo(log);
        }
        /// <summary>
        /// 获取接口异常日志信息列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            string fields = "Id,ConfigId,StateCode,ExceptionInfo,CreateTime";
            string whereCndition = "where StateCode = 500";
            List<InterfaceExceptionlog> list = InterfaceExceptionlogOperation.GetInterfaceExceptionlogList(fields, whereCndition);
        }
        /// <summary>
        /// 接口初始化方法测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            InterfaceConfigInitBizProcess.SaveInterfaceInitial("InterfaceMonitor.Frameworks.BizProcess.InterfaceConfigInitBizProcess", "测试应用系统", "192.168.1.90", "test3", "test123", "WUWEI", "13812345678", 0, "./test/test3.pdf", "添加描述测试内容");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfo("InterfaceMonitor.Frameworks.Dal.InterfaceConfigInfoDal", "测试接口2", "192.168.1.80", 100);
            InterfaceRealtimeBizProcess.UpdateInterfaceRealtimeInfoWithException("InterfaceMonitor.Frameworks.Dal.InterfaceConfigInfoDal", "测试接口2", "192.168.1.80", 80, "InterfaceMonitor.Frameworks.Dal.InterfaceConfigInfoDal尝试连接失败，请重试！");
        }
        /// <summary>
        /// 接口配置信息、接口实时状态信息及接口异常日志信息分页逻辑测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            List<InterfaceConfigInfo> configs = InterfaceConfigInfoOperation.GetInterfaceConfigInfoPageList("Id,InterfaceName,ApplicationName,ServerAddress", "where UserPwd = 'test123'", 1, 2);
            List<InterfaceExceptionlog> logs = InterfaceExceptionlogOperation.GetInterfaceExceptionlogPageList("Id,ConfigId,StateCode,ExceptionInfo,CreateTime", "where StateCode = 500", 1, 3);
            List<InterfaceRealtimeInfo> realtimes = InterfaceRealtimeInfoOperation.GetInterfaceRealtimeInfoPageList("Id,InterfaceName,ApplicationName,ServerAddress,StateCode,UpdateTime", "where ApplicationName like '%测试接口%'", 1, 2);
        }
        /// <summary>
        /// 写入Blb类型数据测试
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            byte[] bytes = File.ReadAllBytes("./test.jpg");
            string connString = "server=localhost;Database=test;Uid=root;Pwd=jianglin";
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlTransaction trans = null;
            try
            {
                conn = new MySqlConnection(connString);
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "insert into pictures(pictureBytes,CreateTime) values(@bytes,@createtime)";
                cmd.Parameters.Add("@bytes", MySql.Data.MySqlClient.MySqlDbType.MediumBlob);
                cmd.Parameters.Add("@createtime", MySql.Data.MySqlClient.MySqlDbType.DateTime);
                cmd.Parameters[0].Value = bytes;
                cmd.Parameters[1].Value = DateTime.Now;
                cmd.ExecuteNonQuery();
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (null != trans)
                    trans.Rollback();
            }
            finally
            {
                if (null != conn)
                    conn.Close();
            }
        }
        /// <summary>
        /// 读取Bolb数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button19_Click(object sender, EventArgs e)
        {
            string connString = "server=localhost;Database=test;Uid=root;Pwd=jianglin";
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlTransaction trans = null;
            try
            {
                conn = new MySqlConnection(connString);
                cmd = conn.CreateCommand();
                conn.Open();
                trans = conn.BeginTransaction();
                cmd.Transaction = trans;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select pictureBytes from pictures where Id = 1";
                System.Data.Common.DbDataReader reader = cmd.ExecuteReader();
                byte[] buffer = null;
                if (reader.HasRows)
                {
                    reader.Read();
                    long len = reader.GetBytes(0, 0, null, 0, 0);
                    buffer = new byte[len];
                    len = reader.GetBytes(0, 0, buffer, 0, (int)len);
                    MemoryStream stream = new MemoryStream(buffer);
                    System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
                    image.Save(string.Format("../{0}.jpg", Guid.NewGuid().ToString()));
                }
            }
            catch (Exception ex)
            {
                if (null != trans)
                    trans.Rollback();
            }
            finally
            {
                if (null != conn)
                    conn.Close();
            }
        }
        /// <summary>
        /// Webservice调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button20_Click(object sender, EventArgs e)
        {
            WebService1SoapClient client = new WebService1SoapClient();
            try
            {
                //调用UpdateInterfaceRealtimeInfoService接口
                client.UpdateInterfaceRealtimeInfoService("InterfaceMonitor.Frameworks.BizProcess.InterfaceConfigInitBizProcess", "测试应用系统", "192.168.1.90", 90);
                //异步调用方法
                //client.UpdateInterfaceRealtimeInfoServiceAsync("InterfaceMonitor.Frameworks.BizProcess.InterfaceConfigInitBizProcess", "测试应用系统", "192.168.1.90", 80);
                //调用UpdateInterfaceRealtimeInfoWithExceptionService接口
                //client.UpdateInterfaceRealtimeInfoWithExceptionService("InterfaceMonitor.Frameworks.BizProcess.InterfaceConfigInitBizProcess", "测试应用系统", "192.168.1.90", 90, "接口相关WebService调用异常");
                //异步调用方法
                //client.UpdateInterfaceRealtimeInfoWithExceptionServiceAsync("InterfaceMonitor.Frameworks.BizProcess.InterfaceConfigInitBizProcess", "测试应用系统", "192.168.1.90", 90, "接口相关WebService调用异常");
            }
            catch (Exception ex)
            {
                if (null != client)
                    client.Close();
            }
        }
    }
}
