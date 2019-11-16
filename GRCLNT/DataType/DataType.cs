using System.Collections.Generic;

namespace GRCLNT.DataType
{
    public class STR_User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pwd { get; set; }
        public int DeptId { get; set; }
        public string Tel { get; set; }
        public string Email { get; set; }

        public string UsrToStr()
        {
            string res = " ";
            res += CommFuncs.CheckNullStr(Id.ToString());
            res += " ";
            res += CommFuncs.CheckNullStr(Name);
            res += " ";
            res += CommFuncs.CheckNullStr(Pwd);
            res += " ";
            res += CommFuncs.CheckNullStr(DeptId.ToString());
            res += " ";
            res += CommFuncs.CheckNullStr(Tel);
            res += " ";
            res += CommFuncs.CheckNullStr(Email);
            res += " ";
            return res;
        }

        public STR_User UsrFromStr(string str)
        {
            STR_User user = new STR_User();
            string[] paras = str.Split(' ');
            if (paras.Length < 6)
                return user;
            user.Id = int.Parse(CommFuncs.DeCheckNullStr(paras[0]));
            user.Name = CommFuncs.DeCheckNullStr(paras[1]);
            user.Pwd = CommFuncs.DeCheckNullStr(paras[2]);
            user.DeptId = int.Parse(CommFuncs.DeCheckNullStr(paras[3]));
            user.Tel = CommFuncs.DeCheckNullStr(paras[4]);
            user.Email = CommFuncs.DeCheckNullStr(paras[5]);
            return user;
        }

        public static STR_User UsrFromStrs(string[] strs)
        {
            STR_User user = new STR_User();
            user.Id = int.Parse(CommFuncs.DeCheckNullStr(strs[0]));
            user.Name = CommFuncs.DeCheckNullStr(strs[1]);
            user.Pwd = CommFuncs.DeCheckNullStr(strs[2]);
            user.DeptId = int.Parse(CommFuncs.DeCheckNullStr(strs[3]));
            user.Tel = CommFuncs.DeCheckNullStr(strs[4]);
            user.Email = CommFuncs.DeCheckNullStr(strs[5]);
            return user;
        }

        public static List<STR_User> UsrsFromStrs(string[] strs)
        {
            List<STR_User> res = new List<STR_User>();
            if (strs.Length % 6 != 0)
                return res;
            else
            {
                int iUsrCnt = strs.Length / 6;

                for (int i = 0; i < iUsrCnt; ++i)
                {
                    STR_User usr = new STR_User();
                    string[] curStrs;
                    List<string> st = new List<string>(strs);
                    curStrs = st.GetRange(i * 6, 6).ToArray();
                    usr = UsrFromStrs(curStrs);
                    res.Add(usr);
                }
            }

            return res;
        }
    }

}
