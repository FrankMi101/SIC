using BLL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class APIListofT<T>
    {
        public static List<T> CeneralList(string apiType,string sp, object parameter)
        {
            List<T> myList;
              //   var parameter = new { Operate, UserID, UserRole, SchoolYear, SchoolCode, Grade, SearchBy, SearchValue, Scope };
             //  var sp = "dbo.SIC_sys_ActionMenuList @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@TabID,@ObjID,@AppID";
            myList = GeneralList.CommonList<T>(sp, parameter);
            return myList;
        }
        public static T CeneralValue(string apiType, string sp, object parameter)
        {
             //   var parameter = new { Operate, UserID, UserRole, SchoolYear, SchoolCode, Grade, SearchBy, SearchValue, Scope };
            //  var sp = "dbo.SIC_sys_ActionMenuList @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@TabID,@ObjID,@AppID";
            return  GeneralValue.CommonValue<T>(sp, parameter); 
        }
    }
}