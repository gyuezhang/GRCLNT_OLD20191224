using Stylet;

namespace GRCLNT
{
    class PageEntWellViewModel : Screen
    {
        public PageEntWellViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
