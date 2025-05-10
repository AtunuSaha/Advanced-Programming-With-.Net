using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
