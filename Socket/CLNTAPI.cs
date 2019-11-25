using Models;
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
                API_Login_Req iLogin = new API_Login_Req(name, pwd);
                CLNTClient.Send(API_ID.API_Login, JsonConvert.SerializeObject(iLogin));
            }
            else
            {
                CLNTClient.TryReconn();
                CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_Login,RES_STATE.SVR_NOTFOUND_RECONN,""));
            }
        }

        public static void ChangeUserInfo(User user)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_ChangeUserInfo, JsonConvert.SerializeObject(user));
            }
            else
            {
                CLNTClient.TryReconn();
                CLNTResHandler.OnChangeUserInfo(new CLNTStringPackageInfo(API_ID.API_ChangeUserInfo, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }
        

        public static void ResetPwd(string userId,string oldPwd,string newPwd)
        {
            if (CLNTClient.IsConnected)
            {
                API_ResetPwd iResetPwd = new API_ResetPwd(userId, oldPwd, newPwd);
                CLNTClient.Send(API_ID.API_ResetPwd, JsonConvert.SerializeObject(iResetPwd));
            }
            else
            {
                CLNTClient.TryReconn();
                //CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void GetLevelZones(int iLevel)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_GetLevelZoning, iLevel.ToString());
            }
            else
            {
                CLNTClient.TryReconn();
               // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void CreateWell(List<Well> wells)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_CreateWell, JsonConvert.SerializeObject(wells));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void GetWellByFilter(string filter)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_GetWellByFilter, filter);
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void DeleteWell(int id)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_DeleteWell, id.ToString());
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }
    }
}
