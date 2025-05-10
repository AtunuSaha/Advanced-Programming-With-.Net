using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IBookFeatures
    {
        List<Book> SearchByTitle(string title);
        List<Book> SearchByAuthor(string authorName);
        List<Book> GetRecommendationsByAuthor(int bookId);
        List<Book> GetRecommendationsByGenre(int bookId);
    }
}
