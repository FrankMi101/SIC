//using BLL;
//using SIC.Generic.LIB;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace SIC
{
    public partial class StudentListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                SetPageAttribution();
                AssemblePage();

            }
        }
        private void SetPageAttribution()
        {
            hfCategory.Value = "Home";
            hfPageID.Value = "StudentList";
            hfCode.Value = "Search";
            hfUserID.Value = User.Identity.Name;
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfUserRole.Value = WorkingProfile.UserRole;
            hfRunningModel.Value = WebConfig.RunningModel();
            Session["HomePage"] = "Loading.aspx?pID=StudentList";
            hfSelectedTab.Value = "01";
            Session["Term"] = "2";
            Session["Semester"] = "1";
        }
        private void AssemblePage()
        {

            string schoolYear = WorkingProfile.SchoolYear;
            string schoolCode = WorkingProfile.SchoolCode;
            try
            {

                if (schoolCode.Substring(0, 2) == "05")
                {
                    hfSelectedTab.Value = "09";

                    DDLPanel.SelectedIndex = 1;
                }
                var parameters = new CommonListParameter()
                {
                    Operate = "",
                    UserID = User.Identity.Name,
                    Para1 = hfUserRole.Value,
                    Para2 = WorkingProfile.SchoolYear,
                    Para3 = WorkingProfile.SchoolCode,
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
            ddlSearchby.SelectedIndex = 0;
            TextSearch.Visible = true;
            ddlSearchValue.Visible = false;


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


        }


        protected void DDLSearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSearchby.SelectedValue == "SurName")
            {
                TextSearch.Visible = true;
                ddlSearchValue.Visible = false;
            }
            else
            {
                TextSearch.Visible = false;
                ddlSearchValue.Visible = true;
                AppsPage.BuildingList(ddlSearchValue, ddlSearchby.SelectedValue, User.Identity.Name, ddlSchoolYear.SelectedValue, ddlSchool.SelectedValue, "");
                ddlSearchValue.SelectedIndex = 0;
            }

        }
        protected void BtnGradeTab_Click(object sender, EventArgs e)
        {
            string Grade = hfSelectedTab.Value;
            if (Grade != "")
            {
                BindStudentListGridViewData();
                Assembing_GradeTab();
            }

        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            BindStudentListGridViewData();
            Assembing_GradeTab();
        }
        // private async Task BindStudentListGridViewData()
        private void BindStudentListGridViewData()
        {
            try
            {
                // GridView1.DataSource = await Task.Run(() => GetDataSource());// GetDataSource(true);
                GridView1.DataSource = GetDataSource();// GetDataSource(true);
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                var em = ex.Message;
            }

        }

        private List<StudentList> GetDataSource()
        {
            string schoolyear = ddlSchoolYear.SelectedValue;
            string schoolcode = ddlSchool.SelectedValue;
            string searchby = ddlSearchby.SelectedValue;
            string searchValue = ddlSearchValue.SelectedValue;
            string grade = hfSelectedTab.Value;
            Session["Term"] = ddlTerm.SelectedValue;
            Session["Semester"] = ddlSmester.SelectedValue;
            if (searchby == "SurName") searchValue = TextSearch.Text;

            var parameter = new
            {
                Operate = "StudentList",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = schoolyear,
                SchoolCode = schoolcode,
                Grade = hfSelectedTab.Value,
                SearchBy = searchby,
                Searchvalue = searchValue,
                Scope =  ddlScope.SelectedValue,
                Program = ddlProgram.SelectedValue,
                Term = ddlTerm.SelectedValue,
                Semester = ddlSmester.SelectedValue
            };

            var mystduentList = ListData.SearchStudentList<StudentList>(parameter);
            return mystduentList;
        }

        protected void DDLPanel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var parameters = new CommonListParameter()
            {
                Operate = "",
                UserID = User.Identity.Name,
                Para1 = hfUserRole.Value,
                Para2 = ddlSchoolYear.SelectedValue,
                Para3 = WorkingProfile.SchoolCode,
                Para4 = DDLPanel.SelectedValue,
            };
            AppsPage.BuildingList(ddlSchoolCode, ddlSchool, "DDLListSchool", parameters);

            if (ddlSchool.Items.Count > 0)
            {
                ddlSchool.SelectedIndex = 0;
                AppsPage.SetListValue(ddlSchoolCode, ddlSchool.SelectedValue);
                WorkingProfile.SchoolCode = ddlSchool.SelectedValue;
                if (DDLPanel.SelectedValue == "Elementary")
                    hfSelectedTab.Value = "01";
                else
                    hfSelectedTab.Value = "09";

                Assembing_GradeTab();
                BindStudentListGridViewData();
            }


        }


        private void Assembing_GradeTab()
        {
            var parameters = new
            {
                Operate = "GradeTab",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = ddlSchoolYear.SelectedValue,
                SchoolCode = ddlSchool.SelectedValue
            };
            var Grade = hfSelectedTab.Value; ;
            AppsPage.BuildingTab(GradeTab, parameters, Grade);


            //    await BindStudentListGridViewData();


        }
    }
}