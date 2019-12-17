using Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Socket
{
    public class CLNTAPI
    {
        public static void Login(string name, string pwd)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_Login, JsonConvert.SerializeObject(""));
            }
            else
            {
                CLNTClient.TryReconn();
                CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_Login, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }
    }


}
