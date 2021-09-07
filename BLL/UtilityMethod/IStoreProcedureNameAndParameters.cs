using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public  interface IStoreProcedureNameAndParameters
    {
        string SPNameAndPara(string category, string action);
        string SPNameAndPara(List<CommonSP> category, string action);
        string SPNameAndPara(string category,string action, object parameter);
    }
    public class StoreProcedureNameAndParameters : IStoreProcedureNameAndParameters
    {
        public string SPNameAndPara(string className, string action)
        {
            return Common.SPName(className, action,"");
        }
        public string SPNameAndPara(string category, string action, object parameter)
        {
            var sp = SPNameAndPara(category,action);
            return CheckStoreProcedureParameters.GetParamerters(sp, parameter);
        }

        public string SPNameAndPara(List<CommonSP> category, string action)
        {
            return CommonSPandParamter.GetSPName(category,action);
        }
    }
    public class CheckStoreProcedureParameters
    {
        public static string GetParamerters(string sp, object obj)
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

    }
}
