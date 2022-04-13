﻿using System;
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
    /// Interaction logic for SportsmanEditWindow.xaml
    /// </summary>
    public partial class SportsmanEditWindow : Window
    {
        private const int MAX_NAME_LENGTH = 50;
        private const int MAX_HEIGHT_LENGTH = 3;
        private const int MAX_WEIGHT_LENGTH = 3;
        private Classes.Sportsman sportsman;
        public SportsmanEditWindow(Classes.Sportsman sportsman)
        {
            InitializeComponent();
            this.sportsman = sportsman;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Gender gender in Enum.GetValues(typeof(Gender)))
            {
                Gender_ComboBox.Items.Add(gender);
            }
            SportsmanInit();
        }
        private void SportsmanInit()
        {
            ListOfSporkind();

            Name_TextBox.Text = sportsman.Name;

            DateOnly dateOnlyOfBirth = new DateOnly(sportsman.DateOfBirth.Year, sportsman.DateOfBirth.Month, sportsman.DateOfBirth.Day);
            DateOfBirth.SelectedDate = dateOnlyOfBirth.ToDateTime(TimeOnly.MinValue);

            Height_TextBox.Text = sportsman.Height.ToString();

            Weight_TextBox.Text = sportsman.Weight.ToString();

            Gender_ComboBox.SelectedIndex = (int)sportsman.Gender;

            SportKind_ComboBox.SelectedValue = sportsman.SportKind.Id;

            Country_ComboBox.SelectedValue = sportsman.CountryId;
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

        public void NameValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[A-Za-z\sа-яА-Я]");
            if (regex.IsMatch(e.Text) && Name_TextBox.Text.Length < MAX_NAME_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void HeightValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(e.Text) && Height_TextBox.Text.Length < MAX_HEIGHT_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void WeightValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(e.Text) && Weight_TextBox.Text.Length < MAX_WEIGHT_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void Space_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key != Key.Space ? false : true;
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            SportsmanInit();
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

                    Classes.Sportsman sportsmanUpdate;
                    sportsmanUpdate = context.Sportsmen.Where(c => c.Id == sportsman.Id).First();

                    if (sportsmanUpdate != null)
                    {
                        sportsmanUpdate.Name = Name_TextBox.Text;
                        sportsmanUpdate.DateOfBirth = dateOfBirth;
                        sportsmanUpdate.Height = height;
                        sportsmanUpdate.Weight = weight;
                        sportsmanUpdate.Gender = (Gender)Gender_ComboBox.SelectedIndex;
                        sportsmanUpdate.SportKindId = sportKindId;
                        sportsmanUpdate.CountryId = countryId;

                        context.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось обновить элемент. Probably is was deleted");
                    }

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
