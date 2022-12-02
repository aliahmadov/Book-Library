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
using System.Windows.Shapes;

namespace BookLibrary.Windows
{
    /// <summary>
    /// Interaction logic for InsertWindow.xaml
    /// </summary>
    public partial class InsertWindow : Window
    {
        public InsertWindow()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(idTxtBox.Text, out int result);

            if (hasParsed)
            {
                var dtx = new DataClassesDataContext();
                var isBookExist = dtx.Books.Any(b => b.Id == result);

                if (isBookExist && idTxtBox.Text.Length != 0)
                {
                    idLabel.Foreground = Brushes.Red;
                    idLabel.Content = "ID already exists";
                    idLabel.FontSize = 9;
                    idLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    idLabel.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                idLabel.Foreground = Brushes.Red;
                idLabel.Content = "Wrong Input";
                idLabel.FontSize = 9;
                idLabel.Visibility = Visibility.Visible;
            }
        }

        private void themesTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(themesTxtBox.Text, out int result);

            if (hasParsed)
            {
                var dtx = new DataClassesDataContext();
                var isThemesExist = dtx.Themes.Any(t => t.Id == result);

                if (!isThemesExist && themesTxtBox.Text.Length != 0 && themesTxtBox.Text != "0")
                {
                    themesLabel.Foreground = Brushes.Red;
                    themesLabel.Content = "Non-existent themes ID";
                    themesLabel.FontSize = 9;
                    themesLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    themesLabel.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                themesLabel.Foreground = Brushes.Red;
                themesLabel.Content = "Wrong Input";
                themesLabel.FontSize = 9;
                themesLabel.Visibility = Visibility.Visible;
            }
        }

        private void ctgTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(ctgTxtBox.Text, out int result);
            if (hasParsed)
            {
                var dtx = new DataClassesDataContext();
                var isCategoryExist = dtx.Categories.Any(d => d.Id == result);

                if (!isCategoryExist && ctgTxtBox.Text.Length != 0 && ctgTxtBox.Text != "0")
                {
                    catLabel.Foreground = Brushes.Red;
                    catLabel.Content = "Non-existent category ID";
                    catLabel.FontSize = 9;
                    catLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    catLabel.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                catLabel.Foreground = Brushes.Red;
                catLabel.Content = "Wrong Input";
                catLabel.FontSize = 9;
                catLabel.Visibility = Visibility.Visible;
            }
        }

        private void authorTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(authorTxtBox.Text, out int result);
            if (hasParsed)
            {
                var dtx = new DataClassesDataContext();
                var isAuthorExist = dtx.Authors.Any(a => a.Id == result);

                if (!isAuthorExist && authorTxtBox.Text.Length != 0 && authorTxtBox.Text != "0")
                {
                    authorLabel.Foreground = Brushes.Red;
                    authorLabel.Content = "Non-existent author ID";
                    authorLabel.FontSize = 9;
                    authorLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    authorLabel.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                authorLabel.Foreground = Brushes.Red;
                authorLabel.Content = "Wrong Input";
                authorLabel.FontSize = 9;
                authorLabel.Visibility = Visibility.Visible;
            }
        }

        private void pressTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(pressTxtBox.Text, out int result);
            if (hasParsed)
            {
                var dtx = new DataClassesDataContext();
                var isPressExist = dtx.Presses.Any(p => p.Id == result);

                if (!isPressExist && pressTxtBox.Text.Length != 0 && pressTxtBox.Text != "0")
                {
                    pressLabel.Foreground = Brushes.Red;
                    pressLabel.Content = "Non-existent press ID";
                    pressLabel.FontSize = 9;
                    pressLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    pressLabel.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                pressLabel.Foreground = Brushes.Red;
                pressLabel.Content = "Wrong Input";
                pressLabel.FontSize = 9;
                pressLabel.Visibility = Visibility.Visible;
            }
        }

        private void qtyTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(qtyTxtBox.Text, out int result);

            if(!hasParsed)
            {
                qtyLabel.Foreground = Brushes.Red;
                qtyLabel.Content = "Wrong Input";
                qtyLabel.FontSize = 9;
                qtyLabel.Visibility = Visibility.Visible;
            }
            else if(hasParsed && result<0)
            {
                qtyLabel.Foreground = Brushes.Red;
                qtyLabel.Content = "Enter positive number or 0";
                qtyLabel.FontSize = 9;
                qtyLabel.Visibility = Visibility.Visible;
            }
            else
            {
                qtyLabel.Visibility = Visibility.Hidden;
            }
        }
    }
}
