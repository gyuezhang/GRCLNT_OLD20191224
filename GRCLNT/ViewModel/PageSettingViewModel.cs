using Models;
using Stylet;

namespace GRCLNT
{
    class PageSettingViewModel : Screen
    {
        public PageSettingViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.Setting);
        }
        private WndMainViewModel wndMainVM { get; set; }

    }
}
