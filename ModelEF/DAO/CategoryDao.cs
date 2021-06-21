using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class CategoryDao
    {
        private NguyenThiDieuYContext db;
        public CategoryDao()
        {
            db = new NguyenThiDieuYContext();
        }
        public IEnumerable<Category> ListWhereAll(string keySearch, int page, int pagesize)
        {
            IQueryable<Category> model = db.Categories;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.tenloai.Contains(keySearch));
            }

            return model.OrderBy(x => x.tenloai).ToPagedList(page, pagesize);
        }
        public List<Category> ListAll()
        {
            return db.Categories.ToList();
        }
        public bool FindName(string tenloai)
        {
            return db.Categories.Any(x => x.tenloai == tenloai);
        }
        public string Insert(Category entityCategory)
        {
            //var user = FindId(entityUser.admin_id);
            db.Categories.Add(entityCategory);
            db.SaveChanges();
            return entityCategory.tenloai;
        }
        public Category FindId(System.Int32 id)
        {
            return db.Categories.Find(id);
        }
        public string Update(Category entityCategory)
        {
            var category = FindId(entityCategory.maloai);
            var result = db.Categories.SingleOrDefault(x => x.maloai.Contains(entityCategory.maloai) );
            if (category != null)
            {
               result.tenloai = entityCategory.tenloai;
                result.mota = entityCategory.mota;
            }
            db.SaveChanges();
            return entityCategory.tenloai;
        }

        private object FindId(string maloai)
        {
            throw new NotImplementedException();
        }

        public bool Delete(System.Int32 id)
        {
            try
            {
                var category = db.Categories.Find(id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

