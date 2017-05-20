using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Achiever.Data;
using Achiever.Data.Common;
using Achiever.Services.Data;
using Achiever.Services.Data.Interfaces;
using Achiever.Services.Web;
using Achiever.Web.Service.Controllers.Base;

namespace Achiever.Web.Service
{
    public static class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            // Register your MVC controllers.
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterWebApiModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiModelBinderProvider();

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterWebApiFilterProvider(config);

            // Register services
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.Register(x => new ApplicationDbContext()) 
                .As<DbContext>()
                .InstancePerRequest();
            builder.Register(x => new HttpCacheService())
                .As<ICacheService>()
                .InstancePerRequest();
            builder.Register(x => new IdentifierProvider())
                .As<IIdentifierProvider>()
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(DbRepository<>))
                .As(typeof(IDbRepository<>))
                .InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AssignableTo<BaseController>().PropertiesAutowired();

            builder.RegisterType<NomenclatureData>()
               .As<INomenclatureData>()
               .InstancePerRequest();

            builder.RegisterGeneric(typeof(DefaultService<>))
                .As(typeof(IDefaultService<>))
                .InstancePerRequest();

            var servicesAssembly = Assembly.GetAssembly(typeof(IAchievementsService));
            builder.RegisterAssemblyTypes(servicesAssembly).AsImplementedInterfaces();
        }
    }
}