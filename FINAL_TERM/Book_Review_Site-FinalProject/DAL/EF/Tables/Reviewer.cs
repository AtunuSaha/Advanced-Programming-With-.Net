using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Reviewer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
        public virtual List<Review> Reviews { get; set; }

        public Reviewer()
        {
            Reviews = new List<Review>();
        }
    }
}
