using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GRCLNT
{
    /// <summary>
    /// 用户信息结构体
    /// </summary>
    public struct STR_Cfg_Login
    {
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public bool RecordPwd { get; set; }
        public bool AutoLogin { get; set; }
        public string ServerIp { get; set; }
    }

    /// <summary>
    /// 名称：配置文件类
    /// 功能：记录程序信息
    /// </summary>
    public class Cfg
    {
        /// <summary>
        /// 检测如果不存在配置文件则在exe目录下生成一个Cfg.xml
        /// </summary>
        public static void Init()
        {
            string strExePath = System.Environment.CurrentDirectory;
            string strCfgPath = strExePath + "\\Cfg.xml";

            if (File.Exists(strCfgPath))
            {
            }
            else
            {
                XmlWriterSettings mySettings = new XmlWriterSettings();
                mySettings.Indent = true;//是否进行缩进
                mySettings.IndentChars = ("    ");

                XmlWriter myWriter = XmlWriter.Create(strCfgPath, mySettings);

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

        /// <summary>
        /// 获取配置文件中的登录信息
        /// </summary>
        /// <returns>登录信息结构体</returns>
        public static STR_Cfg_Login GetLogin()
        {
            STR_Cfg_Login res = new STR_Cfg_Login();
            string strExePath = System.Environment.CurrentDirectory;
            string strCfgPath = strExePath + "\\Cfg.xml";
            XmlReader myReader = XmlReader.Create(strCfgPath);

            while (myReader.Read())
            {
                if (myReader.NodeType == XmlNodeType.Element)
                {
                    switch (myReader.Name)
                    {
                        case "UserName":
                            {
                                res.UserName = myReader.ReadString();
                            }
                            break;
                        case "UserPwd":
                            {
                                res.UserPwd = myReader.ReadString();
                            }
                            break;
                        case "RecordPwd":
                            {
                                res.RecordPwd = (myReader.ReadString() != "0");
                            }
                            break;
                        case "AutoLogin":
                            {
                                res.AutoLogin = (myReader.ReadString() != "0");
                            }
                            break;
                        case "ServerIp":
                            {
                                res.ServerIp = myReader.ReadString();
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            myReader.Close();
            return res;
        }

        /// <summary>
        /// 保存登录信息到配置文件中
        /// </summary>
        /// <param name="login">登录信息结构体</param>
        public static void SaveLogin(STR_Cfg_Login login)
        {
            string strExePath = System.Environment.CurrentDirectory;
            string strCfgPath = strExePath + "\\Cfg.xml";
            XmlWriterSettings mySettings = new XmlWriterSettings();
            mySettings.Indent = true;//是否进行缩进
            mySettings.IndentChars = ("    ");

            XmlWriter myWriter = XmlWriter.Create(strCfgPath, mySettings);

            myWriter.WriteStartElement("Login");
            myWriter.WriteElementString("UserName", login.UserName);
            myWriter.WriteElementString("UserPwd", login.UserPwd);
            if (login.RecordPwd)
                myWriter.WriteElementString("RecordPwd", "1");
            else
                myWriter.WriteElementString("RecordPwd", "0");

            if (login.AutoLogin)
                myWriter.WriteElementString("AutoLogin", "1");
            else
                myWriter.WriteElementString("AutoLogin", "0");

            myWriter.WriteElementString("ServerIp", login.ServerIp);
            myWriter.WriteEndElement();
            myWriter.Flush();
            myWriter.Close();
        }
    }
}
