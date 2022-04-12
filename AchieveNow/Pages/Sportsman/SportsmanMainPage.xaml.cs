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
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.SportKind;
using System.Text.RegularExpressions;

namespace AchieveNow.Pages.Sportsman
{
    /// <summary>
    /// Interaction logic for SportsmanPage.xaml
    /// </summary>
    public partial class SportsmanMainPage : Page
    {
        TextBlock? ToDate = null;
        DatePicker? DateOfBirth2 = new DatePicker { SelectedDate = null };
        private const int MAX_HEIGHT_LENGTH = 3;
        private const int MAX_WEIGHT_LENGTH = 3;
        public SportsmanMainPage()
        {
            InitializeComponent();
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ShowSportsmen()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var query = context.Sportsmen
                    .Include("SportKind")
                    .Include("Country")
                    .ToList();

                SportsmenGrid.ItemsSource = query;
            }
        }

        private void Update()
        {
            Gender_ComboBox.Items.Clear();
            SportKind_ComboBox.Items.Clear();
            Country_ComboBox.Items.Clear();

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    SportsmenGrid.ItemsSource = null;
                    return;
                }
                ShowSportsmen();

                foreach (Gender gender in Enum.GetValues(typeof(Gender)))
                {
                    Gender_ComboBox.Items.Add(gender);
                }
                
                var sportKinds = context.SportKinds.ToList();
                foreach (Classes.SportKind sportKind in sportKinds)
                {
                    SportKind_ComboBox.Items.Add(sportKind);
                }

                SportKind_ComboBox.DisplayMemberPath = "Name";
                SportKind_ComboBox.SelectedValuePath = "Id";

                var countries = context.Countries.ToList();
                foreach (Classes.Country country in countries)
                {
                    Country_ComboBox.Items.Add(country);
                }

