using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Socket
{
    /// <summary>
    /// 区别各个API，此结构体同服务器一致
    /// </summary>
    public enum API_ID
    {
        API_ConnState,
        API_ChangeUserInfo,

        API_GetLevelZoning,

        API_CreateWell, 
        API_GetWellByFilter,
        API_SetWellParas,

        API_AddAreaCode,
        API_DeleteAreaCode,
        API_ChangeAreaCode,
        API_GetAreaCodes,

        API_AdminUserResetPwd,
        API_AdminUserLogin,


        API_AddDept,
        API_DeleteDept,
        API_ChangeDept,
        API_GetDepts,


        API_AddUser,
        API_DeleteUser,
        API_ChangeUser,
        API_GetUsers,
        API_Login,
        API_ResetPwd,

        API_AddEntWell,
        API_ChangeEntWell,
        API_DeleteEntWell,
        API_GetEntWells,

        API_AddEntWellPara,
        API_ChangeEntWellPara,
        API_DeleteEntWellPara,
        API_GetEntWellParas,

        API_AddWell,
        API_ChangeWell,
        API_DeleteWell,
        API_GetWells,

        API_AddWellPara,
        API_ChangeWellPara,
        API_DeleteWellPara,
        API_GetWellParas,
    }

    /// <summary>
    /// 服务器API返回状态
    /// </summary>
    public enum RES_STATE
    {
        /// <summary>
        /// 服务器返回状态,此部分同服务器一致
        /// </summary>
        OK,
        FAILED,
        BAD_REQUEST,


        /// <summary>
        /// 客户端自身状态
        /// </summary>
        SVR_NOTFOUND_RECONN,
    }
}
