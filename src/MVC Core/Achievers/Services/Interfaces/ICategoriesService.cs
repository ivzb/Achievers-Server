using Achievers.Models.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Achievers.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<CategoryDetailsViewModel> FindAsync(int id);

        Task<List<CategoryViewModel>> AllAsync(int page, int pageSize);

        Task<List<CategoryViewModel>> GetChildrenAsync(int parentId);
        
        Task<int> CreateAsync();

        Task<bool> ExistAsync(int id);
    }
}
