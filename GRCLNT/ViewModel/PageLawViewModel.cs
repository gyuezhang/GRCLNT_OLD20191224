using Stylet;

namespace GRCLNT
{
    class PageLawViewModel : Screen
    {
        public PageLawViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
