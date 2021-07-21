using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
  public interface IReportParameter
    {
      //  List<ReportParameter> ReportParameters();
        List<ReportParameter> ReportParameters(ListOfSelected parameter);
    }
    public class IEPReportParameter : IReportParameter
    {
        private ListOfSelected _parameter;
        //public IEPReportParameter(ListOfSelected parameter)
        //{
        //    this._parameter = parameter;
        //}
        //public List<ReportParameter> ReportParameters()
        //{
        //    return addToReportParameter();

        //}

        public List<ReportParameter> ReportParameters(ListOfSelected parameter)
        {
            _parameter = parameter;
            return addToReportParameter();
        }
        private List<ReportParameter> addToReportParameter() {
            var reportParameters = new List<ReportParameter>
            {
               new ReportParameter() { ParaName = "PersonID", ParaValue = _parameter.ObjID },
               new ReportParameter() { ParaName = "SchoolYear", ParaValue = _parameter.SchoolYear },
               new ReportParameter() { ParaName = "SchoolCode", ParaValue = _parameter.SchoolCode },
               new ReportParameter() { ParaName = "Term", ParaValue = "0" },
           };
            return reportParameters;
        }
    }
    public class SSFormReportParameter : IReportParameter
    {
        private ListOfSelected _parameter;
        //public SSFormReportParameter(ListOfSelected parameter)
        //{
        //    this._parameter = parameter;
        //}
        //public List<ReportParameter> ReportParameters()
        //{
        //     return addToReportParameter();
        //}
        public List<ReportParameter> ReportParameters(ListOfSelected parameter)
        {
            _parameter = parameter;
            return addToReportParameter();

        }
        private List<ReportParameter> addToReportParameter()
        {
            var reportParameters = new List<ReportParameter>
            {
               new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = _parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = _parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = _parameter.SchoolCode },
                new ReportParameter() { ParaName = "PersonID", ParaValue = _parameter.ObjID },
                new ReportParameter() { ParaName = "FormNo", ParaValue = _parameter.ObjNo }
           };
            return reportParameters;
        }
    }
    public class TPAReportParameter : IReportParameter
    {
        private ListOfSelected _parameter;
        //public TPAReportParameter(ListOfSelected parameter)
        //{
        //    this._parameter = parameter;
        //}

        //public List<ReportParameter> ReportParameters()
        //{
            
        //    return addToReportParameter();

        //}

        public List<ReportParameter> ReportParameters(ListOfSelected parameter)
        {
            _parameter = parameter;
            return addToReportParameter();

        }
        private List<ReportParameter> addToReportParameter()
        {
            var reportParameters = new List<ReportParameter>
            {
                 new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = _parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = _parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = _parameter.SchoolCode },
                new ReportParameter() { ParaName = "EmployeeID", ParaValue = _parameter.ObjID },
                new ReportParameter() { ParaName = "SessionID", ParaValue = _parameter.ObjNo },
                new ReportParameter() { ParaName = "Category", ParaValue = _parameter.ObjType }
           };
            return reportParameters;
        }
    }
    public class GiftReportParameter : IReportParameter
    {
        private ListOfSelected _parameter;
        //public GiftReportParameter(ListOfSelected parameter)
        //{
        //    this._parameter = parameter;
        //}
        //public List<ReportParameter> ReportParameters()
        //{
        //    return addToReportParameter();
        //}

        public List<ReportParameter> ReportParameters(ListOfSelected parameter)
        {
            _parameter = parameter;
            return addToReportParameter();
        }
        private List<ReportParameter> addToReportParameter()
        {
            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = _parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = _parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = _parameter.SchoolCode },
                new ReportParameter() { ParaName = "PersonID", ParaValue = _parameter.ObjID },
                new ReportParameter() { ParaName = "Term", ParaValue = _parameter.ObjNo }
           };
            return reportParameters;
        }
    }
    public class IndexCardReportParameter : IReportParameter
    {
        private ListOfSelected _parameter;
        //public IndexCardReportParameter(ListOfSelected parameter)
        //{
        //    this._parameter = parameter;
        //}
        //public List<ReportParameter> ReportParameters()
        //{
        //     return addToReportParameter();

        //}
        public List<ReportParameter> ReportParameters(ListOfSelected parameter)
        {
            _parameter = parameter;
            return addToReportParameter();

        }
        private List<ReportParameter> addToReportParameter()
        {
            var reportParameters = new List<ReportParameter>
            {
                new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = _parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = _parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = _parameter.SchoolCode },
                new ReportParameter() { ParaName = "PersonID", ParaValue = _parameter.ObjID }
           };
            return reportParameters;
        }

 
    }
    public class AlertCardReportParameter : IReportParameter
    {
        private ListOfSelected _parameter;

        //public AlertCardReportParameter(ListOfSelected parameter)
        //{
        //    _parameter = parameter;
        //}

        //public List<ReportParameter> ReportParameters()
        //{
        //     return addToReportParameter();
        //}

        public List<ReportParameter> ReportParameters(ListOfSelected parameter)
        {
            _parameter = parameter;
            return addToReportParameter();

        }
        private List<ReportParameter> addToReportParameter()
        {
            var reportParameters = new List<ReportParameter>
            {
                 new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = _parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = _parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = _parameter.SchoolCode },
                new ReportParameter() { ParaName = "PersonID", ParaValue = _parameter.ObjID },
                new ReportParameter() { ParaName = "Term", ParaValue = _parameter.ObjNo }
           };
            return reportParameters;
        }
    }
    public class RCReportParameter : IReportParameter
    {
        private ListOfSelected _parameter;
        //public RCReportParameter(ListOfSelected parameter)
        //{
        //    _parameter = parameter;
        //}

        //public List<ReportParameter> ReportParameters()
        //{
        //    return addToReportParameter();
        //}

        public List<ReportParameter> ReportParameters(ListOfSelected parameter)
        {
            _parameter = parameter;
            return addToReportParameter();
        }
        private List<ReportParameter> addToReportParameter()
        {
            var reportParameters = new List<ReportParameter>
            {
             new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
                new ReportParameter() { ParaName = "UserID", ParaValue = _parameter.UserID },
                new ReportParameter() { ParaName = "SchoolYear", ParaValue = _parameter.SchoolYear },
                new ReportParameter() { ParaName = "SchoolCode", ParaValue = _parameter.SchoolCode },
                new ReportParameter() { ParaName = "PersonID", ParaValue = _parameter.ObjID },
                new ReportParameter() { ParaName = "Term", ParaValue = _parameter.ObjNo }
           };
            return reportParameters;
        }
    }

    public class BuildReportingParameters
    {
        
        public static List<ReportParameter> GetReportParameter(string reportType, ListOfSelected parameter)
        {
            var myReportClass = ReportParameterMapClass.ReportParametersInstance(reportType);
            return new GeneralReportParameter(myReportClass).GeneralReportParameters(parameter);

            //switch (reportType)
            //{
            //    case "IEP":
            //    case "IEPPDF":
            //        return new GeneralReportParameter(new IEPReportParameter()).GeneralReportParameters(parameter);
            //    case "TPA":
            //        return new GeneralReportParameter(new TPAReportParameter()).GeneralReportParameters(parameter);   
            //    default:
            //        return new GeneralReportParameter(new IEPReportParameter()).GeneralReportParameters(parameter);  
            //}
  
        }
    }
    public class GeneralReportParameter
    {
        private readonly IReportParameter _reportPrameter;
        public GeneralReportParameter(IReportParameter reportParamter)
        {
            _reportPrameter = reportParamter;
        }
        public List<ReportParameter> GeneralReportParameters( ListOfSelected parameter)
        {       
                return _reportPrameter.ReportParameters(parameter);
        }
    }
    public class ReportParameterMapClass
    {
        public static IReportParameter ReportParametersInstance(string reportType)
        {
           // return new IEPReportParameter();
            switch (reportType)
            {
                case "IEP":
                case "IEPPDF":
                    return new IEPReportParameter();
                case "TPA":
                    return new TPAReportParameter();
                case "SSF":
                    return new SSFormReportParameter();
                case "OfficeIndixCard":
                    return new IndexCardReportParameter();
                case "RC":
                    return  new RCReportParameter();
                case "AlterRC":
                    return  new AlertCardReportParameter();
                case "GiftRC":
                    return  new GiftReportParameter();
                default:
                    return  new IEPReportParameter();

            }
        }
    }
}
