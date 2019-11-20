using Models;
using Stylet;

namespace GRCLNT
{
    class PageHomeViewModel : Screen
    {
        public User user { get; set; } = RTData.loginSuccessUserInfo;
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
            OnShowUserInfo();
        }

        public string pwdOld { get; set; }
        public string pwdNew { get; set; }
        public string pwdNew2 { get; set; }

        public void OnChangePwdOK()
        {
            OnShowUserInfo();
        }
    }
}
