using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIC
{
    public class AppsBase : System.Web.UI.Page
    {
        public static List<T> GeneralList<T>(string sp, object parameter)
        {
            return BLL.Common.CommonList<T>(sp, parameter);
        }
        public static List<T> GeneralList<T>(string className, string action, object parameter)
        {
            return BLL.Common.CommonList<T>(className, action, parameter);
        }
        public static T GeneralValue<T>(string sp, object parameter)
        {
            return BLL.Common.CommonValue<T>(sp, parameter);
        }
        public static T GeneralValue<T>(string className, string action, object parameter)
        {
            return BLL.Common.CommonValue<T>(className, action, parameter);
        }
    }
}