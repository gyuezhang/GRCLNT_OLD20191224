using Stylet;

namespace GRCLNT
{
    class PageWellViewModel : Screen
    {
        public PageWellViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
