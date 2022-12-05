using BookLibrary.Commands;
using BookLibrary.Models;
using BookLibrary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.ViewModels
{
    internal class UserHomeViewModel:BaseViewModel
    {
        public RelayCommand ShowCommand { get; set; }
        public RelayCommand TakeCommand { get; set; }
        public RelayCommand ReturnCommand { get; set; }
        public RelayCommand BackCommand { get; set; }


        public string TotalPrice { get; set; }

        private UserBook GetUserBook(Book book)
        {
            var dtx = new DataClassesDataContext();
            var author = dtx.Authors.FirstOrDefault(d => d.Id == book.Id_Author);
            var category = dtx.Categories.FirstOrDefault(d => d.Id == book.Id_Category);
            var press = dtx.Presses.FirstOrDefault(d => d.Id == book.Id_Press);

            return new UserBook
            {
                Id = book.Id,
                Author = author.FirstName + " " + author.LastName,
                Category = category.Name,
                Press = press.Name,
                Name = book.Name,
                Comment = book.Comment,
                Pages = book.Pages,
                YearPress = book.YearPress,
                Price = Convert.ToDouble(book.BookPrice)

            };
        }

        private List<UserBook> GetUserBooks()
        {
            var dtx = new DataClassesDataContext();
            var count = dtx.Books.Count();
 
            var books=new List<UserBook>();
            for (int i = 0; i < count; i++)
            {
                books.Add(GetUserBook(dtx.Books.Skip(i).First()));
            }
            return books;
        }



        public UserHomeViewModel()
        {

            BackPage = App.MyGrid.Children[0];

            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            ShowCommand = new RelayCommand(c =>
            {

                var dtx = new DataClassesDataContext();
               // var books = dtx.Books.Select(d => d.Quantity > 0);

                var view = new UserShowBooksUC();
                var viewModel = new UserShowBooksViewModel();
                view.DataContext = viewModel;
                view.userDataGrid.ItemsSource = GetUserBooks();

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);

            });


            TakeCommand = new RelayCommand(d =>
            {
                var view = new UserTakeBookUC();
                var viewModel = new UserTakeBookViewModel();
                view.DataContext = viewModel;
                TotalPrice = view.priceLbl.Content?.ToString();

                viewModel.TotalPrice = Convert.ToDouble(TotalPrice);
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);

            });

            ReturnCommand = new RelayCommand(d =>
            {
                var view = new UserReturnBook();
                var viewModel = new UserReturnBookViewModel();
                view.DataContext = viewModel;

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);

            });
        }
    }
}
