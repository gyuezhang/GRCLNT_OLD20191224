using MaterialDesignThemes.Wpf;
using Stylet;
using System;
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
                    items.Add(new AddrBarItem(EnumPage.Well));
                    break;
                case EnumPage.Well_AddMtdSel:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_AddMtdSel));
                    break;
                case EnumPage.Well_AddManual:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_AddMtdSel));
                    items.Add(new AddrBarItem(EnumPage.Well_AddManual));
                    break;
                case EnumPage.Well_Edit:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_Edit));
                    break;
                case EnumPage.Well_AddAuto:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_AddMtdSel));
                    items.Add(new AddrBarItem(EnumPage.Well_AddAuto));
                    break;
                case EnumPage.Well_Search:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_Search));
                    break;

                case EnumPage.Well_Search_Loc:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_Search));
                    items.Add(new AddrBarItem(EnumPage.Well_Search_Loc));
                    break;
                case EnumPage.Well_Search_Lst:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_Search));
                    items.Add(new AddrBarItem(EnumPage.Well_Search_Lst));
                    break;

                case EnumPage.Well_State:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_State));
                    break;
                case EnumPage.Well_Output:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_Output));
                    break;
                case EnumPage.Well_Setting:
                    items.Add(new AddrBarItem(EnumPage.Well));
                    items.Add(new AddrBarItem(EnumPage.Well_Setting));
                    break;
                case EnumPage.EntWell:
                    items.Add(new AddrBarItem(EnumPage.EntWell));
                    break;
                case EnumPage.SediCtrl:
                    items.Add(new AddrBarItem(EnumPage.SediCtrl));
                    break;
                case EnumPage.GwDyna:
                    items.Add(new AddrBarItem(EnumPage.GwDyna));
                    break;
                case EnumPage.GwProj:
                    items.Add(new AddrBarItem(EnumPage.GwProj));
                    break;
                case EnumPage.Hydro:
                    items.Add(new AddrBarItem(EnumPage.Hydro));
                    break;
                case EnumPage.Law:
                    items.Add(new AddrBarItem(EnumPage.Law));
                    break;
                case EnumPage.Setting:
                    items.Add(new AddrBarItem(EnumPage.Setting));
                    break;
                default:
                    break;
            }
            items[items.Count - 1].vHasChild = Visibility.Collapsed;
        }

        public void OnChipClick(string pageId)
        {
            try
            {
                EnumPage id = (EnumPage)Enum.Parse(typeof(EnumPage), pageId);
                wndMainVM.UpdateAddr(id);
                wndMainVM.UpdatePages(id);
            }
            catch
            {

            }
        }
    }
}
