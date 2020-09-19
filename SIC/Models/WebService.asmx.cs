using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BLL;
using ClassLibrary;

namespace SIC.Models
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]


    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public string GetHelpContent(string operation, string userId, string categoryId, string areaId, string itemCode)
        {
            try
            {
                return HelpContext.Content(operation, userId, categoryId, areaId, itemCode,"Help");
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        [WebMethod]
        public string GetHelpContent(string operation, string userId, string categoryId, string areaId, string itemCode,string type)
        {
            try
            {
                return HelpContext.Content(operation, userId, categoryId, areaId, itemCode, type);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        [WebMethod]
        public string SaveHelpContent(string operation, string userId, string categoryId, string areaId, string itemCode, string value)
        {
            try
            {
                return HelpContext.Content(operation, userId, categoryId, areaId, itemCode,"Help", value);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        [WebMethod]
        public string GetTitleContent(string operation, string userId, string categoryId, string areaId, string itemCode)
        {
            try
            {
                return TitleContext.Content(operation, userId, categoryId, areaId, itemCode);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }
        [WebMethod]
        public string SaveTitleContent(string operation, string userId, string categoryId, string areaId, string itemCode, string title, string subtitle)
        {
            try
            {
                return TitleContext.Content(operation, userId, categoryId, areaId, itemCode, title, subtitle);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return "";
            }

        }

        [WebMethod]
        public List<MenuItems> MenuOfStudentList(string operation, MenuListParameter parameter)
        {
            try
            {
                return AppsPage.ActionMenuStudentList<MenuItems>(parameter);   
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }

        }

        [WebMethod]
        public List<MenuItems> MenuOfSchoolList(string operation, MenuListParameter parameter)
        {
            try
            {
                return AppsPage.ActionMenuSchoolList<MenuItems>(parameter);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }

        }
        [WebMethod]
        public List<MenuItems> MenuOfClassList(string operation, MenuListParameter parameter)
        {
            try
            {
                return AppsPage.ActionMenuClassList<MenuItems>(parameter);
            }
            catch (Exception ex)
            {
                var em = ex.Message;
                return null;
            }

        }


    }
}
