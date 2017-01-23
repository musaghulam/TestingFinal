using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.Cors;

namespace Testing
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //var jsonpFormatter =  new JsonpMediaTypeFormatter(config.Formatters.JsonFormatter);
            //config.Formatters.Insert(0, jsonpFormatter);

            //EnableCorsAttribute Cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors();

          
           
        }
    }
}
