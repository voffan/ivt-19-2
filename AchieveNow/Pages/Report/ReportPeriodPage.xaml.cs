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
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using AchieveNow.Classes;
using AchieveNow.ProgramClasses;
using AchieveNow.Pages.Competition;
using AchieveNow.Pages.Achievement;
using AchieveNow.Pages.Sportsman;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;
using MySql.Data.MySqlClient;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Text.Json;

namespace AchieveNow.Pages.Report
{
    /// <summary>
    /// Interaction logic for ReportPeriodPage.xaml
    /// </summary>
    public partial class ReportPeriodPage : Page, IReport
    {
        public ReportPeriodPage()
        {
            InitializeComponent();
            Page_ReportPeriodPage.Focus();
            Update();
        }

        public void ShowGrid()
        {
            
        }

        // Вывести в ComboBox данные из таблицы Locations и Sportkinds
        private void ListOfSportkinds()
        {
            SportKind_ComboBox.Items.Clear();

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
            }
        }

        private void Update()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                {
                    ReportPeriodGrid.ItemsSource = null;
                    return;
                }

                ListOfSportkinds();
            }
        }

        private void ClearForms()
        {
            SportKind_ComboBox.SelectedItem = null;
            FromDateOfExecution_DatePicker.SelectedDate = null;
            ToDateOfExecution_DatePicker.SelectedDate = null;
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
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

            DateOnly fromDateOfExecution;
            DateOnly toDateOfExecution;

            if (FromDateOfExecution_DatePicker.SelectedDate != null && ToDateOfExecution_DatePicker.SelectedDate != null)
            {

                fromDateOfExecution = DateOnly.FromDateTime((DateTime)FromDateOfExecution_DatePicker.SelectedDate);
                toDateOfExecution = DateOnly.FromDateTime((DateTime)ToDateOfExecution_DatePicker.SelectedDate);

                if (fromDateOfExecution > toDateOfExecution)
                {
                    MessageBox.Show("Время ОТ не должно быть позднее, чем время ДО");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Выберите даты периода");
                return;
            }


            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                List<ReportPeriodGrid> win = new List<ReportPeriodGrid>();
                string sql = $"SELECT Sportsmen.Id, Sportsmen.Name, Achievements.Result, SportKinds.Name, Competitions.DateOfExecution, Competitions.Name AS \"Competition\", Achievements.DateOfIssue, Sportsmen.Gender, Countries.Name FROM SportKinds JOIN Sportsmen ON SportKinds.Id = Competitions.SportKindId JOIN Achievements ON Achievements.SportsmanId = Sportsmen.Id JOIN Competitions ON Competitions.Id = Achievements.CompetitionId JOIN Countries ON Countries.Id = Sportsmen.CountryId WHERE SportKinds.Id = {sportKindId} AND (Competitions.DateOfExecution >= '{fromDateOfExecution}' AND Competitions.DateOfExecution <= '{toDateOfExecution}') AND Achievements.Result = 3";

                FileInfo configurationFile = new FileInfo("ConfigurationDB.json");
                var configurationDB = JsonSerializer.Deserialize<ConfigurationDB>(File.ReadAllText(configurationFile.ToString()));

                if (configurationDB.isRemote)
                {
                    // Подключение к MySQL требует проверки
                    string connString = $"Server={configurationDB?.Server};Database={configurationDB?.Database};port=3306;User Id={configurationDB?.User};password={configurationDB?.Password}";

                    using (var connection = new MySqlConnection(connString))
                    {
                        connection.Open();

                        MySqlCommand command = new MySqlCommand(sql, connection);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) // если есть данные
                            {
                                while (reader.Read())   // построчно считываем данные
                                {
                                    var id = reader.GetValue(0);
                                    var name = reader.GetValue(1);
                                    Result result = (Result)Enum.GetValues(typeof(Result)).GetValue(Convert.ToInt64(reader.GetValue(2)));
                                    var sportKind = reader.GetValue(3);
                                    var dateOfExecution = Convert.ToDateTime(reader.GetValue(4));
                                    var competition = reader.GetValue(5);
                                    var dateOfIssue = Convert.ToDateTime(reader.GetValue(6));
                                    Gender gender = (Gender)Enum.GetValues(typeof(Gender)).GetValue(Convert.ToInt64(reader.GetValue(7)));
                                    var country = reader.GetValue(8);

                                    win.Add(new ReportPeriodGrid() { Id = id.ToString(), Name = name.ToString(), Result = result.ToString(), SportKind = sportKind.ToString(), DateOfExecution = DateOnly.FromDateTime(dateOfExecution), Competition = competition.ToString(), DateOfIssue = DateOnly.FromDateTime(dateOfIssue), Gender = gender.ToString(), Country = country.ToString() });
                                }
                            }
                        }
                    }
                }
                else
                {
                    using (var connection = new SqliteConnection("Data Source=AchieveNowDB.db"))
                    {
                        connection.Open();

                        SqliteCommand command = new SqliteCommand(sql, connection);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows) // если есть данные
                            {
                                while (reader.Read())   // построчно считываем данные
                                {
                                    var id = reader.GetValue(0);
                                    var name = reader.GetValue(1);
                                    //Result result = (Result)Enum.GetValues(typeof(Result)).GetValue(Convert.ToInt64(reader.GetValue(2)));
                                    var result = reader.GetValue(2);
                                    var sportKind = reader.GetValue(3);
                                    var dateOfExecution = Convert.ToDateTime(reader.GetValue(4));
                                    var competition = reader.GetValue(5);
                                    var dateOfIssue = Convert.ToDateTime(reader.GetValue(6));
                                    Gender gender = (Gender)Enum.GetValues(typeof(Gender)).GetValue(Convert.ToInt64(reader.GetValue(7)));
                                    var country = reader.GetValue(8);

                                    win.Add(new ReportPeriodGrid() { Id = id.ToString(), Name = name.ToString(), Result = result.ToString(), SportKind = sportKind.ToString(), DateOfExecution = DateOnly.FromDateTime(dateOfExecution), Competition = competition.ToString(), DateOfIssue = DateOnly.FromDateTime(dateOfIssue), Gender = gender.ToString(), Country = country.ToString() });
                                }
                            }
                        }
                    }
                }
                ReportPeriodGrid.ItemsSource = win;
            }
        }

        public void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Out of бумага");
        }

        public void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            ClearForms();
            Update();
        }

        private void ReportWinner_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportWinnerPage());
        }

        private void ReportPeriod_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportPeriodPage());
        }

        private void PageKeyUp(object sender, KeyEventArgs e)
        {
            Keybo.VReportPageOnKeyUpHandler(sender, e, this);
            Keybo.VReportPageOnKeyUpHandler2(sender, e, this);
        }

        public void NavigateToMainPage()
        {
            NavigationService.Navigate(new Competition.CompetitionMainPage());
        }
    }
}

