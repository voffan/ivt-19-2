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
using AchieveNow.Pages.Location;
using AchieveNow.Pages.SportKind;
using AchieveNow.Pages.Country;
using AchieveNow.Pages.User;

namespace AchieveNow
{
    public static class Keybo
    {
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, CompetitionMainPage page)
        {
            // MessageBox.Show(e.Key.ToString());
            if (e.Key == Key.D1 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CompetitionMainPage());
            }
            if (e.Key == Key.D2 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new AchievementMainPage());
            }
            if (e.Key == Key.D3 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportsmanMainPage());
            }
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
            switch (e.Key)
            {
                case Key.Enter:
                    page.Search_Button_Click(null, null);
                    break;
                case Key.F3:
                    page.AddCompetition_Button_Click(null, null);
                    break;
                case Key.F5:
                    page.Refresh_Button_Click(null, null);
                    break;
                case Key.F6:
                    page.ShowReportWindow();
                    break;
                default:
                    break;
            }
        }

        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, AchievementMainPage page)
        {
            if (e.Key == Key.D1 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CompetitionMainPage());
            }
            if (e.Key == Key.D2 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new AchievementMainPage());
            }
            if (e.Key == Key.D3 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportsmanMainPage());
            }
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
            switch (e.Key)
            {
                case Key.Enter:
                    page.Search_Button_Click(null, null);
                    break;
                case Key.F3:
                    page.AddAchievement_Click(null, null);
                    break;
                case Key.F5:
                    page.Refresh_Button_Click(null, null);
                    break;
                case Key.F6:
                    page.ShowReportWindow();
                    break;
                default:
                    break;
            }
        }
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, SportsmanMainPage page)
        {
            if (e.Key == Key.D1 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CompetitionMainPage());
            }
            if (e.Key == Key.D2 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new AchievementMainPage());
            }
            if (e.Key == Key.D3 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportsmanMainPage());
            }
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
            switch (e.Key)
            {
                case Key.Enter:
                    page.Search_Button_Click(null, null);
                    break;
                case Key.F3:
                    page.AddSportsman_Button_Click(null, null);
                    break;
                case Key.F5:
                    page.Refresh_Button_Click(null, null);
                    break;
                case Key.F6:
                    page.ShowReportWindow();
                    break;
                default:
                    break;
            }
        }
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, LocationMainPage page)
        {
            if (e.Key == Key.D1 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CompetitionMainPage());
            }
            if (e.Key == Key.D2 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new AchievementMainPage());
            }
            if (e.Key == Key.D3 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportsmanMainPage());
            }
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
            switch (e.Key)
            {
                case Key.Enter:
                    page.Search_Button_Click(null, null);
                    break;
                case Key.F3:
                    page.AddLocation_Button_Click(null, null);
                    break;
                case Key.F5:
                    page.Refresh_Button_Click(null, null);
                    break;
                case Key.F6:
                    page.ShowReportWindow();
                    break;
                default:
                    break;
            }
        }
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, SportKindMainPage page)
        {
            if (e.Key == Key.D1 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CompetitionMainPage());
            }
            if (e.Key == Key.D2 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new AchievementMainPage());
            }
            if (e.Key == Key.D3 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportsmanMainPage());
            }
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
            switch (e.Key)
            {
                case Key.Enter:
                    page.Search_Button_Click(null, null);
                    break;
                case Key.F3:
                    page.AddSportKind_Button_Click(null, null);
                    break;
                case Key.F5:
                    page.Refresh_Button_Click(null, null);
                    break;
                case Key.F6:
                    page.ShowReportWindow();
                    break;
                default:
                    break;
            }
        }
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, CountryMainPage page)
        {
            if (e.Key == Key.D1 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CompetitionMainPage());
            }
            if (e.Key == Key.D2 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new AchievementMainPage());
            }
            if (e.Key == Key.D3 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportsmanMainPage());
            }
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
            switch (e.Key)
            {
                case Key.Enter:
                    page.Search_Button_Click(null, null);
                    break;
                case Key.F3:
                    page.AddCountry_Button_Click(null, null);
                    break;
                case Key.F5:
                    page.Refresh_Button_Click(null, null);
                    break;
                case Key.F6:
                    page.ShowReportWindow();
                    break;
                default:
                    break;
            }
        }
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, UserMainPage page)
        {
            if (e.Key == Key.D1 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CompetitionMainPage());
            }
            if (e.Key == Key.D2 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new AchievementMainPage());
            }
            if (e.Key == Key.D3 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportsmanMainPage());
            }
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space))
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
            switch (e.Key)
            {
                case Key.Enter:
                    page.Search_Button_Click(null, null);
                    break;
                case Key.F3:
                    page.AddUser_Button_Click(null, null);
                    break;
                case Key.F5:
                    page.Refresh_Button_Click(null, null);
                    break;
                case Key.F6:
                    page.ShowReportWindow();
                    break;
                default:
                    break;
            }
        }
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, IAddWindow addWindow)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    addWindow.Exit_Click(null, null);
                    break;
                case Key.Enter:
                    addWindow.AddButton_Click(null, null);
                    break;
                case Key.F5:
                    addWindow.Refresh_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, IEditWindow editWindow)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    editWindow.Exit_Click(null, null);
                    break;
                case Key.Enter:
                    editWindow.UpdateButton_Click(null, null);
                    break;
                case Key.F5:
                    editWindow.Refresh_Click(null, null);
                    break;
                default:
                    break;
            }
        }
    }
}
