using BookLibrary.Commands;
using BookLibrary.ViewModels.Window_ViewModels.AdditionalViewModels;
using BookLibrary.Windows.Additional_Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BookLibrary.ViewModels.Window_ViewModels
{
    internal class InsertWindowViewModel : BaseViewModel
    {

        private Book book;

        public Book Book
        {
            get { return book; }
            set { book = value; OnPropertyChanged(); }
        }

        private string selectedAuthor;

        public string SelectedAuthor
        {
            get { return selectedAuthor; }
            set { selectedAuthor = value; OnPropertyChanged(); }
        }


        private string selectedCategory;

        public string SelectedCategory
        {
            get { return selectedCategory; }
            set { selectedCategory = value; OnPropertyChanged(); }
        }

        private string selectedPress;

        public string SelectedPress
        {
            get { return selectedPress; }
            set { selectedPress = value; OnPropertyChanged(); }
        }

        private string selectedThemes;

        public string SelectedThemes
        {
            get { return selectedThemes; }
            set { selectedThemes = value; OnPropertyChanged(); }
        }

        public string AddedAuthorName { get; set; }
        public string AddedAuthorSurname { get; set; }
        public string AddedCategory { get; set; }

        public string AddedPress { get; set; }

        public string AddedThemes { get; set; }
        public RelayCommand AddCategoryCommand { get; set; }
        public RelayCommand AddPressCommand { get; set; }
        public RelayCommand AddThemesCommand { get; set; }
        public RelayCommand AddAuthorCommand { get; set; }

        public void DefaultValueToRadioButtons(StackPanel stackPanel)
        {

            foreach (var item in stackPanel.Children)
            {
                var button = new Button();
                var comboBox = new ComboBox();
                if (item is StackPanel sP)
                {
                    foreach (var item2 in sP.Children)
                    {
                        if (item2 is StackPanel sP2)
                        {
                            foreach (var item3 in sP2.Children)
                            {
                                if (item3 is RadioButton rB)
                                {
                                    if (rB.Content.ToString() == "Choose")
                                    {
                                        rB.IsChecked = true;

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        public InsertWindowViewModel()
        {
            Book = new Book();

            AddAuthorCommand = new RelayCommand(c =>
            {
                var view = new AddAuthorWindow();
                var viewModel = new AddAuthorViewModel();
                view.DataContext = viewModel;
                view.ShowDialog();
                AddedAuthorName = viewModel.Name;
                AddedAuthorSurname = viewModel.Surname;
            });

            AddPressCommand = new RelayCommand(c =>
            {
                var view=new AddPressWindow();
                var viewModel = new AddPressViewModel();
                view.DataContext=viewModel;

                view.ShowDialog();
                AddedPress = viewModel.Name;
            });


            AddCategoryCommand = new RelayCommand(c =>
            {
                var view = new AddCategoryWindow();
                var viewModel = new AddCategoryViewModel();
                view.DataContext=viewModel;

                view.ShowDialog();
                AddedCategory=viewModel.Name;
            });

            AddThemesCommand = new RelayCommand(c =>
            {
                var view = new AddThemesWindow();
                var viewModel = new AddThemesViewModel();
                view.DataContext = viewModel;

                view.ShowDialog();
                AddedThemes = viewModel.Name;

            });

        }
    }
}
