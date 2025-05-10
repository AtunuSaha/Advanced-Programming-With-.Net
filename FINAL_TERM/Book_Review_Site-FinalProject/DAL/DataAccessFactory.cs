using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Book, int, Book> BookData()
        {
            return new BookRepo();
        }

        public static IBookFeatures BookFeatures()
        {
            return new BookRepo();
        }

        public static IRepo<Review, int, bool> ReviewData()
        {
            return new ReviewRepo();
        }

        public static IReviewFeatures ReviewFeatures()
        {
            return new ReviewRepo();
        }

        public static IRepo<Reviewer, int, Reviewer> ReviewerData()
        {
            return new ReviewerRepo();
        }

        public static IRepo<Author, int, Author> AuthorData()
        {
            return new AuthorRepo();
        }
    }
}
