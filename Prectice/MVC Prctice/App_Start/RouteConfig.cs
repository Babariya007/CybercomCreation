using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_Prctice
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Home",
                url: "Home",
                defaults: new { controller = "Home", action = "Home" }
            ); 

            routes.MapRoute(
                name: "About",
                url: "About-Us",
                defaults: new { controller = "AboutUs", action = "AboutUs"}
            );

            routes.MapRoute(
                name: "EmployeeDetails",
                url: "EmployeeDetails",
                defaults: new { controller = "Employee", action = "Index" }
            );

            routes.MapRoute(
                name: "EmployeeDetailsByID",
                url: "EmployeeDetails/{id}",
                defaults: new { controller = "Employee", action = "GetDetailsByID" }
            );

            routes.MapRoute(
                name: "EmployeeDetailsByName",
                url: "EmployeeDetails/{id}/Name",
                defaults: new { controller = "Employee", action = "GetNameByID" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );  

        }
    }
}
