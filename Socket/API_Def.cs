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
        API_Login,
        API_ChangeUserInfo,
        API_ResetPwd,

        API_GetLevelZoning,

        API_CreateWell, 
        API_GetWellByFilter,
        API_DeleteWell,
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
