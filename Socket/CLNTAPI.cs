using Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Socket
{
    public class CLNTAPI
    {
        public static void Login2(string name, string pwd)
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

        public static void ChangeUserInfo(C_User user)
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
        public static void ChangeWell(Well well)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_ChangeWell, JsonConvert.SerializeObject(well));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void GetWellParas2()
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_GetWellParas,"");
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void SetWellParas(WellParas wells)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_SetWellParas, JsonConvert.SerializeObject(wells));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void AddAreaCode(C_AreaCode ac)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_AddAreaCode, JsonConvert.SerializeObject(ac));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }


        public static void DeleteAreaCode(int id)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_DeleteAreaCode, id.ToString());
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void ChangeAreaCode(C_AreaCode ac)
        {
            
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_ChangeAreaCode, JsonConvert.SerializeObject(ac));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }

        }

        public static void GetAreaCodes()
        {

            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_GetAreaCodes,"");
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void AdminUserLogin(string pwd)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_AdminUserLogin, pwd);
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }

        }

        public static void AdminUserResetPwd(string oldPwd,string newPwd)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_AdminUserResetPwd, oldPwd + " " + newPwd);
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void AddDept(string deptname)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_AddDept, deptname);
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void ChangeDept(string oldDeptName, string newDeptName)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_ChangeDept, oldDeptName + " " + newDeptName);
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void DeleteDept(string name)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_DeleteDept, name);
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void GetDepts()
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_GetDepts, "");
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void AddUser(C_User u)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_AddUser, JsonConvert.SerializeObject(u));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }

        }
        public static void DeleteUser(C_User u)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_DeleteUser, JsonConvert.SerializeObject(u));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void ChangeUser(C_User u)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_ChangeUser, JsonConvert.SerializeObject(u));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }



        public static void GetUsers()
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_GetUsers, "");
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void Login(string name,string pwd)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_Login, name + " " +pwd);
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void ResetPwd(int id,string oldPwd,string newPwd)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_ResetPwd, id.ToString() + " " + oldPwd + " " + newPwd);
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }
        public static void AddWellPara(C_WellPara wp)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_AddWellPara, JsonConvert.SerializeObject(wp));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }


        public static void AddEntWellPara(C_WellPara wp)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_AddEntWellPara, JsonConvert.SerializeObject(wp));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void DeleteWellPara(C_WellPara wp)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_DeleteWellPara, JsonConvert.SerializeObject(wp));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void DeleteEntWellPara(C_WellPara wp)
        {
            if (CLNTClient.IsConnected)
            {

                CLNTClient.Send(API_ID.API_DeleteEntWellPara, JsonConvert.SerializeObject(wp));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void ChangeWellPara(C_WellPara oldWp,C_WellPara newWp)
        {
            if (CLNTClient.IsConnected)
            {
                List<C_WellPara> wpLst = new List<C_WellPara>();
                wpLst.Add(oldWp);
                wpLst.Add(newWp);

                CLNTClient.Send(API_ID.API_ChangeWellPara, JsonConvert.SerializeObject(wpLst));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }
        public static void ChangeEntWellPara(C_WellPara oldWp, C_WellPara newWp)
        {
            if (CLNTClient.IsConnected)
            {
                List<C_WellPara> wpLst = new List<C_WellPara>();
                wpLst.Add(oldWp);
                wpLst.Add(newWp);

                CLNTClient.Send(API_ID.API_ChangeEntWellPara, JsonConvert.SerializeObject(wpLst));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void GetWellParas()
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_GetWellParas, "");
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void GetEntWellParas()
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_GetEntWellParas, "");
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void AddWells(List<C_Well> wells)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_AddWell, JsonConvert.SerializeObject(wells));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void AddEntWells(List<C_EntWell> wells)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_AddEntWell, JsonConvert.SerializeObject(wells));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void DeleteWell(C_Well well)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_DeleteWell, JsonConvert.SerializeObject(well));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void DeleteEntWell(C_EntWell well)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_DeleteEntWell, JsonConvert.SerializeObject(well));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void ChangeWell(C_Well well)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_ChangeWell, JsonConvert.SerializeObject(well));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void ChangeEntWell(C_EntWell well)
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_ChangeEntWell, JsonConvert.SerializeObject(well));
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void GetWells()
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_GetWells, "");
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }

        public static void GetEntWells()
        {
            if (CLNTClient.IsConnected)
            {
                CLNTClient.Send(API_ID.API_GetEntWells, "");
            }
            else
            {
                CLNTClient.TryReconn();
                // CLNTResHandler.OnLogin(new CLNTStringPackageInfo(API_ID.API_ResetPwd, RES_STATE.SVR_NOTFOUND_RECONN, ""));
            }
        }
    }


}
