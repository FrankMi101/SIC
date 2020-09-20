using BLL;
using ClassLibrary;
using System;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace SIC
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                SaveUserWorkingEnvironment();
                //  string deviceScreen = WorkingProfile.ClientUserScreen;
                // int xInt = deviceScreen.IndexOf("x");
                //  string devicewidth = deviceScreen.Substring(0, xInt);

                //int dWidth = int.Parse(devicewidth);
                //if (dWidth < 800)
                //{
                //    Page.Response.Redirect("Mobile/DefaultM.aspx");
                //}
                //else
                //{
                //    DefaultLoad();
                //}

                DefaultLoad();
            }
        }
        private void DefaultLoad()
        {

            WorkingProfile.PageCategory = "Home";
            WorkingProfile.PageArea = "General";
            WorkingProfile.PageItem = "EPA00";
            hfPageID.Value = "Default";
            hfUserLoginRole.Value = WorkingProfile.UserRoleLogin;
            hfUserID.Value = User.Identity.Name;
            hfRunningModel.Value = WebConfig.RunningModel();
            hfApprYear.Value = WorkingProfile.SchoolYear;
            hfApprSchool.Value = WorkingProfile.SchoolCode;
            hfApprEmployeeID.Value = WorkingProfile.UserEmployeeId;
            hfTeacherName.Value = WorkingProfile.UserName;

            if (DBConnection.CurrentDB != "Production")
            {
                LabelTrain.Text = DBConnection.CurrentDB;
                LabelTrain.Visible = true;
            }
            try
            {
                var parameter = new CommonListParameter()
                {
                    Operate = "UserRole",
                    UserID = User.Identity.Name,
                    Para1 = "",
                    Para2 = "",
                    Para3 = "",
                    Para4 = ""
                };

                AppsPage.BuildingList(rblLoginAS, "UserRole", parameter, WorkingProfile.UserRole);

                LoginUserRole.InnerText = UserProfile.LoginUserName + " as " + rblLoginAS.SelectedItem.Text;

                hfCurrentUserRole.Value = WorkingProfile.UserRole;

                GetUserLastWorkingValue();
            }
            catch (Exception ex)
            { }
            string pId = Page.Request.QueryString["pID"];
            pId = "Loading.aspx?pID=Summary";

            if (WorkingProfile.UserRole == "Teacher")
            {
                pId = "Loading.aspx?pID=StudentList";
            }
            else
            {
                if (pId == "Summary")
                { pId = "Loading.aspx?pID=StudentList"; }
                else
                {
                    if (Session["HomePage"] != null)
                    {
                        pId = Session["HomePage"].ToString();
                    }
                    else
                    {
                        pId = "Loading.aspx?pID=StudentList";
                    }
                }
            }
            GoList.Attributes.Add("src", pId);
        }


        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("Account/Login.aspx");
        }


        protected void RblLoginAS_SelectedIndexChanged(object sender, EventArgs e)
        {
            WorkingProfile.UserRole = rblLoginAS.SelectedValue;
            hfCurrentUserRole.Value = WorkingProfile.UserRole;
            Page.Response.Redirect("Default.aspx");
        }
        private void GetUserLastWorkingValue()
        {
            LabelSchoolYear.Text = UserProfile.CurrentSchoolYear;
            LabelSchoolCode.Text = UserLastWorking.SchoolCode;
            LabelSchool.Text = UserLastWorking.SchoolName;
            hfSchoolArea.Value = UserLastWorking.SchoolArea;
            WorkingProfile.SchoolArea = hfSchoolArea.Value;
        }
        private void SaveUserWorkingEnvironment()
        {
            string screenSize = WorkingProfile.ClientUserScreen;
            string machineName = Server.MachineName;
            string browserType = HttpContext.Current.Request.Browser.Type;
            string browserVersion = HttpContext.Current.Request.Browser.Version;

            string lastValue = UserLastWorking.LastValue(User.Identity.Name, "LastValue", WorkingProfile.UserRole, machineName, screenSize, browserType, browserVersion);

        }
    }
}