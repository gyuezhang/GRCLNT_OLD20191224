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

        public void OnResetPwd()
        {
            if(strResetPwdNew1 != strResetPwdNew2)
            {

            }
            else if((strResetPwdNew1 == null) || (strResetPwdNew2 == null))
            {

            }
            else if(strResetPwdNew1 == strResetPwdOld)
            {

            }
            else
            {
                userInfo.Pwd = strResetPwdNew1;
                CLNTAPI.API_ChangeAccount(userInfo);
            }
        }

        public string strResetPwdOld { get; set; }
        public string strResetPwdNew1 { get; set; }
        public string strResetPwdNew2 { get; set; }

        public void ChangeAccountRes(RES_STATE state)
        {
            if (state == RES_STATE.OK)
            {
            }
        }
    }
}
