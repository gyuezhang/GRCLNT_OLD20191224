using Models;
using System.IO;
using System.Xml;

namespace Util
{
    public class Cfg
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
