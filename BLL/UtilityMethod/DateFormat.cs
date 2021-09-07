using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DateFormat
    {
        public static string DateF(DateTime datetime, string dFormat)
        {
            switch (dFormat)
            {
                case "YMD":
                    return datetime.ToString("yyyy-MM-dd");
                case "YMDH":
                    return datetime.ToString("yyyy-MM-dd HH:mm");
                case "MDY":
                    return datetime.ToString("d");
                default:
                    return datetime.ToString("MM/dd/yyyy");
            }
        }

        public static string Format(DateTime pDate, string pFormat)
        {
            try
            {
                if (pDate.GetType() == typeof(DateTime))
                {
                    string vYY = pDate.Year.ToString();
                    string vMM = TwinValue(pDate.Month);
                    string vDD = TwinValue(pDate.Day);
                
                    switch (pFormat)
                    {
                        case "YYYYMMDD":
                           return   vYY + "/" + vMM + "/" + vDD;
                         case "DDMMYYYY":
                           return  vDD + "/" + vMM + "/" + vYY;
                         case "MMDDYYYY":
                            return vMM + "/" + vDD + "/" + vYY;
                         case "MMMDDYYYY":
                            return  pDate.ToString("MMMM dd") +" " + vYY;
                         case "MMMDD":
                          return pDate.ToString("MMMM dd");
                         case "YYYYMMM":
                           return  pDate.ToString("yyyy MMMM");
                         default:
                            return vYY + "/" + vMM + "/" + vDD;
                     }
                }
                else
                {return pDate.ToString(); 
                }
              
            }
            catch (Exception ex)
            {
                var exm = ex.Message;
                return pDate.ToString();
            }
        }
        private static string TwinValue(int iValue)
        {
            if (iValue < 10) return "0" + iValue.ToString();
            return iValue.ToString();
        }
        public static DateTime YMD(string eDate)
        {
            try
            {
                string[] format = new[] { "dd/MM/yyyy", "d/M/yyyy", "dd-MM-yyyy", "yyyy/MM/dd" };
                DateTime oDate = DateTime.ParseExact(eDate, format, System.Globalization.DateTimeFormatInfo.InvariantInfo, System.Globalization.DateTimeStyles.None);
                return oDate;
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        public static string YMD(DateTime vDate, string split )
        {
            string rDate = "";
            if (vDate == null)
            { rDate = ""; }
            else
            {
                string vYY = vDate.Year.ToString();
                string vMM = TwinValue(vDate.Month);
                string vDD = TwinValue(vDate.Day);
            
                rDate = vYY + split + vMM + split + vDD;

            }
            return rDate;
        }

        public static int Age(DateTime BirthDate)
        {
            DateTime now = DateTime.Today;
            return Age(BirthDate, now);


        }
        public static int Age(DateTime birthdate, DateTime comparedate)
        {

            int age = comparedate.Year - birthdate.Year;
            if (comparedate < birthdate.AddYears(age))
            { age--; }

            return age;
        }


        public static string SchoolYearFrom(string strType, string cSchoolYear)
        {
            string bYear = cSchoolYear.Substring(0, 4);
            string eYear = cSchoolYear.Substring(4, 4);
            return bYear + strType + eYear;
        }

        public static string SchoolYearNext(string strType, string cSchoolYear)
        {
            string bYear = cSchoolYear.Substring(4, 4);
            int iYear = int.Parse(bYear) + 1;
            string eYear = iYear.ToString();
            return bYear + strType + eYear;
        }

        public static string SchoolYearPrevious(string strType, string cSchoolYear)
        {
            string eYear = cSchoolYear.Substring(0, 4);
            int iYear = int.Parse(eYear) - 1;

            string bYear = iYear.ToString();
            return bYear + strType + eYear;
        }

        public static string YearTOGO(string strType, int month, string cSchoolYear)
        {
            string rSchoolyear = "";
            int thisYear = (month)>8 ? int.Parse(cSchoolYear.Substring(4, 4)): int.Parse(cSchoolYear.Substring(0, 4));
            int goYear = 0;
            if (strType == "Next")
            {
                goYear = thisYear + 1;
                rSchoolyear = thisYear.ToString() + goYear.ToString();
            }
            else
            {
                goYear = thisYear - 1;
                rSchoolyear = goYear.ToString() + thisYear.ToString();
            }
            return rSchoolyear;
        }

    }

}

