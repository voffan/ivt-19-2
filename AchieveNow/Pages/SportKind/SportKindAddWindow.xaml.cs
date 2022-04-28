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
using Microsoft.EntityFrameworkCore;

namespace AchieveNow.Pages.SportKind
{
    public partial class SportKindAddWindow : Window
    {
        private const int MAX_NAME_LENGTH = 50;
        public SportKindAddWindow()
        {
            InitializeComponent();
        }    
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name_TextBox.Text == "")
            {
                MessageBox.Show("В названии пусто");
                return;
            }

            if (Name_TextBox.Text.Length > 50)
            {
                MessageBox.Show("Название не должно превышать 50 символов");
                return;
            }

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    Classes.SportKind SportKind = new Classes.SportKind(Name_TextBox.Text);

                    context.SportKinds.Add(SportKind);
                    context.SaveChanges();

                    Close();
                }
            }
            catch (Exception ex)
            {
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
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
    }
}
