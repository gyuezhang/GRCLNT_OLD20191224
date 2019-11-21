using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT
{
    //定义页面及子页面
    public enum EnumPage
    {
        Home,
            Home_Dashboard,
            Home_UsrInfo,
                Home_UsrInfo_ChangeInfo,
                Home_UsrInfo_ChangPwd,

        Well,
            Well_AddMtdSel,
                Well_AddEdit,
                Well_AddAuto,
            Well_Search,
            Well_State,
            Well_Output,
            Well_Setting,

        EntWell,
        SediCtrl,
        GwDyna,
        GwProj,
        Hydro,
        Law,
        Setting,
    }
}
