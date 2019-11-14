using System;
using Stylet;
using GRCLNT;
using GRCLNT.Socket;
using MaterialDesignThemes.Wpf;
using System.Net;

namespace GRCLNT.Wnd
{
    public class WndMainViewModel : Screen
    {
        private IWindowManager windowManager;
        public WndMainViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager;
        }
    }
}
