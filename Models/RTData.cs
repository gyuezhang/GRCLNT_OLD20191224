using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RTData
    {
        public static C_User loginSuccessUserInfo { get; set; } = new C_User();

        public static BDZoning zoning { get; set; } = new BDZoning();

        public static WellParas wellParas { get; set; } = new WellParas();
    }
}
