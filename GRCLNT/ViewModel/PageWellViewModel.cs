using Models;
using Socket;
using Stylet;
using System.Collections.Generic;

namespace GRCLNT
{
    class PageWellViewModel : Screen
    {
        public PageWellViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.Well);
            czoning = RTData.zoning;
            if(czoning.allLevel4Nodes.Count>0)
                czoning.curlevel4Node = czoning.allLevel4Nodes[0];
            CLNTResHandler.createWell += CLNTResHandler_createWell;
            CLNTResHandler.getWellByFilter += CLNTResHandler_getWellByFilter;
            CLNTResHandler.deleteWell += CLNTResHandler_deleteWell;
        }

        private void CLNTResHandler_deleteWell(RES_STATE state)
        {
            switch (state)
            {
                case RES_STATE.OK:
                    wndMainVM.mainMessageQueue.Enqueue("删除机井成功");
                    RefreshWells("");
                    break;
                case RES_STATE.FAILED:
                    wndMainVM.mainMessageQueue.Enqueue("删除机井失败");
                    break;
                default:
                    break;
            }
        }

        public List<Well> curWells { get; set; } = new List<Well>();
        public Well curSelectWell { get; set; }

        public void OnEditWell()
        {
            Well a = curSelectWell;
        }
        public bool CanOnEditWell => (curSelectWell!=null);
        public void OnDeleteWell()
        {
            CLNTAPI.DeleteWell(curSelectWell.Id);
        }
        public bool CanOnDeleteWell => (curSelectWell != null);
        private void CLNTResHandler_getWellByFilter(RES_STATE state, List<Well> wells)
        {
            switch (state)
            {
                case RES_STATE.OK:
                    curWells = wells;
                    break;
                case RES_STATE.FAILED:
                    wndMainVM.mainMessageQueue.Enqueue("获取机井失败");
                    break;
                default:
                    break;
            }
        }

        private void CLNTResHandler_createWell(RES_STATE state)
        {
            switch (state)
            {
                case RES_STATE.OK:
                    wndMainVM.mainMessageQueue.Enqueue("创建机井成功");
                    break;
                case RES_STATE.FAILED:
                    wndMainVM.mainMessageQueue.Enqueue("创建机井失败");
                    break;
                default:
                    break;
            }

        }

        private WndMainViewModel wndMainVM { get; set; }
        public int iPageIndex { get; set; } = 0;

        public BDZoning czoning { get; set; } 
        public void Onlevel4Changed()
        {

        }
        public void OnShowPage(string i)
        {
            iPageIndex = int.Parse(i);
            switch(iPageIndex)
            {
                case 0:
                    wndMainVM.UpdateAddr(EnumPage.Well);
                    break;
                case 1:
                    wndMainVM.UpdateAddr(EnumPage.Well_AddMtdSel);
                    break;
                case 2:
                    wndMainVM.UpdateAddr(EnumPage.Well_AddEdit);
                    createWell= new Well();
                    break;
                case 3:
                    inputFilePath = "";
                    wndMainVM.UpdateAddr(EnumPage.Well_AddAuto);
                    break;
                case 4:
                    wndMainVM.UpdateAddr(EnumPage.Well_Search);
                    break;
                case 5:
                    wndMainVM.UpdateAddr(EnumPage.Well_Search_Loc);
                    break;
                case 6:
                    wndMainVM.UpdateAddr(EnumPage.Well_Search_Lst);
                    RefreshWells("");
                    break;
                case 7:
                    wndMainVM.UpdateAddr(EnumPage.Well_State);
                    break;
                case 8:
                    wndMainVM.UpdateAddr(EnumPage.Well_Output);
                    break;
                case 9:
                    wndMainVM.UpdateAddr(EnumPage.Well_Setting);
                    break;
                default:
                    break;
            }
        }

        public string inputFilePath { get; set; }

        public void OnOpenDlgToAutoInput()
        {
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
            ofd.DefaultExt = ".xlsx";
            ofd.Filter = "Excel文件|*.xlsx;*.xls";
            if (ofd.ShowDialog() == true)
            {
                //此处做你想做的事 ...=ofd.FileName; 
                inputFilePath = ofd.FileName;
            }

        }

        public void OnStartAutoInput()
        {

        }


        public void OnOpenAutoInputTemplate()
        {

        }

        public void OnCreateWell()
        {
            List<Well> wells = new List<Well>();
            createWell.TsOrSt = czoning.curlevel4Node.name;
            createWell.Village = czoning.curlevel5Node.name;
            wells.Add(createWell);
            CLNTAPI.CreateWell(wells);
        }

        public Well createWell { get; set; } = new Well();

        public void RefreshWells(string filter)
        {
            CLNTAPI.GetWellByFilter(filter);
        }
    }
}
