using RaportManager.Domian;
using System;
using System.Web.Http;

namespace RaportMaszynowy.Web.Controllers.Api
{
    public class MachineStatusApiController : ApiController
    {
        [HttpGet]
        public void ReportError()
        {
            using (var context = new Model1())
            {
                context.MachineError.Add(new MachineError()
                {
                    MachineErrorDate = DateTime.Now,
                    Description = "Brak"
                    
                });

                context.SaveChanges();
            }
        }
    }
}