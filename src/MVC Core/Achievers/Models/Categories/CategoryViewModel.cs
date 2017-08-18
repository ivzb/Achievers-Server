using Achievers.Data.Models;
using Achievers.Infrastructure.Mapping;
using AutoMapper;

namespace Achievers.Models.Categories
{
    public class CategoryViewModel : IMapFrom<Category>, IMapTo<Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int? ParentId { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<CategoryViewModel, Category>()
                .ForMember(x => x.Id, m => m.Ignore());
        }
    }
}
