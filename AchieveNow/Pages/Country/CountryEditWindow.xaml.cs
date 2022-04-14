using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;

namespace AchieveNow.Pages.Country
{
    /// <summary>
    /// Interaction logic for CountryEditWindow.xaml
    /// </summary>
    public partial class CountryEditWindow : Window
    {
        private const int MAX_NAME_LENGTH = 50;
        Classes.Country country;

        public CountryEditWindow(Classes.Country country)
        {
            InitializeComponent();

            this.country = country;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CountryInit();
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

        private void CountryInit()
        {
            Name_TextBox.Text = country.Name;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            CountryInit();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name_TextBox.Text == "")
            {
                MessageBox.Show("В названии пусто");
                return;
            }

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    if (!context.IsAvailable)
                        return;

                    Classes.Country countryUpdate;
                    countryUpdate = context.Countries.Where(c => c.Id == country.Id).First();

                    if (countryUpdate != null)
                    {
                        countryUpdate.Name = Name_TextBox.Text;

                        // Сделать UPDATE
                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить элемент. Возможно, он был удалён");
                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла неизвестная ошибка: " + ex.Message);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
