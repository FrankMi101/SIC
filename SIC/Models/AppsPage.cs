/// <summary>
/// Summary description for WorkingProfile
/// </summary>
/// 
using BLL;
using ClassLibrary;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SIC
{
    public class AppsPage : AppsBase
    {
        public AppsPage()
        {

        }
        public static void SetPageAttribute(Page myPage)
        {
            try
            {
                var myControl = (HiddenField)myPage.FindControl("hfSchoolYear");
                myControl.Value = WorkingProfile.SchoolYear;
                myControl = (HiddenField)myPage.FindControl("hfPageID");
                myControl.Value = WorkingProfile.PageItem;
                myControl = (HiddenField)myPage.FindControl("hfSchoolCode");
                myControl.Value = WorkingProfile.SchoolCode;
                myControl = (HiddenField)myPage.FindControl("hfSchoolArea");
                myControl.Value = WorkingProfile.SchoolArea;
                myControl = (HiddenField)myPage.FindControl("hfUserLoginRole");
                myControl.Value = WorkingProfile.UserRoleLogin;
                myControl = (HiddenField)myPage.FindControl("hfRunningModel");
                myControl.Value = WebConfig.RunningModel();
                myControl = (HiddenField)myPage.FindControl("hfContentChange");
                myControl.Value = "0";
                myControl = (HiddenField)myPage.FindControl("hfStudentID");
                myControl.Value = WorkingProfile.UserEmployeeId;
            }
            catch
            {

            }



        }
        public static void SetPageAttribute2(Page myPage)
        {
            try
            {
                var myControl = (HiddenField)myPage.FindControl("hfCategory");
                myControl.Value = WorkingProfile.PageCategory;
                myControl = (HiddenField)myPage.FindControl("hfPageID");
                myControl.Value = WorkingProfile.PageItem;
                myControl = (HiddenField)myPage.FindControl("hfCode");
                myControl.Value = WorkingProfile.PageItem;
                myControl = (HiddenField)myPage.FindControl("hfArea");
                myControl.Value = WorkingProfile.PageArea;
                myControl = (HiddenField)myPage.FindControl("hfUserLoginRole");
                myControl.Value = WorkingProfile.UserRoleLogin;
                myControl = (HiddenField)myPage.FindControl("hfRunningModel");
                myControl.Value = WebConfig.RunningModel();
                myControl = (HiddenField)myPage.FindControl("hfContentChange");
                myControl.Value = "0";
            }
            catch
            {

            }
        }

        public static void CheckPageReadOnly(Page myPage, string checkType, string loginUserId)
        {
            var parameter = new PageHelp
            {
                Operate = "PageHelp",
                UserID = myPage.User.Identity.Name,
                Category = "",
                Area = "",
                Code = ""
            };
            //string pageHelpe = AppraisalPageHelp.PageHelp("PageHelp", parameter);//  AppraisalProcess.AppraisalPageItem("PageHelp", myPage.User.Identity.Name, category, area, code);
            //string pageFor = AppraisalPageHelp.PageHelp("PageActiveFor", parameter);// Process.AppraisalPageItem("PageActiveFor", myPage.User.Identity.Name, category, area, code);
            //string pageEp = AppraisalPageHelp.PageHelp("PageEP", parameter);// AppraisalProcess.AppraisalPageItem("PageEP", myPage.User.Identity.Name, category, area, code);
            //string pageRecover = "No"; //*** no need recover feature o page tile ***//  AppraisalPageHelp.PageHelp("PageRecover", parameter);//  AppraisalProcess.AppraisalPageItem("PageRecover", myPage.User.Identity.Name, category, area, code);




        }
        public static List<T> GoPageItemsList<T>(object parameter)
        {

            return GeneralList<T>("AppsPageHelp", "GoPageItems", parameter);
        }
        public static List<T> ActionMenuStudentList<T>(object parameter)
        {

            return GeneralList<T>("GeneralList", "MenuOfStudentList", parameter);
        }

        public static List<T> ActionMenuClassList<T>(object parameter)
        {

            return GeneralList<T>("GeneralList", "MenuOfClassList", parameter);
        }
        public static List<T> ActionMenuSchoolList<T>(object parameter)
        {

            return GeneralList<T>("GeneralList", "MenuOfSchoolList", parameter);
        }

        public static string GoPage(object parameter)
        {
            return GeneralValue<string>("AppsPageHelp", "GoPage", parameter);
        }
        public static string GoPage(string action, string userID, string category, string area, string code)
        {
            var parameter = new
            {
                Operate = action,
                UserID = userID,
                Category = category,
                Area = area,
                Code = code
            };
            return "xxx.aspx"; // AppraisalActivity.AppraisalPageItem(parameter);
        }

        public static void SetListValue(System.Web.UI.WebControls.ListControl myListControl, object value)
        {
            AssemblingList.SetValue(myListControl, value);
        }

        public static void BuildingList(System.Web.UI.WebControls.ListControl myListControl, string action, CommonListParameter parameter)
        {
            AssemblingList.SetLists("", myListControl, action, parameter);
        }

        public static void BuildingList(System.Web.UI.WebControls.ListControl myListControl, string action, CommonListParameter parameter, object initialValue)
        {
            AssemblingList.SetLists("", myListControl, action, parameter, initialValue);
        }

        public static void BuildingList(System.Web.UI.WebControls.ListControl myListControl, string operate, string userId, string para1, string para2, string para3)
        {
            var parameter = CommonParameters.GetListParameters(operate, userId, para1, para2, para3);
            BuildingList(myListControl, operate, parameter);
        }
        public static void BuildingList(System.Web.UI.WebControls.ListControl myListControl, string operate, string userId, string para1, string para2, string para3, object initialvalue)
        {
            var parameter = CommonParameters.GetListParameters(operate, userId, para1, para2, para3);
            BuildingList(myListControl, operate, parameter, initialvalue);
        }

        public static void BuildingList(System.Web.UI.WebControls.ListControl myCodeListControl, System.Web.UI.WebControls.ListControl myListNameControl, string action, CommonListParameter parameter)
        {
            AssemblingList.SetListSchool(myCodeListControl, myListNameControl, action, parameter);
        }
        public static void BuildingList(System.Web.UI.WebControls.ListControl myCodeListControl, System.Web.UI.WebControls.ListControl myListNameControl, string action, CommonListParameter parameter, object initialValue)
        {
            AssemblingList.SetListSchool(myCodeListControl, myListNameControl, action, parameter, initialValue);
        }

        public static void BuildingTab(System.Web.UI.HtmlControls.HtmlGenericControl myDIVTab, object parameter, string Grade)
        {

            var gradeList = GeneralList<CommonList>("GeneralList", "Grade", parameter);
            var UL = new HtmlGenericControl("ul");
           // int tabCount = gradeList.Count;
          //  int tabWidth = tabCount > 8 ? 70 : 45;

            try
            {
                foreach (var item in gradeList)
                {
                    var a = getALink(item.Code,item.Name,Grade) ;
                    var li = getLi(item.Code, item.Name, Grade);
                 
                    li.InnerText = "";
                    li.Controls.Add(a);
                    UL.Controls.Add(li);

                }
             myDIVTab.InnerHtml = "";
               myDIVTab.Controls.Add(UL);

            }
            catch (System.Exception ex)
            {
                var em = ex.Message;
                throw;
            }
        }

        private static HtmlAnchor getALink(string code, string name, string Grade)
        {
            var a = new HtmlAnchor();
            a.InnerText = name;
            a.ID = code;
            a.HRef = "#";
            string classAdd = code == Grade ? "aLinkTabHS" : "aLinkTabH";
            a.Attributes.Add("class", classAdd);
            return a;
        }
        private static HtmlGenericControl getLi(string code, string name, string Grade)
        {
            var li = new HtmlGenericControl("li");
            li.ID = "GT_" + code;
            string classAdd = code == Grade ? "liTabHS" : "liTabH";
            li.Attributes.Add("class", classAdd);

            if (name.Length > 9)
                li.Style.Add("width", "100");
            else if (name.Length > 8)
                li.Style.Add("width", "80");
            else
                li.Style.Add("width", "80");
            return li;
        }

        public static string ItemNamebyCode(string operate, string userID, string categoryID, string areaID)
        {

            return Menus.ItemNamebyCode(operate, userID, categoryID, areaID);

        }
        public static string ItemNamebyCode(string operate, string userID, string categoryID, string areaID, string itemCode)
        {
            return Menus.ItemNamebyCode(operate, userID, categoryID, areaID, itemCode);

        }

        

    }

}