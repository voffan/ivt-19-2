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
using AchieveNow.ProgramClasses;
using AchieveNow.Classes;
using AchieveNow.Pages.Competition;

namespace AchieveNow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //MainFrame.Content = new CompetitionMainPage();

            var competitionAddWindow = new CompetitionAddWindow();
            //competitionAddWindow.Owner = this;
            competitionAddWindow.ShowDialog();

            /*SeeTheListOfCompetitions competitions = new SeeTheListOfCompetitions();
            competitions.ShowCompetitions();*/

            /*SeeTheListOfAchievements achievements = new SeeTheListOfAchievements();
            achievements.ShowAchievements();*/

            /*SeeTheListOfSportsmen sportsmen = new SeeTheListOfSportsmen();
            sportsmen.ShowSportsmen();*/
        }
    }
}
