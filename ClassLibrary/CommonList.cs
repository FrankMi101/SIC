using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CommonList
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
    public class CommonListSchool :CommonList
    {
       
    }
    public class NameValueList
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
