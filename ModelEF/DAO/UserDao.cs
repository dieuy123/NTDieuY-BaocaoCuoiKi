using ModelEF.Model;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEF.DAO
{
    public class UserDao
    {
        private NguyenThiDieuYContext db;
        public UserDao()
        {
            db = new NguyenThiDieuYContext();
        }

        //    public UserDao()
        //    {
        //        db = new NTDieuYContext();

        //}
        //    public int login(String user,string pass)
        //    {
        //        var resul = db.User.SingleOrDefault(x => x.Username)
        //    }
        public int login(string user, string pass)
        {
            var result = db.UserAccounts.SingleOrDefault(x => x.UserName.Contains(user) && x.Password.Contains(pass));
            if (result == null)
            {
                return 0;
            }
            else { return 1; }
        }



        public IEnumerable<UserAccount> ListWhereAll(string keySearch, int page, int pagesize)
        {
            IQueryable<UserAccount> model = db.UserAccounts;
            if (!string.IsNullOrEmpty(keySearch))
            {
                model = model.Where(x => x.UserName.Contains(keySearch));
            }

            return model.OrderBy(x => x.UserName).ToPagedList(page, pagesize);
        }
        public UserAccount FindId(System.Int32 admin_id)
        {
            return db.UserAccounts.Find(admin_id);
        }
        public bool FindId(string Username)
        {
            return db.UserAccounts.Any(x => x.UserName == Username);
        }
        public string Insert(UserAccount entityUser)
        {
            db.UserAccounts.Add(entityUser);
            db.SaveChanges();
            return entityUser.UserName;
        }
        public string Update(UserAccount entityUser)
        {
            var user = FindId(entityUser.ID);
            if (user != null)
            {
                user.UserName = entityUser.UserName;
                if (!string.IsNullOrEmpty(entityUser.Password))
                {
                    user.Password = entityUser.Password;
                }
            }
            db.SaveChanges();
            return entityUser.UserName;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = (UserAccount)db.UserAccounts.Find(id);
                db.UserAccounts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //public bool FindName(string userName)
        //{
        //    throw new NotImplementedException();
        //}
    }

    //public List<UserAccount> ListAll()
    //    {

    //        var list = db.Database.SqlQuery<UserAccount>("Sp_UserAccount_ListAll").ToList();
    //        return list;

    //    }
        
    }



