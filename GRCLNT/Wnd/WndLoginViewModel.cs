using System;
using Stylet;
using GRCLNT;
using GRCLNT.Socket;
using MaterialDesignThemes.Wpf;
using System.Net;
using System.Windows.Threading;

namespace GRCLNT.Wnd
{
    public class WndLoginViewModel : Screen
    {
        private IWindowManager windowManager;
        public WndLoginViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
            Cfg.Init();
            InitWidgetFromCfg();
            API_RecvRes.SetWndLoginViewModel(this);
            CLNTClient.Init(loginCfg.ServerIp);
            TimerLoginSuccess.Tick += TimerLoginSuccess_Tick;
            if (loginCfg.AutoLogin && bFirstLogin)
            {
                StartLogin();
            }


        }

        private void TimerLoginSuccess_Tick(object sender, EventArgs e)
        {
            TimerLoginSuccess.Stop();
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                var wndMainViewModel = new WndMainViewModel();
                this.windowManager.ShowWindow(wndMainViewModel);
                this.RequestClose();
            }));
        }

        private DispatcherTimer TimerLoginSuccess = new DispatcherTimer();

        private static bool bFirstLogin { get; set; } = true;
        public int iTransitionerIndex { get; set; } = 0;
        public CfgLogin loginCfg { get; set; } = new CfgLogin();
        public void ShowSetting()
        {
            iTransitionerIndex = 1;
        }

        public void TestServer()
        {
            if(CheckIp())
            {
                CLNTClient.Init(loginCfg.ServerIp);
                NormalMessageQueue.Enqueue("正在尝试连接服务器");
            }
        }

        public SnackbarMessageQueue NormalMessageQueue { get; set; } = new SnackbarMessageQueue();

        public void ConnRes(RES_STATE state)
        {
            switch(state)
            {
                case RES_STATE.OK:
                    NormalMessageQueue.Enqueue("已成功连接到服务器");
                    break;
                default:
                    break;
            }
        }

        public void LoginRes(RES_STATE state)
        {
            switch(state)
            {
                case RES_STATE.OK:
                    LoginSuccess();
                    NormalMessageQueue.Enqueue("登录成功");
                    break;
                case RES_STATE.FAILED:
                    NormalMessageQueue.Enqueue("用户名或密码错误");
                    break;
                default:
                    break;
            }
        }

        public void LoginSuccess()
        {
            bFirstLogin = false;
            Cfg.SaveLogin(loginCfg); 
            TimerLoginSuccess.Interval = new TimeSpan(0, 0, 0, 3);
            TimerLoginSuccess.Start();
        }

        public void SettingDone()
        {
            if (CheckIp())
            {
                iTransitionerIndex = 0; 
                Cfg.SaveLogin(loginCfg);
            }
        }

        public void ExitLogin()
        {
            this.RequestClose();
        }

        private void InitWidgetFromCfg()
        {
            loginCfg = Cfg.GetLogin();
        }

        public void StartLogin()
        {
            CLNTAPI.Login(loginCfg.UserName, loginCfg.UserPwd);
        }

        private bool CheckIp()
        {
            if(loginCfg.ServerIp == "")
            {
                NormalMessageQueue.Enqueue("IP地址不能为空");
                return false;
            }
            try
            {
                IPAddress.Parse(loginCfg.ServerIp);
            }
            catch
            {
                NormalMessageQueue.Enqueue("无效的IP地址");
                return false;
            }
            return true;
        }
    }
}
