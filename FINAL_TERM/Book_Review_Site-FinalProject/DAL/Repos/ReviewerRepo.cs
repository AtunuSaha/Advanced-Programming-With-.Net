using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReviewerRepo : Repo, IRepo<Reviewer, int, Reviewer>
    {
        public Reviewer Create(Reviewer obj)
        {
            db.Reviewers.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Reviewers.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Reviewer Get(int id)
        {
            return db.Reviewers.Find(id);
        }

        public List<Reviewer> Get()
        {
            return db.Reviewers.ToList();
        }

        public Reviewer Update(Reviewer obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }
    }
}
