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
        // GET: api/Menu
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public IEnumerable<MenuItems> Get(string Operate, string UserID, string UserRole, string SchoolYear, string SchoolCode, string TabID, string ObjID, string AppID)
        {
            List<MenuItems> myList;
            var parameter = new { Operate, UserID, UserRole, SchoolYear, SchoolCode, TabID, ObjID, AppID };
            var sp = "dbo.SIC_sys_ActionMenuList @Operate,@UserID,@UserRole,@SchoolYear,@SchoolCode,@TabID,@ObjID,@AppID";  
            myList = GeneralList.CommonList<MenuItems>(sp, parameter);
            return myList;

        }
        // GET: api/Menu/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Menu
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Menu/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Menu/5
        public void Delete(int id)
        {
        }
    }
}
