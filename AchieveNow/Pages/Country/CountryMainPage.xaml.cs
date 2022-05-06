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
using AchieveNow.Pages.Location;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.Country
{
    /// <summary>
    /// Interaction logic for CountryMainPage.xaml
    /// </summary>
    public partial class CountryMainPage : Page, IMainPage
    {
        public CountryMainPage()
        {
            InitializeComponent();
            Page_CountryMainPage.Focus();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ShowCountries()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var query = context.Countries
                    .ToList();

                CountriesGrid.ItemsSource = query;
            }
        }

        private void Update()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    CountriesGrid.ItemsSource = null;
                    return;
                }

                ShowCountries();
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

        public void ShowReportWindow()
        {
            var reportWindow = new Report.ReportWindow();
            reportWindow.ShowDialog();
        }

        public void ShowWinnerPage()
        {
            NavigationService.Navigate(new Report.ReportWinnerPage());
        }

        public void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearForms();
            Update();
        }

        public void AddCountry_Button_Click(object sender, RoutedEventArgs e)
        {
            CountryAddWindow addWindow = new CountryAddWindow();
            addWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            Update();
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

        private void Button_SportKinds(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportKindMainPage());
        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMainPage());
        }

        public void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var search = context.Countries.Where(c => EF.Functions.Like(c.Name!, $"%{Name_TextBox.Text}%"));

                CountriesGrid.ItemsSource = search.ToList();
            }
        }

        private void Delete_CountriesGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (CountriesGrid.SelectedItem != null)
            {
                List<Classes.Country> countries = new List<Classes.Country>();

                foreach (Classes.Country country in CountriesGrid.SelectedItems)
                {
                    countries.Add(country);
                }

                DeleteWindow deleteWindow = new DeleteWindow(countries);
                deleteWindow.ShowDialog();

                // Обновить после закрытия диалогового окна удаления
                Update();
            }
            else
            {
                MessageBox.Show("Выберите страну");
            }
        }

        private void Edit_CountriesGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (CountriesGrid.SelectedItem != null)
            {
                if (CountriesGrid.SelectedItems.Count == 1)
                {
                    Classes.Country country = (Classes.Country)CountriesGrid.SelectedItem;

                    CountryEditWindow editWindow = new CountryEditWindow(country);
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
                MessageBox.Show("Выберите страну");
            }
        }

        private void PageKeyUp(object sender, KeyEventArgs e)
        {
            Keybo.PageOnKeyUpHandler(sender, e, this);
            Keybo.PageOnKeyUpHandler2(sender, e, this);
        }

        private void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Vali.Name(sender, e, Name_TextBox);
        }

        private void PreviewKeyDown_OnlyOneSpace(object sender, KeyEventArgs e)
        {
            Vali.PreviewKeyDown_OnlyOneSpace(sender, e, Name_TextBox);
        }

        private void Name_TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Vali.VName_TextBox_LostKeyboardFocus(sender, e, Name_TextBox);
        }

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Vali.VName_TextBox_TextChanged(sender, e, Name_TextBox);
        }

        public void Add_Button_Click()
        {
            AddCountry_Button_Click(null, null);
        }
    }
}
