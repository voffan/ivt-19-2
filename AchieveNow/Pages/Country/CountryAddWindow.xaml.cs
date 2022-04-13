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

        private void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[A-Za-z\sа-яА-ЯёЁ]");

            if (regex.IsMatch(e.Text) && Name_TextBox.Text.Length < MAX_NAME_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
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
    }
}
