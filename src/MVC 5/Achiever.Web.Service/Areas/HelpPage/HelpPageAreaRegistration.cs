using System.Web.Http;
using System.Web.Mvc;

namespace Achiever.Web.Service.Areas.HelpPage
{
    public class HelpPageAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HelpPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
#if DEBUG
            context.MapRoute(
                "HelpPage_Default",
                "Help/{action}/{apiId}",
                new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });
#endif

            HelpPageConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}