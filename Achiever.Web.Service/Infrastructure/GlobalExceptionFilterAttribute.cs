namespace Achiever.Web.Service.Infrastructure
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Filters;

    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            HttpRequestMessage request = context.Request;
            Exception exception = context.Exception;
            HttpError httpError = new HttpError(exception, includeErrorDetail: true);
            HttpResponseMessage response = request.CreateErrorResponse(HttpStatusCode.InternalServerError, httpError);
            context.Response = response;
        }
    }
}