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
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.Achievement;
using AchieveNow.Pages.Sportsman;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Location;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.Country
{
    /// <summary>
    /// Interaction logic for CountryMainPage.xaml
    /// </summary>
    public partial class CountryMainPage : Page
    {
        public CountryMainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ShowCountries()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var query = context.Countries
                    .ToList();

                CountriesGrid.ItemsSource = query;
            }
        }

        private void Update()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    CountriesGrid.ItemsSource = null;
                    return;
                }

                ShowCountries();
            }
        }

        private void ClearForms()
        {
            Name_TextBox.Text = "";
        }

        private void Page_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Dispose();
            }
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearForms();
            Update();
        }

        private void AddCountry_Button_Click(object sender, RoutedEventArgs e)
        {
            CountryAddWindow addWindow = new CountryAddWindow();
            addWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            Update();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Soon");
        }

        private void Button_Competitions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompetitionMainPage());
        }

        private void Button_Achievements(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AchievementMainPage());
        }

        private void Button_Sportsmen(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportsmanMainPage());
        }

        private void Button_Locations(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LocationMainPage());
        }

        private void Button_SportKinds(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportKindMainPage());
        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMainPage());
        }

        private void Edit_CountriesGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_CountriesGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
