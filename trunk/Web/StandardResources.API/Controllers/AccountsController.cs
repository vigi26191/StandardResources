using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace StandardResources.API.Controllers
{
    [RoutePrefix("api/accounts")]
    public class AccountsController : ApiController
    {
        public string Get()
        {
            return "done!";
        }
    }
}
