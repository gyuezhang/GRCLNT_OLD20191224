using System;
using System.Windows;
using MaterialDesignThemes.Wpf;
using Models;
using Stylet;

namespace GRCLNT
{
    public class WndLoginViewModel : Screen
    {
        public WndLoginViewModel()
        {

        }

        public CfgLogin loginCfg { get; set; } = Cfg.GetLogin();

        public void OnStartLogin()
        {
            LoginSuccess();
        }

        public void OnSettingOK()
        {
            iTransitionerIndex = 0;
        }

        public void OnTestServer()
        {
            iTransitionerIndex = 0;
        }

        public void OnShowSetting()
        {
            iTransitionerIndex = 1;
        }

        public void OnExit()
        {
            this.RequestClose();
        }

        public void LoginSuccess()
        {
            Cfg.SetLogin(loginCfg);
        }

        #region 窗口状态，用于修复双击窗口会移动位置的bug
        public WindowState loginWindowState { get; set; }
        public void OnStateChanged()
        {
            if (loginWindowState == WindowState.Maximized)
            {
                loginWindowState = WindowState.Normal;
            }
        }
        #endregion

        public int iTransitionerIndex { get; set; } = 0;

        
        #region 提示消息
        public SnackbarMessageQueue loginMessageQueue { get; set; } = new SnackbarMessageQueue();
        
        #endregion
    }
}
