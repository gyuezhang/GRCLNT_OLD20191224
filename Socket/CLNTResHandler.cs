using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    public class CLNTResHandler
    {
        public delegate void ConnStateEventHandler(RES_STATE state);
        public static event ConnStateEventHandler ConnState;
        public static void OnConnState(CLNTStringPackageInfo request)
        {
            ConnState(request.resState);
        }

        public delegate void LoginEventHandler(RES_STATE state, User user);
        public static event LoginEventHandler login;
        public static void OnLogin(CLNTStringPackageInfo request)
        {
            string a = string.Join("", request.Parameters);
            User u = JsonConvert.DeserializeObject<User>(a);
            login(request.resState, u);
        }
    }
}
