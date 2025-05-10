using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.Tables
{
    public class Review
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
       
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [ForeignKey("Reviewer")]
        public int ReviewerId { get; set; }
        public virtual Reviewer Reviewer { get; set; }
    }
}
