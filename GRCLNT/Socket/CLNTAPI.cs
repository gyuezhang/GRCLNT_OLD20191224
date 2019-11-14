using GRCLNT.DataType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT.Socket
{
    /// <summary>
    /// 调用API类
    /// </summary>
    public class CLNTAPI
    {
        /// <summary>
        /// 登录接口
        /// 连接服务器失败后，每0.5s重连一次，重试3次
        /// </summary>
        /// <param name="name">用户名</param>
        /// <param name="pwd">密码</param>
        public static void Login(string name, string pwd)
        {
            if (!CLNTClient.ezClient.IsConnected)
            {
                System.Threading.Thread.Sleep(500);

                for (int i = 0; i < 3; ++i)
                {
                    if (CLNTClient.ezClient.IsConnected)
                    {
                        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Login " + name + " " + pwd + "\r\n"));
                        return;
                    }
                    CLNTStringPackageInfo request = new CLNTStringPackageInfo(API_ID.API_Login, RES_STATE.SVR_NOTFOUND, new string[0]);
                    //API_RecvRes.API_Admin_Login(request);
                    System.Threading.Thread.Sleep(500);
                }
            }
            else
            {
                CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Login " + name + " " + pwd + "\r\n"));
            }
        }

        /// <summary>
        /// 更换管理员密码接口
        /// </summary>
        /// <param name = "oldPwd" > 旧密码 </ param >
        /// < param name="newPwd">新密码</param>
        //public static void ChangePwd(string oldPwd, string newPwd)
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_ChangePwd " + oldPwd + " " + newPwd + "\r\n"));
        //}

        //public static void GetAllDepts()
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_GetAllDepts " + "\r\n"));
        //}

        //public static void CreateDept(string deptName)
        //{
        //    byte[] a = Encoding.UTF8.GetBytes("API_Admin_CreateDept " + deptName + "\r\n");
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_CreateDept " + deptName + "\r\n"));
        //}

        //public static void ChangeDept(string oldName, string newName)
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_ChangeDept " + oldName + " " + newName + "\r\n"));
        //}

        //public static void DeleteDept(string deptName)
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_DeleteDept " + deptName + "\r\n"));
        //}

        //public static void GetDeptIdByName(string deptName)
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_GetDeptIdByName " + deptName + "\r\n"));
        //}

        //public static void CreateUser(STR_User user)
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_CreateUser " + user.UsrToStr() + "\r\n"));
        //}

        //public static void ChangeUser(STR_User user)
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_ChangeUser " + user.UsrToStr() + "\r\n"));
        //}

        //public static void GetAllUsers()
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_GetAllUsers " + "\r\n"));
        //}

        //public static void DeleteUser(string Id)
        //{
        //    if (CLNTClient.ezClient.IsConnected)
        //        CLNTClient.ezClient.Send(Encoding.UTF8.GetBytes("API_Admin_DeleteUsers " + Id + "\r\n"));
        //}
    }
}
