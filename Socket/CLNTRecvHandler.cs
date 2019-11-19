using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    public class CLNTRecvHandler
    {
        public delegate void ConnStateEventHandler(CLNTStringPackageInfo request);
        public static event ConnStateEventHandler ConnState;
        public static void OnConnState(CLNTStringPackageInfo request)
        {
            ConnState(request);
        }
    }
}
