using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.Threading;
using Models;

namespace Util
{
    public class ExcelOper
    {
        public static void OpenInputTemplete()
        {
            string fdp = System.Environment.CurrentDirectory + "\\Templates";
            string fp = fdp + "\\机井信息导入模板.xlsx";
            if(!File.Exists(fp))
            {
                if (!Directory.Exists(fdp))
                    Directory.CreateDirectory(fdp);
                XSSFWorkbook wb = new XSSFWorkbook();  //新建xlsx工作簿
                ISheet sheet = wb.CreateSheet("模板");

                IRow row; ICell cell; ICellStyle cStyle;

                //titie
                sheet.AddMergedRegion(new CellRangeAddress(0, 0, 0, 26));
                row = sheet.CreateRow(0);
                cell = row.CreateCell(0);
                cStyle = wb.CreateCellStyle();
                cStyle.Alignment = HorizontalAlignment.Center;
                cell.CellStyle = cStyle;
                cell.SetCellValue("机井普查统计表");

                //columns
                row = sheet.CreateRow(1);
                row.CreateCell(0).SetCellValue( "序号");
                row.CreateCell(1).SetCellValue( "所属乡镇（街道）");
                row.CreateCell(2).SetCellValue( "所属村");
                row.CreateCell(3).SetCellValue( "位置");
                row.CreateCell(4).SetCellValue( "东经");
                row.CreateCell(5).SetCellValue( "北纬");
                row.CreateCell(6).SetCellValue( "权属单位");
                row.CreateCell(7).SetCellValue( "用途");
                row.CreateCell(8).SetCellValue( "成井时间");
                row.CreateCell(9).SetCellValue( "井深（m）");
                row.CreateCell(10).SetCellValue("管材");
                row.CreateCell(11).SetCellValue("井管内径（mm）");
                row.CreateCell(12).SetCellValue("止水深度（m）");
                row.CreateCell(13).SetCellValue("咸水底板深度（m）");
                row.CreateCell(14).SetCellValue("过滤器位置（m）");
                row.CreateCell(15).SetCellValue("静水位（m）");
                row.CreateCell(16).SetCellValue("水泵型号");
                row.CreateCell(17).SetCellValue("水泵功率（kw）");
                row.CreateCell(18).SetCellValue("井控面积（亩）");
                row.CreateCell(19).SetCellValue("供水人口（人）");
                row.CreateCell(20).SetCellValue("是否为水位观测点");
                row.CreateCell(21).SetCellValue("是否安装计量设备");
                row.CreateCell(22).SetCellValue("连接机井眼数");
                row.CreateCell(23).SetCellValue("是否连接防渗渠道");
                row.CreateCell(24).SetCellValue("防渗渠道长度（km）");
                row.CreateCell(25).SetCellValue("备注");

                //data row1
                row = sheet.CreateRow(2);
                row.CreateCell(0).SetCellValue("1");
                row.CreateCell(1).SetCellValue("宝平街道");
                row.CreateCell(2).SetCellValue("石佛营");
                row.CreateCell(3).SetCellValue("村北");
                row.CreateCell(4).SetCellValue("117.259563");
                row.CreateCell(5).SetCellValue("39.705596");
                row.CreateCell(6).SetCellValue("权属单位");
                row.CreateCell(7).SetCellValue("村委会");
                row.CreateCell(8).SetCellValue("2019/1/16");
                row.CreateCell(9).SetCellValue("120");
                row.CreateCell(10).SetCellValue("钢筋混凝土");
                row.CreateCell(11).SetCellValue("273");
                row.CreateCell(12).SetCellValue("40");
                row.CreateCell(13).SetCellValue("60");
                row.CreateCell(14).SetCellValue("50-100");
                row.CreateCell(15).SetCellValue("8.2");
                row.CreateCell(16).SetCellValue("QJ200-40-81");
                row.CreateCell(17).SetCellValue("15");
                row.CreateCell(18).SetCellValue("");
                row.CreateCell(19).SetCellValue("1400");
                row.CreateCell(20).SetCellValue("");
                row.CreateCell(21).SetCellValue("是");
                row.CreateCell(22).SetCellValue("");
                row.CreateCell(23).SetCellValue("");
                row.CreateCell(24).SetCellValue("");
                row.CreateCell(25).SetCellValue("");

                //data row2
                row = sheet.CreateRow(3);
                row.CreateCell(0).SetCellValue("2");
                row.CreateCell(1).SetCellValue("王卜庄");
                row.CreateCell(2).SetCellValue("东孟");
                row.CreateCell(3).SetCellValue("村北");
                row.CreateCell(4).SetCellValue("117.265936");
                row.CreateCell(5).SetCellValue("39.695246");
                row.CreateCell(6).SetCellValue("村委会");
                row.CreateCell(7).SetCellValue("灌溉");
                row.CreateCell(8).SetCellValue("2003/3/7");
                row.CreateCell(9).SetCellValue("65");
                row.CreateCell(10).SetCellValue("水泥");
                row.CreateCell(11).SetCellValue("300");
                row.CreateCell(12).SetCellValue("100");
                row.CreateCell(13).SetCellValue("80");
                row.CreateCell(14).SetCellValue("30-120");
                row.CreateCell(15).SetCellValue("7.3");
                row.CreateCell(16).SetCellValue("QJ200-32-39");
                row.CreateCell(17).SetCellValue("5.5");
                row.CreateCell(18).SetCellValue("60");
                row.CreateCell(19).SetCellValue("");
                row.CreateCell(20).SetCellValue("是");
                row.CreateCell(21).SetCellValue("是");
                row.CreateCell(22).SetCellValue("2");
                row.CreateCell(23).SetCellValue("是");
                row.CreateCell(24).SetCellValue("0.059");
                row.CreateCell(25).SetCellValue("");

                //data row3
                row = sheet.CreateRow(4);
                row.CreateCell(0).SetCellValue("3");
                row.CreateCell(1).SetCellValue("牛道口");
                row.CreateCell(2).SetCellValue("郭家深");
                row.CreateCell(3).SetCellValue("村南");
                row.CreateCell(4).SetCellValue("117.256359");
                row.CreateCell(5).SetCellValue("39.456321");
                row.CreateCell(6).SetCellValue("村委会");
                row.CreateCell(7).SetCellValue("灌溉");
                row.CreateCell(8).SetCellValue("2015/5/28");
                row.CreateCell(9).SetCellValue("72");
                row.CreateCell(10).SetCellValue("水泥");
                row.CreateCell(11).SetCellValue("375");
                row.CreateCell(12).SetCellValue("80");
                row.CreateCell(13).SetCellValue("60");
                row.CreateCell(14).SetCellValue("40-100");
                row.CreateCell(15).SetCellValue("7.6");
                row.CreateCell(16).SetCellValue("QJ200-32-39");
                row.CreateCell(17).SetCellValue("5.5");
                row.CreateCell(18).SetCellValue("55");
                row.CreateCell(19).SetCellValue("");
                row.CreateCell(20).SetCellValue("");
                row.CreateCell(21).SetCellValue("是");
                row.CreateCell(22).SetCellValue("");
                row.CreateCell(23).SetCellValue("");
                row.CreateCell(24).SetCellValue("");
                row.CreateCell(25).SetCellValue("");
                FileStream fs = new FileStream(fp, FileMode.Create);
                wb.Write(fs);
                wb.Close();

            }
            System.Diagnostics.Process.Start(fp);

        }

