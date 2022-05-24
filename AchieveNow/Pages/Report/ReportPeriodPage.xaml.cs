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

                ShowGrid();
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

            MessageBox.Show("Coming Soon!");
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
