using Stylet;

namespace GRCLNT
{
    class PageGwProjViewModel : Screen
    {
        public PageGwProjViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
