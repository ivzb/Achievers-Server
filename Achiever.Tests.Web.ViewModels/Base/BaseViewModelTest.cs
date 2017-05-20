namespace Achiever.Tests.Web.ViewModels
{
    using Achiever.Web.Infrastructure.Mapping;
    using Achiever.Web.ViewModels;
    using AutoMapper;

    public abstract class BaseViewModelTest
    {
        public BaseViewModelTest()
        {
            AutoMapperConfig automapperConfig = new AutoMapperConfig();
            automapperConfig.Execute(typeof(AchievementViewModel).Assembly);
        }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}