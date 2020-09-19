using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class Common
    {
         
        public static string GetSP(string action, string className)
        {
            switch (SPSource.SPFile)
            {
                case "JsonFile":
                    return GetSPFrom.JsonFile(action);
                case "DBTable":
                    return GetSPFrom.DbTable(action, className);
                default:
                    return   GetSPInClass(action);
            }

        }

        public static List<T> CommonList<T>(string action, object parameter)
        {
            try
            {
               string sp = GetSP(action,"GeneralList");
                var myList = new CommonOperate<T>();
                return myList.ListOfT(sp, parameter);

            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }

        }
        public static T CommonValue<T>(string action, object parameter)
        {
            try
            {
                 string sp = GetSP(action,"GeneralValue"); 
                var myValue = new CommonOperate<T>();
                return myValue.ValueOfT(sp, parameter);
            
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }
        }
        public static List<T> CommonList<T>(string className ,string action , object parameter)
        {
            try
            {
                switch (className)
                {
                    case "GeneralList":
                        return GeneralList.CommonList<T>(action, parameter);
                    case "AppsPageHelp":
                        return AppsPageHelp.CommonList<T>(action, parameter);
                    case "CommentsBank":
                        return CommentsBank.CommonList<T>(action, parameter);
                    default:
                        return AppsPageHelp.CommonList<T>(action, parameter);
                }
                 
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }

        }
        public static T CommonValue<T>(string className, string action, object parameter)
        {
            try
            {

                switch (className)
                {
                    case "GeneralList":
                        return GeneralList.CommonValue<T>(action, parameter);
            
                    case "CommentsBank":
                        return CommentsBank.CommonValue<T>(action, parameter);
                    case "AppsPageHelp":
                        return AppsPageHelp.CommonValue<T>(action, parameter);
                    default:
                        return AppsPageHelp.CommonValue<T>(action, parameter);
                }
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }
        }
        public static string SPName(string className, string action, object parameter)
        {
            try
            {

                switch (className)
                {
                    case "GeneralList":
                        return GeneralList.GetSP(action) ;

                    case "CommentsBank":
                        return CommentsBank.GetSP(action);
                    case "AppsPageHelp":
                        return AppsPageHelp.GetSP(action);
                    default:
                        return AppsPageHelp.GetSP(action);
                }
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }
        }
        private static string GetSPInClass(string action)
        {
            string parameter = " @Operate,@UserID,@Type";
            switch (action)
            {
                case "General":
                    return "dbo.SIC_sys_GeneralList" + parameter;

                case "DDList":
                    return "dbo.SIC_sys_ListsValuePara" + parameter;
                case "SchoolList":
                    return "dbo.SIC_sys_SchoolList" + parameter;
                default:
                    return action;

            }
        }
    }
}
