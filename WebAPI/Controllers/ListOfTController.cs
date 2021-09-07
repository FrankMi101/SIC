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
    public class ListOfTController<T> : ApiController where T : BaseClassT
    {
        private readonly StoreProcedureNameAndParameters _spClass = new StoreProcedureNameAndParameters();
        public List<T> Get(string Operate, string UserID, string Para1, string Para2, string Para3, string Para4)
        {
            List<T> myList;
            var parameter = new { Operate, UserID, Para1, Para2, Para3, Para4 };
            var commenSp = new List<CommonSP> { new GeneralList() };
            var sp = _spClass.SPNameAndPara(commenSp, "DDList");

            // var sp = "dbo.SIC_sys_ListItems @Operate,@UserID,@Para1,@Para2,@Para3,@Para4";
            myList = GeneralList.CommonList<T>(sp, parameter);
            return myList;

        }
        // GET: api/ListOfT
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // GET: api/ListOfT/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ListOfT
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListOfT/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListOfT/5
        public void Delete(int id)
        {
        }
    }
}
