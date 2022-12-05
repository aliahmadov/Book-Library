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
    internal class UserReturnBookViewModel : BaseViewModel
    {

        private string returnCOde;

        public string ReturnCode
        {
            get { return returnCOde; }
            set { returnCOde = value; OnPropertyChanged(); }
        }

        private int bookId;

        public int BookId
        {
            get { return bookId; }
            set { bookId = value; OnPropertyChanged(); }
        }

        private int stdId;

        public int StudentId
        {
            get { return stdId; }
            set { stdId = value; OnPropertyChanged(); }
        }

        public ObservableCollection<RentCodeGenerator> RentCodes { get; set; }
        public RelayCommand ReturnCommand { get; set; }

        public UserReturnBookViewModel()
        {
            RentCodes = new ObservableCollection<RentCodeGenerator>();
            ReturnCommand = new RelayCommand(c =>
            {
                if (File.Exists("rents.json"))
                {
                    RentCodes = FileHelper.ReadRents("rents");
                }
                var dtx = new DataClassesDataContext();
                for (int i = 0; i < RentCodes.Count; i++)
                {
                    if (StudentId == RentCodes[i].StudentId &&
                    BookId == RentCodes[i].BookId && ReturnCode == RentCodes[i].Code.ToString())
                    {
                        var rent = RentCodes[i];
                        var book = dtx.Books.FirstOrDefault(b => b.Id == BookId);
                        book.Quantity += 1;
                        DatabaseController.UpdateBook(book.Id, book.YearPress, book.Comment, book.Name, book.Pages, book.Quantity);

                        var updatedScard = dtx.S_Cards.FirstOrDefault(s => s.Id == rent.S_CardId);
                        updatedScard.DateIn = rent.DateIn;
                        DatabaseController.UpdateSCard(updatedScard);
                        MessageBox.Show($"{book.Name} book has been returned successfully");

                    }
                }
            });
        }



    }
}
