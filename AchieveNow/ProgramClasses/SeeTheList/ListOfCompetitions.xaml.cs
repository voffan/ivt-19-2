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
using AchieveNow.Classes;
using Microsoft.EntityFrameworkCore;

namespace AchieveNow.ProgramClasses.SeeTheList
{
    /// <summary>
    /// Interaction logic for ListOfCompetitions.xaml
    /// </summary>
    public partial class ListOfCompetitions : Page
    {
        public ListOfCompetitions()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var query = context.Competitions
                    .Include("Location")
                    .Include("SportKind")
                    .ToList();

                competitionsGrid.ItemsSource = query;

                /*var competitions = context.Competitions
                    .Include(c => c.Location)
                    .Include(c => c.SportKind)
                    .ToList();
                List<Competition> competitionList = new List<Competition>();
                foreach (Competition competition in competitions)
                {
                    new Competition { Id = competition.Id, Name = competition.Name, Location = competition.Location, SportKind = competition.SportKind, DateOfExecution = competition.DateOfExecution };
                }

                competitionsGrid.ItemsSource = competitionList;*/
            }
        }

        private void Page_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Dispose();
            }
        }
    }
}
