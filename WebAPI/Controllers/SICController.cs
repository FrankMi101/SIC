using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary;
using BLL;

namespace WebAPI.Controllers
{
    public class SICController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        ///  http://localhost:44350/api/SIC/?Operate=Grade&Parameter
        /// </summary>
        /// <param name="Operate"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public IEnumerable<NameValueList> Get(string Operate, GeneralParameter Parameter)
        {
            var sp = "[dbo].[SIC_sys_GeneralList]";
            Parameter.Operate = Operate;
            return GeneralList.CommonList<NameValueList>(sp, Parameter);
        }
        // GET api/<controller>
        /// <summary>
        ///  http://localhost:44350/api/SIC/?Operate=Grade&UserID=mif&Para1=20202021&Para2=0290&Para3=Admin&Para4=Elementary
        /// </summary>
        /// <param name="Operate"></param>
        /// <param name="UserID"></param>
        /// <param name="Para1"></param>
        /// <param name="Para2"></param>
        /// <param name="Para3"></param>
        /// <param name="Para4"></param>
        /// <returns></returns>
        public IEnumerable<NameValueList> Get(string Operate, string UserID, string UserRole, string SchoolYear, string SchoolCode, string Para1, string Para2, string Para3)
        {
            var sp = "[dbo].[SIC_sys_GeneralList]";
            var parameter = new { Operate, UserID, UserRole,SchoolYear,SchoolCode,Para1,Para2,Para3};
            return GeneralList.CommonList<NameValueList>(sp,parameter);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}