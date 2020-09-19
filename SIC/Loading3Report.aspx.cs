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




                var parameter = new MenuListParameter
                {
                    Operate = "StudentReport",
                    UserID = User.Identity.Name,
                    UserRole = Page.Request.QueryString["uRole"],
                    SchoolYear = Page.Request.QueryString["sYear"],
                    SchoolCode = Page.Request.QueryString["sCode"],
                    Grade = Page.Request.QueryString["grade"],
                    StudentID = Page.Request.QueryString["sID"],
                    PageID = Page.Request.QueryString["pageID"],
                    Term = Session["Term"].ToString()

                };


                var myGoPageItem = AppsPage.GoPageItemsList<GoPageItems>(parameter)[0];
                string reportingService = myGoPageItem.PageSite;
                string reportPath = myGoPageItem.PagePath;
                string reportName = myGoPageItem.PageFile;
                string PagePara = myGoPageItem.PagePara;

                var myParameter = GetReportParameter(parameter);

                Byte[] myReport = ReportRender.GetReportR3(reportingService, reportPath, reportName, "PDF", myParameter);



                if (myReport.Length < 100)
                    NotPDFReport.Visible = true;
                else
                    ReportRender.RenderDocument(myReport, reportName, "PDF");


            }
        }
        private List<ReportParameter> GetReportParameter(MenuListParameter parameter)
        {

            var myParameter = new List<ReportParameter>();


            switch (parameter.PageID)
            {

                case "OfficeIndexCard":
                    myParameter.Add(ReportRender.GetParameter(1, "SchoolYear", parameter.SchoolYear));
                    myParameter.Add(ReportRender.GetParameter(2, "SchoolCode", parameter.SchoolCode));
                    myParameter.Add(ReportRender.GetParameter(3, "PersonID", parameter.StudentID));



                    break;
                case "AlternativeRCPDF":
                    myParameter.Add(ReportRender.GetParameter(1, "userid", User.Identity.Name));
                    myParameter.Add(ReportRender.GetParameter(2, "school_year", parameter.SchoolYear));
                    myParameter.Add(ReportRender.GetParameter(3, "school_code", parameter.SchoolCode));
                    myParameter.Add(ReportRender.GetParameter(4, "person_id", parameter.StudentID));
                    myParameter.Add(ReportRender.GetParameter(5, "terms", Session["Term"].ToString()));
                    myParameter.Add(ReportRender.GetParameter(6, "semester", Session["Semester"].ToString()));

                    break;
                case "GiftPDF":
                    myParameter.Add(ReportRender.GetParameter(1, "userid", User.Identity.Name));
                    myParameter.Add(ReportRender.GetParameter(2, "school_year", parameter.SchoolYear));
                    myParameter.Add(ReportRender.GetParameter(3, "school_code", parameter.SchoolCode));
                    myParameter.Add(ReportRender.GetParameter(4, "person_id", parameter.StudentID));
                    myParameter.Add(ReportRender.GetParameter(5, "terms", Session["Term"].ToString()));
                    break;
                case "IEPPDF":
                    myParameter.Add(ReportRender.GetParameter(1, "PersonID", parameter.StudentID));
                    myParameter.Add(ReportRender.GetParameter(2, "SchoolYear", parameter.SchoolYear));
                    myParameter.Add(ReportRender.GetParameter(3, "SchoolCode", parameter.SchoolCode));
                    myParameter.Add(ReportRender.GetParameter(4, "Term", Session["Term"].ToString()));


                    break;
                default:
                    myParameter.Add(new ReportParameter() { ParaName ="SchoolYear", ParaValue = parameter.SchoolYear });
                    myParameter.Add(new ReportParameter() { ParaName = "SchoolCode", ParaValue = parameter.SchoolCode });
                    myParameter.Add(new ReportParameter() { ParaName = "StudentID", ParaValue = parameter.StudentID });
                    break;
            }
             

            return myParameter;
        }
    }
}