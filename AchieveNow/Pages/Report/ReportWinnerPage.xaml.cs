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
    /// Interaction logic for ReportWinnerPage.xaml
    /// </summary>
    public partial class ReportWinnerPage : Page, IReport
    {
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

                List<WinnerGrid> win = new List<WinnerGrid>();
                string sql = "SELECT *, row_number() over(order by mytable.Scores) as Place FROM (SELECT Sportsmen.Id, Sportsmen.Name, SportKinds.Name, Sportsmen.Gender, Countries.Name, (SUM(Achievements.Result)+SUM(Competitions.Level)) as \"Scores\" FROM SportKinds JOIN Sportsmen ON SportKinds.Id = Sportsmen.SportKindId JOIN Achievements ON Achievements.SportsmanId = Sportsmen.Id JOIN Competitions ON Competitions.Id = Achievements.CompetitionId JOIN Countries ON Countries.Id = Sportsmen.CountryId GROUP BY Sportsmen.Name) mytable GROUP BY mytable.Name ORDER BY mytable.Scores";

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
            /*            MessageBox.Show("Out of бумага");
                        Microsoft.Office.Interop.Excel.Application excel = null;
                        Microsoft.Office.Interop.Excel.Workbook wb = null;
                        object missing = Type.Missing;
                        Microsoft.Office.Interop.Excel.Worksheet ws = null;
                        Microsoft.Office.Interop.Excel.Range rng = null;

                        // collection of DataGrid Items
                        var dtExcelDataTable = ReportWinnerGrid(txtFrmDte.Text, txtToDte.Text, strCondition);

                        excel = new Microsoft.Office.Interop.Excel.Application();
                        wb = excel.Workbooks.Add();
                        ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                        ws.Columns.AutoFit();
                        ws.Columns.EntireColumn.ColumnWidth = 25;

                        // Header row
                        for (int Idx = 0; Idx < dtExcelDataTable.Columns.Count; Idx++)
                        {
                            ws.Range["A1"].Offset[0, Idx].Value = dtExcelDataTable.Columns[Idx].ColumnName;
                        }

                        // Data Rows
                        for (int Idx = 0; Idx < dtExcelDataTable.Rows.Count; Idx++)
                        {
                            ws.Range["A2"].Offset[Idx].Resize[1, dtExcelDataTable.Columns.Count].Value = dtExcelDataTable.Rows[Idx].ItemArray;
                        }

                        excel.Visible = true;
                        wb.Activate();*/
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

public class WinnerGrid
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string SportKind { get; set; }
    public string Gender { get; set; }
    public string Country { get; set; }
    public string Point { get; set; }
    public string Place { get; set; }
}