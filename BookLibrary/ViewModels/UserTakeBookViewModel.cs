using BookLibrary.Commands;
using BookLibrary.Services;
using System;
using System.Collections.Generic;
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


        public RelayCommand RentCommand { get; set; }


        public UserTakeBookViewModel()
        {
            var dtx = new DataClassesDataContext();
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

                DatabaseController.InsertSCard(new_SCard);
            });
        }

    }
}