        public static void ReadWellsFromFile(string path)
        {
            readWellPath = path;
            ThreadStart childref = new ThreadStart(ThreadReadWellsFromFile);
            Thread childThread = new Thread(childref);
            childThread.Start();
        }

        public static string readWellPath { get; set; }

        public static void ThreadReadWellsFromFile()
        {
            if (!File.Exists(readWellPath))
            {
                OnReadWell(false, 0,0, null);
            }

            IWorkbook wk = new XSSFWorkbook(readWellPath);
            ISheet sheet = wk.GetSheetAt(0);
            IRow row;
            List<Well> wells = new List<Well>();
            Well tempWell = new Well();
            for (int i = 2; i <= sheet.LastRowNum; i++)
            {
                row = sheet.GetRow(i);  //读取当前行数据
                if (row != null)
                {
                    try
                    {
                        tempWell = new Well();
                        if (row.GetCell(1) != null)
                            tempWell.TsOrSt = row.GetCell(1).ToString();
                        if (row.GetCell(2) != null)
                            tempWell.Village = row.GetCell(2).ToString();
                        if (row.GetCell(3) != null)
                            tempWell.Loc = row.GetCell(3).ToString();
                        if (row.GetCell(4) != null)
                        {
                            tempWell.Lng = row.GetCell(4).ToString();
                            if (double.Parse(tempWell.Lng) < 117 || double.Parse(tempWell.Lng) > 118)
                            {
                                continue;
                            }
                        }
                        else
                            continue;
                        if (row.GetCell(5) != null)
                        {
                            tempWell.Lat = row.GetCell(5).ToString();
                            if (double.Parse(tempWell.Lat) < 39 || double.Parse(tempWell.Lat) > 40)
                            {
                                continue;
                            }
                        }
                        else
                            continue;
                        if (row.GetCell(6) != null)
                            tempWell.UnitCat = row.GetCell(6).ToString();
                        if (row.GetCell(7) != null)
                            tempWell.Usefor = row.GetCell(7).ToString();
                        if (row.GetCell(8) != null)
                            tempWell.DigTime = row.GetCell(8).DateCellValue;
                        if (row.GetCell(9) != null)
                            tempWell.WellDepth = float.Parse(row.GetCell(9).ToString());
                        if (row.GetCell(10) != null)
                            tempWell.TubeMat = row.GetCell(10).ToString();
                        if (row.GetCell(11) != null)
                            tempWell.TubeIr = float.Parse(row.GetCell(11).ToString());
                        if (row.GetCell(12) != null)
                            tempWell.StanWaterDepth = float.Parse(row.GetCell(12).ToString());
                        if (row.GetCell(13) != null)
                            tempWell.SaltWaterFloorDepth = float.Parse(row.GetCell(13).ToString());
                        if (row.GetCell(14) != null)
                        {
                            string tmp = row.GetCell(14).ToString();
                            tempWell.FilterLocLow = float.Parse(tmp.Split('-')[0]);
                            tempWell.FilterLocHigh = float.Parse(tmp.Split('-')[1]);
                        }
                        if (row.GetCell(15) != null)
                            tempWell.StillWaterLoc = float.Parse(row.GetCell(15).ToString());
                        if (row.GetCell(16) != null)
                            tempWell.PumpMode = row.GetCell(16).ToString();
                        if (row.GetCell(17) != null)
                            tempWell.PumpPower = float.Parse(row.GetCell(17).ToString());
                        if (row.GetCell(18) != null)
                            tempWell.CoverArea = float.Parse(row.GetCell(18).ToString());
                        if (row.GetCell(19) != null)
                            tempWell.SupPeopleNum = int.Parse(row.GetCell(19).ToString());
                        if (row.GetCell(20) != null)
                            tempWell.IsWaterLevelOp = (row.GetCell(20).ToString() == "是");
                        if (row.GetCell(21) != null)
                            tempWell.IsMfInstalled = (row.GetCell(21).ToString() == "是");
                        if (row.GetCell(22) != null)
                            tempWell.LinkWellNo = int.Parse(row.GetCell(22).ToString());
                        if (row.GetCell(23) != null)
                            tempWell.IsSeepChnLinked = (row.GetCell(23).ToString() == "是");
                        if (row.GetCell(24) != null)
                            tempWell.SeepChnLength = float.Parse(row.GetCell(24).ToString());
                        if (row.GetCell(25) != null)
                            tempWell.Remark = row.GetCell(25).ToString();
                        wells.Add(tempWell);
                    }
                    catch
                    {
                        continue;
                    }
                }
                OnReadWell(true, i-1, sheet.LastRowNum -2, wells);
            }
            OnReadWell(true, sheet.LastRowNum - 2, sheet.LastRowNum - 2, wells);
        }

        public delegate void ReadWellEventHandler(bool state,int curIndex,int totalCount,List<Well> wells);
        public static event ReadWellEventHandler readWell;
        public static void OnReadWell(bool state, int curIndex, int totalCount, List<Well> wells)
        {
            readWell(state,curIndex,totalCount,wells);
        }


    }
}
