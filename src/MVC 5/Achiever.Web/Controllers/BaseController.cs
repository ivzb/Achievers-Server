namespace Achiever.Web.Controllers
{
    using Achiever.Services.Web;
    using Achiever.Web.Infrastructure.Mapping;
    using AutoMapper;
    using System;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }

        [HttpPost]
        public ActionResult Export(string contentType, string base64, string fileName)
        {
            var fileContents = Convert.FromBase64String(base64);
            return File(fileContents, contentType, fileName);
        }
    }
}