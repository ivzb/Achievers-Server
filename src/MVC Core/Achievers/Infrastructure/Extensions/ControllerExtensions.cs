using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Achievers.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static async Task<IActionResult> ViewOrNotFound(this Controller controller, Func<Task<object>> getModelFunc)
        {
            var model = await getModelFunc();

            if (model == null)
            {
                return controller.NotFound();
            }

            return controller.View(model);
        }

        public static async Task<IActionResult> JsonOrNotFound(this Controller controller, Func<Task<object>> getModelFunc)
        {
            var model = await getModelFunc();

            if (model == null)
            {
                return controller.NotFound();
            }
            
            return controller.Json(model);
        }
    }
}
