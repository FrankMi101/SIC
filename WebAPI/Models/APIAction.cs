using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI
{
    public class APIAction<T> : IAPIAction<T>
    {
        public List<T> CeneralList(string apiType, string sp, object parameter)
        {
            return GeneralList.CommonList<T>(sp, parameter);
        }

        public T CeneralValue(string apiType, string sp, object parameter)
        {
            return GeneralValue.CommonValue<T>(sp, parameter);
        }
    }
}