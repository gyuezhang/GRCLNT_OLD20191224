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

        public delegate void GetLevelZonesEventHandler(RES_STATE state, List<ZoningNode> nodes);
        public static event GetLevelZonesEventHandler getLevelZones;
        public static void OnGetLevelZones(CLNTStringPackageInfo request)
        {
            try
            {
                getLevelZones(request.resState, JsonConvert.DeserializeObject<List<ZoningNode>>(string.Join("", request.Parameters)));
            }
            catch
            {

            }
        }

        public delegate void CreateWellEventHandler(RES_STATE state);
        public static event CreateWellEventHandler createWell;
        public static void OnCreateWell(CLNTStringPackageInfo request)
        {
            try
            {
                createWell(request.resState);
            }
            catch
            {

            }
        }

        public delegate void GetWellByFilterEventHandler(RES_STATE state, List<Well> wells);
        public static event GetWellByFilterEventHandler getWellByFilter;
        public static void OnGetWellByFilter(CLNTStringPackageInfo request)
        {
            try
            {

                getWellByFilter(request.resState, JsonConvert.DeserializeObject<List<Well>>(string.Join("", request.Parameters)));
            }
            catch
            {

            }
        }

        public delegate void DeleteWellEventHandler(RES_STATE state);
        public static event DeleteWellEventHandler deleteWell;
        public static void OnDeleteWell(CLNTStringPackageInfo request)
        {
            try
            {
                deleteWell(request.resState);
            }
            catch
            {

            }
        }

        public delegate void ChangeWellEventHandler(RES_STATE state);
        public static event ChangeWellEventHandler changeWell;
        public static void OnChangeWell(CLNTStringPackageInfo request)
        {
            try
            {
                changeWell(request.resState);
            }
            catch
            {

            }
        }

        public delegate void GetWellParasEventHandler(RES_STATE state, WellParas paras);
        public static event GetWellParasEventHandler getWellParas;
        public static void OnGetWellParas(CLNTStringPackageInfo request)
        {
            try
            {
                getWellParas(request.resState, JsonConvert.DeserializeObject<WellParas>(string.Join("", request.Parameters)));
            }
            catch
            {

            }
        }

        public delegate void SetWellParasEventHandler(RES_STATE state);
        public static event SetWellParasEventHandler setWellParas;
        public static void OnSetWellParas(CLNTStringPackageInfo request)
        {
            try
            {
                setWellParas(request.resState);
            }
            catch
            {

            }
        }
    }
}
