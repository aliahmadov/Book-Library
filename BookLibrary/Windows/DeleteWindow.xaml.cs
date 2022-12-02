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
    /// Interaction logic for DeleteWindow.xaml
    /// </summary>
    public partial class DeleteWindow : Window
    {
        public DeleteWindow()
        {
            InitializeComponent();
        }

        private void idTxtbox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var tB = sender as TextBox;
            var hasParsed = int.TryParse(tB.Text, out int result);

            var dtx = new DataClassesDataContext();
            if (hasParsed)
            {
                bool isBookExist = dtx.Books.Any(c => c.Id == result);
                if (!isBookExist)
                {
                    idLabel.Content = "Id does not exist";
                    idLabel.Visibility = Visibility.Visible;
                }
                else
                {
                    idLabel.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                idLabel.Content = "Wrong Input";
                idLabel.Visibility = Visibility.Visible;
            }

        }
    }
}
