using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIC.SICSetup
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
                    case "Encryption":
                        goPage = "EncryptionStr.aspx";
                        break;
                    case "ClientPage":
                        goPage = "ClientPage.aspx";
                        break;
                    case "SchoolList":
                        goPage = "SchoolListPage.aspx";
                        break;
                    case "StaffListTCDSB":
                        goPage = "StaffListPage.aspx?Scope=All";
                        break;
                    case "StaffListSchool":
                        goPage = "StaffListPage.aspx?Scope=School";
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