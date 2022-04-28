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
using System.Text.RegularExpressions;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;

namespace AchieveNow.Pages.Sportsman
{
    /// <summary>
    /// Interaction logic for SportsmanAddWindow.xaml
    /// </summary>
    public partial class SportsmanAddWindow : Window
    {
        private const int MAX_NAME_LENGTH = 50;
        private const int MAX_HEIGHT_LENGTH = 3;
        private const int MAX_WEIGHT_LENGTH = 3;
        public SportsmanAddWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                Gender_ComboBox.Items.Add(gender);
            }
            ListOfSporkind();
        }

        private void ListOfSporkind()
        {
            SportKind_ComboBox.Items.Clear();
            Country_ComboBox.Items.Clear();

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

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

        private void HeightValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Vali.Height(sender, e, Height_TextBox);
        }

        private void WeightValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Vali.Weight(sender, e, Weight_TextBox);
        }

        private void PreviewKeyDown_Space(object sender, KeyEventArgs e)
        {
            Vali.PreviewKeyDown_NoSpace(sender, e);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ListOfSporkind();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name_TextBox.Text == "")
            {
                MessageBox.Show("В имя пусто");
                return;
            }

            DateOnly dateOfBirth;
            if (DateOfBirth.SelectedDate != null)
            {

                dateOfBirth = DateOnly.FromDateTime((DateTime)DateOfBirth.SelectedDate);
                if (dateOfBirth >= DateOnly.FromDateTime(DateTime.Now))
                {
                    MessageBox.Show("Дата рождения не может быть сегодня или в будущем");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Выберите дату рождения");
                return;
            }

            if (Height_TextBox.Text == "")
            {
                MessageBox.Show("В рост пусто");
                return;
            }

            int height;
            try
            {
                Int32.TryParse(Height_TextBox.Text, out int heightParsed);
                height = heightParsed;
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка при вводе роста");
                return;
            }

            if (Weight_TextBox.Text == "")
            {
                MessageBox.Show("В вес пусто");
                return;
            }

            int weight;
            try
            {
                Int32.TryParse(Weight_TextBox.Text, out int weightParsed);
                weight = weightParsed;
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка при вводе веса");
                return;
            }

            
            if (Gender_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите гендер");
                return;
            }

            int gender;
            gender = Gender_ComboBox.SelectedIndex;

            if (SportKind_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите вид спорта");
                return;
            }

            int sportKindId;
            try
            {
                Int32.TryParse(SportKind_ComboBox.SelectedValue.ToString(), out int sportKindIdParsed);
                sportKindId = sportKindIdParsed;
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка при выборе вида спорта");
                return;
            }

            if (Country_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите Японию");
                return;
            }

            int countryId;
            try
            {
                Int32.TryParse(Country_ComboBox.SelectedValue.ToString(), out int countryIdParsed);
                countryId = countryIdParsed;
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка при выборе страны");
                return;
            }

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    if (!context.IsAvailable)
                        return;

                    Classes.Sportsman sportsman = new Classes.Sportsman
                    (
                        Name_TextBox.Text,
                        dateOfBirth,
                        height,
                        weight,
                        (Gender)gender,
                        sportKindId,
                        countryId
                    );

                    context.Sportsmen.Add(sportsman);
                    context.SaveChanges();

                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла неизвестная ошибка: " + ex.Message);
            }
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
