namespace Achiever.Web.Service.Controllers.Base
{
    using AutoMapper;
    using Achiever.Web.Infrastructure.Mapping;
    using System.Web.OData;
    using Achiever.Web.Service.Infrastructure;

    [GlobalExceptionFilter]
    public class BaseController : ODataController
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