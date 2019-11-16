using System;
using Stylet;
using GRCLNT;
using GRCLNT.Socket;
using MaterialDesignThemes.Wpf;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using GRCLNT.Pages;

namespace GRCLNT.Wnd
{
    public class WndMainViewModel : Screen
    {
        private IWindowManager windowManager;
        public WndMainViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
            dbMaxHeight = SystemParameters.WorkArea.Height + 7;
            dbMaxWidth = SystemParameters.WorkArea.Width + 7;
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

            vImageDragVisible = (CurWindowState != WindowState.Maximized)? Visibility.Visible:Visibility.Hidden;
        }

        public void MenuClick(string index)
        {
            int iIndex = int.Parse(index);
            vSettingFocus = Visibility.Hidden;
            vMenuFocus = Visibility.Visible;
            switch (iIndex)
            {
                case 1:
                    iBdFocus = 1;
                    curPage = new PageHomePageViewModel();
                    break;
                case 2:
                    iBdFocus = 3;
                    curPage = new PageWellViewModel();
                    break;
                case 3:
                    iBdFocus = 5;
                    curPage = new PageEntWellViewModel();
                    break;
                case 4:
                    iBdFocus = 7;
                    curPage = new PageSediCtrlViewModel();
                    break;
                case 5:
                    iBdFocus = 9;
                    curPage = new PageGwDynaViewModel();
                    break;
                case 6:
                    iBdFocus = 11;
                    curPage = new PageGwProjViewModel();
                    break;
                case 7:
                    iBdFocus = 13;
                    curPage = new PageHydroViewModel();
                    break;
                case 8:
                    iBdFocus = 15;
                    curPage = new PageLawViewModel();
                    break;
                case 9:
                    vSettingFocus = Visibility.Visible;
                    vMenuFocus = Visibility.Hidden;
                    curPage = new PageSettingViewModel();
                    break;
                default:
                    break;
            }
        }

        public int iBdFocus { get; set; } = 1;
        public Visibility vSettingFocus { get; set; } = Visibility.Hidden;

        public Visibility vMenuFocus { get; set; } = Visibility.Visible;

        public Screen curPage { get; set; } = new PageHomePageViewModel();
    }
}
