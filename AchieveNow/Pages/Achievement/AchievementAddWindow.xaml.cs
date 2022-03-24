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

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
