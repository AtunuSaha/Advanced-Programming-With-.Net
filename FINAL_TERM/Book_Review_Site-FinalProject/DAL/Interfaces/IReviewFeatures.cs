using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IReviewFeatures
    {
        List<Review> GetReviewsByBook(int bookId);
        List<Review> GetReviewsByReviewer(int reviewerId);
        List<Review> SearchByBookTitle(string title);
        
    }
}
