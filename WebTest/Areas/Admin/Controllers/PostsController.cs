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
    public class PostsController : Controller
    {
        private readonly GenericMediator<Posts> _mediator;

        public PostsController()
        {
            var dbContext = new ApplicationDbContext();
            _mediator = new GenericMediator<Posts>(dbContext);
        }

        public ActionResult Index(string Searchtext, int? page)
        {
            var pageSize = 5; // Số lượng item mỗi trang
            var pageIndex = page ?? 1; // Trang hiện tại

            // Lấy danh sách các Post theo bộ lọc và phân trang
            var posts = _mediator.GetItems(
                filter: x => string.IsNullOrEmpty(Searchtext) ||
                             x.Title.Contains(Searchtext) ||
                             x.Alias.Contains(Searchtext),
                pageIndex: pageIndex,
                pageSize: pageSize
            );

            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageIndex;

            return View(posts);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Posts model)
        {
            // Thiết lập dữ liệu mặc định cho Post
            model.CreatedDate = DateTime.Now;
            model.ModifiedDate = DateTime.Now;
            model.Alias = WebTest.Models.Common.Filter.FilterChar(model.Title);
            model.CategoryId = 14;

            if (_mediator.AddItem(model))
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var post = _mediator.GetItemById(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Posts model)
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