using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace AchieveNow.Pages.Country
{
    /// <summary>
    /// Interaction logic for CountryEditWindow.xaml
    /// </summary>
    public partial class CountryEditWindow : Window, IEditWindow
    {
        Classes.Country country;

        public CountryEditWindow(Classes.Country country)
        {
            InitializeComponent();

            this.country = country;
            Name_TextBox.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CountryInit();
        }

        private void CountryInit()
        {
            Name_TextBox.Text = country.Name;
        }

        public void Refresh_Click(object sender, RoutedEventArgs e)
        {
            CountryInit();
        }

        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name_TextBox.Text == "")
            {
                MessageBox.Show("В названии пусто");
                return;
            }

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    if (!context.IsAvailable)
                        return;

                    Classes.Country countryUpdate;
                    countryUpdate = context.Countries.Where(c => c.Id == country.Id).First();

                    if (countryUpdate != null)
                    {
                        countryUpdate.Name = Name_TextBox.Text;

                        // Сделать UPDATE
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

        public void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Keybo.PageOnKeyUpHandler(sender, e, this);
        }
    }
}
