using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;
using WebTest.Models.EF;

namespace WebTest.Areas.Admin.Controllers
{
    public class ServiceImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/
        public ActionResult Index(int id)
        {
            ViewBag.ServiceId = id;
            var items = db.ServiceImages.Where(x => x.ServiceId == id).ToList();
            return View(items);
        }

        [HttpPost]
        public ActionResult AddImage(int ServiceId, string url)
        {
            db.ServiceImages.Add(new ServiceImage
            {
                ServiceId = ServiceId,
                Image = url,
                IsDefault = false
            });
            db.SaveChanges();
            return Json(new { Success = true });
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ServiceImages.Find(id);
            db.ServiceImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}