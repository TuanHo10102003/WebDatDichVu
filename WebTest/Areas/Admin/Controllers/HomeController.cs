﻿using System;
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
            return View();
        }
    }
}