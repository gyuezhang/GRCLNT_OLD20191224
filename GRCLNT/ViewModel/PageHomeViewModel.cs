using MaterialDesignThemes.Wpf;
using Models;
using Socket;
using Stylet;
using System;
using Util;

namespace GRCLNT
{
    class PageHomeViewModel : Screen
    {
        public PageHomeViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            CLNTResHandler.changeUserInfo += CLNTResHandler_changeUserInfo;
            CLNTResHandler.resetPwd += CLNTResHandler_resetPwd;
            wndMainVM.UpdateAddr(EnumPage.Home);
        }

        private WndMainViewModel wndMainVM { get; set; }
        private void CLNTResHandler_resetPwd(RES_STATE state)
        {
            switch (state)
            {
                case RES_STATE.OK:
                    wndMainVM.mainMessageQueue.Enqueue("重置密码成功，建议尽快重新登录");
                    OnShowUserInfo();
                    break;
                case RES_STATE.FAILED:
                    wndMainVM.mainMessageQueue.Enqueue("重置密码失败");
                    break;
                default:
                    break;
            }
        }

        private void CLNTResHandler_changeUserInfo(RES_STATE state, User user)
        {
            switch(state)
            {
                case RES_STATE.OK:
                    RTData.loginSuccessUserInfo = user;
                    _curUser = user;
                    wndMainVM.mainMessageQueue.Enqueue("修改用户信息成功");
                    OnShowUserInfo();
                    break;
                case RES_STATE.FAILED:
                    wndMainVM.mainMessageQueue.Enqueue("修改用户信息失败");
                    break;
                default:
                    break;
            }
        }

        public User _curUser { get; set; } = RTData.loginSuccessUserInfo;
        public int iPageIndex { get; set; } = 0;

        public void OnShowDashboard()
        {
            iPageIndex = 1;
            wndMainVM.UpdateAddr(EnumPage.Home_Dashboard);
        }

        public void OnShowUserInfo()
        {
            iPageIndex = 2;
            wndMainVM.UpdateAddr(EnumPage.Home_UsrInfo);

        }

        public void OnChangeInfo()
        {
            iPageIndex = 3;
            wndMainVM.UpdateAddr(EnumPage.Home_UsrInfo_ChangeInfo);
        }

        public void OnChangePwd()
        {
            pwdOld = "";
            pwdNew = "";
            pwdNew2 = "";
            iPageIndex = 4;
            wndMainVM.UpdateAddr(EnumPage.Home_UsrInfo_ChangPwd);
        }

        public void OnChangeInfoOK()
        {
            if(CheckChangeInfo())
            {
                User tmpUser = new User();
                tmpUser.Id = _curUser.Id;
                tmpUser.Name = _curUser.Name;
                tmpUser.Pwd = _curUser.Pwd;
                tmpUser.DeptName = _curUser.DeptName;
                tmpUser.Tel = changeUserTel;
                tmpUser.Email = changeUserEmail;
                CLNTAPI.ChangeUserInfo(tmpUser);
            }
        }

        public string pwdOld { get; set; }
        public string pwdNew { get; set; }
        public string pwdNew2 { get; set; }
        public string changeUserTel { get; set; } = RTData.loginSuccessUserInfo.Tel;
        public string changeUserEmail { get; set; } = RTData.loginSuccessUserInfo.Email;
        public void OnChangePwdOK()
        {
            if(CheckResetPwd())
                CLNTAPI.ResetPwd(_curUser.Id, Md5.GetHash(pwdOld), Md5.GetHash(pwdNew));
        }

        public  bool CheckResetPwd()
        {
            if(pwdOld == "")
            {
                wndMainVM.mainMessageQueue.Enqueue("旧密码不能为空");
                return false;
            }

            if (pwdNew == "")
            {
                wndMainVM.mainMessageQueue.Enqueue("新密码不能为空");
                return false;
            }

            if (pwdNew != pwdNew2)
            {
                wndMainVM.mainMessageQueue.Enqueue("新密码不一致");
                return false;
            }

            if (pwdNew == pwdOld)
            {
                wndMainVM.mainMessageQueue.Enqueue("新旧密码一致，未作出更改");
                return false;
            }

            return true;
        }
        
        public bool CheckChangeInfo()
        {
            if(!Str.IsNum(changeUserTel))
            {
                wndMainVM.mainMessageQueue.Enqueue("非法电话号码");
                return false;
            }
            
            if(!Str.IsEmail(changeUserEmail))
            {
                wndMainVM.mainMessageQueue.Enqueue("邮箱格式不正确");
                return false;
            }

            if((_curUser.Tel == changeUserTel)&&(_curUser.Email == changeUserEmail))
            {
                OnShowUserInfo();
                return false;
            }

            return true;
        }
    }
}
