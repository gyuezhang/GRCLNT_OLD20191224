using System;
using Stylet;


namespace GRCLNT.Wnd
{
    public class WndLoginViewModel : Screen
    {
        public int iTransitionerIndex { get; set; } = 0;

        public void ShowSetting()
        {
            iTransitionerIndex = 1;
        }

        public void TestServer()
        {
            iTransitionerIndex = 0;
        }

        public void SaveSetting()
        {
            iTransitionerIndex = 0;
        }

        public void ExitLogin()
        {
            this.RequestClose();
        }
    }
}
