using Stylet;

namespace GRCLNT
{
    class PageSediCtrlViewModel : Screen
    {
        public PageSediCtrlViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.SediCtrl);
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
