namespace Achiever.Data
{
    using System.Data.Entity;

    [DbConfigurationType(typeof(ApplicationDbConfiguration))] // todo: inspect if this works
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=AchieverConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}