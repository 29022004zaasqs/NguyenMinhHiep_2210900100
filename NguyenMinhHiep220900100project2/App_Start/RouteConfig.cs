using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace NguyenMinhHiep220900100project2
{
    public class RouteConfig
{
    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

        // Route cho đăng nhập và đăng ký
        routes.MapRoute(
            name: "Account",
            url: "Account/{action}/{id}",
            defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
        );

        // Route cho Products (Nếu muốn cấu hình rõ ràng, không bắt buộc)
        routes.MapRoute(
            name: "Products",
            url: "Products/{action}/{id}",
            defaults: new { controller = "Products", action = "Index", id = UrlParameter.Optional }
        );

        // Route mặc định cho tất cả các controller khác
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );

    }
}
}