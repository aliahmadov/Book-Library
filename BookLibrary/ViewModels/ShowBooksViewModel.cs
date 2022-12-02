using BookLibrary.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.ViewModels
{
    internal class ShowBooksViewModel:BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        public ShowBooksViewModel()
        {
            BackPage = App.MyGrid.Children[0];

            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });
        }
    }
}
