using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FizzWare.NBuilder;
using RaportManager.Domian;

namespace RaportMaszynowy.Web.Controllers.Api
{
    public class ItemSettingsApiController : ApiController
    {

        public Settings GetActive()
        {
            using (var context = new Model1())
            {
               var dbItem = context.Settings.SingleOrDefault(x => x.isActive == true);
                return dbItem;
            }
        }


    }
}
