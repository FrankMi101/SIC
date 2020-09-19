using BLL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 
namespace SIC
{
    public partial class Loading3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

      
               

                var parameter = new MenuListParameter
                {
                    Operate = "StudentPage",
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
                string PageSite = myGoPageItem.PageSite;
                string PagePath = myGoPageItem.PagePath;
                string PageFile = myGoPageItem.PageFile;
                string PagePara = myGoPageItem.PagePara;
                string goPage = PageSite + PagePath + PageFile + PagePara;
                if ( parameter.PageID == "IEPPDF2")
                {
                    var para1 = ReportRender.reportFormat("PDF");
                        
                    goPage  = PageSite + PagePath + PageFile + PagePara + para1;
                       }
                 PageURL.HRef = goPage;
          
            }
        }

    }
}