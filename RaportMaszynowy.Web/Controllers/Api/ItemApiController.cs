using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FizzWare.NBuilder;
using RaportManager.Domian;

namespace RaportMaszynowy.Web.Controllers.Api
{
    public class ItemApiController : ApiController
    {
        // GET: api/ItemApi
        public IEnumerable<Item> Get()
        {
            var items =  Builder<Item>.CreateListOfSize(10).WhereAll().Build();
            return items; 
        }


        public IEnumerable<Item> GetNew(DateTime date)
        {
            return new List<Item>();
        }

        public bool ChangeStatus(int id, bool status)
        {

            Model1 db = new Model1();
            Item item = db.Item.Find(id);
            item.Status = status;
            db.SaveChanges();

            // znajdziesz item 
            //zmnienisz status 
            // zapiszesz 
            // ZROBIONE

            return true; 



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
