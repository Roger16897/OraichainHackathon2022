using _1877_HA.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.WebHost;

namespace _1877_HA {

    public static class WebApiConfig {
        public static void Register(HttpConfiguration config)
        {
            var httpControllerRouteHandler = typeof(HttpControllerRouteHandler).GetField("_instance",
                          BindingFlags.Static |
                          BindingFlags.NonPublic);

            if (httpControllerRouteHandler != null)
            {
                httpControllerRouteHandler.SetValue(null,
                    new Lazy<HttpControllerRouteHandler>(() => new SessionHttpControllerRouteHandler(), true));
            }
            config.MapHttpAttributeRoutes();


        }
    }

}
