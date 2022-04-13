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
using AchieveNow.Classes;
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.Sportsman;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Location;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

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

        private void ShowAchievements()
        {
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
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
            NavigationService.Navigate(new UserMainPage());
        }

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            ShowAchievements();
        }

        private void AddAchievement_Click(object sender, RoutedEventArgs e)
        {
            var AchievementAddWindow = new AchievementAddWindow();
            AchievementAddWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            ShowAchievements();
        }



        TextBlock? ToDate = null;
        DatePicker? DateOfIssue2 = new DatePicker { SelectedDate = null };
        private void isIntervalDate_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Visible;
            ToDate = new TextBlock { Text = "До", FontSize = 12, HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 0, 0, 2) };
            DateOfIssue2 = new DatePicker { Margin = new Thickness(0, 0, 0, 10) };

            Date_StackPanel.Children.Add(ToDate);
            Date_StackPanel.Children.Add(DateOfIssue2);
        }

        private void isIntervalDate_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Hidden;
            Date_StackPanel.Children.Remove(ToDate);
            Date_StackPanel.Children.Remove(DateOfIssue2);
            DateOfIssue2 = new DatePicker { SelectedDate = null };
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                IQueryable<Classes.Achievement> achievementIQuer = context.Achievements
                    .Include("Competition")
                    .Include("Result");

                if (Name_TextBox.Text != "")
                {
                    achievementIQuer = achievementIQuer.Where(c => EF.Functions.Like(c.Name!, $"%{Name_TextBox.Text}%"));
                }

                if (Result_ComboBox.SelectedItem != null)
                {
                    achievementIQuer = achievementIQuer.Where(c => c.Result == (Result)Result_ComboBox.SelectedValue);
                }

                if (Competition_ComboBox.SelectedItem != null)
                {
                    achievementIQuer = achievementIQuer.Where(c => c.CompetitionId == (int)Competition_ComboBox.SelectedValue);
                }

                if (isIntervalDate_CheckBox.IsChecked == false)
                {
                    if (DateOfIssue.SelectedDate != null)
                    {
                        DateOnly dateOfIssue = DateOnly.FromDateTime((DateTime)DateOfIssue.SelectedDate);

                        achievementIQuer = achievementIQuer.Where(c => c.DateOfIssue == dateOfIssue);
                    }
                }
                else
                {
                    if (DateOfIssue.SelectedDate != null && DateOfIssue2 != null && DateOfIssue2.SelectedDate != null)
                    {
                        DateOnly dateOfIssue = DateOnly.FromDateTime((DateTime)DateOfIssue.SelectedDate);
                        DateOnly dateOfIssue2 = DateOnly.FromDateTime((DateTime)DateOfIssue2.SelectedDate);

                        achievementIQuer = achievementIQuer
                            .Where(c => c.DateOfIssue >= dateOfIssue)
                            .Where(c => c.DateOfIssue <= dateOfIssue2);
                    }
                }
            }
        }

        private void Result_ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}