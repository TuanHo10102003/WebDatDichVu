using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Models;

namespace WebTest.Controllers
{
    public class IntroductionController : Controller
    {
        // GET: Introduction
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IntroductionList()
        {
            var IntroductionList = db.Introductions.Where(x => x.IsActive).ToList();
            return View(IntroductionList);
        }

    }
}