public class ReportPeriodGrid
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Result { get; set; }
    public string SportKind { get; set; }
    public DateOnly DateOfExecution { get; set; }
    public string Competition { get; set; }
    public DateOnly DateOfIssue { get; set; }
    public string Gender { get; set; }
    public string Country { get; set; }
}

// 2022-05-25 12:55. Альтернативный вариант report если нужны баллы
/*
 SELECT *, row_number() over(order by mytable.Scores desc) as Place
FROM (
	SELECT Sportsmen.Id, Sportsmen.Name, SportKinds.Name, Sportsmen.Gender, Countries.Name, Competitions.DateOfExecution, (SUM(Achievements.Result)+SUM(Competitions.Level)) as "Scores"
	FROM SportKinds JOIN Sportsmen ON SportKinds.Id = Competitions.SportKindId JOIN Achievements ON Achievements.SportsmanId = Sportsmen.Id JOIN Competitions ON Competitions.Id = Achievements.CompetitionId JOIN Countries ON Countries.Id = Sportsmen.CountryId
	WHERE SportKinds.Id = 1 AND (Competitions.DateOfExecution >= '2022-02-01' AND Competitions.DateOfExecution <= '2022-04-31')
	GROUP BY Sportsmen.Id
) mytable
ORDER BY mytable.Scores DESC
 */
