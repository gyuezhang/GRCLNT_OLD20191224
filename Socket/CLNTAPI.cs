
using Newtonsoft.Json;
using System.Data;

namespace Socket
{
    public class CLNTAPI
    {
        [JsonObject(MemberSerialization.OptIn)]
        class LoginInput
        {
            public LoginInput(string name,string pwd)
            {
                this.name = name;
                this.pwd = pwd;
            }
            [JsonProperty]
            private string name { get; set; }
            [JsonProperty]
            private string pwd { get; set; }
        }

        public static void Login(string name, string pwd)
        {
            if (CLNTClient.IsConnected)
            {
                LoginInput iLogin = new LoginInput(name, pwd);
                CLNTClient.Send(API_ID.API_Login, JsonConvert.SerializeObject(iLogin));
            }
            else
            {
                CLNTClient.TryReconn();
            }
        }
    }
}
