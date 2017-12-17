using TestApi.Controllers;
using TestApi.Core.Controllers;
using TestApi.Core.Services;

using Autofac;
using Autofac.Integration.WebApi;
using System.Net;
using System.Reflection;
using System.Web.Http;

namespace TestApi.App_Start
{
    public class DependencyContainer
    {
        public static IContainer BuildContainer(HttpConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(typeof(NotFoundController).GetTypeInfo().Assembly);
            builder.RegisterApiControllers(typeof(TestController).GetTypeInfo().Assembly);
            builder.RegisterApiControllers(typeof(TeamController).GetTypeInfo().Assembly);
            builder.RegisterApiControllers(typeof(PlayerController).GetTypeInfo().Assembly);
            builder.RegisterApiControllers(typeof(LeagueController).GetTypeInfo().Assembly);
            builder.RegisterWebApiFilterProvider(configuration);

            // Register all services.
            //TODO register alle services....
            builder.RegisterType<LeagueService>();
            builder.RegisterType<PlayerService>();
            builder.RegisterType<TeamService>();

            //builder.RegisterModule(new ServiceModule());
            //builder.RegisterType<LeagueService>().As<LeagueService>().InstancePerRequest();
            //builder.RegisterType<PlayerService>().As<PlayerService>().InstancePerRequest();
            //builder.RegisterType<TeamService>().As<TeamService>().InstancePerRequest();

            var container = builder.Build();
            return container;
        }
    }
}