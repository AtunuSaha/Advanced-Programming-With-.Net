using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public virtual List<Book> Books { get; set; }

        public Author()
        {
            Books = new List<Book>();
        }
    }
}
