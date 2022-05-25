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
using System.Windows.Shapes;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;

namespace AchieveNow.Pages.User
{
    /// <summary>
    /// Логика взаимодействия для UserEditWindow.xaml
    /// </summary>
    public partial class UserEditWindow : Window, IEditWindow
    {
        private Classes.User user;
        public UserEditWindow(Classes.User _user)
        {
            InitializeComponent();

            user = _user;
            Login_TextBox.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Position position in Enum.GetValues(typeof(Position)))
            {
                Position_ComboBox.Items.Add(position);
            }

            UserInit();
        }

        private void UserInit()
        {
            Login_TextBox.Text = user.Login;

            Password_TextBox.Text = user.Password;

            Position_ComboBox.SelectedItem = user.Position;
        }

        public void Refresh_Click(object sender, RoutedEventArgs e)
        {
            UserInit();
        }

        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Login_TextBox.Text == "")
            {
                MessageBox.Show("Логин пустой");
                return;
            }

            if (Login_TextBox.Text.Length > 50)
            {
                MessageBox.Show("Логин не должен превышать 50 символов");
                return;
            }


            if (Password_TextBox.Text == "")
            {
                MessageBox.Show("Пароль пустой");
                return;
            }

            if (Password_TextBox.Text.Length > 50)
            {
                MessageBox.Show("Пароль не должен превышать 50 символов");
                return;
            }


            if (Position_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите должность");
                return;
            }

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    if (!context.IsAvailable)
                        return;

                    Classes.User userUpdate;
                    userUpdate = context.Users.Where(u => u.Id == user.Id).First();

                    if (userUpdate != null)
                    {
                        userUpdate.Login = Login_TextBox.Text;
                        userUpdate.Password = Password_TextBox.Text;
                        userUpdate.Position = (Position)Position_ComboBox.SelectedItem;

                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить элемент. Возможно, он был удалён");
                    }

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла неизвестная ошибка: " + ex.Message);
            }
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
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

        public void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Keybo.PageOnKeyUpHandler(sender, e, this);
        }
    }
}
