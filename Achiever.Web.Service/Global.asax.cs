using Achiever.Web.Infrastructure.Mapping;
using Achiever.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Achiever.Web.Service
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(AchievementViewModel).Assembly);
            var formatter = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            formatter.SerializerSettings.DateFormatString = "dd/MM/yyyy HH:mm:ss";
        }
    }
}
