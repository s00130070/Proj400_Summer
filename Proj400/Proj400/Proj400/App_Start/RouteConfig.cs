using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Proj400
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(null, "", new
            {
                Controller = "ProductInfo",
                Action = "List",
                catagory = (string)null,
                page = 1
            });

            //Default
            //routes.MapRoute(
            //    name: "Default",
            //    url: "{controller}/{action}/{id}",
            //    defaults: new { controller = "ProductInfo", action = "Home", id = UrlParameter.Optional }
            //);

            // Other Routes

            routes.MapRoute(null, "Page{page}", new
            {
                Controller = "ProductInfo",
                Action = "List",
                catagory = (string)null,
            },
            new { page = @"\d+" }
            );

            //routes.MapRoute(null, "{category}", new
            //{
            //    Controller = "ProductInfo",
            //    action = "List",
            //    Page = 1
            //});

            routes.MapRoute(null, "category/Page{page}", new
            {
                Controller = "ProductInfo",
                action = "List",
            },
            new { page = @"\d+" }
            );

            routes.MapRoute(null, "{controller}/{action}");





            // routes.MapRoute(
            //     name: "Cart-New",
            //     url: "Cart/new",
            //     defaults: new { controller = "Cart", action = "New" },
            //     constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
            // );

            routes.MapRoute(
               name: "Cart",
               url: "Cart",
               defaults: new { controller = "Cart", action = "New" },
               constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "GET" }) }
           );

            routes.MapRoute(
                name: "Cart-Create",
                url: "Cart",
                defaults: new { controller = "Cart", action = "Create" },
                constraints: new { httpMethod = new HttpMethodConstraint(new string[] { "POST" }) }
            );

            routes.MapRoute(
                name: "Cart-Show",
                url: "Cart/{id}",
                defaults: new { controller = "Cart", action = "Show" }
            );

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Cart", action = "New" }
            );
        }
    }
}
