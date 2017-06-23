using Achievers.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Achievers.Models.Categories;
using Achievers.Data;
using Achievers.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Achievers.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly AchieversDbContext data;

        public CategoriesService(AchieversDbContext data)
        {
            this.data = data;
        }

        public async Task<List<CategoryViewModel>> AllAsync(int page, int pageSize)
        {
            var query = this.data.Categories.AsQueryable();
            
            return await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(CategoryViewModel.FromCategory)
                .ToListAsync();
        }

        public async Task<int> CreateAsync()
        {
            throw new NotImplementedException("todo");

            var newCategory = new Category
            {

            };

            this.data.Add(newCategory);
            await this.data.SaveChangesAsync();

            return newCategory.Id;
        }

        public async Task<CategoryDetailsViewModel> FindAsync(int id)
            => await this.data
                .Categories
                .Where(x => x.Id == id)
                .Select(CategoryDetailsViewModel.FromCategory)
                .FirstOrDefaultAsync();

        public async Task<List<CategoryViewModel>> GetChildrenAsync(int parentId)
            => await this.data
                .Categories
                .Where(x => x.ParentId == parentId)
                .Select(CategoryViewModel.FromCategory)
                .ToListAsync();
    }
}
