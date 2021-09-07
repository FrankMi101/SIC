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
    public class ListItemsController : ApiController
    {
        private IAPIAction<NameValueList> _iapiAction;//= new APIAction<NameValueList>();
        public ListItemsController(IAPIAction<NameValueList> iapiAction)
        {
            _iapiAction = iapiAction ?? new APIAction<NameValueList>();
        }
        //  private readonly StoreProcedureNameAndParameters _spClass = new StoreProcedureNameAndParameters();
        // GET: api/ListItems
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ListItems/5
        public string Get(int id)
        {
            return "value";
        }
        public IEnumerable<NameValueList> Get(string Operate, string UserID, string Para1, string Para2, string Para3, string Para4 )
        {
            var parameter = new { Operate, UserID, Para1, Para2, Para3, Para4 };
            var sp = "dbo.SIC_sys_ListItems";// @Operate,@UserID,@Para1,@Para2,@Para3,@Para4";
            return _iapiAction.CeneralList("DDLList", sp, parameter);
          //  List<NameValueList> myList;
          //  myList =  APIListofT<NameValueList>.CeneralList("DDLList",sp,parameter) ; // GeneralList.CommonList<NameValueList>(sp, parameter);
         //   return myList;

        }
        // POST: api/ListItems
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ListItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ListItems/5
        public void Delete(int id)
        {
        }
    }
}
