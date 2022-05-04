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
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.Location
{
    /// <summary>
    /// Interaction logic for LocationMainPage.xaml
    /// </summary>
    public partial class LocationMainPage : Page
    {
        public LocationMainPage()
        {
            InitializeComponent();
            Page_LocationMainPage.Focus();
            Update();
        }

        private void ShowLocations()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var query = context.Locations
                    .Include(l => l.Country)
                    .ToList();

                LocationsGrid.ItemsSource = query;
            }
        }

        private void Update()
        {
            Country_ComboBox.Items.Clear();
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    LocationsGrid.ItemsSource = null;
                    return;
                }
                ShowLocations();

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
            Country_ComboBox.SelectedItem = null;
        }

        private void Page_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Dispose();
            }
        }

        public void AddLocation_Button_Click(object sender, RoutedEventArgs e)
        {
            var locationAddWindow = new LocationAddWindow();
            locationAddWindow.ShowDialog();
            // Искомое находится здесь
            ShowLocations();
            ClearForms();
            Update();
        }

        public void ShowReportWindow()
        {
            var reportWindow = new Report.ReportWindow();
            reportWindow.ShowDialog();
        }

        public void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearForms();
            Update();
        }

        public void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                IQueryable<Classes.Location> locationIQuer = context.Locations
                    .Include("Country");

                if (Name_TextBox.Text != "")
                {
                    locationIQuer = locationIQuer.Where(c => EF.Functions.Like(c.Name!, $"%{Name_TextBox.Text}%"));
                }

                if (Country_ComboBox.SelectedItem != null)
                {
                    locationIQuer = locationIQuer.Where(c => c.CountryId == (int)Country_ComboBox.SelectedValue);
                }

                try
                {
                    var search = locationIQuer.ToList();
                    LocationsGrid.ItemsSource = search;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
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

        private void Button_SportKinds(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportKindMainPage());
        }

        private void Button_Contries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CountryMainPage());
        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserMainPage());
        }

        private void Edit_LocationGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (LocationsGrid.SelectedItem != null)
            {
                if (LocationsGrid.SelectedItems.Count == 1)
                {
                    Classes.Location location = (Classes.Location)LocationsGrid.SelectedItem;

                    LocationEditWindow editWindow = new LocationEditWindow(location);
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

        private void Delete_LocationsGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (LocationsGrid.SelectedItem != null)
            {
                List<Classes.Location> locations = new List<Classes.Location>();

                foreach (Classes.Location location in LocationsGrid.SelectedItems)
                {
                    locations.Add(location);
                }

                DeleteWindow deleteWindow = new DeleteWindow(locations);
                deleteWindow.ShowDialog();

                // Обновить после закрытия диалогового окна удаления
                Update();
            }
            else
            {
                MessageBox.Show("Выберите спортсмена");
            }
        }

        private void PageKeyUp(object sender, KeyEventArgs e)
        {
            Keybo.PageOnKeyUpHandler(sender, e, this);
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
            if (Name_TextBox.Text.Length > 0 && Name_TextBox.Text.EndsWith(' '))
            {
                Name_TextBox.Text = Name_TextBox.Text.Substring(0, Name_TextBox.Text.Length - 1);
            }
        }

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Name_TextBox.Text = Name_TextBox.Text.Replace("  ", " ");
        }
    }
}
