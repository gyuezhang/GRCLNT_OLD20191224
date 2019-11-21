using Stylet;

namespace GRCLNT
{
    class PageHydroViewModel : Screen
    {
        public PageHydroViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
