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
using Microsoft.EntityFrameworkCore;

namespace AchieveNow.Pages.Competition
{
    /// <summary>
    /// Interaction logic for CompetitionAddWindow.xaml
    /// </summary>
    public partial class CompetitionAddWindow : Window, IAddWindow
    {
        public CompetitionAddWindow()
        {
            InitializeComponent();
            Name_TextBox.Focus();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Level level in Enum.GetValues(typeof(Level)))
            {
                Level_ComboBox.Items.Add(level);
            }

            ListOfLocationsAndSporkinds();
        }

        //Вывести в Combobox данные из таблицы Locations и Sportkinds
        private void ListOfLocationsAndSporkinds()
        {
            Location_ComboBox.Items.Clear();
            SportKind_ComboBox.Items.Clear();

            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                var locations = context.Locations.ToList();
                foreach (Classes.Location location in locations)
                {
                    Location_ComboBox.Items.Add(location);
                }

                Location_ComboBox.DisplayMemberPath = "Name";
                Location_ComboBox.SelectedValuePath = "Id";

                var sportKinds = context.SportKinds.ToList();
                foreach (Classes.SportKind sportKind in sportKinds)
                {
                    SportKind_ComboBox.Items.Add(sportKind);
                }

                SportKind_ComboBox.DisplayMemberPath = "Name";
                SportKind_ComboBox.SelectedValuePath = "Id";
            }
        }

        public void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ListOfLocationsAndSporkinds();
        }

        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void AddButton_Click(object sender, RoutedEventArgs e)
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


            if (Level_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите уровень");
                return;
            }


            if (Location_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите локацию");
                return;
            }

            int locationId;
            try
            {
                Int32.TryParse(Location_ComboBox.SelectedValue.ToString(), out int locationIdParsed);
                locationId = locationIdParsed;
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка при выборе локации");
                return;
            }


            int sportKindId;
            if (SportKind_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите вид спорта");
                return;
            }

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
            

            DateOnly dateOfExecution;
            if (DateOfExecution.SelectedDate != null)
            {

                dateOfExecution = DateOnly.FromDateTime((DateTime)DateOfExecution.SelectedDate);
                if (dateOfExecution < DateOnly.FromDateTime(DateTime.Now))
                {
                    MessageBox.Show("Нельзя выбрать прошедшие даты");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Выберите дату проведения");
                return;
            }

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    if (!context.IsAvailable)
                        return;

                    Classes.Competition competition = new Classes.Competition(Name_TextBox.Text, (Level)Level_ComboBox.SelectedIndex, locationId, sportKindId, dateOfExecution);

                    context.Competitions.Add(competition);
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
            Vali.VName_TextBox_LostKeyboardFocus(sender, e, Name_TextBox);
        }

        private void Name_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Vali.VName_TextBox_TextChanged(sender, e, Name_TextBox);
        }
        public void Window_KeyUp(object sender, KeyEventArgs e)
        {
            Keybo.PageOnKeyUpHandler(sender, e, this);
        }
    }
}
