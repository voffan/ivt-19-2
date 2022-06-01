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
using MySql.Data.MySqlClient;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Text.Json;
using Path = System.IO.Path;

namespace AchieveNow.Pages.Report
{
    /// <summary>
    /// Interaction logic for ReportPeriodPage.xaml
    /// </summary>
    public partial class ReportPeriodPage : Page, IReport
    {
        List<ReportPeriodGrid> win = new List<ReportPeriodGrid>();
        const string ReportPath = "Winner Period Report.xlsx";

        public ReportPeriodPage()
        {
            InitializeComponent();
            Page_ReportPeriodPage.Focus();
            Update();
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
            ReportPeriodGrid.ItemsSource = null;
            win.Clear();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            ReportPeriodGrid.ItemsSource = null;
            win.Clear();

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
                                    long result = (long)reader.GetValue(2);
                                    var sportKind = reader.GetValue(3);
                                    var dateOfExecution = Convert.ToDateTime(reader.GetValue(4));
                                    var competition = reader.GetValue(5);
                                    var dateOfIssue = Convert.ToDateTime(reader.GetValue(6));
                                    Gender gender = (Gender)Enum.GetValues(typeof(Gender)).GetValue(Convert.ToInt64(reader.GetValue(7)));
                                    var country = reader.GetValue(8);

                                    string convertedResult = "";
                                    switch (result)
                                    {
                                        case 3:
                                            convertedResult = "Первое место";
                                            break;
                                        case 2:
                                            convertedResult = "Второе место";
                                            break;
                                        case 1:
                                            convertedResult = "Третье место";
                                            break;
                                    }

                                    win.Add(new ReportPeriodGrid() { Id = id.ToString(), Name = name.ToString(), Result = convertedResult, SportKind = sportKind.ToString(), DateOfExecution = DateOnly.FromDateTime(dateOfExecution), Competition = competition.ToString(), DateOfIssue = DateOnly.FromDateTime(dateOfIssue), Gender = gender.ToString(), Country = country.ToString() });
                                }
                            }
                        }
                    }
                }
                if (win.Count > 0)
                    ReportPeriodGrid.ItemsSource = win;
                else
                    ReportPeriodGrid.ItemsSource = null;
            }
        }

        public void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            if (ReportPeriodGrid.ItemsSource == null)
            {
                MessageBox.Show("В отчёте пусто");
                return;
            }

            using (ExcelContext excelContext = new ExcelContext())
            {
                string sportKind = SportKind_ComboBox.SelectedItem.ToString();
                string fromDate = ((DateTime)FromDateOfExecution_DatePicker.SelectedDate).ToString("dd-MM-yyyy");
                string toDate = ((DateTime)ToDateOfExecution_DatePicker.SelectedDate).ToString("dd-MM-yyyy");
                string date = DateTime.UtcNow.ToString("dd-MM-yyyy");

                try
                {
                    string sheetName = $"{date} {sportKind}";
                    if (excelContext.Open(filePath: Path.Combine(Environment.CurrentDirectory, ReportPath), sheetName))
                    {
                        excelContext.Merge(1, 1, 1, 9);
                        excelContext.Set(column: "A", row: 1, data: "Отчёт победителей соревнования по заданному виду спорта за выбранный период", size: 16, isBold: true, isCenter: true);

                        excelContext.Merge(3, 1, 3, 5);
                        excelContext.Set(column: "A", row: 3, data: "Вид спорта: " + sportKind, size: 14, isBold: true, isCenter: true);

                        excelContext.Merge(3, 6, 3, 9);
                        excelContext.Set(column: "F", row: 3, data: $"Период от {fromDate} до {toDate}", size: 14, isBold: true, isCenter: true);

                        int row = 5;
                        excelContext.Set(column: "A", row: row, data: "ID", isRight: true, isBold: true, columnWidth: 5);
                        excelContext.Set(column: "B", row: row, data: "Спортсмен", isBold: true, columnWidth: 40);
                        excelContext.Set(column: "C", row: row, data: "Результат", isBold: true, columnWidth: 15);
                        excelContext.Set(column: "D", row: row, data: "Вид спорта", isBold: true, columnWidth: 20);
                        excelContext.Set(column: "E", row: row, data: "Дата проведения", isBold: true, columnWidth: 16);
                        excelContext.Set(column: "F", row: row, data: "Соревнование", isBold: true, columnWidth: 30);
                        excelContext.Set(column: "G", row: row, data: "Дата выдачи", isBold: true, columnWidth: 14);
                        excelContext.Set(column: "H", row: row, data: "Пол", isBold: true, columnWidth: 14);
                        excelContext.Set(column: "I", row: row, data: "Страна", isBold: true, columnWidth: 35);

                        ++row;
                        if (win.Count > 0)
                        {
                            foreach (ReportPeriodGrid winner in win)
                            {
                                excelContext.Set(column: "A", row: row, data: winner.Id, isRight: true);
                                excelContext.Set(column: "B", row: row, data: winner.Name);
                                excelContext.Set(column: "C", row: row, data: winner.Result);
                                excelContext.Set(column: "D", row: row, data: winner.SportKind);
                                excelContext.Set(column: "E", row: row, data: winner.DateOfExecution.ToString());
                                excelContext.Set(column: "F", row: row, data: winner.Competition);
                                excelContext.Set(column: "G", row: row, data: winner.DateOfIssue.ToString());
                                excelContext.Set(column: "H", row: row, data: winner.Gender);
                                excelContext.Set(column: "I", row: row, data: winner.Country);

                                ++row;
                            }
                        }

                        excelContext.Save();
                        MessageBox.Show("Отчёт был сохранён в excel файле " + ReportPath);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
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
