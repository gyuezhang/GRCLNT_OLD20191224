using Stylet;

namespace GRCLNT
{
    class PageHydroViewModel : Screen
    {
        public PageHydroViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.Hydro);
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
