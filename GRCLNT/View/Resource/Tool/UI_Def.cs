﻿using MaterialDesignThemes.Wpf;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GRCLNT
{
    //定义页面及子页面
    public enum EnumPage
    {
        Home,
            Home_Dashboard,
            Home_UsrInfo,
                Home_UsrInfo_ChangeInfo,
                Home_UsrInfo_ChangPwd,

        Well,
            Well_AddMtdSel,
                Well_AddEdit,
                Well_AddAuto,
            Well_Search,
            Well_State,
            Well_Output,
            Well_Setting,

        EntWell,
        SediCtrl,
        GwDyna,
        GwProj,
        Hydro,
        Law,
        Setting,
    }

    public class AddrBarItem : PropertyChangedBase
    {
        public EnumPage pageId { get; set; }
        private string _cont;
        private PackIconKind _iconKind;
        private Visibility _vHasChild;
        private string _strPageId;

        public string strPageId
        {
            get { return _strPageId; }
            set
            {
                SetAndNotify(ref _strPageId, value);
            }
        }

        public string cont
        {
            get { return _cont; }
            set
            {
                SetAndNotify(ref _cont, value);
            }
        }

        public PackIconKind iconKind
        {
            get { return _iconKind; }
            set
            {
                SetAndNotify(ref _iconKind, value);
            }
        }

        public Visibility vHasChild
        {
            get { return _vHasChild; }
            set
            {
                SetAndNotify(ref _vHasChild, value);
            }
        }

        public AddrBarItem(EnumPage id)
        {
            pageId = id;
            cont = GetPageIdName();
            iconKind = GetIconKind();
            vHasChild = Visibility.Visible;
            strPageId = id.ToString();
        }

        private string GetPageIdName()
        {
            switch(pageId)
            {
                case EnumPage.Home:
                    return "首页";
                case EnumPage.Home_Dashboard:
                    return "仪表盘";
                case EnumPage.Home_UsrInfo:
                    return "用户信息";
                case EnumPage.Home_UsrInfo_ChangeInfo:
                    return "更换用户信息";
                case EnumPage.Home_UsrInfo_ChangPwd:
                    return "重置密码";
                case EnumPage.Well:
                    return "机井信息";
                case EnumPage.Well_AddMtdSel:
                    return "信息采集";
                case EnumPage.Well_AddEdit:
                    return "手动添加";
                case EnumPage.Well_AddAuto:
                    return "自动导入";
                case EnumPage.Well_Search:
                    return "查询";
                case EnumPage.Well_State:
                    return "统计";
                case EnumPage.Well_Output:
                    return "导出";
                case EnumPage.Well_Setting:
                    return "设置";
                case EnumPage.EntWell:
                    return "企业井管理";
                case EnumPage.SediCtrl:
                    return "控沉工作";
                case EnumPage.GwDyna:
                    return "地下水动态";
                case EnumPage.GwProj:
                    return "地下水工程";
                case EnumPage.Hydro:
                    return "水文地质";
                case EnumPage.Law:
                    return "法律法规";
                case EnumPage.Setting:
                    return "设置";
                default:
                return "";
            }
        }

        private PackIconKind GetIconKind()
        {
            switch (pageId)
            {
                case EnumPage.Home:
                    return PackIconKind.Home;
                case EnumPage.Home_Dashboard:
                    return PackIconKind.ViewDashboard;
                case EnumPage.Home_UsrInfo:
                    return PackIconKind.AccountBadgeHorizontal;
                case EnumPage.Home_UsrInfo_ChangeInfo:
                    return PackIconKind.AccountDetails;
                case EnumPage.Home_UsrInfo_ChangPwd:
                    return PackIconKind.LockReset;
                case EnumPage.Well:
                    return PackIconKind.WaterPump;
                case EnumPage.Well_AddMtdSel:
                    return PackIconKind.Forwardburger;
                case EnumPage.Well_AddEdit:
                    return PackIconKind.PlaylistEdit;
                case EnumPage.Well_AddAuto:
                    return PackIconKind.ScrewMachineFlatTop;
                case EnumPage.Well_Search:
                    return PackIconKind.SearchWeb;
                case EnumPage.Well_State:
                    return PackIconKind.ChartLine;
                case EnumPage.Well_Output:
                    return PackIconKind.PageNextOutline;
                case EnumPage.Well_Setting:
                    return PackIconKind.Equaliser;
                case EnumPage.EntWell:
                    return PackIconKind.Factory;
                case EnumPage.SediCtrl:
                    return PackIconKind.Layers;
                case EnumPage.GwDyna:
                    return PackIconKind.Water;
                case EnumPage.GwProj:
                    return PackIconKind.Worker;
                case EnumPage.Hydro:
                    return PackIconKind.Map;
                case EnumPage.Law:
                    return PackIconKind.ScaleBalance;
                case EnumPage.Setting:
                    return PackIconKind.Settings;
                default:
                    return PackIconKind.Brightness1;
            }
        }
    }
}
