using Stylet;

namespace GRCLNT
{
    class PageGwDynaViewModel : Screen
    {
        public PageGwDynaViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.GwDyna);
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
