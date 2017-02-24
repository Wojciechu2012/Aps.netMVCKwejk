using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ImageTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ImageGallery",
                url: "Gallery/{page}",
                defaults: new { controller = "ImageGallery", action = "Index", page = UrlParameter.Optional }
               
                );
            routes.MapRoute(
               name: "EditUser",
               url: "Edytuj/{id}",
               defaults: new { controller = "Manage", action = "ManageUsers"}

               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ImageGallery", action = "Index", id = UrlParameter.Optional }
                
            );
        }
    }
}
