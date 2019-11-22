using Stylet;

namespace GRCLNT
{
    class PageLawViewModel : Screen
    {
        public PageLawViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.Law);
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
