using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<Review> Reviews { get; set; }
        
        public string Genre { get; set; }

        public Book()
        {
            Reviews = new List<Review>();
        }
    }
}
