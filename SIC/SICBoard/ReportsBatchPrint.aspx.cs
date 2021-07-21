//using BLL;
//using SIC.Generic.LIB;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;

namespace SIC
{
    public partial class ReportsBatchPrint : System.Web.UI.Page
    {
        readonly string pageID = "BatchPrintPage";
        protected async void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["SelectedDataSet"] = null;
                Page.Response.Expires = 0;
                SetPageAttribution();
                AssemblePage();
               await  BindStudentListGridViewData();
            }
        }
        private void SetPageAttribution()
        {
            hfCategory.Value = "BatchPrint";
            hfArea.Value = pageID;
            hfPageID.Value = pageID;
            hfItemCode.Value = "Search";
            hfUserID.Value = User.Identity.Name;
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfUserRole.Value = WorkingProfile.UserRole;
            hfRunningModel.Value = WebConfig.RunningModel();
            Session["HomePage"] = "Loading.aspx?pID=" + pageID ;
            Session["Semester"] = "1";
            Session["Term"] = "1";
        }
        private void AssemblePage()
        {
            hfSearchTextFields.Value = WebConfig.getValuebyKey("TextSearchFields");
            string schoolYear = WorkingProfile.SchoolYear;
            string schoolCode = WorkingProfile.SchoolCode;
            try
            {

                if (schoolCode.Substring(0, 2) == "05")
                { 
                    DDLPanel.SelectedIndex = 1;
                }
                var parameters = new CommonListParameter()
                {
                    Operate = "",
                    UserID = User.Identity.Name,
                    Para1 = hfUserRole.Value,
                    Para2 = schoolYear,
                    Para3 = schoolCode,
                };
                AppsPage.BuildingList(ddlSchoolYear, "SchoolYear", parameters, schoolYear);
                AppsPage.BuildingList(ddlReportForm, "Report&Form", parameters, schoolYear);

                string BoardRole = WebConfig.getValuebyKey("BoardAccessRole");

                if (BoardRole.IndexOf(WorkingProfile.UserRole) != -1)
                    DDLPanel.Enabled = true;
                else
                    DDLPanel.Enabled = false;

                parameters.Para4 = DDLPanel.SelectedValue;
                AppsPage.BuildingList(ddlSchoolCode, ddlSchool, "DDLListSchool", parameters, schoolCode);


            }
            catch (Exception ex)
            { var em = ex.Message; }
        }
        private void InitialPage()
        {
            if (WorkingProfile.SchoolCode == "")
            {
                ddlSchool.SelectedIndex = 0;
                AppsPage.SetListValue(ddlSchoolCode, ddlSchool.SelectedValue);
                WorkingProfile.SchoolCode = ddlSchool.SelectedValue;
            }
            else
            {
                AppsPage.SetListValue(ddlSchoolCode, WorkingProfile.SchoolCode);
                AppsPage.SetListValue(ddlSchool, WorkingProfile.SchoolCode);

            }
            hfSearchby.Value = "LastName";
            hfSearchValue.Value = "";
             //ddlSearchby.SelectedIndex = 0;
            //TextSearch.Visible = true;
           // ddlSearchValue.Visible = false;
        }
        protected void DDLSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLastWorking.SchoolYear = ddlSchoolYear.SelectedValue;
            WorkingProfile.SchoolYear = ddlSchoolYear.SelectedValue;
            //  await BindGridViewData();
        }

        protected void DDLPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var parameters = new CommonListParameter()
            {   Operate = "",
                UserID = User.Identity.Name,
                Para1 = hfUserRole.Value,
                Para2 = ddlSchoolYear.SelectedValue,
                Para3 = ddlSchool.SelectedValue,
                Para4 = DDLPanel.SelectedValue
            }; 
            AppsPage.BuildingList(ddlSchoolCode, ddlSchool, "DDLListSchool", parameters);
            WorkingProfile.SchoolCode = ddlSchool.SelectedValue;
            SchoolChange();
        }
        protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppsPage.SetListValue(ddlSchoolCode, ddlSchool.SelectedValue);
            SchoolChange();
        }
        protected void DDLSchoolCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppsPage.SetListValue(ddlSchool, ddlSchoolCode.SelectedValue);
            SchoolChange();
        }
        private async void SchoolChange()
        {
            UserLastWorking.SchoolCode = ddlSchoolCode.SelectedValue;
            WorkingProfile.SchoolCode = ddlSchoolCode.SelectedValue;
           
           await  BindStudentListGridViewData();
 
            hfSearchby.Value = "LastName";
            hfSearchValue.Value = "";
        }
        //protected void DDLSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    Assembing_GradeTab();
        //    TextSearch.Visible = false;
        //    ddlSearchValue.Visible = false;
        //    var serachText = WebConfig.getValuebyKey("TextSearchFields");
        //    if (serachText.Contains(ddlSearchby.SelectedValue))  // .IndexOf(ddlSearchby.SelectedValue) != -1)
        //    {
        //        TextSearch.Visible = true;
        //    }
        //    else
        //    {
        //        ddlSearchValue.Visible = true;
        //        AppsPage.BuildingList(ddlSearchValue, ddlSearchby.SelectedValue, User.Identity.Name, ddlSchoolYear.SelectedValue, ddlSchool.SelectedValue, ddlSemester.SelectedValue);
        //        ddlSearchValue.SelectedIndex = 0;
        //    }

        //}
    
        protected async void  BtnSearch_Click(object sender, EventArgs e)
        {
 
           await BindStudentListGridViewData();
        }
        protected async void BtnSearchGo_Click(object sender, EventArgs e)
        { 
           await BindStudentListGridViewData();
        }
         private async Task BindStudentListGridViewData()
  
        {
            try
            {
               
                GridView1.DataSource = await Task.Run(() => GetDataSource());// GetDataSource(true);
                 GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var em = ex.Message;
            }

        }

        private List<StudentList> GetDataSource()
        {
            Session["Semester"] = ddlSemester.SelectedValue;
            Session["Term"] = ddlTerm.SelectedValue;

            var parameter = new
            {
                Operate = "BatchPrintStudentList",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = ddlSchoolYear.SelectedValue,
                SchoolCode = ddlSchool.SelectedValue,
                ReportID = ddlReportForm.SelectedValue, 
                SearchBy =  ddlPrintBy.SelectedValue,
                SearchValue = GetSearchValue(),  
                Program = ddlProgram.SelectedValue,
                Term = ddlTerm.SelectedValue,
                Semester = ddlSemester.SelectedValue
            };

            var mystduentList = ListData.BatchPrintGeneralList<StudentList>(pageID, parameter, btnSearchGo);
            return mystduentList;
        }
        private string GetSearchValue()
        {
            if (ddlPrintByValue.SelectedValue == "") return ddlSchool.SelectedValue;
            return ddlPrintByValue.SelectedValue;
        }

        protected void DdlPrintBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            var parameters = new CommonListParameter()
            {
                Operate = "BatchPrint",
                UserID = User.Identity.Name,
                Para1 = hfUserRole.Value,
                Para2 = ddlSchoolYear.SelectedValue,
                Para3 = ddlSchool.SelectedValue,
                Para4 = ddlPrintBy.SelectedValue
            };
            AppsPage.BuildingList(ddlPrintByValue, ddlPrintBy.SelectedValue, parameters);
         }
    }
}