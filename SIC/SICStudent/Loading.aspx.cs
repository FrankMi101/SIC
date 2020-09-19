using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIC.SICStudent
{
    public partial class Loading : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string goPage = Page.Request.QueryString["pID"].ToString();
                switch (goPage)
                    {
                    case "StudentList":
                        goPage = "StudentListPage.aspx";
                        break;
                    case "SchoolList":
                        goPage = "SchoolListPage.aspx";
                        break;
   
                     default:
                        goPage = "Home.aspx";
                        break;
                }

                PageURL.HRef = goPage;
            }
        }
    }
}