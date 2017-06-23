using Achievers.Infrastructure.Extensions;
using Achievers.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Achievers.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categories;

        public CategoriesController(
            ICategoriesService categories)
        {
            this.categories = categories;
        }

        public async Task<IActionResult> Details(int id)
            => await this.JsonOrNotFound(async () => await this.categories.FindAsync(id));
        
    
    }
}
