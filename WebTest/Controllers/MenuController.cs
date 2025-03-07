using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuTop()
        {
            var items = db.Categories.OrderBy(x => x.Position).ToList();
            return PartialView("_MenuTop", items);
        }

        public ActionResult MenuServiceCategory()
        {
            var items = db.ServiceCategories.ToList();
            return PartialView("_MenuServiceCategory", items);
        }
        public ActionResult MenuLeft(int? id)
        {
            if (id != null)
            {
                ViewBag.CateId = id;
            }
            var items = db.ServiceCategories.ToList();
            return PartialView("_MenuLeft", items);
        }

        public ActionResult MenuArrivals()
        {
            var items = db.ServiceCategories.ToList();
            return PartialView("_MenuArrivals", items);
        }
        public ActionResult Home_MenuCategory()
        {
            var serviceCategories = db.ServiceCategories
                .Where(c => c.IsActive == true)
                .Select(c => new ServiceCategoryModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Icon = c.Icon,
                    Alias = c.Alias,
                    Services = db.Service
                        .Where(s => s.ServiceCategoryId == c.Id && s.IsActive == true)
                        .Select(s => new ServiceModel
                        {
                            Id = s.Id,
                            Title = s.Title,
                            Alias = s.Alias
                        }).ToList()
                }).ToList();

            return PartialView(serviceCategories);
        }




    }
}