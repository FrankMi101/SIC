using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI
{
   public interface IAPIAction<T>
    {
        List<T> CeneralList(string apiType, string sp, object parameter);
        T CeneralValue(string apiType, string sp, object parameter);
    }
}
