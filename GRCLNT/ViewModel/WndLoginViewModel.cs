using System.Windows;
using MaterialDesignThemes.Wpf;
using Models;
using Socket;
using Stylet;
using Util;

namespace GRCLNT
{
    public class WndLoginViewModel : Screen
    {
        private IWindowManager _windowManager;

        public WndLoginViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            CLNTClient.Conn(loginCfg.SvrIp);

        }

        #region Bindings

        public CfgLogin loginCfg { get; set; } = Cfg.GetLogin();

        public WindowState loginWindowState { get; set; }

        public SnackbarMessageQueue loginMessageQueue { get; set; } = new SnackbarMessageQueue();

        public int iTransitionerIndex { get; set; } = 0;

        #endregion Bindings

        #region Actions

        public void OnStartLogin()
        {
            CLNTAPI.Login(loginCfg.UsrName, loginCfg.UsrPwd);
        }

        public void OnSettingOK()
        {
            iTransitionerIndex = 0;
            CLNTClient.Conn(loginCfg.SvrIp);
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

        /// <summary>
        /// 窗口状态，用于修复双击窗口会移动位置的bug
        /// </summary>
        public void OnStateChanged()
        {
            if (loginWindowState == WindowState.Maximized)
            {
                loginWindowState = WindowState.Normal;
            }
        }

        #endregion Actions



        public void LoginSuccess()
        {
            Cfg.SetLogin(loginCfg);
        }

        public void StartManualLogin()
        {

        }

        public void StartAutoLogin()
        {

        }

        public void LoginRes()
        {

        }
    }
}
