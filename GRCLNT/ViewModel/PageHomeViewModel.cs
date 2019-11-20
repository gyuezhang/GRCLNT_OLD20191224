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
        }

        public void OnShowUserInfo()
        {
            iPageIndex = 2;
        }

        public void OnChangeUserInfo()
        {

        }

        public void OnResetPwd()
        {

        }
    }
}
