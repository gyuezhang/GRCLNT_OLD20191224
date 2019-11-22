using MaterialDesignThemes.Wpf;
using Stylet;
using System.Collections.Generic;
using System.Windows;

namespace GRCLNT
{
    class CtrlAddrBarViewModel : Screen
    {
        public CtrlAddrBarViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM; 
            UpdateList(EnumPage.Home_Dashboard);
        }
        private WndMainViewModel wndMainVM { get; set; }

        public List<AddrBarItem> items { get; set; } = new List<AddrBarItem>();

        public void UpdateList(EnumPage id)
        {
            items.Clear();
            switch (id)
            {
                case EnumPage.Home:
                    items.Add(new AddrBarItem(EnumPage.Home));
                    break;
                case EnumPage.Home_Dashboard:
                    items.Add(new AddrBarItem(EnumPage.Home));
                    items.Add(new AddrBarItem(EnumPage.Home_Dashboard));
                    break;
                case EnumPage.Home_UsrInfo:
                    items.Add(new AddrBarItem(EnumPage.Home));
                    items.Add(new AddrBarItem(EnumPage.Home_UsrInfo));
                    break;
                case EnumPage.Home_UsrInfo_ChangeInfo:
                    items.Add(new AddrBarItem(EnumPage.Home));
                    items.Add(new AddrBarItem(EnumPage.Home_UsrInfo));
                    items.Add(new AddrBarItem(EnumPage.Home_UsrInfo_ChangeInfo));
                    break;
                case EnumPage.Home_UsrInfo_ChangPwd:
                    items.Add(new AddrBarItem(EnumPage.Home));
                    items.Add(new AddrBarItem(EnumPage.Home_UsrInfo));
                    items.Add(new AddrBarItem(EnumPage.Home_UsrInfo_ChangPwd));
                    break;
                case EnumPage.Well:
                    break;
                case EnumPage.Well_AddMtdSel:
                    break;
                case EnumPage.Well_AddEdit:
                    break;
                case EnumPage.Well_AddAuto:
                    break;
                case EnumPage.Well_Search:
                    break;
                case EnumPage.Well_State:
                    break;
                case EnumPage.Well_Output:
                    break;
                case EnumPage.Well_Setting:
                    break;
                case EnumPage.EntWell:
                    break;
                case EnumPage.SediCtrl:
                    break;
                case EnumPage.GwDyna:
                    break;
                case EnumPage.GwProj:
                    break;
                case EnumPage.Hydro:
                    break;
                case EnumPage.Law:
                    break;
                case EnumPage.Setting:
                    break;
                default:
                    break;
            }
            items[items.Count - 1].vHasChild = Visibility.Collapsed;
        }
    }
}
