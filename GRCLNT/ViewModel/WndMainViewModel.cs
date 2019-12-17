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
    public class WndMainViewModel : Screen
    {
        public WndMainViewModel(IWindowManager windowManager)
        {
            //_windowManager = windowManager;
            //dbMaxHeight = SystemParameters.WorkArea.Height + 7;
            //dbMaxWidth = SystemParameters.WorkArea.Width + 7;
            //curPage = new PageHomeViewModel(this);
            //((PageHomeViewModel)curPage).OnShowDashboard();

            ////addrsBar = new CtrlAddrBarViewModel(this);
            //UpdateAddr(EnumPage.Home_Dashboard);

            //CLNTAPI.GetLevelZones(4);
            //CLNTAPI.GetLevelZones(5);

            //CLNTResHandler.getLevelZones += CLNTResHandler_getLevelZones;

        }

    }
}
