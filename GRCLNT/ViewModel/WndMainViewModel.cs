using Stylet;
using System;
using System.Windows;

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

        public void OnLogOut()
        {
            App.Current.Dispatcher.Invoke((Action)(() =>
            {
                var wndLoginViewModel = new WndLoginViewModel(_windowManager);
                this._windowManager.ShowWindow(wndLoginViewModel);
                RequestClose();
            }));

        }
    }
}
