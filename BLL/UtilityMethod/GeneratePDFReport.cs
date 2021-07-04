
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace BLL
{
    public class GeneratePDFReport
    {
        public static Byte[] GetOneReport2(ListOfSelected parameter, string reportServer, string reportPath, string reportName, string reportFormat)
        {
            var reportParameters = GetReportParameter(reportName, parameter);

            return getPDFReport(reportServer, reportPath, reportName, reportFormat, reportParameters);
        }
        public static Byte[] GetOneReport(string reportName, ListOfSelected parameter)
        {
            var reportParameters = GetReportParameter(reportName, parameter);
            string reportServer = getReportLocation(reportName, "Services");
            string reportPath = getReportLocation(reportName, "Path");

            return getPDFReport(reportServer, reportPath, reportName, "PDF", reportParameters);
        }

        public static Byte[] GetMultipleReports(string _reportName, string _reportFormat, List<ListOfSelected> myList)
        {
            Document doc = new Document();
            MemoryStream msOutput = new MemoryStream();
            PdfCopy pCopy = new PdfSmartCopy(doc, msOutput); // using iTextSharp pdf function
            doc.Open();
            foreach (var item in myList)
            {
                try
                {
                    Byte[] myPDF = GetOneReport(_reportName, item); // item  => ListOFSelected
                    if (myPDF.Length > 10)
                    {
                        AddFileToPCopy(ref pCopy, myPDF);
                    }
                }
                catch { }
            }
            try
            {
                pCopy.Close();
                doc.Close();
            }
            catch { }

            return msOutput.ToArray();
        }
        private static void AddFileToPCopy(ref PdfCopy pCopy, byte[] pdfFile)
        {
            MemoryStream stream1 = new MemoryStream(pdfFile);
            PdfReader pdfFile1 = new PdfReader(stream1.ToArray());
            for (int i = 1; i <= pdfFile1.NumberOfPages; i++)
            {
                pCopy.AddPage(pCopy.GetImportedPage(pdfFile1, i));
            }
            pdfFile1.Close();
        }
        private static List<ReportParameter> GetReportParameter(string reportName, ListOfSelected parameter)
        {
            //ParameterFactory pFactory = new ParameterFactory();
            //var pFactory = new ParameterFactory(new IEPPara()) ;
            //return pFactory.rParameter(parameter);
            IReportParameter iParameter = new IEPReportParameter(parameter);
            switch (reportName)
            {
                case "IEP":
                    iParameter = new IEPReportParameter(parameter);
                    break;//  return iepParameter.reportParameters();
                case "TPA":
                    iParameter = new TPAReportParameter(parameter);
                    break; //  return tpaParameter.reportParameters();
                case "SSF":
                    iParameter = new SSFormReportParameter(parameter);
                    break;  //  return ssfParameter.reportParameters();
                case "OfficeIndixCard":
                    iParameter = new IEPReportParameter(parameter);
                    break;   //  return indParameter.reportParameters();
                case "RC":
                    iParameter = new IEPReportParameter(parameter);
                    break;   //   return rcParameter.reportParameters();
                case "AlterRC":
                    iParameter = new IEPReportParameter(parameter);
                    break;   //  return altParameter.reportParameters();
                case "GiftRC":
                    iParameter = new GiftReportParameter(parameter);
                    break;  //   return giftParameter.reportParameters();
                default:
                    iParameter = new IEPReportParameter(parameter);
                    break;  //    return tcParameter.reportParameters();
            }
            return iParameter.ReportParameters();

            //var reportParameters = new List<ReportParameter>
            //{
            //    new ReportParameter() { ParaName = "Operate", ParaValue = "Report" },
            //    new ReportParameter() { ParaName = "UserID", ParaValue = parameter.UserID },
            //    new ReportParameter() { ParaName = "SchoolYear", ParaValue = parameter.SchoolYear },
            //    new ReportParameter() { ParaName = "SchoolCode", ParaValue = parameter.SchoolCode },
            //    new ReportParameter() { ParaName = "EmployeeID", ParaValue = parameter.ObjID },
            //    new ReportParameter() { ParaName = "SessionID", ParaValue = parameter.ObjNo },
            //    new ReportParameter() { ParaName = "Category", ParaValue = parameter.ObjType }
            //};
            //return reportParameters;
        }
        private static Byte[] getPDFReport(string reportingServices, string reportPath, string reportName, string reportFormat, List<ReportParameter> _reportParameter)

        {
            //  Byte[] result;
            try
            {
                ReportingWebService.ReportExecutionService RS = new ReportingWebService.ReportExecutionService();
                //  CredentialCache cache = new CredentialCache();
                string accessUser = WebConfigurationManager.AppSettings["WebServiceUser"];// WebConfig.ReportUser();
                string accessRWSPW = WebConfigurationManager.AppSettings["WebServiceWP"];//  WebConfig.ReportPW();
                string accessDomain = WebConfigurationManager.AppSettings["NetWorkDomain"];//  WebConfig.DomainName();
                                                                                           //  string reportingServices = WebConfigurationManager.AppSettings["ReportingService"];// WebConfig.ReportServices(); 
                                                                                           //  string reportPath = WebConfigurationManager.AppSettings["ReportPathWS"];//  WebConfig.ReportPathWS()  + "/" + _reportName;
                string format = reportFormat;

                RS.Url = reportingServices;
                RS.Credentials = new System.Net.NetworkCredential(accessUser, accessRWSPW, accessDomain);

                string report = reportPath + reportName;


                string historyID = null;
                string devInfo = "<DeviceInfo><Toolbar>False</Toolbar></DeviceInfo>";

                string encoding = "";
                string mimeType = "";
                ReportingWebService.Warning[] warnings = new ReportingWebService.Warning[0];
                string[] streamIDs = null;


                ReportingWebService.ServerInfoHeader sh = new ReportingWebService.ServerInfoHeader();
                RS.ServerInfoHeaderValue = sh;

                var rptParameters = GetReportingServiceParameters(_reportParameter);

                ReportingWebService.ExecutionInfo execInfo = new ReportingWebService.ExecutionInfo();
                ReportingWebService.ExecutionHeader execHeader = new ReportingWebService.ExecutionHeader();

                execInfo = RS.LoadReport(report, historyID);

                RS.SetExecutionParameters(rptParameters, "en-us");

                string extension = "";
                string SessionId = RS.ExecutionHeaderValue.ExecutionID;
                return RS.Render(format, devInfo, out extension, out encoding, out mimeType, out warnings, out streamIDs);

            }
            catch (Exception ex)
            {
                string error = ex.Message;
                return new Byte[0];
            }
        }
        private static string getReportLocation(string reportName, string locationType)
        {
            if (locationType == "Service") return WebConfigurationManager.AppSettings["ReportingService"];
            switch (reportName)
            {
                case "IEPReport":
                    return "SES_Reports/IEP/Production";
                case "SSForm":
                    return "SES_Reports/SSForm/Production";
                default:
                    return "TC_Report/Production";
            }
        }
        private static ReportingWebService.ParameterValue[] GetReportingServiceParameters(List<ReportParameter> _reportParameter)
        {
            int pLeng = _reportParameter.Count;

            ReportingWebService.ParameterValue[] rptParameters = new ReportingWebService.ParameterValue[pLeng];

            int i = 0;
            foreach (var item in _reportParameter)
            {
                rptParameters[i] = new ReportingWebService.ParameterValue()
                {
                    Name = item.ParaName,
                    Value = item.ParaValue.ToString()
                };
                i += 1;
            }
            return rptParameters;
        }

    }
    public class ReportParameter
    {
        public string ParaName { get; set; }
        public string ParaValue { get; set; }

    }
    public class ListOfSelected
    {
        public string UserID { get; set; }
        public string SchoolYear { get; set; }
        public string SchoolCode { get; set; }
        public string ObjID { get; set; }
        public string ObjNo { get; set; }
        public string ObjType { get; set; }
    }
}
