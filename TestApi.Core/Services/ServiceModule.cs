using Autofac;

namespace TestApi.Core.Services
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder oBuilder)
        {
            //oBuilder.RegisterType<UserSessionStateCache>().SingleInstance();
            oBuilder.RegisterType<LeagueService>();
            oBuilder.RegisterType<PlayerService>();
            oBuilder.RegisterType<TeamService>();
        }
    }
}
