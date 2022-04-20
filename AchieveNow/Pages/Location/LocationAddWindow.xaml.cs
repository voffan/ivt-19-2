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
using AchieveNow.Pages.Location;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.Achievement;
using AchieveNow.Pages.Sportsman;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.Location
{
    /// <summary>
    /// Логика взаимодействия для LocationAddWindow.xaml
    /// </summary>
    public partial class LocationAddWindow : Window
    {
        private const int MAX_NAME_LENGTH = 50;
        public LocationAddWindow()
        {
            InitializeComponent();


            ClearAndListOfCountry();
        }
        private void ClearAndListOfCountry()
        {
            Country_ComboBox.Items.Clear();

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var countries = context.Countries.ToList();
                foreach (Classes.Country country in countries)
                {
                    Country_ComboBox.Items.Add(country);
                }

                Country_ComboBox.DisplayMemberPath = "Name";
                Country_ComboBox.SelectedValuePath = "Id";
            }
        }
        private void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[A-Za-z\sа-яА-ЯёЁ-]");
            if (regex.IsMatch(e.Text) && Name_TextBox.Text.Length < MAX_NAME_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void Space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // e.Handled = e.Key != Key.Space ? false : true;
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ClearAndListOfCountry();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name_TextBox.Text == "")
            {
                MessageBox.Show("В имя пусто");
                return;
            }

            if (Country_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите страну");
                return;
            }

            int countryId;
            try
            {
                Int32.TryParse(Country_ComboBox.SelectedValue.ToString(), out int countryIdParsed);
                countryId = countryIdParsed;
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка при выборе страны");
                return;
            }

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    if (!context.IsAvailable)
                        return;

                    Classes.Location location = new Classes.Location
                    (
                        Name_TextBox.Text,
                        countryId
                    );

                    context.Locations.Add(location);
                    context.SaveChanges();

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла неизвестная ошибка: " + ex.Message);
            }
        }
    }
}
