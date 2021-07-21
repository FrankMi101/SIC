using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Common
    {
        public static string SPName(List<CommonSP> cSP, string action, object parameter)
        {
            try
            {
                string sp = GetSPbyClassAndAction(cSP, action ); // this is a OOP method
              //  string sp = GetSPbyClassAndAction(className, action);
                return GetParamerters(sp, parameter);
            }
            catch (Exception ex)
            {
                return  "SP nmae for " + action;
            }
        }
        public static string SPName(string className, string action, object parameter)
        {
            try
            {
                string sp = GetSPbyClassAndAction(className, action); // this is a OOP method
                                                                            //  string sp = GetSPbyClassAndAction(className, action);
                return GetParamerters(sp, parameter);
            }
            catch (Exception ex)
            {
                return className + " " + action;
            }
        }
        public static List<T> CommonList<T>(string sp, object parameter)
        {
            try
            {
                  string fsp = CheckParamerters(sp, parameter) ;
                var myList = new CommonOperate<T>();
                return myList.ListOfT(fsp, parameter);

            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }

        }
   
        public static List<T> CommonList<T>(string className, string action, object parameter)
        {
            try
            {
                string sp = SPName(className, action, parameter);
                return CommonList<T>(sp, parameter);
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }

        }
        public static T CommonValue<T>(string sp, object parameter)
        {
            try
            {
               // string sp = GetSP(action, "GeneralValue");
                var myValue = new CommonOperate<T>();
                return myValue.ValueOfT(sp, parameter);

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
                string sp = SPName(className, action, parameter);
                return CommonValue<T>(sp, parameter);             
            }
            catch (Exception ex)
            {
                string em = ex.StackTrace;
                throw;
            }
        }

        private static string GetSPbyClassAndAction(string className, string action)
        {
            try
            {
                switch (className)
                {
                    case "GeneralList":
                        return GeneralList.GetSP(action);
                    case "GeneralValue":
                        return GeneralValue.GetSP(action);
                    case "CommentsBank":
                        return CommentsBank.GetSP(action);
                    case "AppsPageHelp":
                        return AppsPageHelp.GetSP(action);
                    case "SecurityManage":
                        return AppsSecurityManagement.GetSP(action);
                    case "SISInfo":
                        return SISInfoBase.GetSP(action);
                    default:
                        return AppsPageHelp.GetSP(action);
                }
            }
            catch (Exception ex)
            {
                return className + " " + action;
            }
        }
        private static string GetSPbyClassAndAction(List<CommonSP> classSP, string action )
        {
            try
            {
                return CommonSPandParamter.GetSPName(classSP, action);
            }
            catch (Exception ex)
            {
                return    "SP Name for " + action;
            }
        }

   
        public static string CheckParamerters(string sp, object obj)
        {
            if (sp.Contains("@"))
                return sp;
            else
                return sp + GetParameterStrFromParameterObj(obj);
        }
        private static string GetParamerters(string sp, object obj)
        {
            if (sp.Contains("@"))
                return sp;
            else
                return sp + GetParameterStrFromParameterObj(obj);
        }

        private static string GetParameterStrFromParameterObj(object obj)
        {
            var myP = PropertiesOfType<string>(obj);
            int x = 0;
            var para = "";
            foreach (var item in myP)
            {
                if (item.Value != null)
                {
                    if (x == 0)
                        para = " @" + item.Key;
                    else
                        para = para + ",@" + item.Key;
                    x++;
                }

            };
            return para;
        }
        private static IEnumerable<KeyValuePair<string, T>> PropertiesOfType<T>(object obj)
        {
            return from p in obj.GetType().GetProperties()
                   where p.PropertyType == typeof(T)
                   select new KeyValuePair<string, T>(p.Name, (T)p.GetValue(obj));
        }
   

        private static string GetParameterStrFromParameterObj2(object obj)
        {
            //for (int i = 0; i < 10; i++)
            //{  }
            var myObj = (IEnumerable<KeyValuePair<string, string>>)obj;
            int x = 0;
            var para = "";
            foreach (var item in myObj)
            {
                if (item.Value != null)
                {
                    if (x == 0)
                        para = " @" + item.Key;
                    else
                        para = para + ",@" + item.Key;
                    x++;
                }

            };
            return para;
        }

    }
}
