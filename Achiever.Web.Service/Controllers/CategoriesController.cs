using Achiever.Data;
using Achiever.Data.Models;
using Achiever.Services.Data.Interfaces;
using Achiever.Web.Service.Controllers.Base;
using Achiever.Web.ViewModels;
using System.Net.Http;
using System.Web.Http;

namespace Achiever.Web.Service.Controllers
{
    public class CategoriesController : GenericBaseController<Category, CategoryViewModel>
    {
        public CategoriesController(ICategoriesService service)
            : base(service)
        {
        }

        [HttpGet]
        public HttpResponseMessage ReadAll()
        {
            return base.GetValues();
        }
        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            return base.Get(id);
        }
    }
}