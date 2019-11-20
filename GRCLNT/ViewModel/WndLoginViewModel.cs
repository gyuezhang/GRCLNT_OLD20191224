using System.Net;
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
            CLNTResHandler.ConnState += CLNTResHandler_ConnState;
            CLNTResHandler.login += CLNTResHandler_login;
            CheckAutoLogin();
        }
        private static bool bFirstLogin { get; set; } = true;

        private void CLNTResHandler_ConnState(RES_STATE state)
        {
            switch (state)
            {
                case RES_STATE.OK:
                    loginMessageQueue.Enqueue("已成功连接到服务器");
                    break;
                case RES_STATE.FAILED:
                    break;
                default:
                    break;
            }
        }

        private void CLNTResHandler_login(RES_STATE state, User user)
        {
            switch(state)
            {
                case RES_STATE.OK:
                    RTData.loginSuccessUserInfo = user;
                    LoginSuccess();
                    break;
                case RES_STATE.FAILED:
                    break;
                default:
                    break;
            }
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
            StartManualLogin();
        }

        public void OnSettingOK()
        {
            iTransitionerIndex = 0;
            CLNTClient.Conn(loginCfg.SvrIp);
        }

        public void OnTestServer()
        {
            if(ChangeIp())
            {
                loginMessageQueue.Enqueue("正在连接到服务器");
                CLNTClient.Conn(loginCfg.SvrIp);
            }
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
            loginMessageQueue.Enqueue("登录成功");
            bFirstLogin = false;
        }

        public void StartManualLogin()
        {
            CLNTAPI.Login(loginCfg.UsrName, Md5.GetMd5Hash(loginCfg.UsrPwd));
        }

        public void StartAutoLogin()
        {
            CLNTAPI.Login(Cfg.GetLogin().UsrName, Cfg.GetLogin().UsrPwd);
        }

        private bool ChangeIp()
        {
            if (loginCfg.SvrIp == "")
            {
                loginMessageQueue.Enqueue("IP地址不能为空");
                return false;
            }
            try
            {
                IPAddress.Parse(loginCfg.SvrIp);
            }
            catch
            {
                loginMessageQueue.Enqueue("无效的IP地址");
                return false;
            }
            return true;
        }

        private void CheckAutoLogin()
        {
            if (loginCfg.RecordPwd)
                loginCfg.UsrPwd = "11111111";
            if (loginCfg.AutoLogin && bFirstLogin)
                StartAutoLogin();
        }
    }
}
