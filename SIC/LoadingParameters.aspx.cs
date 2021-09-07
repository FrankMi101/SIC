using BLL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace SIC
{
    public partial class LoadingParameters : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var parameter = new MenuListParameter
                {
                    UserID = User.Identity.Name,
                    UserRole = Page.Request.QueryString["uRole"],
                    SchoolYear = Page.Request.QueryString["sYear"],
                    SchoolCode = Page.Request.QueryString["sCode"],
                    ObjName = Page.Request.QueryString["oName"],
                    ObjID = Page.Request.QueryString["oID"],
                    ObjType = Page.Request.QueryString["oType"],
                    Category = Page.Request.QueryString["category"],
                };

                if (parameter.UserRole != "Admin")
                {
                    ddlSchoolYear.Enabled = false;
                    ddlSchoolCode.Enabled = false;
                    ddlSchools.Enabled = false;
                }
                hfObjName.Value = Page.Request.QueryString["oName"].ToString();
                hfObjType.Value = Page.Request.QueryString["oType"].ToString();
                hfObjPageH.Value = Page.Request.QueryString["pageH"].ToString();
                hfObjPageW.Value = Page.Request.QueryString["pageW"].ToString();

                AssemblePage();
            }
        }

        private void AssemblePage()
        {
            string schoolYear = Page.Request.QueryString["sYear"];
            string schoolCode = Page.Request.QueryString["sCode"];
            hfUserRole.Value = Page.Request.QueryString["uRole"];
            try
            {
                var parameters = new CommonListParameter()
                {
                    Operate = "",
                    UserID = User.Identity.Name,
                    Para1 = hfUserRole.Value,
                    Para2 = schoolYear,
                    Para3 = schoolCode,
                    Para4 = schoolCode.Substring(0,2) == "05" ? "S":"E",
                };
                AppsPage.BuildingList(ddlSchoolYear, "SchoolYear", parameters, schoolYear);
                AppsPage.BuildingList(ddlSchoolCode, ddlSchools, "DDLListSchool", parameters, schoolCode);
                AppsPage.BuildingList(ddlGrades,  "Grade", parameters, "12");
                AppsPage.BuildingList(ddlReportPeriod,   "ReportPeriod", parameters, "F");
                AppsPage.BuildingList(ddlCourse, "Course", parameters, "000");
 
            }
            catch 
            {  }
        }

        protected void DDLSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SchoolChange();
        }
      
        protected void DDLSchools_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppsPage.SetListValue(ddlSchoolCode, ddlSchools.SelectedValue);
            SchoolChange();
        }
        protected void DDLSchoolCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppsPage.SetListValue(ddlSchools, ddlSchoolCode.SelectedValue);
            SchoolChange();
        }
        private void SchoolChange()
        {
            var parameters = new CommonListParameter()
            {
                Operate = "",
                UserID = User.Identity.Name,
                Para1 = hfUserRole.Value,
                Para2 = ddlSchoolYear.SelectedValue,
                Para3 = ddlSchoolCode.SelectedValue,
                Para4 = "00",
            };
            AppsPage.BuildingList(ddlGrades,   "Grade", parameters, "12");
            AppsPage.BuildingList(ddlReportPeriod, "ReportPeriod", parameters, "F");
            AppsPage.BuildingList(ddlCourse, "Course", parameters, "000");

        }
    }
}