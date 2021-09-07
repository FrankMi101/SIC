using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
namespace SIC.SICStudent
{
    public partial class EnrolmentEdit : System.Web.UI.Page
    {
        readonly string pageID = "EnrolmentEdit";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                SetPageAttribution();
                AssemblePage();
                BindData();
            }
        }
        private void SetPageAttribution()
        {
            hfCategory.Value = "Enrolment";
            hfArea.Value = pageID;
            hfPageID.Value = pageID;
            hfItemCode.Value = "Search";
            hfUserID.Value = User.Identity.Name;
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfUserRole.Value = WorkingProfile.UserRole;
            hfRunningModel.Value = WebConfig.RunningModel();
            Session["HomePage"] = "Loading.aspx?pID=" + pageID;
            var parameter = new Base2Parameter()
            {
                Operate = "SchoolYearDate",
                UserID = User.Identity.Name,
                UserRole = hfUserRole.Value,
                SchoolYear = Page.Request.QueryString["SchoolYear"],
                SchoolCode = Page.Request.QueryString["SchoolCode"]
            };
            var myDate = ListData.SearchGeneralList<SchoolDateStr>("SchoolDateList", parameter);

            hfSchoolyearStartDate.Value = myDate[0].StartDate.ToString();
            hfSchoolyearEndDate.Value = myDate[0].EndDate.ToString();

        }
        private void AssemblePage()
        {
            hfSearchTextFields.Value = WebConfig.getValuebyKey("TextSearchFields");
            string schoolYear = Page.Request.QueryString["SchoolYear"];
            string schoolCode = Page.Request.QueryString["SchoolCode"];
            try
            {


                var parameters = new CommonListParameter()
                {
                    Operate = "",
                    UserID = User.Identity.Name,
                    Para1 = schoolYear,
                    Para2 = schoolCode
                };
                AppsPage.BuildingList(ddlSchoolYear, "SchoolYear", parameters);
                AppsPage.BuildingList(ddlEnrolmentType, "EnrolmentType", parameters);
                AppsPage.BuildingList(ddlEntryTypeName, "EntryTypeName", parameters);
                AppsPage.BuildingList(ddlDemitReason, "DemitReason", parameters);
                AppsPage.BuildingList(ddlFundingSourceType, "FundingSourceType", parameters);
                AppsPage.BuildingList(ddlRegisterCode, "RegisterCode", parameters);
                AppsPage.BuildingList(ddlSchoolYearTrack, "SchoolYearTrack", parameters);
                AppsPage.BuildingList(ddlGrade, "Grade", parameters);

                AppsPage.BuildingList(ddlSchoolBSID, "SchoolBSID", parameters);
                AppsPage.BuildingList(ddlSchoolCode, "ListSchoolCode", parameters);
                AppsPage.BuildingList(ddlSchools, "ListSchool", parameters);

                AppsPage.BuildingList(ddlDemitSchoolBSID, "SchoolBSID", parameters);
                AppsPage.BuildingList(ddlDemitSchoolCode, "ListSchoolCode", parameters);
                AppsPage.BuildingList(ddlDemitSchool, "ListSchool", parameters, schoolCode);



            }

            catch
            {   }
        }


        private void BindData()
        {
            try
            {
                var myData = GetDataSource();
                AppsPage.SetListValue(ddlSchoolYear, myData[0].SchoolYear);
                AppsPage.SetListValue(ddlEnrolmentType, myData[0].EnrolmentTypeID);
                AppsPage.SetListValue(ddlEntryTypeName, myData[0].EntryTypeName);
                AppsPage.SetListValue(ddlDemitReason, myData[0].DemitReasonName);
                AppsPage.SetListValue(ddlGrade, myData[0].Grade);
                AppsPage.SetListValue(ddlFundingSourceType, myData[0].FundingSourceType);
                AppsPage.SetListValue(ddlRegisterCode, myData[0].RegisterCode);
                AppsPage.SetListValue(ddlSchoolYearTrack, myData[0].SchoolYearTrack);
                AppsPage.SetListValue(ddlSchoolBSID, myData[0].SchoolBSID);
                AppsPage.SetListValue(ddlSchools, myData[0].SchoolCode);
                AppsPage.SetListValue(ddlSchoolCode, myData[0].SchoolCode);

                AppsPage.SetListValue(ddlDemitSchoolBSID, myData[0].DemitNextBSID);
                AppsPage.SetListValue(ddlDemitSchool, myData[0].DemitNextSchoolCode);
                AppsPage.SetListValue(ddlDemitSchoolCode, myData[0].DemitNextSchoolCode);

                TextBoxLanguage.Text = myData[0].LanguageInstruct.ToString();
                TextBoxPayerType.Text = myData[0].FundingPayerType.ToString();
                TextBoxRemark.Text = myData[0].Remark.ToString();
                dateStart.Value = myData[0].EffectiveDate;
                CheckBoxFundingResident.Checked = myData[0].FundingResidentFlag == "x" ? true : false;
                CheckBoxActiveFlag.Checked = myData[0].ActiveFlag == "x" ? true : false;
                TextBoxDemitNextSchool.Text = myData[0].SchoolNameNext.ToString();
                TextBoxDemitNextBSID.Text = myData[0].DemitNextBSID.ToString();

            }
            catch
            {
               
            }

        }

        private List<Enrolment> GetDataSource()
        {

            var parameter = new
            {
                Operate = "GetRecord",
                UserID = User.Identity.Name,
                UserRole = WorkingProfile.UserRole,
                SchoolYear = Page.Request.QueryString["SchoolYear"],
                PersonID = Page.Request.QueryString["PersonID"],
                SchoolCode = Page.Request.QueryString["SchoolCode"],
                EnrolmentTypeID = Page.Request.QueryString["TypeID"],
                EffectiveDate = Page.Request.QueryString["EffectiveDate"],
                ActiveFlag = ""
            };
            //  var myenrolmentList = AppsSIS.GeneralList<StudentEnrolment>(pageID,parameter);
            var record = AppsSIS.GeneralList<Enrolment>("SISInfo", "GetRecord", parameter);
            // string sp = "dbo.SIC_sys_ListofStudentEnrolmentRecords";
            //   var enrolmentList = AppsBase.GeneralList<Enrolment>(sp, parameter);
            return record;
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            SaveAction("Insert");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            SaveAction("Remove");
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            SaveAction("Update");
        }

        protected void ButtonDemit_Click(object sender, EventArgs e)
        {
            SaveAction("Demit");
        }
        private void SaveAction(string action)
        {
            string demitReason = ddlDemitReason.SelectedItem.Text;
            string demitNextSchool = TextBoxDemitNextSchool.Text;
            if (demitReason == "This Board") demitNextSchool = ddlDemitSchool.SelectedValue;


            var parameter = new
            {
                Operate = action,
                UserID = User.Identity.Name,
                UserRole = WorkingProfile.UserRole,
                SchoolYear = ddlSchoolYear.SelectedValue,
                PersonID = Page.Request.QueryString["PersonID"],
                SchoolCode = Page.Request.QueryString["SchoolCode"],
                EnrolmentTypeID = Page.Request.QueryString["TypeID"],
                EffectiveDate = Page.Request.QueryString["EffectiveDate"],
                ActiveFlag = CheckBoxActiveFlag.Checked ? 'x' : ' ',
                EntryTypeName = ddlEntryTypeName.SelectedItem.Text,
                RegisterCode = ddlRegisterCode.SelectedItem.Text,
                SchoolYearTrack = ddlSchoolYearTrack.SelectedItem.Text,
                Grade = ddlGrade.SelectedValue,
                LanguageInstruct = TextBoxLanguage.Text,
                FundingPayerType = TextBoxPayerType.Text,
                FundingResidentFlag = CheckBoxFundingResident.Checked ? 'x' : ' ',
                Remark = TextBoxRemark.Text,
                DemitReasonName = demitReason,
                DemitNextSchool = demitNextSchool,
            };



            var result = AppsSIS.GeneralValue<string>("SISInfo", action, parameter);

            CreateSaveMessage(action, result);
        }
        private void CreateSaveMessage(string action, string result)
        {
            try
            {
                string strScript = "window.alert( + action + ' Action ' + result + )";
                ClientScript.RegisterStartupScript(GetType(), "actionMessage", strScript, true);

                // *** AJAX Save Message
                // ScriptManager.RegisterStartupScript(Me.Page, Me.Page.GetType, "save_script", strScript.ToString(), True)
            }
            catch
            { }



        }


    }
}