using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;

namespace InterfaceMonitor.Frameworks.Utility
{
    /// <summary>
    /// Description:配置基类，使用XML实现配置信息保存
    /// Author:WUWEI
    /// Date:2018/05/25
    /// </summary>
    public class SettingBase
    {
        private string m_fileName;
        public string FileName
        {
            get { return m_fileName; }
            set { m_fileName = value; }
        }
        private string m_formatVersion;
        public string FormatVersion
        {
            get { return m_formatVersion; }
            set { m_formatVersion = value; }
        }

        public static string DefaultLocation(LocationType locationType)
        {
            switch (locationType)
            {
                case LocationType.UserLocal:
                    return Application.LocalUserAppDataPath;
                case LocationType.UserCommon:
                    return Application.CommonAppDataPath;
                case LocationType.Application:
                    return AppDomain.CurrentDomain.BaseDirectory;
                default:
                    break;
            }
            return null;
        }
        public string DefaultName()
        {
            return string.Format("{0}.xml", "InterfaceMonitor.Utility.SysSettingBase");
        }
        public SettingBase()
        {
            m_formatVersion = Application.ProductVersion;
        }
        public virtual void Save(string fileName)
        {
            XmlSerializer serializer = null;
            try
            {
                serializer = new XmlSerializer(this.GetType());
                using (TextWriter textWriter = new StreamWriter(fileName))
                    serializer.Serialize(textWriter, this);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Saving settings class '{0}' to {1} failed.", this.GetType().ToString(), fileName), ex);
            }
        }
        public virtual void Save()
        {
            Save(m_fileName);
        }
        public static SettingBase Load(SettingBase defaultSettings, string fileName)
        {
            defaultSettings.m_fileName = fileName;
            if (!File.Exists(fileName))
                return defaultSettings;
            SettingBase settings = defaultSettings;
            try
            {
                XmlSerializer serializer = new XmlSerializer(defaultSettings.GetType());
                using (TextReader reader = new StreamReader(fileName))
                {
                    settings = (SettingBase)serializer.Deserialize(reader);
                    settings.m_fileName = fileName;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Loading settings from file '{1}' to {0} failed.", defaultSettings.GetType().ToString(), fileName), ex);
            }
            if (File.Exists(fileName + ".tmp"))
                File.Delete(fileName + ".tmp");
            return settings;
        }
        public static SettingBase LoadFromPath(SettingBase defaultSettings, string path)
        {
            string fileName = Path.Combine(path, defaultSettings.DefaultName());
            return Load(defaultSettings, fileName);
        }
        public static SettingBase Load(SettingBase defaultSettings, LocationType locationType, string name)
        {
            string fileName = Path.Combine(DefaultLocation(locationType), name);
            return Load(defaultSettings, fileName);
        }
        public static SettingBase Load(SettingBase defaultSettings, LocationType locationType)
        {
            return Load(defaultSettings, locationType, defaultSettings.DefaultName());
        }
        public string SettingsFilePath
        {
            get { return m_fileName; }
        }
    }
    public enum LocationType
    {
        UserLocal,
        UserCommon,
        Application
    }
}
