using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Achievers.Data.Models;

namespace Achievers.Infrastructure.Extensions
{
    public static class ControllerExtensions
    {
        public static async Task<IActionResult> ViewOrNotFound(this Controller controller, Func<Task<object>> source)
        {
            var model = await source();

            if (model == null)
            {
                return controller.NotFound();
            }

            return controller.View(model);
        }

        public static async Task<IActionResult> JsonOrNotFound(this Controller controller, Func<Task<object>> source)
        {
            var model = await source();

            if (model == null)
            {
                return controller.NotFound("no entities");
            }
            
            return controller.Json(model);
        }

        public static async Task<IActionResult> FileOrNotFound(this Controller controller, Func<Task<File>> source)
        {
            File model = await source();

            if (model == null)
            {
                return controller.NotFound();
            }
            
            return controller.File(model.Content, model.ContentType, model.Name);
        }
    }
}