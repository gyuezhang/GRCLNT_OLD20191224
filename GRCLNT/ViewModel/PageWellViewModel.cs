using Models;
using Socket;
using Stylet;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using Util;
using BruTile.Predefined;
using Mapsui.Layers;
using Mapsui.UI.Wpf;
using Mapsui.Geometries;
using Mapsui.Projection;
using Mapsui.Providers;
using System.Linq;
using Mapsui.Styles;
using System.Reflection;
using System.Windows.Controls;
using LiveCharts.Wpf;
using LiveCharts;
using LiveCharts.Defaults;
using System.Windows.Media;
using Microsoft.WindowsAPICodePack.Dialogs;

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
            CLNTResHandler.changeWell += CLNTResHandler_changeWell;
            CLNTResHandler.getWellParas += CLNTResHandler_getWellParas;
            CLNTResHandler.setWellParas += CLNTResHandler_setWellParas;
            ExcelOper.readWell += ExcelOper_readWell;

            CLNTAPI.GetWellParas();

            InitMap();
            InitOutputLst();
            
        }

        private void CLNTResHandler_setWellParas(RES_STATE state)
        {
            switch (state)
            {
                case RES_STATE.OK:
                    wndMainVM.mainMessageQueue.Enqueue("参数设置成功");
                    break;
                case RES_STATE.FAILED:
                    wndMainVM.mainMessageQueue.Enqueue("参数设置失败");
                    break;
                default:
                    break;
            }
        }

        private void CLNTResHandler_getWellParas(RES_STATE state, WellParas paras)
        {
            wellParas = paras;
        }

        public void InitOutputLst()
        {
            WellOutPut wop1 = new WellOutPut();
            wop1.Name = "封皮";
            wop1.Des = "封皮";
            WellOutPut wop2 = new WellOutPut();
            wop2.Name = "编制单位";
            wop2.Des = "编制单位";
            WellOutPut wop3 = new WellOutPut();
            wop3.Name = "目录";
            wop3.Des = "目录";
            WellOutPut wop4 = new WellOutPut();
            wop4.Name = "观测井分布图";
            wop4.Des = "观测井分布图";
            WellOutPut wop5 = new WellOutPut();
            wop5.Name = "监测井情况表";
            wop5.Des = "监测井情况表";
            WellOutPut wop6 = new WellOutPut();
            wop6.Name = "整编";
            wop6.Des = "整编";
            WellOutPut wop7 = new WellOutPut();
            wop7.Name = "监测井情况表";
            wop7.Des = "监测井情况表";
            WellOutPut wop8 = new WellOutPut();
            wop8.Name = "水位分布图";
            wop8.Des = "水位分布图";
            WellOutPut wop9 = new WellOutPut();
            wop9.Name = "宝坻自动监测井";
            wop9.Des = "宝坻自动监测井";
            WellOutPut wop10 = new WellOutPut();
            wop10.Name = "年特征统计表";
            wop10.Des = "年特征统计表";
            WellOutPut wop11 = new WellOutPut();
            wop11.Name = "平均水位表";
            wop11.Des = "平均水位表";
            WellOutPut wop12 = new WellOutPut();
            wop12.Name = "统测";
            wop12.Des = "统测";
            WellOutPut wop13 = new WellOutPut();
            wop13.Name = "检测情况表";
            wop13.Des = "检测情况表";
            WellOutPut wop14 = new WellOutPut();
            wop14.Name = "灌溉井开采量表";
            wop14.Des = "灌溉井开采量表";
            WellOutPut wop15 = new WellOutPut();
            wop15.Name = "实开农业机井";
            wop15.Des = "实开农业机井";
            WellOutPut wop16 = new WellOutPut();
            wop16.Name = "灌溉井开采量表";
            wop16.Des = "灌溉井开采量表";
            WellOutPut wop17 = new WellOutPut();
            wop17.Name = "灌溉井开采量总表";
            wop17.Des = "灌溉井开采量总表";
            WellOutPut wop18 = new WellOutPut();
            wop18.Name = "总开采量";
            wop18.Des = "总开采量";
            WellOutPut wop19 = new WellOutPut();
            wop19.Name = "生活农业开采量表";
            wop19.Des = "生活农业开采量表";
            WellOutPut wop20 = new WellOutPut();
            wop20.Name = "城镇机井开采量调查表";
            wop20.Des = "城镇机井开采量调查表";
            WellOutPut wop21 = new WellOutPut();
            wop21.Name = "开采量总表";
            wop21.Des = "封开采量总表皮";
            WellOutPut wop22 = new WellOutPut();
            wop22.Name = "镇街开采量";
            wop22.Des = "镇街开采量";
            WellOutPut wop23 = new WellOutPut();
            wop23.Name = "气象资料";
            wop23.Des = "气象资料";
            WellOutPut wop24 = new WellOutPut();
            wop24.Name = "动态曲线图";
            wop24.Des = "动态曲线图";
            WellOutPut wop25 = new WellOutPut();
            wop25.Name = "开采量统计图";
            wop25.Des = "开采量统计图";
            outPutItems.Add(wop1);
            outPutItems.Add(wop2);
            outPutItems.Add(wop3);
            outPutItems.Add(wop4);
            outPutItems.Add(wop5);
            outPutItems.Add(wop6);
            outPutItems.Add(wop7);
            outPutItems.Add(wop8);
            outPutItems.Add(wop9);
            outPutItems.Add(wop10);
            outPutItems.Add(wop11);
            outPutItems.Add(wop12);
            outPutItems.Add(wop13);
            outPutItems.Add(wop14);
            outPutItems.Add(wop15);
            outPutItems.Add(wop16);
            outPutItems.Add(wop17);
            outPutItems.Add(wop18);
            outPutItems.Add(wop19);
            outPutItems.Add(wop20);
            outPutItems.Add(wop21);
            outPutItems.Add(wop22);
            outPutItems.Add(wop23);
            outPutItems.Add(wop24);
            outPutItems.Add(wop25);
        }

        public MapControl map { get; set; } = new MapControl();

        public WellParas wellParas { get; set; } = new WellParas();
        public UserControl curChart { get; set; } = new UserControl();

        public void OnStartOutPut()
        {

           
        }

        public bool CanOnStartOutPut => (outputDirectory != null);


        public void OnSelectDirectoryToOutput()
        {

            var dlg = new CommonOpenFileDialog();
            dlg.Title = "My Title";
            dlg.IsFolderPicker = true;
            // dlg.InitialDirectory = currentDirectory;

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;
            // dlg.DefaultDirectory = currentDirectory;
            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                outputDirectory = dlg.FileName;
                // Do something with selected folder string
            }
        }

        public string outputDirectory { get; set; }
        public void RefreshState()
        {
            curChart = new CartesianChart();
            SeriesCollection sc = new SeriesCollection();
            sc = new SeriesCollection
            {
                new LineSeries
                {
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(1233),
                        new ObservableValue(513),
                        new ObservableValue(224),
                        new ObservableValue(741),
                        new ObservableValue(745),
                        new ObservableValue(333),
                        new ObservableValue(152),
                        new ObservableValue(267),
                        new ObservableValue(743),
                        new ObservableValue(173),
                        new ObservableValue(683),
                        new ObservableValue(356),
                        new ObservableValue(1321),
                        new ObservableValue(725),
                        new ObservableValue(746),
                        new ObservableValue(343),
                        new ObservableValue(115),
                        new ObservableValue(245),
                        new ObservableValue(711),
                        new ObservableValue(147),
                        new ObservableValue(746),
                        new ObservableValue(343),
                        new ObservableValue(115),
                        new ObservableValue(514)
                    },
                    PointGeometrySize = 10,
                    StrokeThickness = 4,
                    Fill = Brushes.Transparent
                },
            };
            List<string> lbs = new List<string>();

            ((CartesianChart)curChart).Series = sc;
            Axis x = new Axis();
            x.Title = "乡镇街道";
            x.Labels = lbs;
            lbs.Add("宝平街道");
            lbs.Add("钰华街道");
            lbs.Add("口东街道");
            lbs.Add("朝霞街道");
            lbs.Add("潮阳街道");
            lbs.Add("海滨街道");
            lbs.Add("八门城镇");
            lbs.Add("大白庄镇");
            lbs.Add("大口屯镇");
            lbs.Add("大唐庄镇");
            lbs.Add("大钟庄镇");
            lbs.Add("尔王庄镇");
            lbs.Add("方家庄镇");
            lbs.Add("郝各庄镇");
            lbs.Add("黄庄镇"  );
            lbs.Add("霍各庄镇");
            lbs.Add("林亭口镇");
            lbs.Add("牛道口镇");
            lbs.Add("牛家牌镇");
            lbs.Add("史各庄镇");
            lbs.Add("王卜庄镇");
            lbs.Add("新安镇"  );
            lbs.Add("新开口镇");
            lbs.Add("周良庄镇");
            Axis y = new Axis();
            y.Title = "机井数量";
            ((CartesianChart)curChart).AxisX.Add(x);
            ((CartesianChart)curChart).AxisY.Add(y);
        }
        public void InitMap()
        {
            map.Map.Layers.Add(new TileLayer(KnownTileSources.Create()));
            map.Map.Layers.Add(CreateWellLayer());

            var centerOfBD = new Mapsui.Geometries.Point(117.309716, 39.717173);
            var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(centerOfBD.X, centerOfBD.Y);
            map.Map.Home = n => n.NavigateTo(sphericalMercatorCoordinate, map.Map.Resolutions[12]);

        }

        
        private MemoryLayer CreateWellLayer()
        {
            //return new MemoryLayer
            //{
            //    Name = "Points",
            //    IsMapInfoLayer = true,
            //    DataSource = new MemoryProvider(GetCitiesFromEmbeddedResource()),
            //    Style = CreateBitmapStyle()
            //};
            MemoryLayer ml = new MemoryLayer();
            ml.Name = "Point";
            ml.IsMapInfoLayer = true;
            MemoryProvider mp = new MemoryProvider(GetCitiesFromEmbeddedResource());
            ml.DataSource = mp;
            ml.Style = CreateBitmapStyle();
            return ml;
        }
        private SymbolStyle CreateBitmapStyle()
        {
            // For this sample we get the bitmap from an embedded resouce
            // but you could get the data stream from the web or anywhere
            // else.

            var path = @"GRCLNT.View.Resource.Image.well.png";
            var bitmapId = GetBitmapIdForEmbeddedResource(path);
            var bitmapHeight = 64; // To set the offset correct we need to know the bitmap height
            return new SymbolStyle { BitmapId = bitmapId, SymbolScale = 0.20, SymbolOffset = new Offset(0, bitmapHeight * 0.5) };
        }
        private static int GetBitmapIdForEmbeddedResource(string imagePath)
        {
            var assembly = typeof(PageWellViewModel).GetTypeInfo().Assembly;
            var image = assembly.GetManifestResourceStream(imagePath);
            return BitmapRegistry.Instance.Register(image);
        }
        private IEnumerable<IFeature> GetCitiesFromEmbeddedResource()
        {

            return curWells.Select(c =>
            {
                var feature = new Feature();
                if(c.Lng !="" && c.Lat != "")
                {
                    var point = SphericalMercator.FromLonLat(double.Parse(c.Lng), double.Parse(c.Lat));
                    feature.Geometry = point;
                }
                return feature;
            });

            //IEnumerable<IFeature> res = new IEnumerable<IFeature>();
        }
        private void ExcelOper_readWell(bool state, int curIndex, int totalCount, List<Well> wells)
        {
            if(state)
            {
                if(curIndex == totalCount)
                {
                    vInputing = Visibility.Collapsed;
                    txtInputing = "共" + totalCount.ToString() + "条记录，读取完成";

                    autoCreateWells = wells;
                    ThreadStart childref = new ThreadStart(ThreadCreateWellsFromFile);
                    Thread childThread = new Thread(childref);
                    childThread.Start();
                    return;
                }
                vInputing = Visibility.Visible;
                valueInputing = curIndex / totalCount * 100;
                txtInputing = "当前第"+ curIndex.ToString() + "条 / 共" + totalCount.ToString()+"条记录";
            }
            else
            {

            }
        }
        public static List<Well> autoCreateWells { get; set; }
        public void ThreadCreateWellsFromFile()
        {
            vInputing = Visibility.Visible;

            List<Well> tmp = new List<Well>();
            int i = 0;
            foreach (Well well in autoCreateWells)
            {
                ++i;
                tmp.Clear();
                tmp.Add(well);
                CLNTAPI.CreateWell(tmp);
                Thread.Sleep(100);
                valueInputing = Convert.ToInt32((float)i / (float)autoCreateWells.Count *100.0);
                txtInputing = "当前第" + i.ToString() + "条 / 共" + autoCreateWells.Count.ToString() + "条记录";

            }
            vInputing = Visibility.Collapsed;

        }


        public Visibility vInputing { get; set; } = Visibility.Collapsed;
        public int valueInputing { get; set; } = 0;
        public string txtInputing { get; set; } = "";
        private void CLNTResHandler_changeWell(RES_STATE state)
        {
            switch (state)
            {
                case RES_STATE.OK:
                    wndMainVM.mainMessageQueue.Enqueue("编辑机井成功");
                    OnShowPage("6");
                    break;
                case RES_STATE.FAILED:
                    wndMainVM.mainMessageQueue.Enqueue("编辑机井失败");
                    break;
                default:
                    break;
            }
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
            OnShowPage("10");
            editWell = curSelectWell;
        }

        public void OnEditWellOK()
        {
            CLNTAPI.ChangeWell(editWell);
        }

        public void OnEditWellCancel()
        {
            OnShowPage("6");
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
                    wndMainVM.UpdateAddr(EnumPage.Well_AddManual);
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
                    InitMap();
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
                case 10:
                    wndMainVM.UpdateAddr(EnumPage.Well_Edit);
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
            ExcelOper.ReadWellsFromFile(inputFilePath);
        }


        public void OnOpenAutoInputTemplate()
        {
            ExcelOper.OpenInputTemplete();
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
        public Well editWell { get; set; } = new Well();
        public void RefreshWells(string filter)
        {
            CLNTAPI.GetWellByFilter(filter);
        }

        //
        public List<WellOutPut> outPutItems { get; set; } = new List<WellOutPut>();
    }
}
