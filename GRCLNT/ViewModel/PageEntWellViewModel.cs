using Stylet;

namespace GRCLNT
{
    class PageEntWellViewModel : Screen
    {
        public PageEntWellViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.EntWell);
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
