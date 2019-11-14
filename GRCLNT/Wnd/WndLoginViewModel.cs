﻿using System;
using Stylet;
using GRCLNT;


namespace GRCLNT.Wnd
{
    public class WndLoginViewModel : Screen
    {
        public WndLoginViewModel()
        {
            Cfg.Init();
            InitWidgetFromCfg();
        }
        public int iTransitionerIndex { get; set; } = 0;
        public CfgLogin loginCfg { get; set; } = new CfgLogin();
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

        private void InitWidgetFromCfg()
        {
            loginCfg = Cfg.GetLogin();
        }

        public void StartLogin()
        {
            Cfg.SaveLogin(loginCfg);
        }

        public void RecordPwdChange()
        {
            if (!loginCfg.RecordPwd)
            {
                loginCfg.AutoLogin = false;
            }
            Cfg.SaveLogin(loginCfg);
            InitWidgetFromCfg();
        }

        public void AutoLoginChange()
        {
            if (loginCfg.AutoLogin)
            {
                loginCfg.RecordPwd = true; 
            }
            Cfg.SaveLogin(loginCfg);
            InitWidgetFromCfg();
        }
    }
}
