using System;
using System.Net;
using System.Windows;
using System.Windows.Threading;
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

        private static bool bFirstLogin { get; set; } = true;

        private static int iPwdChangeCnt { get; set; } = 0;

        private DispatcherTimer TimerLoginSuccess = new DispatcherTimer();

        public WndLoginViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            iPwdChangeCnt = 0;
            ///获取配置文件的登录信息
            loginCfg = Cfg.GetLogin();
            
            ///注册服务器接口返回处理函数
            CLNTResHandler.ConnState += CLNTResHandler_ConnState;
            CLNTResHandler.login += CLNTResHandler_login;

            ///尝试连接服务器
            CLNTClient.Conn(loginCfg.SvrIp);

            ///把界面的PWD隐藏
            if (loginCfg.RecordPwd)
                curPwd = "11111111";
            else
                curPwd = "";

            ///检测是否自动登录
            CheckAutoLogin();

            ///注册登录成功后等待的Timer函数
            TimerLoginSuccess.Tick += TimerLoginSuccess_Tick;
        }

        private void TimerLoginSuccess_Tick(object sender, System.EventArgs e)
        {
            loginMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.6));
            TimerLoginSuccess.Stop();
            ///注册服务器接口返回处理函数
            CLNTResHandler.ConnState -= CLNTResHandler_ConnState;
            CLNTResHandler.login -= CLNTResHandler_login;
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                var wndMainViewModel = new WndMainViewModel(_windowManager);
                this._windowManager.ShowWindow(wndMainViewModel);
                this.RequestClose();
            }));
        }

        #region API ResHander
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
                    loginMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.6));
                    loginMessageQueue.Enqueue("用户名或密码错误");
                    break;
                default:
                    break;
            }
        }
        #endregion

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
            StartManualLogin();
        }

        public void OnSettingOK()
        {
            iTransitionerIndex = 0;
            CLNTClient.Conn(loginCfg.SvrIp);
        }

        public void OnTestServer()
        {
            if(CheckIp())
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



        public void LoginSuccess()
        {
            if (iPwdChangeCnt > 1)
                loginCfg.UsrPwd = curPwd;

            Cfg.SetLogin(loginCfg);
            loginMessageQueue.Enqueue("登录成功");
            bFirstLogin = false; 
            TimerLoginSuccess.Interval = new TimeSpan(0, 0, 0, 3);
            TimerLoginSuccess.Start();
        }

        public void StartManualLogin()
        {
            loginMessageQueue.Enqueue("正在登录");
            if(iPwdChangeCnt == 1)
                CLNTAPI.Login(loginCfg.UsrName, loginCfg.UsrPwd);
            else
                CLNTAPI.Login(loginCfg.UsrName, Md5.GetHash(curPwd));
        }

        public void StartAutoLogin()
        {
            loginMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(5));
            loginMessageQueue.Enqueue("正在自动登录",
                "取消",
                CancelAutoLogin);
            CLNTAPI.Login(Cfg.GetLogin().UsrName, Cfg.GetLogin().UsrPwd);
        }

        public void CancelAutoLogin()
        {
            loginMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(0.6));
            TimerLoginSuccess.Stop();
            loginMessageQueue.Enqueue("自动登录已取消");
        }

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

        private void CheckAutoLogin()
        {
            if (loginCfg.AutoLogin && bFirstLogin)
                StartAutoLogin();
        }
    }
}
