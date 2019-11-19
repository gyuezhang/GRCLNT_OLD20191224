using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    public class CLNTAPI
    {
        public static void Login(string name, string pwd)
        {

            CLNTClient.Send(API_ID.API_Login,"");
        }
    }
}
