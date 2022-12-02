using BookLibrary.Commands;
using BookLibrary.Services;
using BookLibrary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.ViewModels
{
    internal class AdminHomeViewModel:BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }

        public RelayCommand ShowCommand { get; set; }

        public RelayCommand ModifyCommand { get; set; }

        public RelayCommand DeleteCommand { get; set; }
        public AdminHomeViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            ShowCommand = new RelayCommand(c =>
            {
                var showView = new ShowBooksUC();
                var viewModel = new ShowBooksViewModel();
                showView.DataContext=viewModel;
                showView.allBooksDataGrid.ItemsSource = DatabaseController.GetAllBooks();

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(showView);
            });

            ModifyCommand = new RelayCommand(c =>
            {
                var view = new ModifyUC();
                var viewModel = new ModifyViewModel();
                view.DataContext = viewModel;
                viewModel.ModifyDataGrid = view.modifyDataGrid;
                view.modifyDataGrid.ItemsSource = DatabaseController.GetAllBooks();
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(view);
            });



        }
    }
}
