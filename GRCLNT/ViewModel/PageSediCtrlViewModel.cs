using Stylet;

namespace GRCLNT
{
    class PageSediCtrlViewModel : Screen
    {
        public PageSediCtrlViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
