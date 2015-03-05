using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RaportMaszynowy.Web.Controllers.Api
{
    public class ItemApiController : ApiController
    {
        // GET: api/ItemApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ItemApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ItemApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ItemApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ItemApi/5
        public void Delete(int id)
        {
        }
    }
}
