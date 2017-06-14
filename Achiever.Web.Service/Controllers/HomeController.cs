using System;
using System.Web.Http;

namespace Achiever.Web.Service.Controllers
{
    //[Authorize]
    public class HomeController : ApiController 
    {
        [HttpGet]
        public IHttpActionResult Index()
        {
            return this.Ok(true);
        }
    }
}