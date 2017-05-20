using System.Collections.Generic;
using System.Net.Http;
using AutoMapper;
using Achiever.Web.Infrastructure.Mapping;

namespace Achiever.Tests.Web.Service.Base
{
    public abstract class BaseTestService
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
        protected IList<T> ParseResponseListDataTo<T>(HttpResponseMessage httpResponseMessage)
        {
            IList<T> result;
            httpResponseMessage.TryGetContentValue(out result);
            return result;
        }
        protected T ParseResponseDataTo<T>(HttpResponseMessage httpResponseMessage)
        {
            T result;
            httpResponseMessage.TryGetContentValue(out result);
            return result;
        }
    }
}
