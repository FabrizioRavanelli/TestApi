using Autofac.Integration.WebApi;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using TestApi.App_Start;

namespace TestApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web-API-Konfiguration und -Dienste
            config.DependencyResolver = new AutofacWebApiDependencyResolver(DependencyContainer.BuildContainer(config));

            // Web-API-Routen
            config.MapHttpAttributeRoutes();

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
            config.Routes.MapHttpRoute(
               name: "Error404",
               routeTemplate: "api/{*url}",
               defaults: new { controller = "NotFound", action = "ErrorNotFound" }
            );

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            jsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
