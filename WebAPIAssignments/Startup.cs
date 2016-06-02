using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;
using System.Web.Http;

namespace WebAPIAssignments
{
    public class Startup
    {
        public void Configuration(IAppBuilder appbuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{Controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            appbuilder.UseWebApi(config);
        }
    }
}