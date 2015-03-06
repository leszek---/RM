using RaportManager.Domian;
using System;
using System.Web.Http;

namespace RaportMaszynowy.Web.Controllers.Api
{
    public class MachineStatusApiController : ApiController
    {
        public bool GetMachineStatus()
        {
            var status = MvcApplication.MashineStatus;
            return status;
        }

        public void ReportError()
        {
            using (var context = new Model1())
            {
                context.MachineError.Add(new MachineError()
                {
                    MachineErrorDate = DateTime.Now
                });

                context.SaveChanges();
            }
        }
    }
}