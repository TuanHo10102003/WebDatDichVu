using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "Contact",
              url: "lien-he",
              defaults: new
              {
                  controller = "Contact",
                  action = "Index",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "CheckOut",
              url: "thanh-toan",
              defaults: new
              {
                  controller = "ShoppingCart",
                  action = "CheckOut",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );

            routes.MapRoute(
              name: "ShoppingCart",
              url: "gio-hang",
              defaults: new
              {
                  controller = "ShoppingCart",
                  action = "Index",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "CategoryService",
              url: "danh-muc-dich-vu/{alias}-{id}",
              defaults: new
              {
                  controller = "Services",
                  action = "ServiceCategory",
                  id = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "DetailPost",
              url: "bai-viet/{alias}-{id}",
              defaults: new
              {
                  controller = "Posts",
                  action = "Detail",
                  id = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "AdvList",
              url: "Adv",
              defaults: new
              {
                  controller = "Adv",
                  action = "Index",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "DetailAdv",
              url: "Adv/{alias}-{id}",
              defaults: new
              {
                  controller = "Adv",
                  action = "Detail",
                  id = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "PostsList",
              url: "bai-viet",
              defaults: new
              {
                  controller = "Posts",
                  action = "Index",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "detailService",
              url: "chi-tiet/{alias}-{id}",
              defaults: new
              {
                  controller = "Services",
                  action = "Detail",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "Services",
              url: "dich-vu",
              defaults: new
              {
                  controller = "Services",
                  action = "Index",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "DetailNew",
              url: "tin-tuc/{alias}-{id}",
              defaults: new
              {
                  controller = "News",
                  action = "Detail",
                  id = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "NewsList",
              url: "tin-tuc",
              defaults: new
              {
                  controller = "News",
                  action = "Index",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );

            routes.MapRoute(
              name: "Adv",
              url: "quang-cao",
              defaults: new
              {
                  controller = "Adv",
                  action = "Index",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "IntroductionList",
              url: "gioi-thieu",
              defaults: new
              {
                  controller = "Introduction",
                  action = "IntroductionList",
                  alias = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new
              {
                  controller = "Home",
                  action = "Index",
                  id = UrlParameter.Optional
              },
              namespaces: new[] {
          "WebTest.Controllers"
              }
            );
        }

    }
}