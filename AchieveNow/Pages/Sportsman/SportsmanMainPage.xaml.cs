﻿using System;
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
using AchieveNow.ProgramClasses;
using AchieveNow.Pages.Achievement;
using AchieveNow.Pages.Competition;

namespace AchieveNow.Pages.Sportsman
{
    /// <summary>
    /// Interaction logic for SportsmanPage.xaml
    /// </summary>
    public partial class SportsmanMainPage : Page
    {
        public SportsmanMainPage()
        {
            InitializeComponent();
        }

        private void ShowSportsmen() {
            try
            {
                using (ApplicationContext context = new ApplicationContext())
                {
                    var query = context.Sportsmen
                        .Include("SportKind")
                        .Include("Country")
                        .ToList();

                    SportsmansGrid.ItemsSource = query;
                }
            }
            catch (Exception ex)
            {
                SportsmansGrid.ItemsSource = null;
                ShowErrorWindow showErrorWindow = new ShowErrorWindow();
                showErrorWindow.ShowDialog();

                Console.WriteLine(ex.Message);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ShowSportsmen();
        }

        private void Page_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                context.Dispose();
            }
        }
        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ShowSportsmen();
        }

        private void AddSportsman_Click(object sender, RoutedEventArgs e)
        {
            var SportsmanAddWindow = new SportsmanAddWindow();
            SportsmanAddWindow.ShowDialog();

            // Обновить таблицу после закрытия окна
            ShowSportsmen();
        }

        private void Search_Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Competitions(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CompetitionMainPage());
        }

        private void Button_Achievements(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AchievementMainPage());
        }

        private void Button_Locations(object sender, RoutedEventArgs e)
        {

        }

        private void Button_SportKinds(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Users(object sender, RoutedEventArgs e)
        {

        }
    }
}
