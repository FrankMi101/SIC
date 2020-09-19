using BLL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIC
{

    public class ListData : AppsBase
    {
        public ListData()
        {

        }
       
        public static List<T> SearchStudentList<T>(object parameter)
        {

            return GeneralList<T>("GeneralList", "StudentList", parameter);
        }
        public static List<T> SearchStaffList<T>(object parameter)
        {

            return GeneralList<T>("GeneralList", "StaffList", parameter);
        }
        public static string WorkingListContent(object parameter)
        {

            return GeneralValue<string>("GeneralList", "NameValue", parameter);
        }

        public static List<T> SchoolList<T>(object parameter)
        {

            return GeneralList<T>("GeneralList", "SchoolList", parameter);
        }

    }
}
 