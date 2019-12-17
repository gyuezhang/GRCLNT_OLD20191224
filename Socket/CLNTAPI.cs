using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Socket
{
    public class CLNTAPI
    {
        public static void Login(string name, string pwd)
        {
            Tuple<string, string> loginInputs = new Tuple<string, string>(name, pwd);
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_Login, JsonConvert.SerializeObject(loginInputs));
            }
            else
            {
                CLNTClient.TryReconn();
                CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_Login, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }
    }


}
