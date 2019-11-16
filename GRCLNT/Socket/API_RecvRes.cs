using GRCLNT.DataType;
using GRCLNT.Pages;
using GRCLNT.Wnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT.Socket
{
    /// <summary>
    /// 接收到服务器返回消息后，将消息传给窗口
    /// </summary>
    public class API_RecvRes
    {
        //private static MainWindow wndMain;
        private static WndLoginViewModel wndLoginViewModel;
        private static PageHomePageViewModel pageHomePageViewModel;
        //private static OrgMng_DeptPage pageOrgMng_Dept;
        //private static OrgMng_UserPage pageOrgMng_User;
        //private static OperUserDlg dlgOperUser;

        //public static void SetWndMain(MainWindow w)
        //{
        //    wndMain = w;
        //}

        public static void SetWndLoginViewModel(WndLoginViewModel w)
        {
            wndLoginViewModel = w;
        }

        public static void SetPageHomePageViewModel(PageHomePageViewModel p)
        {
            pageHomePageViewModel = p;
        }
        //public static void SetPageOrgMng_Dept(OrgMng_DeptPage p)
        //{
        //    pageOrgMng_Dept = p;
        //}

        //public static void SetPageOrgMng_User(OrgMng_UserPage p)
        //{
        //    pageOrgMng_User = p;
        //}

        //public static void SetOperUserDlg(OperUserDlg d)
        //{
        //    dlgOperUser = d;
        //}

        /// <summary>
        /// API连接状态
        /// </summary>
        /// <param name="request"></param>
        public static void API_ConnState(CLNTStringPackageInfo request)
        {
            wndLoginViewModel.ConnRes(request.resState);
        }

        /// <summary>
        /// 登录接口返回状态
        /// </summary>
        /// <param name="request"></param>
        public static void API_Login(CLNTStringPackageInfo request)
        {
            wndLoginViewModel.LoginRes(request.resState);
        }

        public static void API_GetUserInfo(CLNTStringPackageInfo request)
        {
            List<STR_User> users = new List<STR_User>();
            users = STR_User.UsrsFromStrs(request.Parameters);
            pageHomePageViewModel.GetUserfInfoRes(request.resState,users[0]);
        }
        ///// <summary>
        ///// 更换密码接口返回状态
        ///// </summary>
        ///// <param name="request"></param>
        //public static void API_Admin_ChangePwd(BMStringPackageInfo request)
        //{

        //}

        //public static void API_Admin_GetAllDepts(BMStringPackageInfo request)
        //{
        //    if (pageOrgMng_Dept != null)
        //        pageOrgMng_Dept.UpdateDeptLstRes(request.resState, request.Parameters);
        //    if (pageOrgMng_User != null)
        //        pageOrgMng_User.UpdateDeptLstRes(request.resState, request.Parameters);
        //}

        //public static void API_Admin_CreateDept(BMStringPackageInfo request)
        //{
        //    pageOrgMng_Dept.CreateDeptRes(request.resState);
        //}

        //public static void API_Admin_ChangeDept(BMStringPackageInfo request)
        //{
        //    pageOrgMng_Dept.ChangeDeptRes(request.resState);
        //}

        //public static void API_Admin_DeleteDept(BMStringPackageInfo request)
        //{
        //    pageOrgMng_Dept.DeleteDeptRes(request.resState);
        //}

        //public static void API_Admin_CreateUser(BMStringPackageInfo request)
        //{
        //    pageOrgMng_User.CreateUserRes(request.resState);
        //}

        //public static void API_Admin_GetDeptIdByName(BMStringPackageInfo request)
        //{
        //    dlgOperUser.GetDeptIdByNameRes(request.resState, int.Parse(request.Parameters[0]));
        //}

        //public static void API_Admin_GetAllUsers(BMStringPackageInfo request)
        //{
        //    List<STR_User> users = new List<STR_User>();
        //    users = STR_User.UsrsFromStrs(request.Parameters);
        //    pageOrgMng_User.GetAllUsersRes(request.resState, users);
        //}

        //public static void API_Admin_DeleteUsers(BMStringPackageInfo request)
        //{
        //    pageOrgMng_User.DeleteUsersRes(request.resState);
        //}

        //public static void API_Admin_ChangeUser(BMStringPackageInfo request)
        //{
        //    pageOrgMng_User.ChangeUser(request.resState);
        //}
    }
}
