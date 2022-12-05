using BookLibrary.Commands;
using BookLibrary.Models;
using BookLibrary.Services;
using BookLibrary.ViewModels.Window_ViewModels;
using BookLibrary.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace BookLibrary.ViewModels
{
    internal class ModifyViewModel : BaseViewModel
    {
        public RelayCommand BackCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public DataGrid ModifyDataGrid { get; set; }

        private Book selectedBook;

        public Book SelectedBook
        {
            get { return selectedBook; }
            set { selectedBook = value; OnPropertyChanged(); }
        }

        public Book InsertedBook { get; set; }

        private bool IsFull(Book book)
        {
            if (book.Name.Length == 0 || book.Comment.Length == 0)
            {
                return false;
            }
            return true;
        }

        private bool IsFullInsertForum(Book book)
        {
            if (book.Id == 0 || book.Id_Press == 0 || book.Id_Category == 0 ||
                book.Id_Author == 0 || book.Id_Themes == 0
                || book.Name == null || book.Comment == null)
                return false;
            return true;
        }

        public ModifyViewModel()
        {
            BackPage = App.MyGrid.Children[0];
            InsertedBook = new Book();
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });

            UpdateCommand = new RelayCommand(c =>
            {
                var updateView = new UpdateWindow();
                var viewModel = new UpdateWindowViewModel();
                updateView.DataContext = viewModel;
                if (SelectedBook != null)
                {
                    viewModel.Book = SelectedBook;
                    string oldName = SelectedBook.Name;
                    string oldComment = SelectedBook.Comment;
                    updateView.ShowDialog();
                    if (IsFull(viewModel.Book))
                    {
                        var b = viewModel.Book;
                        DatabaseController.UpdateBook(b.Id, b.YearPress, b.Comment, b.Name, b.Pages, b.Quantity);
                        MessageBox.Show($"Book with ID {SelectedBook.Id} has been updated successfully", "Success",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        viewModel.Book.Name = oldName;
                        viewModel.Book.Comment = oldComment;
                        MessageBox.Show("Make sure all fields are entered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No book has been selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            });

            InsertCommand = new RelayCommand(c =>
            {
                DataClassesDataContext dtx = new DataClassesDataContext();
                var insertView = new InsertWindow();
                var insertViewModel = new InsertWindowViewModel();
                insertView.DataContext = insertViewModel;
                insertView.authorCmbBox.ItemsSource = SpecialServices.GetAuthors();
                insertView.ctgCmbBox.ItemsSource = SpecialServices.GetCategories();
                insertView.pressCmbBox.ItemsSource = SpecialServices.GetPresses();
                insertView.themesCmbBox.ItemsSource = SpecialServices.GetThemes();
                insertViewModel.DefaultValueToRadioButtons(insertView.insertStackPanel);
                insertView.ShowDialog();

                var theme = new Theme();
                var category = new Category();
                var author = new Author();
                var press = new Press();

                if (insertViewModel.SelectedPress == null)
                {
                    if (insertViewModel.AddedPress != null)
                    {
                        press.Name = insertViewModel.AddedPress;
                        var lastID = dtx.Presses.Skip(dtx.Presses.Count() - 1).First().Id;
                        press.Id = lastID + 1;
                        DatabaseController.InsertPress(press);
                        InsertedBook.Id_Press = press.Id;
                    }
                }
                else
                {
                    press.Id = dtx.Presses.FirstOrDefault(d => d.Name == insertViewModel.SelectedPress).Id;
                    InsertedBook.Id_Press = press.Id;
                }

                if (insertViewModel.SelectedThemes == null)
                {
                    if (insertViewModel.AddedThemes != null)
                    {
                        theme.Name = insertViewModel.AddedThemes;
                        var lastID = dtx.Themes.Skip(dtx.Themes.Count() - 1).First().Id;
                        theme.Id = lastID + 1;
                        DatabaseController.InsertThemes(theme);
                        InsertedBook.Id_Themes = theme.Id;
                    }
                }
                else
                {
                    theme.Id = dtx.Themes.FirstOrDefault(d => d.Name == insertViewModel.SelectedThemes).Id;
                    InsertedBook.Id_Themes = theme.Id;
                }

                if (insertViewModel.SelectedCategory == null)
                {
                    if (insertViewModel.AddedCategory != null)
                    {
                        category.Name = insertViewModel.AddedCategory;
                        var lastID = dtx.Categories.Skip(dtx.Categories.Count() - 1).First().Id;
                        category.Id = lastID + 1;
                        DatabaseController.InsertCategory(category);

                        InsertedBook.Id_Category = category.Id;
                    }
                }
                else
                {
                    category.Id = dtx.Categories.FirstOrDefault(d => d.Name == insertViewModel.SelectedCategory).Id;
                    InsertedBook.Id_Category = category.Id;
                }

                if (insertViewModel.SelectedAuthor == null)
                {
                    if (insertViewModel.AddedAuthorName != null)
                    {

                        author.FirstName = insertViewModel.AddedAuthorName;
                        author.LastName = insertViewModel.AddedAuthorSurname;
                        var lastID = dtx.Authors.Skip(dtx.Authors.Count() - 1).First().Id;
                        author.Id = lastID + 1;
                        DatabaseController.InsertAuthor(author);

                        InsertedBook.Id_Author = author.Id;
                    }
                }
                else
                {
                    author.Id = dtx.Authors.FirstOrDefault(d => d.FirstName + " " + d.LastName == insertViewModel.SelectedAuthor).Id;
                    InsertedBook.Id_Author = author.Id;
                }

                var insertedBook = insertViewModel.Book;

                InsertedBook.Name = insertedBook.Name;
                InsertedBook.Quantity = insertedBook.Quantity;
                InsertedBook.Comment = insertedBook.Comment;
                InsertedBook.Pages = insertedBook.Pages;
                InsertedBook.YearPress = insertedBook.YearPress;
                InsertedBook.Id = insertedBook.Id;
                InsertedBook.BookPrice = insertedBook.BookPrice;

                var isBookExist = dtx.Books.Any(b => b.Id == InsertedBook.Id);



                if (IsFullInsertForum(InsertedBook) && !isBookExist && insertView.qtyLabel.Visibility == Visibility.Hidden)
                {
                    if (press.Id != 0 && theme.Id != 0 && category.Id != 0 && author.Id != 0)
                    {
                        DatabaseController.InsertBook(InsertedBook);
                        MessageBox.Show($"{insertViewModel.Book.Name} has been added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        ModifyDataGrid.ItemsSource = DatabaseController.GetAllBooks();
                    }

                }
                else
                {
                    MessageBox.Show("Insert Operation failed!\nCheck your inputs", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    MessageBox.Show("Make sure all fields are entered", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                }

            });

            DeleteCommand = new RelayCommand(c =>
            {
                var dtx = new DataClassesDataContext();
                var deleteWindow = new DeleteWindow();
                var deleteViewModel = new DeleteViewModel();
                deleteWindow.DataContext = deleteViewModel;
                deleteWindow.ShowDialog();

                if (dtx.Books.Any(d => d.Id == deleteViewModel.Id) && deleteWindow.idLabel.Visibility == Visibility.Hidden)
                {
                    DatabaseController.DeleteBook(deleteViewModel.Id);
                    MessageBox.Show($"Book with ID {deleteViewModel.Id} has been deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    ModifyDataGrid.ItemsSource = DatabaseController.GetAllBooks();
                }
                else
                {
                    MessageBox.Show("Delete Operation failed!\nCheck your input", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }
    }

}
