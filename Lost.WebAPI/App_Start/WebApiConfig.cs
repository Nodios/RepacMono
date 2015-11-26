using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Net.Http.Headers;

namespace Lost.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            //Send JSON on most queries, get XML when send text/xml
            //config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            //Enable CORS(Cross-Origin Requests)
            //config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            //Setup for paging
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApiWithActions",
            //    routeTemplate: "api/{controller}/{action}/{param1}/{param2}",
            //    defaults: new
            //    {
            //        param1 = RouteParameter.Optional,
            //        param2 = RouteParameter.Optional
            //    }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
