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
    public class SearchTeacherController : ApiController
    {
        private IAPIAction<AppraisalList> _iapiaction;//= new APIAction<Student>();
        public SearchTeacherController()
        {
            _iapiaction = new APIAction<AppraisalList>();
        }
        // GET: api/Menu
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public IEnumerable<AppraisalList> Get(string Operate, string UserID, string UserRole, string SchoolYear, string SchoolCode, string Grade, string SearchBy, string SearchValue, string Scope)
        {
            var parameter = new { Operate, UserID, UserRole, SchoolYear, SchoolCode, Grade, SearchBy, SearchValue, Scope };
            var sp = "dbo.SIC_sys_ListofAppraisal";
            return _iapiaction.CeneralList("StudentList", sp, parameter);
           // List<AppraisalList> myList = APIListofT<AppraisalList>.CeneralList("StudentList", sp, parameter);
           // return myList;

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
