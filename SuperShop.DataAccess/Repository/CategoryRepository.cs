using SuperShop.DataAccess.Data;
using SuperShop.DataAccess.Repository.IRepository;
using SuperShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShop.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
           _db.SaveChanges();
        }

        public void Update(Category obj)
        {
            _db.Update<Category>(obj);
        }
    }
}
