using RaportManager.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RaportMaszynowy.Web.Controllers.Api
{
    public class ItemApiController : ApiController
    {
        public IEnumerable<Item> Get(DateTime? lastData)
        {
            using (var context = new Model1())
            {
                var dbitems = context.Item.Where(x => true);

                if (lastData.HasValue)
                {
                    dbitems = dbitems.Where(x => x.DateCreated > lastData);
                }

                var resposne = dbitems.ToList();
                return resposne;
            }
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

                if (dbitem != null)
                {
                    dbitem.Status = status;
                }

                context.SaveChanges();
                return true;
            }
        }
    }
}