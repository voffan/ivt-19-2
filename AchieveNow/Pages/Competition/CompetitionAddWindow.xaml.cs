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
using Microsoft.EntityFrameworkCore;

namespace AchieveNow.Pages.Competition
{
    /// <summary>
    /// Interaction logic for CompetitionAddWindow.xaml
    /// </summary>
    public partial class CompetitionAddWindow : Window
    {
        public CompetitionAddWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                var locations = context.Locations.ToList();

                foreach (Location location in locations)
                {
                    Location_ComboBox.Items.Add(location);
                }

                Location_ComboBox.DisplayMemberPath = "Name";
                Location_ComboBox.SelectedValuePath = "Id";

                var sportKinds = context.SportKinds.ToList();

                foreach (SportKind sportKind in sportKinds)
                {
                    SportKind_ComboBox.Items.Add(sportKind);
                }

                SportKind_ComboBox.DisplayMemberPath = "Name";
                SportKind_ComboBox.SelectedValuePath = "Id";
            }
        }

        private void Location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(Location_ComboBox.SelectedValue.ToString());
        }

        private void SportKind_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show(SportKind_ComboBox.SelectedValue.ToString());
        }

        private void DateOfExecution_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            /*DateTime? dateOfExecution = DateOfExecution.SelectedDate;
            if (dateOfExecution >= DateTime.Today)
            {
                MessageBox.Show(dateOfExecution.Value.Date.ToShortDateString());
            }
            else
            {
                MessageBox.Show("Неправильно выбрана дата!");
            }*/
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                MessageBox.Show("В названии пусто");
            }

            /*if (Location_ComboBox.SelectedValue != null && Int32.TryParse(Location_ComboBox.SelectedValue.ToString(), out int locationId))
            {
                MessageBox.Show(locationId.ToString());
            }
            else
            {
                MessageBox.Show("Ничего не выбрано");
            }

            if (SportKind_ComboBox.SelectedValue != null && Int32.TryParse(SportKind_ComboBox.SelectedValue.ToString(), out int sportKindId))
            {
                MessageBox.Show(sportKindId.ToString());
            }
            else
            {
                MessageBox.Show("Ничего не выбрано");
            }*/

            if (DateOfExecution.SelectedDate.ToString() != "")
            {
                DateTime? dateOfExecution = DateOfExecution.SelectedDate;
                if (dateOfExecution >= DateTime.Today)
                {
                    MessageBox.Show(dateOfExecution.Value.Date.ToShortDateString());
                }
                else
                {
                    MessageBox.Show("Нельзя выбрать прошлые даты");
                }
            } 
            else
            {
                MessageBox.Show("Дата не выбрана");
            }

            this.DialogResult = true;
        }
    }
}
