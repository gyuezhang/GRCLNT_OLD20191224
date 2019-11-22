using Stylet;

namespace GRCLNT
{
    class PageGwProjViewModel : Screen
    {
        public PageGwProjViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.GwProj);
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
