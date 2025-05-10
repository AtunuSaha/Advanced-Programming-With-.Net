using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public double Rating { get; set; }
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int ReviewerId { get; set; }
        public string ReviewerName { get; set; }
    }
}
