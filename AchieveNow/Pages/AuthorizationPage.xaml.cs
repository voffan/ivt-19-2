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
using AchieveNow.Pages.Competition;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;

namespace AchieveNow.Pages
{
    /// <summary>
    /// Interaction logic for AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public AuthorizationPage()
        {
            InitializeComponent();
            Login_TextBox.Focus();
        }

        public void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            Login_Button.IsEnabled = false;
            if (Login_TextBox.Text != "" && Password_PasswordBox.Password != "")
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    if (!context.IsAvailable)
                        return;

                    var user = context.Users
                        .Where(u => u.Login == Login_TextBox.Text)
                        .Where(u => u.Password == Password_PasswordBox.Password)
                        .FirstOrDefault();

                    if (user != null)
                    {
                        Classes.User.position = user.Position;
                        if (Classes.User.position == Position.Сотрудник)
                        {
                            Keybo.State = 1;
                        }
                        else if (Classes.User.position == Position.Судья)
                        {
                            Keybo.State = 2;
                        }
                        NavigationService.Navigate(new CompetitionMainPage());
                        
                    }
                    else
                    {
                        MessageBox.Show("Аккаунт не опознан. Возможно, неправильный логин или пароль");
                    }
                }
            }
            else
            {
                MessageBox.Show("Введите логин и пароль");
            }
            Login_Button.IsEnabled = true;
        }

        private void PageKeyUp(object sender, KeyEventArgs e)
        {
            Keybo.AuthPageOnKeyUpHandler(sender, e, this);
        }
    }
}
