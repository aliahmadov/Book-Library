using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    internal class UserBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public int Pages { get; set; }
        public string Press { get; set; }
        public string Comment { get; set; }
        public double Price { get; set; }
        public int YearPress { get; set; }

    }
}
