using Achiever.Web.Helpers.ModelBinders;
using Achiever.Web.Infrastructure.Mapping;
using Achiever.Web.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Achiever.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            SetBinders();

            AutofacConfig.RegisterAutofac();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(AchievementViewModel).Assembly);
        }

        private void SetBinders()
        {
            ModelBinders.Binders.Add(typeof(DateTime), new CustomDateTimeBinder());
            ModelBinders.Binders.Add(typeof(DateTime?), new CustomNullDateTimeBinder());
        }
    }
}
