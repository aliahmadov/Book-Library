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
        public DateTime DateIn { get; set; }

        public RentCodeGenerator(int id,int stdId, DateTime dateIn, int cardId)
        {
            Code = new Guid();
            Code = Guid.NewGuid();
            BookId = id;
            StudentId = stdId;
            DateIn = dateIn;
            S_CardId = cardId;
        }

    }
}
