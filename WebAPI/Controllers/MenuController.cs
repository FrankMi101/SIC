using BLL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors; 

namespace WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MenuController : ApiController
    {
        private IAPIAction<MenuItems> _iapiaction;//= new APIAction<NameValueList>();
        public MenuController()
        {
            _iapiaction = new APIAction<MenuItems>();
        }
        // GET: api/Menu
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public IEnumerable<MenuItems> Get(string Operate, string UserID, string UserRole, string SchoolYear, string SchoolCode, string TabID, string ObjID, string AppID)
        {
            //List<MenuItems> myList;
            //var parameter = new { Operate, UserID, UserRole, SchoolYear, SchoolCode, TabID, ObjID, AppID };
            //var sp = "dbo.SIC_sys_ActionMenuList @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@TabID,@ObjID,@AppID";  
            //myList = GeneralList.CommonList<MenuItems>(sp, parameter);
            //return myList;

            var parameter = new { Operate, UserID,UserRole, SchoolYear, SchoolCode, TabID, ObjID, AppID };
            var sp = "dbo.SIC_sys_ActionMenuList";// @Operate,@UserID,@Para1,@Para2,@Para3,@Para4";
            return _iapiaction.CeneralList("DDLList", sp, parameter);
           // List<MenuItems>  myList = APIListofT<MenuItems>.CeneralList("DDLList", sp, parameter); // GeneralList.CommonList<NameValueList>(sp, parameter);
           // return myList;
        }

    }
}
