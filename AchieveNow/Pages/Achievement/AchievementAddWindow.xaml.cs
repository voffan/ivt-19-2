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

namespace AchieveNow.Pages.Achievement
{
    /// <summary>
    /// Interaction logic for CompetitionAddWindow.xaml
    /// </summary>
    public partial class AchievementAddWindow : Window
    {
        public AchievementAddWindow()
        {
            InitializeComponent();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListOfCompetitions();
            Result_ComboBox.Items.Add(1);
            Result_ComboBox.Items.Add(2);
            Result_ComboBox.Items.Add(3);
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ListOfCompetitions();
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



                    //Competition_ComboBox.DisplayMemberPath = "DateOfExecution";
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


            if (Competition_ComboBox.SelectedValue == null)
            {
                MessageBox.Show("Выберите соревнование");
                return;
            }

            if (Result_ComboBox.SelectedValue == null)
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

            byte resultId;
            try
            {
                byte.TryParse(Result_ComboBox.SelectedValue.ToString(), out byte resultIdParsed);
                resultId = resultIdParsed;
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка при выборе результата");
                return;
            }

            if (DateOfIssue.SelectedDate.ToString() == "")
            {
                MessageBox.Show("Выберите дату выдачи");
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
            } catch (Exception ex)
            {
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }

            DateOnly dateOfIssue = DateOnly.FromDateTime((DateTime)DateOfIssue.SelectedDate);
            if (dateOfIssue < dateOfExecCompetition)
            {
                MessageBox.Show("Дата выдачи не может быть раньше даты соревнования!");
                return;
            }


            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    Classes.Achievement achievement = new Classes.Achievement(Name_TextBox.Text, dateOfIssue, resultId, competitionId);

                    context.Achievements.Add(achievement);
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
    }
}
