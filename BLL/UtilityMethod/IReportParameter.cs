using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IReportParameter
    {
        List<ReportParameter> ReportParameters();
    }
    public class IEPReportParameter : IReportParameter
    {
        readonly ListOfSelected parameter;
        public IEPReportParameter(ListOfSelected _parameter)
        {
            this.parameter = _parameter;
        }

        public List<ReportParameter> ReportParameters()
        {
            var reportParameters = new List<ReportParameter>
            {
               new ReportParameter() { ParaName = "PersonID", ParaValue = parameter.ObjID },
               new ReportParameter() { ParaName = "SchoolYear", ParaValue = parameter.SchoolYear },
               new ReportParameter() { ParaName = "SchoolCode", ParaValue = parameter.SchoolCode },
               new ReportParameter() { ParaName = "Term", ParaValue = "0" },
           };
            return reportParameters;
        }
    }
    public class SSFormReportParameter : IReportParameter
    {
        ListOfSelected parameter;
        public SSFormReportParameter(ListOfSelected _parameter)
        {
            this.parameter = _parameter;
        }

        public List<ReportParameter> ReportParameters()
        {
            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = parameter.SchoolCode },
                new ReportParameter() { ParaName = "PersonID", ParaValue = parameter.ObjID },
                new ReportParameter() { ParaName = "FormNo", ParaValue = parameter.ObjNo }
            };
            return reportParameters;
        }
    }
    public class TPAReportParameter : IReportParameter
    {
        readonly ListOfSelected parameter;
        public TPAReportParameter(ListOfSelected _parameter)
        {
            this.parameter = _parameter;
        }

        public List<ReportParameter> ReportParameters()
        {
            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = parameter.SchoolCode },
                new ReportParameter() { ParaName = "EmployeeID", ParaValue = parameter.ObjID },
                new ReportParameter() { ParaName = "SessionID", ParaValue = parameter.ObjNo },
                new ReportParameter() { ParaName = "Category", ParaValue = parameter.ObjType }
            };
            return reportParameters;
        }
    }
    public class GiftReportParameter : IReportParameter
    {
        readonly ListOfSelected parameter;
        public GiftReportParameter(ListOfSelected _parameter)
        {
            this.parameter = _parameter;
        }

        public List<ReportParameter> ReportParameters()
        {
            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = parameter.SchoolCode },
                new ReportParameter() { ParaName = "PersonID", ParaValue = parameter.ObjID },
                new ReportParameter() { ParaName = "Term", ParaValue = parameter.ObjNo }
            };
            return reportParameters;
        }
    }
}
