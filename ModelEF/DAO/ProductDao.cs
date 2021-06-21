using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class ProductDao
    { 


   private NguyenThiDieuYContext db;
    public ProductDao()
    {
        db = new NguyenThiDieuYContext();
    }
    public List<Product> ListAll()
    {
        return db.Products.ToList();
    }
    public IEnumerable<Product> ListWhereAll(string keySearch, int page, int pagesize)
    {
        IQueryable<Product> model = db.Products;
        if (!string.IsNullOrEmpty(keySearch))
        {
            model = model.Where(x => x.tensp.Contains(keySearch));
        }

        return model.OrderBy(x => x.tensp).ToPagedList(page, pagesize);
    }

        //public object ListWhereAll(string searchString)
        //{
        //    throw new NotImplementedException();
        //}

        public bool FindName(string brandname)
    {
        return db.Products.Any(x => x.tensp == brandname);
    }
    public string Insert(Product entityBrand)
    {
        //var user = FindId(entityUser.admin_id);
        db.Products.Add(entityBrand);
        db.SaveChanges();
        return entityBrand.tensp;
    }
    public Product FindId(string tensp)
    {
        return db.Products.Find(tensp);
    }
    public string Update(Product entityPro)
    {
        var pro = FindId(entityPro.tensp);
        if (pro != null)
        {
                pro.tensp = entityPro.tensp;
                pro.maloai = entityPro.maloai;
                pro.dongia = entityPro.dongia;
                pro.soluong = entityPro.soluong;
                pro.Image = entityPro.Image;
                pro.trangthai = entityPro.trangthai;
                pro.mota = entityPro.mota;
                pro.mausac = entityPro.mausac;

            }
        db.SaveChanges();
        return entityPro.tensp;
    }

        public object FindId(object masp)
        {
            throw new NotImplementedException();
        }

        public bool Delete(string id)
    {
        try
        {
            var pro = db.Products.Find(id);
            db.Products.Remove(pro);
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
