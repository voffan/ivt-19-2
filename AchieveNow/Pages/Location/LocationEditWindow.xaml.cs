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
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.Achievement;
using AchieveNow.Pages.Sportsman;
using AchieveNow.Pages.Location;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.Location
{
    /// <summary>
    /// Логика взаимодействия для LocationEditWindow.xaml
    /// </summary>
    public partial class LocationEditWindow : Window
    {
        Classes.Location location;
        public LocationEditWindow(Classes.Location __location)
        {
            InitializeComponent();
            location = __location;
            LocationInit();
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

        private void LocationInit()
        {
            ClearAndListOfCountry();
            Name_TextBox.Text = location.Name;
            Country_ComboBox.SelectedValue = location.CountryId;
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
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

                    Classes.Location locationUpdate;
                    locationUpdate = context.Locations.Where(c => c.Id == location.Id).First();

                    if (locationUpdate != null)
                    {
                        locationUpdate.Name = Name_TextBox.Text;
                        locationUpdate.CountryId = countryId;

                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить элемент. Probably is was deleted");
                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла неизвестная ошибка: " + ex.Message);
            }
        }

        private void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {

        }
    }
}
