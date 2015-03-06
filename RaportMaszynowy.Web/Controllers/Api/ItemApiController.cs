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

        public bool ChangeStatus(int id, bool statu)
        {
            using (var context = new Model1())
            {
                var dbitem = context.Item.SingleOrDefault(x => x.ItemID == id);

                if (dbitem != null)
                {
                    dbitem.Status = statu;
                }

                context.SaveChanges();
                return true;
            }
        }
    }
}