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
    public class SearchStudentController : ApiController
    {
        private IAPIAction<Student> _iapiaction;//= new APIAction<Student>();
        public SearchStudentController()
        {
            _iapiaction = new APIAction<Student>();
        }
        // GET: api/Menu
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public IEnumerable<Student> Get(string Operate, string UserID, string UserRole, string SchoolYear, string SchoolCode, string Grade, string SearchBy, string SearchValue, string Scope)
        {
            var parameter = new { Operate, UserID, UserRole, SchoolYear, SchoolCode, Grade, SearchBy, SearchValue, Scope };
            var sp = "dbo.SIC_sys_ListofStudents";
            try
            {
                var myList = _iapiaction.CeneralList("Student", sp, parameter);
                // ( APIListofT<Student>.CeneralList("StudentList", sp, parameter);
                return myList;
            }
            catch (Exception)
            {

                throw;
            }


        }

        // GET: api/Menu/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Menu
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Menu/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/Menu/5
        public void Delete(int id)
        {
        }
    }
}
