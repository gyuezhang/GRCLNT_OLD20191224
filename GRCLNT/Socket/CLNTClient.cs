using SuperSocket.ClientEngine;
using System.Net;
using System.Threading.Tasks;

namespace GRCLNT.Socket
{
    /// <summary>
    /// 封装了EasyClient的客户端类
    /// </summary>
    public class CLNTClient
    {
        /// <summary>
        /// 设置Ip，并尝试连接服务器
        /// </summary>
        /// <param name="strIp"></param>
        public static void Init(string strIp)
        {
            Ip = strIp;
            Port = "6666";//写死默认端口号6666
            ezClient = new EasyClient();
            ezClient.Initialize(new CLNTRecvFilter(), (request) =>
            {
                //将收到的服务器响应分发给各个对应的API处理函数
                switch (request.apiId)
                {
                    case API_ID.API_ConnState:
                        API_RecvRes.API_ConnState(request);
                        break;
                    case API_ID.API_Login:
                        API_RecvRes.API_Login(request);
                        break;
                    //case API_ID.API_Admin_ChangePwd:
                    //    API_RecvRes.API_Admin_ChangePwd(request);
                    //    break;
                    //case API_ID.API_Admin_GetAllDepts:
                    //    API_RecvRes.API_Admin_GetAllDepts(request);
                    //    break;
                    //case API_ID.API_Admin_CreateDept:
                    //    API_RecvRes.API_Admin_CreateDept(request);
                    //    break;
                    //case API_ID.API_Admin_ChangeDept:
                    //    API_RecvRes.API_Admin_ChangeDept(request);
                    //    break;
                    //case API_ID.API_Admin_DeleteDept:
                    //    API_RecvRes.API_Admin_DeleteDept(request);
                    //    break;
                    //case API_ID.API_Admin_CreateUser:
                    //    API_RecvRes.API_Admin_CreateUser(request);
                    //    break;
                    //case API_ID.API_Admin_GetDeptIdByName:
                    //    API_RecvRes.API_Admin_GetDeptIdByName(request);
                    //    break;
                    //case API_ID.API_Admin_GetAllUsers:
                    //    API_RecvRes.API_Admin_GetAllUsers(request);
                    //    break;
                    //case API_ID.API_Admin_DeleteUsers:
                    //    API_RecvRes.API_Admin_DeleteUsers(request);
                    //    break;
                    //case API_ID.API_Admin_ChangeUser:
                    //    API_RecvRes.API_Admin_ChangeUser(request);
                    //    break;
                    default:
                        break;
                }
            });
            _ = Conn();
        }

        public static EasyClient ezClient;
        private static string Ip;
        private static string Port;

        /// <summary>
        /// 连接服务器
        /// </summary>
        /// <returns></returns>
        private static async Task Conn()
        {
            await ezClient.ConnectAsync(new IPEndPoint(IPAddress.Parse(Ip), int.Parse(Port)));
        }

        /// <summary>
        /// 返回服务器连接状态
        /// </summary>
        /// <returns>bool状态</returns>
        public static bool IsConnected()
        {
            return ezClient.IsConnected;
        }
    }
}
