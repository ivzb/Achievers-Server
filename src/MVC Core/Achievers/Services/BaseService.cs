using Achievers.Data;

namespace Achievers.Services
{
    public abstract class BaseService
    {
        private readonly AchieversDbContext data;

        public BaseService(AchieversDbContext data)
        {
            this.data = data;
        }

        protected AchieversDbContext Data
        {
            get => this.data;
        }
    }
}