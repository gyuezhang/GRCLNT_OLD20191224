using System;
using System.Text.RegularExpressions;

namespace Util
{
    public class Str
    {
        public static bool IsNum(string strIn)
        {
            Regex reg = new Regex("^[0-9]+$");
            Match ma = reg.Match(strIn);
            return ma.Success;
        }

        public static bool IsEmail(string strIn)
        {
            Regex reg = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
            Match ma = reg.Match(strIn);
            return ma.Success;
        }

        public static bool IsIp(string strIn)
        {
            string num = "(25[0-5]|2[0-4]//d|[0-1]//d{2}|[1-9]?//d)";
            Regex reg = new Regex("^" + num + "//." + num + "//." + num + "//." + num + "$");
            Match ma = reg.Match(strIn);
            return ma.Success;
        }

        public static int IsLat(string strLat)
        {
            try
            {
                double d =double.Parse(strLat);
                if (d > 40 || d < 39)
                    return 3;
                string aa = d.ToString();
                int result = aa.Length - aa.IndexOf(".") - 1;
                if (result < 6)
                    return 2;
            }
            catch
            {
                return -1;
            }
            return 1;
        }

        public static int IsLng(string strLng)
        {
            try
            {
                double d = double.Parse(strLng);
                if (d > 118 || d < 117)
                    return 3;
                string aa = d.ToString();
                int result = aa.Length - aa.IndexOf(".") - 1;
                if (result < 6)
                    return 2;
            }
            catch
            {
                return -1;
            }
            return 1;
        }

    }
}
