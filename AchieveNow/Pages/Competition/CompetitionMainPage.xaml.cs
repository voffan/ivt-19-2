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
using AchieveNow.Classes;
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

        // Отобразить данные из таблицы Competitions в DataGrid
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

        // Вывести в ComboBox данные из таблицы Locations и Sportkinds
        private void ListOfLocationsAndSportkinds()
        {
            Location_ComboBox.Items.Clear();
            SportKind_ComboBox.Items.Clear();

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var locations = context.Locations.ToList();
                    foreach (Location location in locations)
                    {
                        Location_ComboBox.Items.Add(location);
                    }

                    Location_ComboBox.DisplayMemberPath = "Name";
                    Location_ComboBox.SelectedValuePath = "Id";

                    var sportKinds = context.SportKinds.ToList();
                    foreach (SportKind sportKind in sportKinds)
                    {
                        SportKind_ComboBox.Items.Add(sportKind);
                    }

                    SportKind_ComboBox.DisplayMemberPath = "Name";
                    SportKind_ComboBox.SelectedValuePath = "Id";
                }
            }
            catch (Exception ex)
            {
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }
        }

        private void Update()
        {
            ShowCompetitions();
            ListOfLocationsAndSportkinds();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();

            foreach (Level level in Enum.GetValues(typeof(Level)))
            {
                Level_ComboBox.Items.Add(level);
            }
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

        private void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            Level_ComboBox.SelectedItem = null;
            Update();
        }

        private void AddCompetition_Button_Click(object sender, RoutedEventArgs e)
        {
            var competitionAddWindow = new CompetitionAddWindow();
            competitionAddWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            Update();
        }

        TextBlock? ToDate = null;
        DatePicker? DateOfExecution2 = null;

        private void isIntervalDate_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Visible;
            ToDate = new TextBlock { Text = "До", FontSize = 12, HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 0, 0, 2) };
            DateOfExecution2 = new DatePicker { Margin = new Thickness(0, 0, 0, 10)};

            Date_StackPanel.Children.Add(ToDate);
            Date_StackPanel.Children.Add(DateOfExecution2);
        }

        private void isIntervalDate_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Hidden;
            Date_StackPanel.Children.Remove(ToDate);
            Date_StackPanel.Children.Remove(DateOfExecution2);
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                /*int level;
                if (Level_ComboBox.SelectedValue != null)
                {
                    level = Level_ComboBox.SelectedIndex;
                }*/

                var search = context.Competitions
                    .Include("Location")
                    .Include("SportKind")
                    .Where(c => EF.Functions.Like(c.Name!, $"%{Name_TextBox.Text}%"))
                    //.Where(c => EF.Functions.Like(c.Level.ToString(), $"{Level_ComboBox.SelectedIndex}"))
                    .Where(c => EF.Functions.Like(c.Location.Name, $"{Location_ComboBox.SelectedItem}%"))
                    .Where(c => EF.Functions.Like(c.SportKind.Name, $"{SportKind_ComboBox.SelectedItem}%"))
                    .ToList();

                CompetitionsGrid.ItemsSource = search;
            }
        }
    }
}
