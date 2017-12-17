using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Web.Http;
using TestApi;

[assembly: OwinStartup(typeof(Startup))]
namespace TestApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            WebApiConfig.Register(config);
            app.UseCors(CorsOptions.AllowAll);
            app.UseWebApi(config);
        }
    }
}