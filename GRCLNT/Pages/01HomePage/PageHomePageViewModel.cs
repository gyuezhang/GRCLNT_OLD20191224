using GRCLNT.DataType;
using GRCLNT.Socket;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT.Pages
{
    public class PageHomePageViewModel : Screen
    {
        public PageHomePageViewModel()
        {
            API_RecvRes.SetPageHomePageViewModel(this);
            GetUserInfo();
        }

        private void GetUserInfo()
        {
            Cfg.Init();
            CLNTAPI.GetUserInfo(Cfg.GetLogin().UserName);
        }

        public void GetUserfInfoRes(RES_STATE state,STR_User user)
        {
            if(state == RES_STATE.OK)
            {
                userInfo = user;
            }
        }

        public STR_User userInfo { get; set; } = new STR_User();

        public void ChangeUserInfo()
        {
            iTabIndex = 3;
        }

        public void ResetPwd()
        {
            iTabIndex = 4;
        }

        public int iTabIndex { get; set; } = 0;

        public void ShowDashboard()
        {
            iTabIndex = 1;
        }

        public void ShowUserInfo()
        {
            iTabIndex = 2;
        }
    }
}
