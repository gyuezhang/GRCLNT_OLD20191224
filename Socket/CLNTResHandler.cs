﻿using Models;
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
            login(request.resState, JsonConvert.DeserializeObject<User>(string.Join("", request.Parameters)));
        }

        public delegate void ChangeUserInfoEventHandler(RES_STATE state, User user);
        public static event ChangeUserInfoEventHandler changeUserInfo;
        public static void OnChangeUserInfo(CLNTStringPackageInfo request)
        {
            changeUserInfo(request.resState, JsonConvert.DeserializeObject<User>(string.Join("", request.Parameters)));
        }

        public delegate void ResetPwdEventHandler(RES_STATE state);
        public static event ResetPwdEventHandler resetPwd;
        public static void OnResetPwd(CLNTStringPackageInfo request)
        {
            resetPwd(request.resState);
        }
    }
}
