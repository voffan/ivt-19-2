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
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.Achievement;
using AchieveNow.Pages.Sportsman;
using AchieveNow.Pages.Location;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

namespace AchieveNow.Pages.Achievement
{
    /// <summary>
    /// Interaction logic for AchievementEditWindow.xaml
    /// </summary>
    public partial class AchievementEditWindow : Window, IEditWindow
    {
        Classes.Achievement achievement;
        public AchievementEditWindow(Classes.Achievement _achievement)
        {
            InitializeComponent();
            achievement = _achievement;
            Name_TextBox.Focus();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Result result in Enum.GetValues(typeof(Result)))
            {
                Result_ComboBox.Items.Add(result);
            }
            CompetitionInit();
        }
        private void CompetitionInit()
        {
            ListOfCompetitions();

            Name_TextBox.Text = achievement.Name;

            Competition_ComboBox.SelectedValue = achievement.Competition.Id;

            Result_ComboBox.SelectedIndex = (int)achievement.Result - 1;

            DateOnly dateOnlyOfIssue = new DateOnly(achievement.DateOfIssue.Year, achievement.DateOfIssue.Month, achievement.DateOfIssue.Day);
            DateOfIssue.SelectedDate = dateOnlyOfIssue.ToDateTime(TimeOnly.MinValue);
        }
        private void ListOfCompetitions()
        {
            Competition_ComboBox.Items.Clear();

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var competitions = context.Competitions.ToList();
                    foreach (Classes.Competition competition in competitions)
                    {
                        Competition_ComboBox.Items.Add(competition);
                    }

                    Competition_ComboBox.DisplayMemberPath = "Name";
                    Competition_ComboBox.SelectedValuePath = "Id";
                }
            }
            catch (Exception ex)
            {
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }
        }
        public void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ListOfCompetitions();
        }
        public void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name_TextBox.Text == "")
            {
                MessageBox.Show("В имени пусто");
                return;
            }

            if (Competition_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите соревнование");
                return;
            }

            int competitionId;
            try
            {
                Int32.TryParse(Competition_ComboBox.SelectedValue.ToString(), out int competitionIdParsed);
                competitionId = competitionIdParsed;
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка при выборе соревнования");
                return;
            }

            if (Result_ComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите результат");
                return;
            }

            DateOnly dateOfExecCompetition;
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    Classes.Competition? competition = context.Competitions.Find(competitionId);

                    if (competition != null)
                    {
                        dateOfExecCompetition = competition.DateOfExecution;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }

            DateOnly dateOfIssue;
            if (DateOfIssue.SelectedDate != null)
            {
                dateOfIssue = DateOnly.FromDateTime((DateTime)DateOfIssue.SelectedDate);
                if (dateOfIssue < dateOfExecCompetition)
                {
                    MessageBox.Show("Дата выдачи не может быть раньше даты соревнования!\nДата соревнования: " + dateOfExecCompetition.ToString("yyyy-MM-dd"));
                    return;
                }
            }
            else
            {
                MessageBox.Show("Выберите дату выдачи");
                return;
            }

            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    if (!context.IsAvailable)
                        return;

                    Classes.Achievement achievementUpdate;
                    achievementUpdate = context.Achievements.Where(c => c.Id == achievement.Id).First();

                    if (achievementUpdate != null)
                    {
                        achievementUpdate.Name = Name_TextBox.Text;
                        achievementUpdate.CompetitionId = competitionId;
                        achievementUpdate.Result = (Result)Result_ComboBox.SelectedItem;
                        achievementUpdate.DateOfIssue = dateOfIssue;

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
