using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookLibrary.Views
{
    /// <summary>
    /// Interaction logic for UserTakeBookUC.xaml
    /// </summary>
    public partial class UserTakeBookUC : UserControl
    {
        public UserTakeBookUC()
        {
            InitializeComponent();
        }



        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataClassesDataContext dtx = new DataClassesDataContext();
            var hasParsed = int.TryParse(bookIdTxtb.Text, out int result);

            if (hasParsed)
            {
                if (result >= 0)
                {
                    bookIdLbl.Visibility = Visibility.Hidden;
                }
                else
                {
                    bookIdLbl.Content = "Enter positive number";
                    bookIdLbl.Visibility = Visibility.Visible;
                }
            }
            else
            {
                bookIdLbl.Content = "Wrong Input";
                bookIdLbl.Visibility = Visibility.Visible;
            }

            if (dtx.Books.Any(b => b.Id == result))
            {
                bookIdLbl.Visibility = Visibility.Hidden;
            }
            else
            {
                bookIdLbl.Content = "Id does not exist";
                bookIdLbl.Visibility = Visibility.Visible;
            }

        }

        private void dayTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(dayTxtb.Text, out int result);

            if (hasParsed)
            {
                if (result >= 0)
                {
                    dayLbl.Visibility = Visibility.Hidden;
                    Random random = new Random();
                    int book_price = random.Next(10, 50);
                    double end_price = (book_price / 10) * 0.1 * result;
                    priceLbl.Content = end_price.ToString();
                }
                else
                {
                    dayLbl.Content = "Enter positive number";
                    priceLbl.Content = "";
                    dayLbl.Visibility = Visibility.Visible;
                }
            }
            else
            {
                dayLbl.Content = "Wrong Input";
                priceLbl.Content = "";
                dayLbl.Visibility = Visibility.Visible;
            }
        }

        private void stdIdTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(stdIdTxtb.Text, out int result);
            var dtx = new DataClassesDataContext();
            if (hasParsed)
            {
                if (result >= 0)
                {
                    stdIdLbl.Visibility = Visibility.Hidden;
                }
                else
                {
                    stdIdLbl.Content = "Enter positive number";
                    stdIdLbl.Visibility = Visibility.Visible;
                }
            }
            else
            {
                stdIdLbl.Content = "Wrong Input";
                stdIdLbl.Visibility = Visibility.Visible;
            }


            if (dtx.Students.Any(s => s.Id == result))
            {
                stdIdLbl.Visibility = Visibility.Hidden;
            }
            else
            {
                stdIdLbl.Content = "Id does not exist";
                stdIdLbl.Visibility = Visibility.Visible;
            }

        }
    }
}
