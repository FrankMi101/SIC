using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIC 
{
    
    public class DateFormat
    {
        public DateFormat()
        { }
        public static string Format(DateTime pDate, string pFormat)
        {
            return BLL.DateFormat.Format(pDate, pFormat);   
        }

        public static DateTime YMD(string eDate)
        {
            return BLL.DateFormat.YMD(eDate);
        }

        public static string YMD(DateTime vDate)
        {
            return BLL.DateFormat.YMD(vDate,"/");
        }

        public static int Age(DateTime birthdate)
        {
            return BLL.DateFormat.Age(birthdate);
        }
        public static int Age(DateTime birthdate, DateTime comparedate)
        {
            return BLL.DateFormat.Age(birthdate, comparedate);
        }

        public static string SchoolYearFrom(string strType, string cSchoolYear)
        {
            return BLL.DateFormat.SchoolYearFrom(strType, cSchoolYear);
        }

        public static string SchoolYearNext(string strType, string cSchoolYear)
        {
            return BLL.DateFormat.SchoolYearNext(strType, cSchoolYear);
        }

        public static string SchoolYearPrevious(string strType, string cSchoolYear)
        {
            return BLL.DateFormat.SchoolYearPrevious(strType, cSchoolYear);
        }

        public static string YearTOGO(string strType, string cSchoolYear)
        {
            return BLL.DateFormat.YearTOGO(strType,9, cSchoolYear);
        }
  
    }
}