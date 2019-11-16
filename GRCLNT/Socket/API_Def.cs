namespace GRCLNT.Socket
{
    /// <summary>
    /// 区别各个API，此结构体同服务器一致
    /// </summary>
    public enum API_ID
    {
        API_ConnState,

        API_Admin_Login,
        API_Admin_ChangePwd,

        API_Admin_CreateDept,
        API_Admin_DeleteDept,
        API_Admin_ChangeDept,
        API_Admin_GetAllDepts,
        API_Admin_CreateUser,
        API_Admin_DeleteUsers,
        API_Admin_ChangeUser,
        API_Admin_GetAllUsers,
        API_Admin_GetDeptIdByName,

        API_Login,
        API_ChangeAccount,
        API_GetUserInfo,

        API_ChangeWell,
        API_CreateWell,
        API_DeleteWell,
        API_GetWellByFilter,

        API_ChangeEntWell,
        API_CreateEntWell,
        API_DeleteEntWell,
        API_GetEntWellByFilter,
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
        SVR_NOTFOUND,
    }
}
