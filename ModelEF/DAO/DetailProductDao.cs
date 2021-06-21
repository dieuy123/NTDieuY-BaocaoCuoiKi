using ModelEF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class DetailProductDao
    {
        private NguyenThiDieuYContext db;
        public DetailProductDao()
        {
            db = new NguyenThiDieuYContext();
        }
        public List<Product> ListWhereAll(string id)
        {
            return db.Products.ToList();
        }
    }
}
