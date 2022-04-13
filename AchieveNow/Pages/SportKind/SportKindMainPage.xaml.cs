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
using AchieveNow.Pages.Location;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.SportKind
{
    /// <summary>
    /// Interaction logic for SportKindMainPage.xaml
    /// </summary>
    public partial class SportKindMainPage : Page
    {
        public SportKindMainPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ShowSportKinds()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var query = context.SportKinds
                    .ToList();

                SportKindsGrid.ItemsSource = query;
            }
        }

        private void Update()
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    SportKindsGrid.ItemsSource = null;
                    return;
                }
                ShowSportKinds();
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
        private void AddSportKind_Button_Click(object sender, RoutedEventArgs e)
        {         
            var sportKindAddWindow = new SportKindAddWindow();
            sportKindAddWindow.ShowDialog();

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

        private void Button_Contries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CountryMainPage());
        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMainPage());
        }

        private void Edit_SportKindGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_SportKindsGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
