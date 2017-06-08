namespace Achiever.Web.Service
{
    using System.Web.Http;
    using System.Web.OData.Builder;
    using System.Web.OData.Extensions;
    using Achiever.Data.Models;
    using Infrastructure;
    using Microsoft.Owin.Security.OAuth;

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            // odata API routes
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            config.MaxTop(21);
            builder.EntitySet<Category>("Categories");
            builder.EntitySet<Achievement>("Achievements");
            builder.EntitySet<Evidence>("Evidence");

            FunctionConfiguration function = builder.Function("RootCategoryChildren");
            function.ReturnsFromEntitySet<Category>("Categories");

            config.MapODataServiceRoute(
                routeName: "odata",
                routePrefix: "odata",
                model: builder.GetEdmModel()
            );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{action}/{id}",
            //    defaults: new { controller = "Home", action = "Index", id = RouteParameter.Optional }
            //);

            // Web API Filters
            config.Filters.Add(new GlobalExceptionFilterAttribute());
        }
    }
}