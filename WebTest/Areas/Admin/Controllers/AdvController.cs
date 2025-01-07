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
    public class AdvController : Controller
    {
        private readonly GenericMediator<Adv> _mediator;

        public AdvController()
        {
            var dbContext = new ApplicationDbContext();
            _mediator = new GenericMediator<Adv>(dbContext);
        }

        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 5; // Số lượng item mỗi trang
            var pageIndex = page ?? 1; // Trang hiện tại

            var Adv = _mediator.GetItems(
                filter: x => string.IsNullOrEmpty(Searchtext) ||
                             x.Title.Contains(Searchtext) ||
                             x.Alias.Contains(Searchtext),
                pageIndex: pageIndex,
                pageSize: pageSize
            );

            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageIndex;

            return View(Adv);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Adv model)
        {
            // Thiết lập dữ liệu mặc định cho Adv
            model.CreatedDate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            model.Alias = WebTest.Models.Common.Filter.FilterChar(model.Title);
            model.CategoryId = 6;

            if (_mediator.AddItem(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var Adv = _mediator.GetItemById(id);
            if (Adv == null)
            {
                return HttpNotFound();
            }

            return View(Adv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Adv model)
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