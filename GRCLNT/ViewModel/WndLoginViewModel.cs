using System;
using System.Net;
using System.Windows;
using System.Windows.Threading;
using MaterialDesignThemes.Wpf;
using Model;
using Socket;
using Stylet;
using Util;

namespace GRCLNT
{
    public class WndLoginViewModel : Screen
    {
        private IWindowManager _windowManager;

        private static bool bFirstLogin { get; set; } = true;

        private static int iPwdChangeCnt { get; set; } = 0;

        private DispatcherTimer TimerLoginSuccess = new DispatcherTimer();

        #region Bindings

        public CfgLogin loginCfg { get; set; }

        public WindowState loginWindowState { get; set; }

        public SnackbarMessageQueue loginMessageQueue { get; set; } = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.6));

        public int iTransitionerIndex { get; set; } = 0;

        public string curPwd { get; set; }

        #endregion Bindings

        #region Actions

        public void OnStartLogin()
        {
            //StartManualLogin();
        }

        public void OnSettingOK()
        {
            iTransitionerIndex = 0;
            CLNTClient.Conn(loginCfg.SvrIp);
        }

        public void OnTestServer()
        {
            if (CheckIp())
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

        public void OnPwdChanged()
        {
            iPwdChangeCnt++;
        }
        #endregion Actions
        private bool CheckIp()
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
    }
}
