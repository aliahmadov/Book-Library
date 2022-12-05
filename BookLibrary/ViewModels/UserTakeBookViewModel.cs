using BookLibrary.Commands;
using BookLibrary.Helpers;
using BookLibrary.Models;
using BookLibrary.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookLibrary.ViewModels
{
    internal class UserTakeBookViewModel : BaseViewModel
    {
        private int bookId;

        public int BookId
        {
            get { return bookId; }
            set { bookId = value; OnPropertyChanged(); }
        }

        private int dayCount;

        public int DayCount
        {
            get { return dayCount; }
            set { dayCount = value; OnPropertyChanged(); }
        }


        private double totalPrice;

        public double TotalPrice
        {
            get { return totalPrice; }
            set { totalPrice = value; OnPropertyChanged(); }
        }


        private int studentId;

        public int StudentId
        {
            get { return studentId; }
            set { studentId = value; OnPropertyChanged(); }
        }


        private ObservableCollection<RentCodeGenerator> rents;

        public ObservableCollection<RentCodeGenerator> Rents
        {
            get { return rents; }
            set { rents = value; OnPropertyChanged(); }
        }
        public RelayCommand RentCommand { get; set; }

        public RelayCommand BackCommand { get; set; }

        public UserTakeBookViewModel()
        {

            var dtx = new DataClassesDataContext();
            Rents = new ObservableCollection<RentCodeGenerator>();
            if (File.Exists("rents"))
            {
                Rents = FileHelper.ReadRents("rents");
            }

            BackPage = App.MyGrid.Children[0];
            BackCommand = new RelayCommand(c =>
            {
                App.MyGrid.Children.RemoveAt(0);
                App.MyGrid.Children.Add(BackPage);
            });


            RentCommand = new RelayCommand(c =>
            {
                var new_SCard = new S_Card();
                Random random = new Random();
                int value = random.Next(1, 2);
                if (StudentId > 0 && DayCount > 0 && BookId > 0)
                {
                    if (dtx.Books.Any(b => b.Id == BookId))
                    {
                        if (dtx.Students.Any(s => s.Id == StudentId))
                        {

                            new_SCard.Id = dtx.S_Cards.Skip(dtx.S_Cards.Count() - 1).First().Id + 1;
                            new_SCard.Id_Student = StudentId;
                            new_SCard.Id_Lib = value;
                            new_SCard.Id_Book = BookId;
                            new_SCard.DateOut = DateTime.Now;
                            new_SCard.DateIn = null;

                            var book = dtx.Books.FirstOrDefault(d => d.Id == BookId);
                            if (book.Quantity > 0)
                            {
                                book.Quantity -= 1;
                                DatabaseController.UpdateBook(book.Id, book.YearPress, book.Comment, book.Name, book.Pages, book.Quantity);
                                DatabaseController.InsertSCard(new_SCard);
                                MessageBox.Show("Book has been taken successfully");
                                RentCodeGenerator rcg = new RentCodeGenerator(bookId, StudentId, DateTime.Now.AddDays(10),new_SCard.Id);
                                Rents.Add(rcg);
                                FileHelper.WriteRents(Rents.ToList(), "rents");
                                MessageBox.Show($"Your return code: {rcg.Code}");
                                BookId = 0;
                                DayCount = 0;
                                StudentId = 0;
                            }
                            else
                            {
                                MessageBox.Show("Quantity is 0\nYou cannot take this book");
                            }
                        }
                        else
                        {
                            MessageBox.Show($"Student with ID {StudentId} does not exist", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Book with ID {BookId} does not exist", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
                else
                {
                    MessageBox.Show($"Wrong Numbers\nCheck your input and try again . . .", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            });
        }

    }
}
