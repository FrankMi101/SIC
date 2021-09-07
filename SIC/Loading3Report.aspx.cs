using BLL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace SIC
{
    public partial class Loading3Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string reportType = Page.Request.QueryString["pageID"];
                var parameter = new MenuListParameter
                {
                    Operate = Page.Request.QueryString["area"],
                    UserID = User.Identity.Name,
                    UserRole = Page.Request.QueryString["uRole"],
                    SchoolYear = Page.Request.QueryString["sYear"],
                    SchoolCode = Page.Request.QueryString["sCode"],
                    Grade = Page.Request.QueryString["grade"],
                    StudentID = Page.Request.QueryString["sID"],
                    PageID = reportType,
                    Term = Session["Term"].ToString(),
                    Category = Page.Request.QueryString["category"],

                };


                var myGoPageItem = AppsPage.GoPageItemsList<GoPageItems>(parameter)[0];
                string reportService = myGoPageItem.PageSite;
                string reportPath = myGoPageItem.PagePath;
                string reportName = myGoPageItem.PageFile;
                string PagePara = myGoPageItem.PagePara;

                var reportPara = new ReportBase
                {
                    ReportService = myGoPageItem.PageSite,
                    ReportPath = myGoPageItem.PagePath,
                    ReportName = myGoPageItem.PageFile,
                    ReportType = reportType,
                    ReportFormat = "PDF"
                };

                //  var myParameter = GetReportParameter(parameter);
                var inputParameters = new ListOfSelected()
                {
                    UserID = User.Identity.Name,
                    SchoolYear = Page.Request.QueryString["sYear"],
                    SchoolCode = Page.Request.QueryString["sCode"],
                    ObjID = Page.Request.QueryString["sID"],
                    ObjNo = Page.Request.QueryString["grade"],
                    ObjType = Page.Request.QueryString["category"]

                };
                Byte[] myReport = null;
                try
                {
                    myReport = GeneratePDFReport.GetOneReport(reportPara,  inputParameters);

                }
                catch
                {
                    NotPDFReport.Text = "Can't find the Report -- " + reportName + " at " + reportPath;
                    NotPDFReport.Visible = true;
                }

                // add password to the PDF file. it works
                // *************************if necessaray ********************************************************************************
                // Byte[] myReportWithPW = ReportRender.AddPWtoPDFMemory(myReport, parameter.StudentID, null);

                try
                {
                    // *************************if necessaray ********************************************************************************
                    // send a email with attachment of myReport 
                    // SendtheReportAsAttachment(myReportWithPW, parameter.StudentID + "_IEP_Report.pdf", "application/pdf");
                }
                catch
                { }

                try
                {    // *************************if necessaray *****************************************************
                     // save encrypted report 
                     //  SavePDF(myReportWithPW, parameter.SchoolYear, parameter.SchoolCode, parameter.Grade, parameter.StudentID, "IEPReports");
                }
                catch
                { }
                // ***************************************************************************************************************************
                try
                {
                    if (myReport.Length < 100)
                        NotPDFReport.Visible = true;
                    else
                        ReportRenderADO.RenderDocument(myReport, reportName, "PDF");
                    //  ReportRender.RenderDocument(myReportWithPW, reportName, "PDF");

                }
                catch
                {
                    NotPDFReport.Text = "Can't find the Report -- " + reportName + " at " + reportPath;
                    NotPDFReport.Visible = true;
                }


            }
        }
        private void SendtheReportAsAttachment(Byte[] pdfReport, string fileName, string fileType)
        {
            try
            {
                var myMail = new EmailNotice
                {
                    EmailTo = "mif@tcdsb.org",
                    EmailBody = "This is Test IEP Report as Attachment from Memory stream",
                    EmailFormat = "HTML",
                    EmailFrom = "mif@tcdsb.org",
                    EmailSubject = "Student IEP Report",
                    EmailType = "Notice",
                    FileMemory = pdfReport,
                    FileName = fileName,
                    FileType = fileType
                };
                eMailNotification.SendMail(myMail);
            }
            catch
            { }

        }
        private void SavePDF(Byte[] pdfReport, string schoolYear, string schoolCode, string grade, string studentID, string AppID)
        {
            try
            {
                string fileServer = WebConfig.getValuebyKey("PDFFileSavePath");
                string fileName = grade + "_" + studentID + "_IEPReport" + ".pdf";
                string filePath = $@"{fileServer}\{AppID}\{schoolYear}\{schoolCode}";
                //   string filePath = fileServer + @"\" + AppID + @"\" + schoolYear + @"\" + schoolCode;

                //  filePath = filePath.Replace(@"\\", @"\");

                ReportRenderADO.SavePDFReport(pdfReport, fileName, filePath);
            }

            catch 

            {
            }

        }
    }
}