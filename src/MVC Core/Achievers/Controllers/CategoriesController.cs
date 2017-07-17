﻿using Achievers.Infrastructure.Extensions;
using Achievers.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Achievers.Controllers
{
    //[Authorize]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public async Task<IActionResult> Details(int id)
        {
            return await this.JsonOrNotFound(async () => await this.categories.FindAsync(id));
        }

        public async Task<IActionResult> Children(int? parentId)
        {
            if (parentId != null)
            {
                if (!(await this.categories.ExistAsync(parentId.Value)))
                {
                    return this.NotFound(parentId);
                }
            }

            return await this.JsonOrNotFound(async () => await this.categories.GetChildrenAsync(parentId));
        }
    }
}