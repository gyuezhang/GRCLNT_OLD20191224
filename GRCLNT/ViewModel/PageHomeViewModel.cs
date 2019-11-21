using Models;
using Socket;
using Stylet;

namespace GRCLNT
{
    class PageHomeViewModel : Screen
    {
        public PageHomeViewModel()
        {
            CLNTResHandler.changeUserInfo += CLNTResHandler_changeUserInfo;
            CLNTResHandler.resetPwd += CLNTResHandler_resetPwd;
        }

        private void CLNTResHandler_resetPwd(RES_STATE state, string newPwd)
        {
            
        }

        private void CLNTResHandler_changeUserInfo(RES_STATE state, User user)
        {
            switch(state)
            {
                case RES_STATE.OK:
                    RTData.loginSuccessUserInfo = user;
                    _curUser = user;
                    break;
                case RES_STATE.FAILED:
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

        }

        public void OnShowUserInfo()
        {
            iPageIndex = 2;
        }

        public void OnChangeInfo()
        {
            iPageIndex = 3;
        }

        public void OnChangePwd()
        {
            iPageIndex = 4;
        }

        public void OnChangeInfoOK()
        {
            User tmpUser = new User();
            tmpUser.Id = _curUser.Id;
            tmpUser.Name = _curUser.Name;
            tmpUser.Pwd = _curUser.Pwd;
            tmpUser.DeptName = _curUser.DeptName;
            tmpUser.Tel = changeUserTel;
            tmpUser.Email = changeUserEmail;
            CLNTAPI.ChangeUserInfo(tmpUser);
            OnShowUserInfo();
        }

        public string pwdOld { get; set; }
        public string pwdNew { get; set; }
        public string pwdNew2 { get; set; }
        public string changeUserTel { get; set; } = RTData.loginSuccessUserInfo.Tel;
        public string changeUserEmail { get; set; } = RTData.loginSuccessUserInfo.Email;
        public void OnChangePwdOK()
        {
            CLNTAPI.ResetPwd(_curUser.Id, pwdOld, pwdNew);
            OnShowUserInfo();
        }
    }
}
