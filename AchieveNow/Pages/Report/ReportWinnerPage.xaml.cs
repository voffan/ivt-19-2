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

                /*var query = context.Achievements
                    .FromSqlRaw("SELECT Sportsmen.Id, Sportsmen.Name, SportKinds.Name, Sportsmen.Gender, Countries.Name, (SUM(Achievements.Result)+SUM(Competitions.Level)) AS \"Scores\" FROM SportKinds JOIN Sportsmen ON SportKinds.Id = Sportsmen.SportKindId JOIN Achievements ON Achievements.SportsmanId = Sportsmen.Id JOIN Competitions ON Competitions.Id = Achievements.CompetitionId JOIN Countries ON Countries.Id = Sportsmen.CountryId GROUP BY Sportsmen.Name ORDER BY Scores")
                    .Include(x => x.Competition)
                    .Include("SportKinds")
                    .Include("Sportsmen");

                ReportWinnerGrid.ItemsSource = query;*/
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
            MessageBox.Show("What!?");
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
