using Models;
using Newtonsoft.Json;

namespace Socket
{
    public class CLNTAPI
    {
        public static void Login(string name, string pwd)
        {
            if (CLNTClient.IsConnected)
            {
                API_Login_Req iLogin = new API_Login_Req(name, pwd);
                CLNTClient.Send(API_ID.API_Login, JsonConvert.SerializeObject(iLogin));
            }
            else
            {
                CLNTClient.TryReconn();
            }
        }
    }
}
