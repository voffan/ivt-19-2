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
using System.Text.RegularExpressions;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;

namespace AchieveNow.Pages.Country
{
    /// <summary>
    /// Interaction logic for CountryAddWindow.xaml
    /// </summary>
    public partial class CountryAddWindow : Window
    {
        private const int MAX_NAME_LENGTH = 50;

        public CountryAddWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name_TextBox.Text == "")
            {
                MessageBox.Show("В названии пусто");
                return;
            }

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                Classes.Country country = new Classes.Country(Name_TextBox.Text);

                try
                {
                    context.Countries.Add(country);
                    context.SaveChanges();

                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при добавлении страны. Ошибка: " + ex.Message);
                }
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Vali.Name(sender, e, Name_TextBox);
        }

        private void PreviewKeyDown_OnlyOneSpace(object sender, KeyEventArgs e)
        {
            Vali.PreviewKeyDown_OnlyOneSpace(sender, e, Name_TextBox);
        }

        private void Name_TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Name_TextBox.Text.Length > 0 && Name_TextBox.Text.EndsWith(' '))
            {
                Name_TextBox.Text = Name_TextBox.Text.Substring(0, Name_TextBox.Text.Length - 1);
            }
        }

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name_TextBox.Text = Name_TextBox.Text.Replace("  ", " ");
        }
    }
}