                Country_ComboBox.DisplayMemberPath = "Name";
                Country_ComboBox.SelectedValuePath = "Id";
            }
        }

        private void ClearForms()
        {
            Name_TextBox.Text = "";
            Height_TextBox.Text = "";
            Weight_TextBox.Text = "";
            Gender_ComboBox.SelectedItem = null;
            SportKind_ComboBox.SelectedItem = null;
            Country_ComboBox.SelectedItem = null;
            DateOfBirth.SelectedDate = null;
            isIntervalDate_CheckBox.IsChecked = false;
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

        private void AddSportsman_Button_Click(object sender, RoutedEventArgs e)
        {
            var sportsmanAddWindow = new SportsmanAddWindow();
            sportsmanAddWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            ShowSportsmen();
        }
        private void isIntervalDate_CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Visible;
            ToDate = new TextBlock { Text = "До", FontSize = 12, HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(0, 0, 0, 2) };
            DateOfBirth2 = new DatePicker { Margin = new Thickness(0, 0, 0, 10) };

            Date_StackPanel.Children.Add(ToDate);
            Date_StackPanel.Children.Add(DateOfBirth2);
        }

        // По снятию выбора isIntervalDate_CheckBox убрать второй DatePicker
        private void isIntervalDate_CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            FromDate_TextBlock.Visibility = Visibility.Hidden;
            Date_StackPanel.Children.Remove(ToDate);
            Date_StackPanel.Children.Remove(DateOfBirth2);
            DateOfBirth2 = new DatePicker { SelectedDate = null };
        }
        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                IQueryable<Classes.Sportsman> sportsmanIQuer = context.Sportsmen
                    .Include("SportKind")
                    .Include("Country");

                if (Name_TextBox.Text != "")
                {
                    sportsmanIQuer = sportsmanIQuer.Where(c => EF.Functions.Like(c.Name!, $"%{Name_TextBox.Text}%"));
                }

                if (Height_TextBox.Text != "")
                {
                    sportsmanIQuer = sportsmanIQuer.Where(c => c.Height == Int32.Parse(Height_TextBox.Text));
                }

                if (Weight_TextBox.Text != "")
                {
                    sportsmanIQuer = sportsmanIQuer.Where(c => c.Weight == Int32.Parse(Weight_TextBox.Text));
                }

                if (Gender_ComboBox.SelectedItem != null)
                {
                    sportsmanIQuer = sportsmanIQuer.Where(c => c.Gender == (Gender)Gender_ComboBox.SelectedItem);
                }

                if (SportKind_ComboBox.SelectedItem != null)
                {
                    sportsmanIQuer = sportsmanIQuer.Where(c => c.SportKindId == (int)SportKind_ComboBox.SelectedValue);
                }

                if (Country_ComboBox.SelectedItem != null)
                {
                    sportsmanIQuer = sportsmanIQuer.Where(c => c.CountryId == (int)Country_ComboBox.SelectedValue);
                }

                if (isIntervalDate_CheckBox.IsChecked == false)
                {
                    if (DateOfBirth.SelectedDate != null)
                    {
                        DateOnly dateOfBirth = DateOnly.FromDateTime((DateTime)DateOfBirth.SelectedDate);

                        sportsmanIQuer = sportsmanIQuer.Where(c => c.DateOfBirth == dateOfBirth);
                    }
                }
                else
                {
                    if (DateOfBirth.SelectedDate != null && DateOfBirth2 != null && DateOfBirth2.SelectedDate != null)
                    {
                        DateOnly dateOfBirth = DateOnly.FromDateTime((DateTime)DateOfBirth.SelectedDate);
                        DateOnly dateOfBirth2 = DateOnly.FromDateTime((DateTime)DateOfBirth2.SelectedDate);

                        sportsmanIQuer = sportsmanIQuer
                            .Where(c => c.DateOfBirth >= dateOfBirth)
                            .Where(c => c.DateOfBirth <= dateOfBirth2);
                    }
                }

                try
                {
                    var search = sportsmanIQuer.ToList();
                    SportsmenGrid.ItemsSource = search;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[A-Za-z\sа-яА-Я]");
            if (regex.IsMatch(e.Text))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }

        }
        private void HeightValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(e.Text) && Height_TextBox.Text.Length < MAX_HEIGHT_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void WeightValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(e.Text) && Weight_TextBox.Text.Length < MAX_WEIGHT_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void PreviewKeyDown_Space(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key != Key.Space ? false : true;
        }

        private void Button_Competitions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompetitionMainPage());
        }

        private void Button_Achievements(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AchievementMainPage());
        }

        private void Button_Locations(object sender, RoutedEventArgs e)
        {

        }

        private void Button_SportKinds(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportKindMainPage());
        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Countries(object sender, RoutedEventArgs e)
        {

        }

        private void Delete_SportsmenGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (SportsmenGrid.SelectedItem != null)
            {
                List<Classes.Sportsman> sportsmen = new List<Classes.Sportsman>();

                foreach (Classes.Sportsman sportsman in SportsmenGrid.SelectedItems)
                {
                    sportsmen.Add(sportsman);
                }

                DeleteWindow deleteWindow = new DeleteWindow(sportsmen);
                deleteWindow.ShowDialog();

                // Обновить после закрытия диалогового окна удаления
                Update();
            }
            else
            {
                MessageBox.Show("Выберите спортсмена");
            }
        }
        private void Edit_SportsmenGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (SportsmenGrid.SelectedItem != null)
            {
                if (SportsmenGrid.SelectedItems.Count == 1)
                {
                    Classes.Sportsman sportsman = (Classes.Sportsman)SportsmenGrid.SelectedItem;

                    SportsmanEditWindow editWindow = new SportsmanEditWindow(sportsman);
                    editWindow.ShowDialog();

                    Update();
                }
                else
                {
                    MessageBox.Show("Для редактирования разрешается выбрать только одну запись");
                }
            }
            else
            {
                MessageBox.Show("Выберите спортсмена");
            }
        }
    }
}
