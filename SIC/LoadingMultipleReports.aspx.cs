using BLL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Web.UI;
namespace SIC
{
    public partial class LoadingMultipleReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var reportID = Page.Request.QueryString["ReportID"];
                var oneFile = Page.Request.QueryString["OneFile"];

                var parameter = new MenuListParameter
                {
                    Operate = "MultipleReport",
                    UserID = User.Identity.Name,
                    UserRole = WorkingProfile.UserRole,
                    SchoolYear = WorkingProfile.SchoolYear,
                    SchoolCode = WorkingProfile.SchoolCode,
                    StudentID = "",
                    PageID = Page.Request.QueryString["ReportID"],
                    Term = Page.Request.QueryString["Term"]
                };


                var myGoPageItem = AppsPage.MultipleReportItemsList<GoPageItems>(parameter)[0];
                string reportService = myGoPageItem.PageSite;
                string reportPath = myGoPageItem.PagePath;
                string reportName = myGoPageItem.PageFile;

                var reportPara = new ReportBase
                {
                    ReportService = myGoPageItem.PageSite,
                    ReportPath = myGoPageItem.PagePath,
                    ReportName = myGoPageItem.PageFile,
                    ReportType = reportID,
                    ReportFormat = "PDF"
                };

                List<ListOfSelected> inputParameters = (List<ListOfSelected>)Session["SelectedDataSet"];

                Byte[] myReport = null;
                try
                {
                    //  myReport = ReportRenderADO.GetReportR3(reportingService, reportPath, reportName, "PDF", myParameter);
                    myReport = GeneratePDFReport.GetMultipleReports(reportPara, inputParameters);

                }
                catch (Exception ex)
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
                catch (Exception ex)
                { }

                try
                {    // *************************if necessaray *****************************************************
                     // save encrypted report 
                     //  SavePDF(myReportWithPW, parameter.SchoolYear, parameter.SchoolCode, parameter.Grade, parameter.StudentID, "IEPReports");
                }
                catch (Exception ex)
                { }
                // ***************************************************************************************************************************
                try
                {
                    if (myReport.Length < 100)
                        NotPDFReport.Visible = true;
                    else
                        //  ReportRenderADO.RenderDocument(myReport, reportName, "PDF");
                        ShowDocument.Show(reportName, "PDF", myReport);

                }
                catch (Exception ex)
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
            catch (Exception ex)
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

            catch (Exception ex)

            {
            }
        }
    }
}