using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class ReviewRepo : Repo, IRepo<Review, int, bool>, IReviewFeatures
    {
        public bool Create(Review obj)
        {
            db.Reviews.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Reviews.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Review Get(int id)
        {
            return db.Reviews.Find(id);
        }

        public List<Review> Get()
        {
            return db.Reviews.ToList();
        }

        public bool Update(Review obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }

        public List<Review> GetReviewsByBook(int bookId)
        {
            return db.Reviews.Where(r => r.BookId == bookId).ToList();
        }

        public List<Review> GetReviewsByReviewer(int reviewerId)
        {
            return db.Reviews.Where(r => r.ReviewerId == reviewerId).ToList();
        }

        public List<Review> SearchByBookTitle(string title)
        {
            return db.Reviews.Where(r => r.Book.Title.Contains(title)).ToList();
        }
       
    }
}
