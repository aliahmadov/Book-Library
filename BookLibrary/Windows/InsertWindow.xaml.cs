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



        private void qtyTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var hasParsed = int.TryParse(qtyTxtBox.Text, out int result);

            if (!hasParsed)
            {
                qtyLabel.Foreground = Brushes.Red;
                qtyLabel.Content = "Wrong Input";
                qtyLabel.FontSize = 9;
                qtyLabel.Visibility = Visibility.Visible;
            }
            else if (hasParsed && result < 0)
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

        public void CheckRadioButtons(StackPanel stackPanel)
        {

            foreach (var item in stackPanel.Children)
            {
                var button = new Button();
                var comboBox = new ComboBox();
                if (item is StackPanel sP)
                {
                    foreach (var item2 in sP.Children)
                    {
                        if (item2 is Button btn)
                        {
                            button = btn;
                        }
                        if (item2 is ComboBox cmb)
                        {
                            comboBox = cmb;
                        }
                        if (item2 is StackPanel sP2)
                        {
                            foreach (var item3 in sP2.Children)
                            {
                                if (item3 is RadioButton rB)
                                {
                                    if (rB.Content.ToString() == "Choose")
                                    {
                                        if (rB.IsChecked.Value)
                                        {
                                            button.IsEnabled = false;
                                            comboBox.IsEnabled = true;
                                        }
                                        else
                                        {
                                            button.IsEnabled = true;
                                            comboBox.IsEnabled = false;
                                            comboBox.SelectedItem = null;
                                        }

                                    }

                                }
                            }
                        }
                    }
                }
            }
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            CheckRadioButtons(insertStackPanel);
        }
    }
}
