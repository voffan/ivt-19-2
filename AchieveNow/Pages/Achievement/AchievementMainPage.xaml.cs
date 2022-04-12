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
using AchieveNow.ProgramClasses;
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Sportsman;
using AchieveNow.Pages.Location;
using AchieveNow.Pages.Country;

namespace AchieveNow.Pages.Achievement
{
    /// <summary>
    /// Interaction logic for AchievementPage.xaml
    /// </summary>
    public partial class AchievementMainPage : Page
    {
        public AchievementMainPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShowAchievements();
        }

        private void ShowAchievements() {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var query = context.Achievements
                        .Include("Competition")
                        .ToList();

                    AchievementsGrid.ItemsSource = query;
                }
            }
            catch (Exception ex)
            {
                AchievementsGrid.ItemsSource = null;
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }
        }
       
        private void AddAchievement_Click(object sender, RoutedEventArgs e)
        {
            var AchievementAddWindow = new AchievementAddWindow();
            AchievementAddWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            ShowAchievements();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ShowAchievements();
        }

        private void Page_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Dispose();
            }
        }

        private void Button_Competitions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompetitionMainPage());
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
        private void Button_Countries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CountryMainPage());
        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {

        }        
    }
}
