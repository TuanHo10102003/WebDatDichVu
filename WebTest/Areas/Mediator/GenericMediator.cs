using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTest.Models;

namespace WebTest.Areas.Mediator
{
    public class GenericMediator<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        public GenericMediator(ApplicationDbContext dbContext)
        {
            _db = dbContext;
        }

        public IPagedList<T> GetItems(Func<T, bool> filter, int pageIndex, int pageSize)
        {
            var items = _db.Set<T>().AsQueryable();
            if (filter != null)
            {
                items = items.Where(filter).AsQueryable();
            }

            return items.OrderByDescending(x => x.GetType().GetProperty("Id").GetValue(x)).ToPagedList(pageIndex, pageSize);
        }

        public T GetItemById(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public bool AddItem(T model)
        {
            try
            {
                _db.Set<T>().Add(model);
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool UpdateItem(T model)
        {
            try
            {
                _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteItem(int id)
        {
            var item = _db.Set<T>().Find(id);
            if (item != null)
            {
                _db.Set<T>().Remove(item);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool ToggleActiveStatus(int id, out bool isActive)
        {
            isActive = false;

            // Tìm item theo Id
            var item = _db.Set<T>().Find(id);
            if (item == null)
            {
                return false;
            }

            // Kiểm tra xem item có thuộc tính IsActive hay không
            var isActiveProperty = item.GetType().GetProperty("IsActive");
            if (isActiveProperty == null || !isActiveProperty.CanWrite)
            {
                return false;
            }

            // Đảo trạng thái IsActive
            var currentStatus = (bool)isActiveProperty.GetValue(item);
            isActive = !currentStatus;
            isActiveProperty.SetValue(item, isActive);

            // Lưu thay đổi vào database
            _db.Entry(item).State = System.Data.Entity.EntityState.Modified;
            _db.SaveChanges();

            return true;
        }
    }
}