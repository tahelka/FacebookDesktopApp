namespace FacebookAppForDesktopLogic
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml.Serialization;

    public class AppSettings
    {
        public static readonly string sr_FileFullPath = Environment.CurrentDirectory + "\\appSettings.xml";
        private static readonly string sr_FileDoesNotExistMsg = $@"File does not exist. 
Please create one with the following full path:
{sr_FileFullPath}";

        public Point LastWindowLocation { get; set; }

        public Size LastWindowSize { get; set; }

        public bool RememberUser { get; set; }

        public string LastAccessToken { get; set; }

        public string[] Permissions
        {
            get
            {
                return m_Permissions;
            }
        }

        public string AppID = "1008417083525437"; // our app id
        private string[] m_Permissions = new string[]
        {
            "public_profile",
            "user_birthday",
            "user_events",
            "user_friends",
            "user_likes",
            "user_link",
            "user_photos",
            "user_posts",
            "user_managed_groups",
        };

        internal AppSettings()
        {
            LastWindowLocation = new Point(0, 0);
            LastWindowSize = new Size(1000, 500);
            RememberUser = false;
        }

        internal static AppSettings LoadFromFile()
        {
            AppSettings appSettings = new AppSettings();

            if (File.Exists(sr_FileFullPath))
            {
                FileInfo appSettingsFile = new FileInfo(sr_FileFullPath);
                if (appSettingsFile.Length > 0)
                {
                    using (Stream stream = new FileStream(sr_FileFullPath, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                        appSettings = serializer.Deserialize(stream) as AppSettings;
                    }
                }
            }
            else
            {
                MessageBox.Show(sr_FileDoesNotExistMsg);
            }

            return appSettings;
        }

        internal void SaveToFile()
        {
            if (File.Exists(sr_FileFullPath))
            {
                using (Stream stream = new FileStream(sr_FileFullPath, FileMode.Truncate))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppSettings));
                    xmlSerializer.Serialize(stream, this);
                }
            }
            else
            {
                MessageBox.Show(sr_FileDoesNotExistMsg);
            }
        }
    }
}