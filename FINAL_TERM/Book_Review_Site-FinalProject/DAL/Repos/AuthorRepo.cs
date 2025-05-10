using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class AuthorRepo : Repo, IRepo<Author, int, Author>
    {
        public Author Create(Author obj)
        {
            db.Authors.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Authors.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Author Get(int id)
        {
            return db.Authors.Find(id);
        }

        public List<Author> Get()
        {
            return db.Authors.ToList();
        }

        public Author Update(Author obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
