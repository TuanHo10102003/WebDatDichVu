using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;
using WebTest.Models.EF;

namespace WebTest.Controllers
{
    public class AdvController : Controller
    {
        // GET: Poster
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index(int? page)
        {
            var pageSize = 5;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Adv> items = db.Advs.OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Detail(int id)
        {
            var item = db.Advs.Find(id);
            return View(item);
        }
        public ActionResult GetImage()
        {
            Adv item = db.Advs.FirstOrDefault();
            return PartialView(item);
        }


    }
}