using System.Web.Http;
using AutoMapper;
using Achiever.Web.Infrastructure.Mapping;

namespace Achiever.Web.Service.Controllers.Base
{
    public class BaseController : ApiController
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}