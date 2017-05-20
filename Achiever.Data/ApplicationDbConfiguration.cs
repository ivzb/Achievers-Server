namespace Achiever.Data
{
    using System.Data.Common;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public class ApplicationDbConfiguration : DbConfiguration
    {
        public ApplicationDbConfiguration()
        {
            SetManifestTokenResolver(new CustomManifestTokenResolver());
        }

        public class CustomManifestTokenResolver : IManifestTokenResolver
        {
            public string ResolveManifestToken(DbConnection connection)
            {
                return "2012";
            }
        }
    }
}