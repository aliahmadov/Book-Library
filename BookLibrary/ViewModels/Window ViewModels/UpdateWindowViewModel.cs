using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.ViewModels.Window_ViewModels
{
    internal class UpdateWindowViewModel:BaseViewModel
    {
        private Book book;

        public Book Book
        {
            get { return book; }
            set { book = value; OnPropertyChanged(); }
        }

    }
}
