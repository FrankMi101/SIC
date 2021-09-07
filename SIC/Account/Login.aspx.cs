using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIC
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtDomain.Text = WebConfig.DomainName();
                LabelAppName.Text = WebConfig.AppName();
                HostName.InnerText = System.Net.Dns.GetHostName();
 

                txtUserName.Focus();
                if (DBConnection.CurrentDB != "Production")
                {
                    LabelTrain.Text = DBConnection.CurrentDB;
                    LabelTrain.Visible = true;
                }
                string authenticationMethod = WebConfig.getValuebyKey("AuthenticateMethod");
                if (authenticationMethod == "NameOnly")
                {
                       rfPassword.Enabled = false;
                }
            }
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                if (Authentication.AuthenticateMethod(txtUserName.Text) == "NameOnly")
                { CheckAppRole(); }
                else
                {
                    if (Authentication.IsAuthenticated(txtDomain.Text, txtUserName.Text, txtPassword.Text))
                    {
                        CheckAppRole();
                    }
                    else
                    {
                        ShowMessage("MessageAuthenticate");
                        txtUserName.Focus();
                    }
                }
            }
            catch 
            {
                // CheckTestUser();
               // string exM = ex.Message;
                ShowMessage("MessageAuthenticate");
                txtUserName.Focus();
            }

        }
        private void CheckAppRole()
        {
            try
            {
                string loginRole = UserProfile.UserLoginRole(txtUserName.Text);//  Authentication.UserRole(txtUserName.Text);
                if (loginRole == "Other")
                {
                    ShowMessage("MessageNoPermission");
                }
                else
                {
                    CreateAuthenticationTicket(loginRole);
                }
            }
            catch 
            {
                ShowMessage("MessageLoginDB");
            }
        }

        private void ShowMessage(string MessageType)
        {
            errorlabel.Text = WebConfig.getValuebyKey(MessageType);
            errorlabel.Visible = true;
            errorlabel.ForeColor = System.Drawing.Color.Red;
        }
        private void CreateAuthenticationTicket(string loginRole)
        {
            try
            {
                WorkingProfile.UserRole = loginRole;
                WorkingProfile.UserRoleLogin = loginRole;
                WorkingProfile.ClientUserScreen = txtResolution.Value;

                Boolean iscookiepersistent = chkPersist.Checked;
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, txtUserName.Text.ToLower(), DateTime.Now, DateTime.Now.AddMinutes(60), iscookiepersistent, "");
                string encryptedTitcket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTitcket);
                if (iscookiepersistent)
                {
                    authCookie.Expires = authTicket.Expiration;
                }
                Response.Cookies.Add(authCookie);
                System.Security.Principal.GenericIdentity id = new System.Security.Principal.GenericIdentity(authTicket.Name, "LdapAuthentication");
                System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(id, null);

                //  FormsAuthentication.RedirectFromLoginPage(txtUserName.Text.ToLower(), chkPersist.Checked);

                Response.Redirect(FormsAuthentication.GetRedirectUrl(txtUserName.Text.ToLower(), false), false);
            }
            catch 
            {
               
            }


        }
    }
}