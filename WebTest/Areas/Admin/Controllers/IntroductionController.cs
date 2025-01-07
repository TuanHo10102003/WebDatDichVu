using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTest.Areas.Mediator;
using WebTest.Models;
using WebTest.Models.EF;

namespace WebTest.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class IntroductionController : Controller
    {
        private readonly GenericMediator<Introduction> _mediator;

        public IntroductionController()
        {
            var dbContext = new ApplicationDbContext();
            _mediator = new GenericMediator<Introduction>(dbContext);
        }

        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 5;
            var pageIndex = page ?? 1;

            var introductions = _mediator.GetItems(
                filter: x => string.IsNullOrEmpty(Searchtext) ||
                             x.Title.Contains(Searchtext) ||
                             x.Alias.Contains(Searchtext),
                pageIndex: pageIndex,
                pageSize: pageSize
            );

            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageIndex;

            return View(introductions);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Introduction model)
        {
            // Thiết lập dữ liệu mặc định cho Post
            model.CreatedDate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            model.Alias = WebTest.Models.Common.Filter.FilterChar(model.Title);
            model.CategoryId = 2;

            if (_mediator.AddItem(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var introductions = _mediator.GetItemById(id);
            if (introductions == null)
            {
                return HttpNotFound();
            }

            return View(introductions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Introduction model)
        {
            model.ModifiedDate = DateTime.Now;
            model.Alias = WebTest.Models.Common.Filter.FilterChar(model.Title);

            if (ModelState.IsValid && _mediator.UpdateItem(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var success = _mediator.DeleteItem(id);
            return Json(new { success });
        }


        public ActionResult IsActive(int id)
        {
            if (_mediator.ToggleActiveStatus(id, out bool isActive))
            {
                return Json(new { success = true, isActive });
            }
            return Json(new { success = false });
        }

    }
}