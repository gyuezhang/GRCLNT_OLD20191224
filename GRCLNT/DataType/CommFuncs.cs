using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRCLNT.DataType
{
    public class CommFuncs
    {
        public static string CheckNullStr(string strIn)
        {
            if (strIn == null)
                return "emptynovalue";
            else
                return strIn;
        }

        public static string DeCheckNullStr(string strIn)
        {
            if (strIn == "emptynovalue")
                return null;
            else
                return strIn;
        }
    }
}
