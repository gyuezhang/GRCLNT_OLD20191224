using Stylet;

namespace GRCLNT
{
    class PageGwDynaViewModel : Screen
    {
        public PageGwDynaViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
