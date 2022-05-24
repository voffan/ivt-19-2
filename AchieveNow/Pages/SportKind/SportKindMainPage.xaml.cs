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
using AchieveNow.Pages.Location;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.SportKind
{
    /// <summary>
    /// Interaction logic for SportKindMainPage.xaml
    /// </summary>
    public partial class SportKindMainPage : Page, IMainPage
    {
        public SportKindMainPage()
        {
            InitializeComponent();
            Page_SportKindMainPage.Focus();

            if (Classes.User.position == Position.Сотрудник)
            {
                Pages_StackPanel.Children.Remove(User_Button);
            }
            else if (Classes.User.position == Position.Судья)
            {
                Pages_StackPanel.Children.Remove(Location_Button);
                Pages_StackPanel.Children.Remove(SportKind_Button);
                Pages_StackPanel.Children.Remove(Country_Button);
                Pages_StackPanel.Children.Remove(User_Button);
            }
            else if (Classes.User.position == (Position)(-1))
            {
                MessageBox.Show("Вы не авторизовались! Программа завершает работу...");
                Application.Current.Shutdown();
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private void ShowSportKinds()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var query = context.SportKinds
                    .ToList();

                SportKindsGrid.ItemsSource = query;
            }
        }

        private void Update()
        {

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    SportKindsGrid.ItemsSource = null;
                    return;
                }
                ShowSportKinds();
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
        public void AddSportKind_Button_Click(object sender, RoutedEventArgs e)
        {
            var sportKindAddWindow = new SportKindAddWindow();
            sportKindAddWindow.ShowDialog();

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

        private void Button_Contries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CountryMainPage());
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

                var search = context.SportKinds.Where(s => EF.Functions.Like(s.Name!, $"%{Name_TextBox.Text}%"));

                SportKindsGrid.ItemsSource = search.ToList();
            }
        }

        private void Delete_SportKindsGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (SportKindsGrid.SelectedItem != null)
            {
                List<Classes.SportKind> sportKinds = new List<Classes.SportKind>();

                foreach (Classes.SportKind sportKind in SportKindsGrid.SelectedItems)
                {
                    sportKinds.Add(sportKind);
                }

                DeleteWindow deleteWindow = new DeleteWindow(sportKinds);
                deleteWindow.ShowDialog();

                // Обновить после закрытия окна диалогового удаления
                Update();
            }
            else
            {
                MessageBox.Show("Выберите вид спорта");
            }
        }

        private void Edit_SportKindGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (SportKindsGrid.SelectedItem != null)
            {
                if (SportKindsGrid.SelectedItems.Count == 1)
                {
                    Classes.SportKind sportKind = (Classes.SportKind)SportKindsGrid.SelectedItem;

                    SportKindEditWindow editWindow = new SportKindEditWindow(sportKind);
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
                MessageBox.Show("Выберите вид спорта");
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
            AddSportKind_Button_Click(null, null);
        }
    }
}