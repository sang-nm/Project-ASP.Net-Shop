using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Project_ASP.Net_Shop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //http://localhost:61090/Admin
            //http://localhost:61090/Admin/index
            //http://localhost:61090/Admin/create
            routes.MapRoute(
                 name: "Admin",
                 url: "Admin/{action}/{id}",
                 defaults: new { controller = "Admin", action = "index", id = UrlParameter.Optional }
             );
            //http://localhost:61090
            //http://localhost:61090/Home
            //http://localhost:61090/Home/Mainsite
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Mainsite", id = UrlParameter.Optional }
            );
        }
    }
}
