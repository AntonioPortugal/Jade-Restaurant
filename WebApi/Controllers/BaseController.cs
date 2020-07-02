using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RECODME.RD.Jade.WebApi.Controllers
{
    public class BaseController : ControllerBase
    {
        public StatusCodeResult InternalServerError()
        {
            return StatusCode((int)HttpStatusCode.InternalServerError);
        }

        public StatusCodeResult NotModified()
        {
            return StatusCode((int)HttpStatusCode.NotModified);
        }
    }
}
