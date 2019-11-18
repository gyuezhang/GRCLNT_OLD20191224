using Stylet;
using System.IO;
using System.Xml;

namespace Models
{
    public class CfgLogin : PropertyChangedBase
    {
        private string _usrName;
        private string _usrPwd;
        private bool _recordPwd;
        private bool _autoLogin;
        private string _svrIp;

        public string UsrName
        {
            get { return _usrName; }
            set
            {
                SetAndNotify(ref _usrName, value);
            }
        }

        public string UsrPwd
        {
            get { return _usrPwd; }
            set
            {
                SetAndNotify(ref _usrPwd, value);
            }
        }

        public bool RecordPwd
        {
            get { return _recordPwd; }
            set
            {
                SetAndNotify(ref _recordPwd, value);
                if(!value)
                {
                    AutoLogin = value;
                }
            }
        }

        public bool AutoLogin
        {
            get { return _autoLogin; }
            set
            {
                SetAndNotify(ref _autoLogin, value);
                if (value)
                {
                    RecordPwd = value;
                }
            }
        }

        public string SvrIp
        {
            get { return _svrIp; }
            set
            {
                SetAndNotify(ref _svrIp, value);
            }
        }
    }

    public class Cfg : PropertyChangedBase
    {
        private static string cfgPath = System.Environment.CurrentDirectory + "\\Cfg.xml";

        private static CfgLogin _login { get; set; } = new CfgLogin();

        private static void Check()
        {
            if (!File.Exists(cfgPath))
            {
                XmlWriterSettings mySettings = new XmlWriterSettings();
                mySettings.Indent = true;//是否进行缩进
                mySettings.IndentChars = ("    ");

                XmlWriter myWriter = XmlWriter.Create(cfgPath, mySettings);

                myWriter.WriteStartElement("Login");
                myWriter.WriteElementString("UserName", "");
                myWriter.WriteElementString("UserPwd", "");
                myWriter.WriteElementString("RecordPwd", "0");
                myWriter.WriteElementString("AutoLogin", "0");
                myWriter.WriteElementString("ServerIp", "");
                myWriter.WriteEndElement();
                myWriter.Flush();
                myWriter.Close();
            }
        }

        public static CfgLogin GetLogin()
        {
            Check();

            XmlReader myReader = XmlReader.Create(cfgPath);
            while (myReader.Read())
            {
                if (myReader.NodeType == XmlNodeType.Element)
                {
                    switch (myReader.Name)
                    {
                        case "UserName":
                            {
                                _login.UsrName = myReader.ReadString();
                            }
                            break;
                        case "UserPwd":
                            {
                                _login.UsrPwd = myReader.ReadString();
                            }
                            break;
                        case "RecordPwd":
                            {
                                _login.RecordPwd = (myReader.ReadString() != "0");
                            }
                            break;
                        case "AutoLogin":
                            {
                                _login.AutoLogin = (myReader.ReadString() != "0");
                            }
                            break;
                        case "ServerIp":
                            {
                                _login.SvrIp = myReader.ReadString();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            myReader.Close();
            
            return _login;
        }

        public static void SetLogin(CfgLogin login)
        {
            Check();

            XmlWriterSettings mySettings = new XmlWriterSettings();
            mySettings.Indent = true;//是否进行缩进
            mySettings.IndentChars = ("    ");

            XmlWriter myWriter = XmlWriter.Create(cfgPath, mySettings);

            myWriter.WriteStartElement("Login");
            myWriter.WriteElementString("UserName", login.UsrName);
            myWriter.WriteElementString("UserPwd", login.UsrPwd);
            if (login.RecordPwd)
                myWriter.WriteElementString("RecordPwd", "1");
            else
                myWriter.WriteElementString("RecordPwd", "0");

            if (login.AutoLogin)
                myWriter.WriteElementString("AutoLogin", "1");
            else
                myWriter.WriteElementString("AutoLogin", "0");

            myWriter.WriteElementString("ServerIp", login.SvrIp);
            myWriter.WriteEndElement();
            myWriter.Flush();
            myWriter.Close();
        }
    }
}
