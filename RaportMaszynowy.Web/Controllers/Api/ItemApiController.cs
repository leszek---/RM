using System.Collections.Generic;
using System.Web.Http;
using FizzWare.NBuilder;

namespace RaportMaszynowy.Web.Controllers.Api
{
    public class ItemApiController : ApiController
    {
        // GET: api/Item
        public IEnumerable<string> Get()
        {

            //var item = Builder<Item>.CreateListOfSize(10).WhereAll().Have(x => x.Title = "some title").Build();
            return new string[] { "value1", "value2" };
        }

        // GET: api/Item/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Item
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Item/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Item/5
        public void Delete(int id)
        {
        }
    }
}
