using MaterialDesignThemes.Wpf;
using Models;
using Socket;
using Stylet;
using System;
using System.Windows;
using System.Windows.Threading;

namespace GRCLNT
{
    class WndMainViewModel : Screen
    {
        private IWindowManager _windowManager;

        public WndMainViewModel(IWindowManager windowManager)
        {
            _windowManager = windowManager;
            dbMaxHeight = SystemParameters.WorkArea.Height + 7;
            dbMaxWidth = SystemParameters.WorkArea.Width + 7;
            curPage = new PageHomeViewModel(this);
            ((PageHomeViewModel)curPage).OnShowDashboard();

            addrsBar = new CtrlAddrBarViewModel(this);
            UpdateAddr(EnumPage.Home_Dashboard);

            CLNTAPI.GetLevelZones(4);
            CLNTAPI.GetLevelZones(5);

            CLNTResHandler.getLevelZones += CLNTResHandler_getLevelZones;

        }

        private void CLNTResHandler_getLevelZones(RES_STATE state, System.Collections.Generic.List<ZoningNode> nodes)
        {
            if (state == RES_STATE.FAILED)
            {
                mainMessageQueue.Enqueue("获取区划信息失败");
                return;
            }

            if (nodes.Count == 0)
                return;
            int iLevel = nodes[0].level;
            if (iLevel == 4)
                RTData.zoning.InitLevel4Nodes(nodes);
            if (iLevel == 5)
                RTData.zoning.InitLevel5Nodes(nodes);

        }

        public WndMainViewModel()
        {

        }
        public WindowState CurWindowState { get; set; }
        public double dbMaxHeight { get; set; } = SystemParameters.WorkArea.Height + 7;
        public double dbMaxWidth { get; set; } = SystemParameters.WorkArea.Width + 7;

        public Thickness bdMargin { get; set; } = new Thickness(0, 0, 0, 0);
        public Visibility vImageDragVisible { get; set; } = Visibility.Visible;

        public void OnStateChanged()
        {
            //重置最大窗口尺寸（此处避免运行过程中任务栏显隐）
            dbMaxHeight = SystemParameters.WorkArea.Height + 7;
            dbMaxWidth = SystemParameters.WorkArea.Width + 7;
            bdMargin = (CurWindowState == WindowState.Maximized) ? new Thickness(7, 7, 0, 0) : new Thickness(0, 0, 0, 0);

            vImageDragVisible = (CurWindowState != WindowState.Maximized) ? Visibility.Visible : Visibility.Hidden;
        }

        public string strAvaLetter { get; set; } = RTData.loginSuccessUserInfo.Name.Substring(0, 1).ToUpper();
        public void OnLogOut()
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                var wndLoginViewModel = new WndLoginViewModel(_windowManager);
                this._windowManager.ShowWindow(wndLoginViewModel);
                RequestClose();
            }));

        }

        public void OnOpenUsrInfo()
        {

        }

        public void OnChangePage(string strIndex)
        {
            int iIndex = int.Parse(strIndex);
            vSettingFocus = Visibility.Hidden;
            vMenuFocus = Visibility.Visible;
            switch (iIndex)
            {
                case 1:
                    iBdFocus = 1;
                    curPage = new PageHomeViewModel(this);
                    break;
                case 2:
                    iBdFocus = 3;
                    curPage = new PageWellViewModel(this);
                    break;
                case 3:
                    iBdFocus = 5;
                    curPage = new PageEntWellViewModel(this);
                    break;
                case 4:
                    iBdFocus = 7;
                    curPage = new PageSediCtrlViewModel(this);
                    break;
                case 5:
                    iBdFocus = 9;
                    curPage = new PageGwDynaViewModel(this);
                    break;
                case 6:
                    iBdFocus = 11;
                    curPage = new PageGwProjViewModel(this);
                    break;
                case 7:
                    iBdFocus = 13;
                    curPage = new PageHydroViewModel(this);
                    break;
                case 8:
                    iBdFocus = 15;
                    curPage = new PageLawViewModel(this);
                    break;
                case 9:
                    vSettingFocus = Visibility.Visible;
                    vMenuFocus = Visibility.Hidden;
                    curPage = new PageSettingViewModel(this);
                    break;
                default:
                    break;
            }
        }
        public int iBdFocus { get; set; } = 1;
        public Visibility vSettingFocus { get; set; } = Visibility.Hidden;

        public Visibility vMenuFocus { get; set; } = Visibility.Visible;

        public Screen curPage { get; set; }

        public CtrlAddrBarViewModel addrsBar { get; set; }

        public void OnLogout()
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                var wndLoginViewModel = new WndLoginViewModel(_windowManager);
                this._windowManager.ShowWindow(wndLoginViewModel);
                this.RequestClose();
            }));
        }

        public void OnExit()
        {
            this.RequestClose();
        }

        public SnackbarMessageQueue mainMessageQueue { get; set; } = new SnackbarMessageQueue(TimeSpan.FromSeconds(1.2));

        public void UpdateAddr(EnumPage id)
        {
            try
            {
                addrsBar = new CtrlAddrBarViewModel(this);
                addrsBar.UpdateList(id);
            }
            catch
            {

            }
        }

        public void UpdatePages(EnumPage id)
        {
            switch(id)
            {
                case EnumPage.Home:
                    ((PageHomeViewModel)curPage).ShowHome();
                    return;
                case EnumPage.Home_Dashboard:
                    ((PageHomeViewModel)curPage).OnShowDashboard();
                    return ;
                case EnumPage.Home_UsrInfo:
                    ((PageHomeViewModel)curPage).OnShowUserInfo();
                    return ;
                case EnumPage.Home_UsrInfo_ChangeInfo:
                    ((PageHomeViewModel)curPage).OnChangeInfo();
                    return ;
                case EnumPage.Home_UsrInfo_ChangPwd:
                    ((PageHomeViewModel)curPage).OnChangePwd();
                    return;
                case EnumPage.Well:
                    ((PageWellViewModel)curPage).OnShowPage("0");
                    return;
                case EnumPage.Well_AddMtdSel:
                    ((PageWellViewModel)curPage).OnShowPage("1");
                    return ;
                case EnumPage.Well_AddManual:
                    ((PageWellViewModel)curPage).OnShowPage("2");
                    return ;
                case EnumPage.Well_AddAuto:
                    ((PageWellViewModel)curPage).OnShowPage("3");
                    return ;
                case EnumPage.Well_Search:
                    ((PageWellViewModel)curPage).OnShowPage("4");
                    return;
                case EnumPage.Well_Search_Loc:
                    ((PageWellViewModel)curPage).OnShowPage("5");
                    return;
                case EnumPage.Well_Search_Lst:
                    ((PageWellViewModel)curPage).OnShowPage("6");
                    return;
                case EnumPage.Well_State:
                    ((PageWellViewModel)curPage).OnShowPage("7");
                    return ;
                case EnumPage.Well_Output:
                    ((PageWellViewModel)curPage).OnShowPage("8");
                    return ;
                case EnumPage.Well_Setting:
                    ((PageWellViewModel)curPage).OnShowPage("9");
                    return ;
                case EnumPage.EntWell:
                    return ;
                case EnumPage.SediCtrl:
                    return ;
                case EnumPage.GwDyna:
                    return ;
                case EnumPage.GwProj:
                    return ;
                case EnumPage.Hydro:
                    return ;
                case EnumPage.Law:
                    return ;
                case EnumPage.Setting:
                    return ;
                default:
                    return ;
            }
        }
    }
}
