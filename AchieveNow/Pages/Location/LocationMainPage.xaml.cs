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
using AchieveNow.Pages.Country;

namespace AchieveNow.Pages.Location
{
    /// <summary>
    /// Interaction logic for LocationMainPage.xaml
    /// </summary>
    public partial class LocationMainPage : Page
    {
        public LocationMainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ShowLocations()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var query = context.Locations
                    .ToList();

                LocationsGrid.ItemsSource = query;
            }
        }

        private void Update()
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    LocationsGrid.ItemsSource = null;
                    return;
                }
                ShowLocations();
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

        private void AddLocation_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Only for $10!");
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearForms();
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

        private void Button_SportKinds(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportKindMainPage());
        }

        private void Button_Contries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CountryMainPage());
        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_LocationGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_LocationsGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
