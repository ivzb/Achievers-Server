using System.Web.Mvc;

namespace Achiever.Web.Controllers
{
    public class ErrorController : BaseController
    {
        public ActionResult Unexpected()
        {
            return View("Error");
        }
    }
}