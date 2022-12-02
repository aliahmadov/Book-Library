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

                insertView.ShowDialog();

                var insertedBook = insertViewModel.Book;

                var isBookExist = dtx.Books.Any(b => b.Id == insertedBook.Id);
                List<bool> bools = new List<bool>();
                bools.Add(dtx.Authors.Any(a => a.Id == insertedBook.Id_Author));
                bools.Add(dtx.Themes.Any(t => t.Id == insertedBook.Id_Themes));
                bools.Add(dtx.Categories.Any(d => d.Id == insertedBook.Id_Category));
                bools.Add(dtx.Presses.Any(p => p.Id == insertedBook.Id_Press));


                if (IsFullInsertForum(insertedBook) && bools.All(d => d == true) && !isBookExist && insertView.qtyLabel.Visibility == Visibility.Hidden)
                {
                    DatabaseController.InsertBook(insertViewModel.Book);
                    MessageBox.Show($"{insertViewModel.Book.Name} has been added successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    ModifyDataGrid.ItemsSource = DatabaseController.GetAllBooks();

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

                if (dtx.Books.Any(d => d.Id == deleteViewModel.Id) && deleteWindow.idLabel.Visibility==Visibility.Hidden)
                {
                    DatabaseController.DeleteBook(deleteViewModel.Id);
                    MessageBox.Show($"Book with ID {deleteViewModel.Id} has been deleted successfully", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Delete Operation failed!\nCheck your input", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }
    }

}
