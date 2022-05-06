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
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.Achievement;
using AchieveNow.Pages.Sportsman;
using AchieveNow.Pages.Location;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для UserMainPage.xaml
    /// </summary>
    public partial class UserMainPage : Page, IMainPage
    {
        public UserMainPage()
        {
            InitializeComponent();
            Page_UserMainPage.Focus();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void Search_Button_Click(object sender, RoutedEventArgs e)
        {

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

        private void Button_Location(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LocationMainPage());
        }

        private void Button_SportKinds(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SportKindMainPage());
        }

        private void Button_Contries(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CountryMainPage());
        }

        private void Edit_UserGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                if (true)
                {
                    Classes.User user = (Classes.User)UsersGrid.SelectedItem;

                    UserEditWindow editWindow = new UserEditWindow(user);
                    editWindow.ShowDialog();

                    // Update();  // Вернуть after создания метода Update
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

        private void Delete_UsersGrid_ContextMenu_Click(object sender, RoutedEventArgs e)
        {

        }

        public void AddUser_Button_Click(object sender, RoutedEventArgs e)
        {
            var userAddWindow = new UserAddWindow();
            userAddWindow.ShowDialog();

            // Update();
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

        }

        private void PageKeyUp(object sender, KeyEventArgs e)
        {
            Keybo.PageOnKeyUpHandler(sender, e, this);
            Keybo.PageOnKeyUpHandler2(sender, e, this);
        }

        private void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Vali.Name(sender, e, Login_TextBox);
        }

        private void PreviewKeyDown_OnlyOneSpace(object sender, KeyEventArgs e)
        {
            Vali.PreviewKeyDown_OnlyOneSpace(sender, e, Login_TextBox);
        }

        private void Name_TextBox_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (Login_TextBox.Text.Length > 0 && Login_TextBox.Text.EndsWith(' '))
            {
                Login_TextBox.Text = Login_TextBox.Text.Substring(0, Login_TextBox.Text.Length - 1);
            }
        }

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Login_TextBox.Text = Login_TextBox.Text.Replace("  ", " ");
        }

        private void PasswordValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Vali.Password(sender, e);
        }

        private void PreviewKeyDown_Space(object sender, KeyEventArgs e)
        {
            Vali.PreviewKeyDown_NoSpace(sender, e);
        }

        public void Add_Button_Click()
        {
            AddUser_Button_Click(null, null);
        }
    }
}
