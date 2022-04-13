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
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Location;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();

            foreach (Level level in Enum.GetValues(typeof(Level)))
            {
                Level_ComboBox.Items.Add(level);
            }
        }

        // Отобразить данные из таблицы Competitions в DataGrid
        private void ShowCompetitions() {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var query = context.Competitions
                    .Include("Location")
                    .Include("SportKind")
                    .ToList();

                CompetitionsGrid.ItemsSource = query;
            }
        }

        // Вывести в ComboBox данные из таблицы Locations и Sportkinds
        private void ListOfLocationsAndSportkinds()
        {
            Location_ComboBox.Items.Clear();
            SportKind_ComboBox.Items.Clear();

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var locations = context.Locations.ToList();
                foreach (Classes.Location location in locations)
                {
                    Location_ComboBox.Items.Add(location);
                }

                Location_ComboBox.DisplayMemberPath = "Name";
                Location_ComboBox.SelectedValuePath = "Id";

                var sportKinds = context.SportKinds.ToList();
                foreach (Classes.SportKind sportKind in sportKinds)
                {
                    SportKind_ComboBox.Items.Add(sportKind);
                }

                SportKind_ComboBox.DisplayMemberPath = "Name";
                SportKind_ComboBox.SelectedValuePath = "Id";
            }
        }

        // Обновить информацию из БД
        private void Update()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    CompetitionsGrid.ItemsSource = null;
                    return;
                }

                ShowCompetitions();
                ListOfLocationsAndSportkinds();
            }
        }

        // Очистить формы
        private void ClearForms()
        {
            Name_TextBox.Text = "";
            Level_ComboBox.SelectedItem = null;
            Location_ComboBox.SelectedItem = null;
            SportKind_ComboBox.SelectedItem = null;
            DateOfExecution.SelectedDate = null;
            isIntervalDate_CheckBox.IsChecked = false;
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
            ClearForms();
            Update();
        }

        // Открыть диалоговое окно добавления соревнования
        private void AddCompetition_Button_Click(object sender, RoutedEventArgs e)
        {
            var competitionAddWindow = new CompetitionAddWindow();
            competitionAddWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            Update();
        }

        TextBlock? ToDate = null;
        DatePicker? DateOfExecution2 = new DatePicker { SelectedDate = null };

        // По выбору isIntervalDate_CheckBox добавить второй DatePicker
        private void isIntervalDate_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Visible;
            ToDate = new TextBlock { Text = "До", FontSize = 12, HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 0, 0, 2) };
            DateOfExecution2 = new DatePicker { Margin = new Thickness(0, 0, 0, 10)};

            Date_StackPanel.Children.Add(ToDate);
            Date_StackPanel.Children.Add(DateOfExecution2);
        }

        // По снятию выбора isIntervalDate_CheckBox убрать второй DatePicker
        private void isIntervalDate_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Hidden;
            Date_StackPanel.Children.Remove(ToDate);
            Date_StackPanel.Children.Remove(DateOfExecution2);
            DateOfExecution2 = new DatePicker { SelectedDate = null };
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                IQueryable<Classes.Competition> competitionIQuer = context.Competitions
                    .Include("Location")
                    .Include("SportKind");

                if (Name_TextBox.Text != "")
                {
                    competitionIQuer = competitionIQuer.Where(c => EF.Functions.Like(c.Name!, $"%{Name_TextBox.Text}%"));
                }

                if (Level_ComboBox.SelectedItem != null)
                {
                    competitionIQuer = competitionIQuer.Where(c => c.Level == (Level)Level_ComboBox.SelectedItem);
                }

                if (Location_ComboBox.SelectedItem != null)
                {
                    competitionIQuer = competitionIQuer.Where(c => c.LocationId == (int)Location_ComboBox.SelectedValue);
                }

                if (SportKind_ComboBox.SelectedItem != null)
                {
                    competitionIQuer = competitionIQuer.Where(c => c.SportKindId == (int)SportKind_ComboBox.SelectedValue);
                }

                if (isIntervalDate_CheckBox.IsChecked == false)
                {
                    if (DateOfExecution.SelectedDate != null)
                    {
                        DateOnly dateOfExecution = DateOnly.FromDateTime((DateTime)DateOfExecution.SelectedDate);

                        competitionIQuer = competitionIQuer.Where(c => c.DateOfExecution == dateOfExecution);
                    }
                }
                else
                {
                    if (DateOfExecution.SelectedDate != null && DateOfExecution2 != null && DateOfExecution2.SelectedDate != null)
                    {
                        DateOnly dateOfExecution = DateOnly.FromDateTime((DateTime)DateOfExecution.SelectedDate);
                        DateOnly dateOfExecution2 = DateOnly.FromDateTime((DateTime)DateOfExecution2.SelectedDate);

                        competitionIQuer = competitionIQuer
                            .Where(c => c.DateOfExecution >= dateOfExecution)
                            .Where(c => c.DateOfExecution <= dateOfExecution2);
                    }
                }

                var search = competitionIQuer.ToList();

                CompetitionsGrid.ItemsSource = search;
            }
        }
        
        private void Delete_CompetitionsGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (CompetitionsGrid.SelectedItem != null)
            {
                List<Classes.Competition> competitions = new List<Classes.Competition>();

                foreach (Classes.Competition competition in CompetitionsGrid.SelectedItems)
                {
                    competitions.Add(competition);
                }

                DeleteWindow deleteWindow = new DeleteWindow(competitions);
                deleteWindow.ShowDialog();

                // Обновить после закрытия диалогового окна удаления
                Update();
            }
            else
            {
                MessageBox.Show("Выберите соревнование");
            }
        }

        private void Edit_CompetitionsGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (CompetitionsGrid.SelectedItem != null)
            {
                if (CompetitionsGrid.SelectedItems.Count == 1)
                {
                    Classes.Competition competition = (Classes.Competition)CompetitionsGrid.SelectedItem;

                    CompetitionEditWindow editWindow = new CompetitionEditWindow(competition);
                    editWindow.ShowDialog();

                    // Обновить после закрытия диалогового окна редактирования
                    Update();
                }
                else
                {
                    MessageBox.Show("Для редактирования разрешается выбрать только одну запись");
                }
            }
            else
            {
                MessageBox.Show("Выберите соревнование");
            }
        }
    }
}
