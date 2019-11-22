using MaterialDesignThemes.Wpf;
using Models;
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
    }
}
