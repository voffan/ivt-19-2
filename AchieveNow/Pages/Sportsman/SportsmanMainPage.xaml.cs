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
using AchieveNow.Pages.Achievement;
using AchieveNow.Pages.Competition;

namespace AchieveNow.Pages.Sportsman
{
    /// <summary>
    /// Interaction logic for SportsmanPage.xaml
    /// </summary>
    public partial class SportsmanMainPage : Page
    {
        public SportsmanMainPage()
        {
            InitializeComponent();
        }

        private void ShowSportsmen() {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var query = context.Competitions
                        .Include("Location")
                        .Include("SportKind")
                        .ToList();

                    SportsmansGrid.ItemsSource = query;
                }
            }
            catch (Exception ex)
            {
                SportsmansGrid.ItemsSource = null;
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShowSportsmen();
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
            NavigationService.Navigate(new AchievementMainPage());
        }

        private void Button_Competitions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompetitionMainPage());
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ShowSportsmen();
        }

        private void AddSportsman_Click(object sender, RoutedEventArgs e)
        {
            var SportsmanAddWindow = new SportsmanAddWindow();
            SportsmanAddWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            ShowSportsmen();
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
