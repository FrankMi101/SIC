//using BLL;
//using SIC.Generic.LIB;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace SIC
{
    public partial class ReportListPage : System.Web.UI.Page
    {
        readonly string pageID = "ReportListPage";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                SetPageAttribution();
                AssemblePage();
                BindListGridViewData();
            }
        }
        private void SetPageAttribution()
        {
            hfCategory.Value = "Report";
            hfArea.Value = pageID;
            hfPageID.Value = pageID;
            hfItemCode.Value = "Search";
            hfUserID.Value = User.Identity.Name;
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfUserRole.Value = WorkingProfile.UserRole;
            hfRunningModel.Value = WebConfig.RunningModel();
            Session["HomePage"] = "Loading.aspx?pID=" + pageID ;
            hfSelectedTab.Value = "Report";
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

                string BoardRole = WebConfig.getValuebyKey("BoardAccessRole");

                if (BoardRole.IndexOf(WorkingProfile.UserRole) != -1)
                    DDLPanel.Enabled = true;
                else
                    DDLPanel.Enabled = false;

                parameters.Para4 = DDLPanel.SelectedValue;
                AppsPage.BuildingList(ddlSchoolCode, ddlSchool, "DDLListSchool", parameters, schoolCode);
                InitialPage();
                if (ddlSchool.SelectedValue != "") Assembing_GradeTab();
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
            if (DDLPanel.SelectedValue == "E")
                hfSelectedTab.Value = "01";
            else
                hfSelectedTab.Value = "09";

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
        private void SchoolChange()
        {
            UserLastWorking.SchoolCode = ddlSchoolCode.SelectedValue;
            WorkingProfile.SchoolCode = ddlSchoolCode.SelectedValue;
            Assembing_GradeTab();
            BindListGridViewData();
            //ddlSearchby.SelectedIndex = 0;
            //TextSearch.Visible = true;
            //ddlSearchValue.Visible = false;
            hfSearchby.Value = "LastName";
            hfSearchValue.Value = "";

        }
  
        protected void BtnGradeTab_Click(object sender, EventArgs e)
        {
            string Grade = hfSelectedTab.Value;
            if (Grade != "")
            {
                BindListGridViewData(); 
           }

        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            BindListGridViewData();
        }
        protected void BtnSearchGo_Click(object sender, EventArgs e)
        {
            BindListGridViewData();
        }
        // private async Task BindStudentListGridViewData()
        private void BindListGridViewData()
        {
            try
            {
                Assembing_GradeTab();
                // GridView1.DataSource = await Task.Run(() => GetDataSource());// GetDataSource(true);
                GridView1.DataSource = GetDataSource(); 
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var em = ex.Message;
            }

        }

        private List<ReportList> GetDataSource()
        {
      
            var parameter = new
            {
                Operate = "ReportList",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = ddlSchoolYear.SelectedValue,
                SchoolCode = ddlSchool.SelectedValue,
                Grade = hfSelectedTab.Value,
                SearchBy =  hfSearchby.Value, // ddlSearchby.SelectedValue,
                Searchvalue = hfSearchValue.Value,  //  GetSearchValue(), 
            };
            var sp = "dbo.SIC_sys_ListOfReports";
             var myList = ListData.GeneralList<ReportList>(sp,parameter, btnSearchGo);
             return myList;
        }

       private void initialSearchBox()
        {

        }
        private void Assembing_GradeTab()
        {
            var parameters = new
            {
                Operate = "ReportTypeTab",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = ddlSchoolYear.SelectedValue,
                SchoolCode = ddlSchool.SelectedValue
            };
           // var Grade = hfSelectedTab.Value; ;
            AppsPage.BuildingTab(GradeTab, parameters, hfSelectedTab.Value);


            //    await BindStudentListGridViewData();


        }
    }
}