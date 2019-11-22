using MaterialDesignThemes.Wpf;
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
                    return "更换信息";
                case EnumPage.Home_UsrInfo_ChangPwd:
                    return "重置密码";
                case EnumPage.Well:
                    return "机井信息";
                case EnumPage.Well_AddMtdSel:
                    return "采集方式";
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
                    return PackIconKind.Home;
                case EnumPage.Home_UsrInfo:
                    return PackIconKind.Home;
                case EnumPage.Home_UsrInfo_ChangeInfo:
                    return PackIconKind.Home;
                case EnumPage.Home_UsrInfo_ChangPwd:
                    return PackIconKind.Home;
                case EnumPage.Well:
                    return PackIconKind.Home;
                case EnumPage.Well_AddMtdSel:
                    return PackIconKind.Home;
                case EnumPage.Well_AddEdit:
                    return PackIconKind.Home;
                case EnumPage.Well_AddAuto:
                    return PackIconKind.Home;
                case EnumPage.Well_Search:
                    return PackIconKind.Home;
                case EnumPage.Well_State:
                    return PackIconKind.Home;
                case EnumPage.Well_Output:
                    return PackIconKind.Home;
                case EnumPage.Well_Setting:
                    return PackIconKind.Home;
                case EnumPage.EntWell:
                    return PackIconKind.Home;
                case EnumPage.SediCtrl:
                    return PackIconKind.Home;
                case EnumPage.GwDyna:
                    return PackIconKind.Home;
                case EnumPage.GwProj:
                    return PackIconKind.Home;
                case EnumPage.Hydro:
                    return PackIconKind.Home;
                case EnumPage.Law:
                    return PackIconKind.Home;
                case EnumPage.Setting:
                    return PackIconKind.Home;
                default:
                    return PackIconKind.Home;
            }
        }
    }
}
