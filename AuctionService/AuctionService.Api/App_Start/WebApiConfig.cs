using AuctionService.Api.Helpers;
using AuctionService.Data.DataContexts;
using AuctionService.Data.Repositories;
using AuctionService.Domain.Contracts.Repositories;
using AuctionService.Domain.Contracts.Services;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Web.Http;

namespace AuctionService.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            #region Dependency Injection
            var container = new UnityContainer();
            container.RegisterType<AuctionServiceContext, AuctionServiceContext>();

            container.RegisterType<IAuctionRepository, AuctionRepository>();

            container.RegisterType<IAuctionService, Business.Services.AuctionService>();

            config.DependencyResolver = new UnityResolver(container);
            #endregion

            ConfigureWebApi(config);
        }

        public static void ConfigureWebApi(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            formatters.Remove(formatters.XmlFormatter);

            var jsonSettings = formatters.JsonFormatter.SerializerSettings;
            jsonSettings.Formatting = Formatting.Indented;
            jsonSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
