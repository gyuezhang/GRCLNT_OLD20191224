using SuperSocket.ClientEngine;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    public class CLNTClient
    {
        private static EasyClient ezClient;
        private static string Ip;
        private static string Port { get; set; } = "6666";

        public static void Conn(string ip)
        {
            Ip = ip;
            ezClient = new EasyClient();
            ezClient.Initialize(new CLNTRecvFilter(), (request) =>
            {
                 switch(request.apiId)
                 {
                 case API_ID.API_ConnState:
                     break;
                 case API_ID.API_Login:
                     break;
                 default:
                     break;
                 }
            });
            _ = SyncConn();
        }

        public static bool IsConnected => ezClient.IsConnected;

        private static async Task SyncConn()
        {
            await ezClient.ConnectAsync(new IPEndPoint(IPAddress.Parse(Ip), int.Parse(Port)));
        }

        public static void Send(API_ID id,string para)
        {
            ezClient.Send(Encoding.UTF8.GetBytes(id.ToString() + " " + para + "\r\n"));
        }
    }
}
