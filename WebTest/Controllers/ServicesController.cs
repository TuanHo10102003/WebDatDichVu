﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class ServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Services
        public ActionResult Index()
        {
            var items = db.Service.ToList();
            return View(items);
        }

        public ActionResult Detail(string alias, int id)
        {
            var item = db.Service.Find(id);
            if (item != null)
            {
                db.Service.Attach(item);
                item.ViewCount = item.ViewCount + 1;
                db.Entry(item).Property(x => x.ViewCount).IsModified = true;
                db.SaveChanges();
            }
            var countReview = db.Reviews.Where(x => x.ServiceId == id).Count();
            ViewBag.CountReview = countReview;
            return View(item);
        }
     
        public ActionResult ServiceCategory(string alias, int id)
        {
            var items = db.Service.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ServiceCategoryId == id).ToList();
            }
            var cate = db.ServiceCategories.Find(id);
            if (cate != null)
            {
                ViewBag.CateName = cate.Title;
            }

            ViewBag.CateId = id;
            return View(items);
        }

        public ActionResult Partial_ItemsByCateId()
        {
            var items = db.Service.Where(x => x.IsHome && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }

        public ActionResult Partial_ServiceSales()
        {
            var items = db.Service.Where(x => x.IsSale && x.IsActive).Take(12).ToList();
            return PartialView(items);
        }


    }
}