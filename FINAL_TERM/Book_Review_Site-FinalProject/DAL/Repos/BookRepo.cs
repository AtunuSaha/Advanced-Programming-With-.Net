using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class BookRepo : Repo, IRepo<Book, int, Book>, IBookFeatures
    {
        public Book Create(Book obj)
        {
            db.Books.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            var ex = Get(id);
            db.Books.Remove(ex);
            return db.SaveChanges() > 0;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }

        public List<Book> Get()
        {
            return db.Books.ToList();
        }

        public Book Update(Book obj)
        {
            var ex = Get(obj.Id);
            db.Entry(ex).CurrentValues.SetValues(obj);
            db.SaveChanges();
            return obj;
        }

        public List<Book> SearchByTitle(string title)
        {
            return db.Books.Where(b => b.Title.Contains(title)).ToList();
        }

        public List<Book> SearchByAuthor(string authorName)
        {
            return db.Books.Where(b => b.Author.Name.Contains(authorName)).ToList();
        }

        public List<Book> GetRecommendationsByAuthor(int bookId)
        {
            var book = Get(bookId);
            return db.Books.Where(b => b.AuthorId == book.AuthorId && b.Id != bookId).ToList();
        }

        public List<Book> GetRecommendationsByGenre(int bookId)
        {
            var book = Get(bookId);
            return db.Books.Where(b => b.Genre == book.Genre && b.Id != bookId).ToList();
        }
    }
}
