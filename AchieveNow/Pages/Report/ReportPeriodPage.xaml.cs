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
        }

        public void Print_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Out of бумага");
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
