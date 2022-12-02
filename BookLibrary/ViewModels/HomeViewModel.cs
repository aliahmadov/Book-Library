using BookLibrary.Commands;
using BookLibrary.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.ViewModels
{
    internal class HomeViewModel:BaseViewModel
    {

        public RelayCommand AdminCommand { get; set; }

        public RelayCommand UserCommand { get; set; }

        public RelayCommand BackCommand { get; set; }

        public HomeViewModel()
        {

            AdminCommand = new RelayCommand(c =>
            {
                var adminUC = new AdminHomeUC();
                var viewModel = new AdminHomeViewModel();
                adminUC.DataContext = viewModel;

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(adminUC);
            });

            UserCommand = new RelayCommand(c =>
            {
                var userUc=new UserHomeUC();
                var userViewModel = new UserHomeViewModel();
                userUc.DataContext = userViewModel;

                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(userUc);
            });
        }
    }
}
