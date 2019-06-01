using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HamakaNext.Models
{
    public class Book
    {
        public int Id { get; set;}
        public string Title { get; set;}
        public string Author { get; set; }
        public DateTime Published { get; set; }
        public int PageCount { get; set; }
        public virtual User  User{ get; set; }
    }

}
