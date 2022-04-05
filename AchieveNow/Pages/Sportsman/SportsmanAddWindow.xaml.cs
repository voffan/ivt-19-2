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

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var sportKinds = context.SportKinds.ToList();
                foreach (SportKind sportKind in sportKinds)
                {
                    SportKind_ComboBox.Items.Add(sportKind);
                }

                SportKind_ComboBox.DisplayMemberPath = "Name";
                SportKind_ComboBox.SelectedValuePath = "Id";
            }
        }
        
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]");
            e.Handled = regex.IsMatch(e.Text);
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

            if (Name_TextBox.Text.Length > 50)
            {
                MessageBox.Show("Имя не должно превышать 50 символов");
                return;
            }
            
            if (Height_TextBox.Text == "")
            {
                MessageBox.Show("В рост пусто");
                return;
            }

            if (Height_TextBox.Text.Length > 3)
            {
                MessageBox.Show("Рост превышает область допустимых значений");
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
            }

            if (Weight_TextBox.Text.Length > 3)
            {
                MessageBox.Show("Вес превышает область допустимых значений");
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

            int gender;
            if (Gender_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите гендер");
                return;
            }
            else
            {
                gender = Gender_ComboBox.SelectedIndex;
            }

            if (SportKind_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите вид спорта");
                return;
            }
            
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
                        sportKindId
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
    }
}
