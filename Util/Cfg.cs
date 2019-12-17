using Model;
using System.IO;
using System.Xml;

namespace Util
{
    /// <summary>
    /// 配置文件Cfg.xml相关操作，目前只有登录信息
    /// </summary>
    public class Cfg
    {
        /// <summary>
        /// 配置文件路径
        /// </summary>
        private static string cfgPath = System.Environment.CurrentDirectory + "\\Cfg.xml";

        /// <summary>
        /// 登录模块数据
        /// </summary>
        private static CfgLogin _login { get; set; } = new CfgLogin();

        /// <summary>
        /// 检查文件是否存在，不存在就新建一个
        /// </summary>
        private static void Check()
        {
            try
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
            catch
            {

            }
        }

        /// <summary>
        /// 从配置文件中获取登录模块的信息
        /// </summary>
        /// <returns></returns>
        public static CfgLogin GetLogin()
        {
            try
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
            }
            catch
            {

            }
            return _login;
        }

        /// <summary>
        /// 保存登录模块信息到配置文件中
        /// </summary>
        /// <param name="login"></param>
        public static void SetLogin(CfgLogin login)
        {
            try
            {
                Check();

                XmlWriterSettings mySettings = new XmlWriterSettings();
                mySettings.Indent = true;//是否进行缩进
                mySettings.IndentChars = ("    ");

                XmlWriter myWriter = XmlWriter.Create(cfgPath, mySettings);

                myWriter.WriteStartElement("Login");

                myWriter.WriteElementString("UserName", login.UsrName);
                if (login.RecordPwd)
                {
                    myWriter.WriteElementString("RecordPwd", "1");
                    if (login.UsrPwd.Length != 32)
                        myWriter.WriteElementString("UserPwd", Md5.GetHash(login.UsrPwd));
                    else
                        myWriter.WriteElementString("UserPwd", login.UsrPwd);

                }
                else
                {
                    myWriter.WriteElementString("RecordPwd", "0");
                    myWriter.WriteElementString("UserPwd", "");
                }

                if (login.AutoLogin)
                    myWriter.WriteElementString("AutoLogin", "1");
                else
                    myWriter.WriteElementString("AutoLogin", "0");

                myWriter.WriteElementString("ServerIp", login.SvrIp);
                myWriter.WriteEndElement();
                myWriter.Flush();
                myWriter.Close();
            }
            catch
            {

            }
        }
    }

}
