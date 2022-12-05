using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.Models
{
    internal class RentCodeGenerator
    {
        public Guid Code { get; set; }

        public int S_CardId { get; set; }
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime? DateIn { get; set; }

        public DateTime DateOut { get; set; }
        public int DayCount { get; set; }


        public RentCodeGenerator(int id, int stdId, int cardId, int dayCount, DateTime dateOut)
        {
            Code = new Guid();
            Code = Guid.NewGuid();
            BookId = id;
            StudentId = stdId;
            S_CardId = cardId;
            DayCount = dayCount;
            DateOut = dateOut;
        }

    }
}
