using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Linq;

namespace Achievers.Infrastructure.Validation
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public string ViewName { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Request.Method != "POST")
            {
                return;
            }

            var controller = context.Controller as Controller;

            if (controller == null)
            {
                return;
            }

            if (!context.ModelState.IsValid)
            {
                var viewName = this.ViewName ?? context.RouteData.Values["action"] as string;
                var model = context.ActionArguments.First().Value;

                context.Result = new ViewResult
                {
                    ViewName = viewName,
                    ViewData = new ViewDataDictionary(controller.ViewData)
                    {
                        Model = model
                    }
                };
            }
        }
    }
}
