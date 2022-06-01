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
    /// Interaction logic for ReportWinnerPage.xaml
    /// </summary>
    public partial class ReportWinnerPage : Page, IReport
    {
        List<WinnerGrid>? win = new List<WinnerGrid>();
        const string ReportPath = "Winner Report.xlsx";

        public ReportWinnerPage()
        {
            InitializeComponent();
            Page_ReportWinnerPage.Focus();
            Update();
        }

        public void ShowGrid()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                if (!context.IsAvailable)
                    return;

                string sql = "SELECT *, row_number() over(order by mytable.Scores desc) as Place FROM (SELECT Sportsmen.Id, Sportsmen.Name, SportKinds.Name, Sportsmen.Gender, Countries.Name, (SUM(Achievements.Result)+SUM(Competitions.Level)) as \"Scores\" FROM SportKinds JOIN Sportsmen ON SportKinds.Id = Sportsmen.SportKindId JOIN Achievements ON Achievements.SportsmanId = Sportsmen.Id JOIN Competitions ON Competitions.Id = Achievements.CompetitionId JOIN Countries ON Countries.Id = Sportsmen.CountryId GROUP BY Sportsmen.Name) mytable GROUP BY mytable.Name ORDER BY mytable.Scores DESC";

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
                                    Gender gender = (Gender)Enum.GetValues(typeof(Gender)).GetValue(Convert.ToInt64(reader.GetValue(3)));
                                    var scores = reader.GetValue(5);
                                    var place = reader.GetValue(6);

                                    win.Add(new WinnerGrid() { Id = id.ToString(), Name = name.ToString(), SportKind = reader.GetValue(2).ToString(), Gender = gender.ToString(), Country = reader.GetValue(4).ToString(), Point = scores.ToString(), Place = place.ToString() });
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
                                    Gender gender = (Gender)Enum.GetValues(typeof(Gender)).GetValue(Convert.ToInt64(reader.GetValue(3)));
                                    var scores = reader.GetValue(5);
                                    var place = reader.GetValue(6);

                                    win.Add(new WinnerGrid() { Id = id.ToString(), Name = name.ToString(), SportKind = reader.GetValue(2).ToString(), Gender = gender.ToString(), Country = reader.GetValue(4).ToString(), Point = scores.ToString(), Place = place.ToString() });
                                }
                            }
                        }
                    }
                }
                ReportWinnerGrid.ItemsSource = win;
            }
        }

        public void Update()
        {
            ShowGrid();
        }

        public void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            using (ExcelContext excelContext = new ExcelContext())
            {
                try
                {
                    if (excelContext.Open(filePath: Path.Combine(Environment.CurrentDirectory, ReportPath)))
                    {
                        excelContext.Set(column: "A", row: 1, data: "Отчёт спортсменов с наибольшим количеством призовых мест по своему виду спорта", size: 16, isBold: true);

                        excelContext.Set(column: "A", row: 3, data: "ID", isRight: true, isBold: true, columnWidth: 5);
                        excelContext.Set(column: "B", row: 3, data: "Спортсмен", isBold: true, columnWidth: 40);
                        excelContext.Set(column: "C", row: 3, data: "Вид спорта", isBold: true, columnWidth: 20);
                        excelContext.Set(column: "D", row: 3, data: "Пол", isBold: true, columnWidth: 14);
                        excelContext.Set(column: "E", row: 3, data: "Страна", isBold: true, columnWidth: 35);
                        excelContext.Set(column: "F", row: 3, data: "Баллы", isBold: true, columnWidth: 8);
                        excelContext.Set(column: "G", row: 3, data: "Место", isBold: true, columnWidth: 7);

                        int row = 4;
                        if (win != null)
                        {
                            foreach (WinnerGrid winner in win)
                            {
                                excelContext.Set(column: "A", row: row, data: winner.Id, isRight: true);
                                excelContext.Set(column: "B", row: row, data: winner.Name);
                                excelContext.Set(column: "C", row: row, data: winner.SportKind);
                                excelContext.Set(column: "D", row: row, data: winner.Gender);
                                excelContext.Set(column: "E", row: row, data: winner.Country);
                                excelContext.Set(column: "F", row: row, data: winner.Point);
                                excelContext.Set(column: "G", row: row, data: winner.Place);

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

        private void ReportWinner_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportWinnerPage());
        }

        private void ReportPeriod_Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ReportPeriodPage());
        }

        public void Refresh_Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
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
