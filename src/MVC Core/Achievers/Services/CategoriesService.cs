using Achievers.Data;
using Achievers.Data.Models;
using Achievers.Infrastructure.Mapping;
using Achievers.Models.Categories;
using Achievers.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Achievers.Services
{
    public class CategoriesService : BaseService, ICategoriesService
    {
        public CategoriesService(AchieversDbContext data)
            : base (data)
        {
        }

        public async Task<List<CategoryViewModel>> AllAsync(int page, int pageSize)
        {
            IQueryable<Category> query = this.Data.Categories.AsQueryable();
            
            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .To<CategoryViewModel>()
                //.Select(CategoryViewModel.FromCategory)
                .ToListAsync();
        }

        public async Task<int> CreateAsync()
        {
            throw new NotImplementedException("todo");

            Category newCategory = new Category
            {

            };

            this.Data.Add(newCategory);
            await this.Data.SaveChangesAsync();

            return newCategory.Id;
        }

        public async Task<CategoryDetailsViewModel> FindAsync(int id)
        {
            return await this.Data
                .Categories
                .Where(x => x.Id == id)
                .To<CategoryDetailsViewModel>()
                //.Select(CategoryDetailsViewModel.FromCategory)
                .FirstOrDefaultAsync();
        }

        public async Task<List<CategoryViewModel>> GetChildrenAsync(int? parentId)
        {
            return await this.Data
                .Categories
                .Where(x => x.ParentId == parentId)
                .To<CategoryViewModel>()
                //.Select(CategoryViewModel.FromCategory)
                .ToListAsync();
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await this.Data
                .Categories
                .AnyAsync(x => x.Id == id);
        }
    }
}