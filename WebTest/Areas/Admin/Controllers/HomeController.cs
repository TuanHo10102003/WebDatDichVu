using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebTest.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]

    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.HomNay = HttpContext.Application["HomNay"];
            ViewBag.HomQua = HttpContext.Application["HomQua"];
            ViewBag.TuanNay = HttpContext.Application["TuanNay"];
            ViewBag.TuanTruoc = HttpContext.Application["TuanTruoc"];
            ViewBag.ThangNay = HttpContext.Application["ThangNay"];
            ViewBag.ThangTruoc = HttpContext.Application["ThangTruoc"];
            ViewBag.TatCa = HttpContext.Application["TatCa"];
            ViewBag.VisitorsOnline = HttpContext.Application["visitors_online"];



            return View();
        }
    }
}