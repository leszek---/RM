using System.Data.Entity.Migrations;
using RaportManager.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace RaportMaszynowy.Web.Controllers.Api
{

    public class GetItemsRequest
    {
        public DateTime? LastDate { get; set; }
    }

    public class ItemModel
    {
        public int ItemID { get; set; }

        public int ShiftNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public bool Status { get; set; }

        public string SettingsDescription { get; set;  }

        public bool Last { get; set;  }
    }

    public class ItemApiController : ApiController
    {




        [HttpPost]
        public List<ItemModel> GetItems([FromBody]GetItemsRequest request)
        {

            using (var context = new Model1())
            {
                var dbitems = context.Item.Where(x => true);

                if (request != null && request.LastDate.HasValue)
                {
                    dbitems = dbitems.Where(x => x.DateCreated > request.LastDate).OrderBy(x=>x.DateCreated);
                }

                var resposne = dbitems.ToList().Select(x => new ItemModel()
                {

                    ItemID = x.ItemID,
                    DateCreated = x.DateCreated,
                    SettingsDescription = x.Settings != null ? x.Settings.Content : "Brak Ustawień",
                    ShiftNumber = x.ShiftNumber,
                    Status = x.Status

                }).ToList();

          

                return resposne;
            }
        }

           [HttpPost]
        public bool Create([FromBody]Item item)
        {
            using (var context = new Model1())
            {
                var settings = context.Settings.SingleOrDefault(x => x.isActive);
                item.Settings = settings;
                context.Item.AddOrUpdate(item);
                context.SaveChanges();
                return true; 
            }
        }


           public bool UpdateItem([FromBody]ItemModel itemModel)
           {
               if (itemModel == null) throw new ArgumentNullException("item");
               using (var context = new Model1())
            {
                var dbitem = context.Item.SingleOrDefault(x => x.ItemID == itemModel.ItemID);
                if (dbitem != null) dbitem.Status = itemModel.Status;


                context.SaveChanges();
                return true;
            }
           }
    }
}