﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIC
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                string ex = Page.Request.QueryString["ex"].ToString();
                string pageID = Page.Request.QueryString["pageID"].ToString();
                Label1.Text = ex + " in Page " + pageID;
        

        }
    }
}