//using BLL;
//using SIC.Generic.LIB;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;

namespace SIC
{
    public partial class EnrolmentRecords : System.Web.UI.Page
    {
        readonly string pageID = "EnrolmentRecords";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                SetPageAttribution();
                AssemblePage();
                BindStudentListGridViewData();
            }
        }
        private void SetPageAttribution()
        {
            hfCategory.Value = "StudentInfo";
            hfArea.Value = pageID;
            hfPageID.Value = pageID;
            hfItemCode.Value = "Search";
            hfUserID.Value = User.Identity.Name;
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfUserRole.Value = WorkingProfile.UserRole;
            hfRunningModel.Value = WebConfig.RunningModel();
            Session["HomePage"] = "Loading.aspx?pID=" + pageID ; 
           
        }
        private void AssemblePage()
        {
            hfSearchTextFields.Value = WebConfig.getValuebyKey("TextSearchFields");
            string schoolYear = WorkingProfile.SchoolYear;
            string schoolCode = WorkingProfile.SchoolCode;
            try
            {

               
                var parameters = new CommonListParameter()
                {
                    Operate = "",
                    UserID = User.Identity.Name,
                    Para1 = hfUserRole.Value,
                    Para2 = schoolYear,
                    Para3 = schoolCode,
                };
                AppsPage.BuildingList(ddlSchoolYear, "SchoolYear", parameters, schoolYear);
 
               
             }
            catch (Exception ex)
            { var em = ex.Message; }
        }
      
        protected void DDLSchoolYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLastWorking.SchoolYear = ddlSchoolYear.SelectedValue;
            WorkingProfile.SchoolYear = ddlSchoolYear.SelectedValue;
            //  await BindGridViewData();
            BindStudentListGridViewData();
        }

     
    
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
 
           BindStudentListGridViewData();
        }
        protected void BtnSearchGo_Click(object sender, EventArgs e)
        { 
            BindStudentListGridViewData();
        }
        // private async Task BindStudentListGridViewData()
        private void BindStudentListGridViewData()
        {
            try
            {
               var myData = GetDataSource();
                GridView1.DataSource = myData;
                GridView1.DataBind();
                if (myData.Count > 0)
                { 
                 TextBoxStudentName.Text = myData[0].StudentName.ToString();
                TextBoxStudentNo.Text = myData[0].StudentNo.ToString();  
                TextBoxOEN.Text = myData[0].OEN.ToString();
                TextGrade.Text = Page.Request.QueryString["Grade"];
               }

            }
            catch (Exception ex)
            {
                var em = ex.Message;
            }

        }

        private List<Enrolment> GetDataSource()
        {
 
            var parameter = new
            {
                Operate = "Records",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = ddlSchoolYear.SelectedValue,
                PersonID = Page.Request.QueryString["StudentID"]  
          
            };
          //  var myenrolmentList = AppsSIS.GeneralList<StudentEnrolment>(pageID,parameter);
             var enrolmentList = AppsSIS.GeneralList<Enrolment>("SISInfo",pageID, parameter);
          // string sp = "dbo.SIC_sys_ListofStudentEnrolmentRecords";
        //   var enrolmentList = AppsBase.GeneralList<Enrolment>(sp, parameter);
            return enrolmentList;
        }
  
     
    }
}