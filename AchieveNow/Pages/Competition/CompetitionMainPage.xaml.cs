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
using AchieveNow.Pages.Sportsman;

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

                    CompetitionsGrid.ItemsSource = query;
                }
            }
            catch (Exception ex)
            {
                CompetitionsGrid.ItemsSource = null;
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

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
            NavigationService.Navigate(new AchievementMainPage());
        }

        private void Button_Sportsmen(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportsmanMainPage());
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

        TextBlock? ToDate = null;
        DatePicker? DateOfExecution2 = null;

        private void isIntervalDate_Checked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Visible;
            ToDate = new TextBlock { Text = "До", FontSize = 12, HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 0, 0, 2) };
            DateOfExecution2 = new DatePicker { Margin = new Thickness(0, 0, 0, 10)};

            Date_StackPanel.Children.Add(ToDate);
            Date_StackPanel.Children.Add(DateOfExecution2);
        }

        private void isIntervalDate_Unchecked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Hidden;
            Date_StackPanel.Children.Remove(ToDate);
            Date_StackPanel.Children.Remove(DateOfExecution2);
        }
    }
}
