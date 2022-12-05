using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    internal class SCardModel
    {
        public int Id { get; set; }
        public string StdFirstName { get; set; }

        public string StdLastName { get; set; }

        public string BookName { get; set; }
        public string LibFirstName { get; set; }

        public string LibLastName { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime DateOut { get; set; }
    }
}
