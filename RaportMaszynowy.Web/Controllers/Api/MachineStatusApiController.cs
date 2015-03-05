using System.Collections.Generic;
using System.Web.Http;
using FizzWare.NBuilder;

namespace RaportMaszynowy.Web.Controllers.Api
{
    public class MachineStatusApiController : ApiController
    {
  
        public bool GetMachineStatus()
        {

            var status = MvcApplication.MashineStatus;
            return status; 
        }


        public bool SetMachineStatus(bool value)
        {
            MvcApplication.MashineStatus = value;
            return value;
        }


    }
}
