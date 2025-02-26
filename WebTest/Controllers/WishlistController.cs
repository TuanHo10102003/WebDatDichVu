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
    [Authorize]
    public class WishlistController : Controller
    {
        // GET: Wishlist
        public ActionResult Index(int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            IEnumerable<Wishlist> items = db.Wishlists.Where(x => x.UserName == User.Identity.Name).OrderByDescending(x => x.CreatedDate);
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostWishlist(int ServiceId)
        {
            if (Request.IsAuthenticated == false)
            {
                return Json(new { Success = false, Message = "Bạn chưa đăng nhập." });
            }
            var checkItem = db.Wishlists.FirstOrDefault(x => x.ServiceId == ServiceId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                return Json(new { Success = false, Message = "Dịch vụ đã được yêu thích rồi." });
            }
            var item = new Wishlist();
            item.ServiceId = ServiceId;
            item.UserName = User.Identity.Name;
            item.CreatedDate = DateTime.Now;
            db.Wishlists.Add(item);
            db.SaveChanges();
            return Json(new { Success = true });
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PostDeleteWishlist(int ServiceId)
        {
            var checkItem = db.Wishlists.FirstOrDefault(x => x.Id  == ServiceId && x.UserName == User.Identity.Name);
            if (checkItem != null)
            {
                var item = db.Wishlists.Find(checkItem.Id);
                db.Set<Wishlist>().Remove(item);
                var i = db.SaveChanges();
                return Json(new { Success = true, Message = "Xóa thành công." });
            }
            return Json(new { Success = false, Message = "Xóa thất bại." });
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}