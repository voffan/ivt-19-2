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

namespace AchieveNow.Pages.Competition
{
    /// <summary>
    /// Interaction logic for CompetitionPage.xaml
    /// </summary>
    public partial class CompetitionMainPage : Page
    {
        public CompetitionMainPage()
        {
            InitializeComponent();
        }

        private void ShowCompetitions() {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var query = context.Competitions
                        .Include("Location")
                        .Include("SportKind")
                        .ToList();

                    competitionsGrid.ItemsSource = query;
                }
            }
            catch (Exception ex)
            {
                competitionsGrid.ItemsSource = null;
                ShowCompetitionErrorWindow showCompetitionErrorWindow = new ShowCompetitionErrorWindow();
                showCompetitionErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShowCompetitions();
        }

        private void Page_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Dispose();
            }
        }

        private void Button_Achievements(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new AchievementMainPage());
        }

        private void Button_Sportsmen(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new SportsmanMainPage());
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ShowCompetitions();
        }

        private void AddCompetition_Click(object sender, RoutedEventArgs e)
        {
            var competitionAddWindow = new CompetitionAddWindow();
            competitionAddWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            ShowCompetitions();
        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            Name.Text = "";
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            Name.Text = "Название";
        }

        private void Location_GotFocus(object sender, RoutedEventArgs e)
        {
            Location.Text = "";
        }

        private void Location_LostFocus(object sender, RoutedEventArgs e)
        {
            Location.Text = "Локация";
        }

        private void SportKind_GotFocus(object sender, RoutedEventArgs e)
        {
            SportKind.Text = "";
        }

        private void SportKind_LostFocus(object sender, RoutedEventArgs e)
        {
            SportKind.Text = "Вид спорта";
        }
    }
}
