using Stylet;

namespace GRCLNT
{
    class PageWellViewModel : Screen
    {
        public PageWellViewModel(WndMainViewModel _wndMainVM)
        {
            wndMainVM = _wndMainVM;
            wndMainVM.UpdateAddr(EnumPage.Well);
        }
        private WndMainViewModel wndMainVM { get; set; }
        public int iPageIndex { get; set; } = 0;

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
                    break;
                case 3:
                    inputFilePath = "";
                    wndMainVM.UpdateAddr(EnumPage.Well_AddAuto);
                    break;
                case 4:
                    wndMainVM.UpdateAddr(EnumPage.Well_Search);
                    break;
                case 5:
                    wndMainVM.UpdateAddr(EnumPage.Well_State);
                    break;
                case 6:
                    wndMainVM.UpdateAddr(EnumPage.Well_Output);
                    break;
                case 7:
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

    }
}
