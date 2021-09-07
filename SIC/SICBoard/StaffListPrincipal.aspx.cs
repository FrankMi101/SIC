//using BLL;
//using SIC.Generic.LIB;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace SIC
{
    public partial class StaffListPrincipal : System.Web.UI.Page
    {
        readonly string pageID = "StaffListPrincipal";
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception Ex = Server.GetLastError();
            Server.ClearError();
            Response.Redirect("Error.aspx?pID=" + pageID + "&ex=" + Ex.Message);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                SetPageAttribution();
                AssemblePage();
                //    string pID = Page.Request.QueryString["Scope"].ToString();
                BindGridViewListData();
            }
        }
        private void SetPageAttribution()
        {
            hfCategory.Value = "Home";
            hfPageID.Value = pageID;
            hfCode.Value = "Search";
            hfUserID.Value = User.Identity.Name;
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfUserRole.Value = WorkingProfile.UserRole;
            hfRunningModel.Value = WebConfig.RunningModel();
            Session["HomePage"] = "Loading.aspx?pID=" + pageID;
            hfSelectedTab.Value = "Principal";
        }
        private void AssemblePage()
        {
            if (WorkingProfile.UserRole == "Admin")
                ddlType.Enabled = true;
            else
                ddlType.Enabled = false;
            string schoolYear = WorkingProfile.SchoolYear;
            string schoolCode = WorkingProfile.SchoolCode;
            try
            {
                var parameters = new CommonListParameter()
                {
                    Operate = "",
                    UserID = User.Identity.Name,
                    Para1 = hfUserRole.Value,
                    Para2 = WorkingProfile.SchoolYear,
                    Para3 = WorkingProfile.SchoolCode,
                    Para4 = "00"
                };
                AppsPage.BuildingList(ddlSchoolYear, "SchoolYear", parameters, schoolYear);
                AppsPage.BuildingList(ddlSchoolCode, ddlSchool, "DDLListSchool", parameters, schoolCode);
                InitialPage();
                if (ddlSchool.SelectedValue != "") Assembing_Tab();
            }
            catch 
            {  }
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

        }
        protected void DDLSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLastWorking.SchoolYear = ddlSchoolYear.SelectedValue;
            WorkingProfile.SchoolYear = ddlSchoolYear.SelectedValue;
            //  await BindGridViewData();
        }


        protected void DDLSchool_SelectedIndexChanged(object sender, EventArgs e)
        {

            AppsPage.SetListValue(ddlSchoolCode, ddlSchool.SelectedValue);
        }
        protected void DDLSchoolCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppsPage.SetListValue(ddlSchool, ddlSchoolCode.SelectedValue);
        }
        private void SchoolChange()
        {
            UserLastWorking.SchoolCode = ddlSchoolCode.SelectedValue;
            WorkingProfile.SchoolCode = ddlSchoolCode.SelectedValue;
            Assembing_Tab();
        }
        protected void BtnGradeTab_Click(object sender, EventArgs e)
        {
            string Grade = hfSelectedTab.Value;
            if (Grade != "")
            {
                BindGridViewListData();
                Assembing_Tab();
            }

        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            BindGridViewListData();
            Assembing_Tab();
        }
        // private async Task BindGridViewListData()
        private void BindGridViewListData()
        {
            try
            {
                // GridView1.DataSource = await Task.Run(() => GetDataSource());// GetDataSource(true);
                GridView1.DataSource = GetDataSource();// GetDataSource(true);
                GridView1.DataBind();
            }
            catch 
            {
                
            }

        }

        private List<PrincipalList> GetDataSource()
        {
            var parameter = new
            {
                Operate = "PrincipalList",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = ddlSchoolYear.SelectedValue,
                SchoolCode = ddlSchool.SelectedValue,
                Grade = hfSelectedTab.Value,
                SearchBy = hfSearchby.Value,
                Searchvalue = hfSearchValue.Value, //ddlSearchby.SelectedValue == "SurName"? TextSearch.Text : ddlSearchValue.SelectedValue,
                Scope = ddlType.SelectedValue
            };


            var myList = ListData.SearchGeneralList<PrincipalList>(pageID, parameter, btnSearchGo);
            return myList;
        }

        private void Assembing_Tab()
        {
            var parameters = new
            {
                Operate = "StaffPrincipalTab",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = ddlSchoolYear.SelectedValue,
                SchoolCode = ddlSchool.SelectedValue
            };
            var Grade = hfSelectedTab.Value;
            AppsPage.BuildingTab(GradeTab, parameters, Grade);


            //    await BindGridViewListData();


        }
    }
}