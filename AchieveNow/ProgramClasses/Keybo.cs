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
using AchieveNow.Pages.Report;

namespace AchieveNow
{
    public static class Keybo
    {
        public static int State = 0;
        private static bool _keyH = false;
        private static bool _keyE = false;
        private static bool _keyS = false;
        private static bool _keyO = false;
        private static bool _keyY = false;
        private static bool _keyA = false;
        private static int countNoHesoyam = 0;
        public static void PageOnKeyUpHandler2(object sender, KeyEventArgs e, CompetitionMainPage page)
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
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space) && State == 0)
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
        }

        public static void PageOnKeyUpHandler2(object sender, KeyEventArgs e, AchievementMainPage page)
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
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space) && State == 0)
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
        }
        public static void PageOnKeyUpHandler2(object sender, KeyEventArgs e, SportsmanMainPage page)
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
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space) && State == 0)
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
        }
        public static void PageOnKeyUpHandler2(object sender, KeyEventArgs e, LocationMainPage page)
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
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space) && State == 0)
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
        }
        public static void PageOnKeyUpHandler2(object sender, KeyEventArgs e, SportKindMainPage page)
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
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space) && State == 0)
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
        }
        public static void PageOnKeyUpHandler2(object sender, KeyEventArgs e, CountryMainPage page)
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
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space) && State == 0)
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
        }
        public static void PageOnKeyUpHandler2(object sender, KeyEventArgs e, UserMainPage page)
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
            if (e.Key == Key.D4 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new LocationMainPage());
            }
            if (e.Key == Key.D5 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new SportKindMainPage());
            }
            if (e.Key == Key.D6 && Keyboard.IsKeyDown(Key.Space) && State != 2)
            {
                page.NavigationService.Navigate(new CountryMainPage());
            }
            if (e.Key == Key.D7 && Keyboard.IsKeyDown(Key.Space) && State == 0)
            {
                page.NavigationService.Navigate(new UserMainPage());
            }
        }
        public static void PageOnKeyUpHandler(object sender, KeyEventArgs e, IMainPage mainPage)
        {
            if (Keyboard.IsKeyDown(Key.Space))
            {
                switch (e.Key)
                {
                    case Key.A:
                        mainPage.Add_Button_Click();
                        break;
                    case Key.R:
                        mainPage.ShowReportWindow();
                        break;
                    default:
                        break;
                }
            }
            switch (e.Key)
            {
                case Key.Enter:
                    mainPage.Search_Button_Click(null, null);
                    break;
                case Key.F3:
                    mainPage.Add_Button_Click();
                    break;
                case Key.F5:
                    mainPage.Refresh_Button_Click(null, null);
                    break;
                case Key.F4:
                    mainPage.ShowWinnerPage();
                    break;
                default:
                    break;
            }
            if (e.Key == Key.H)
            {
                _keyH = true;
                countNoHesoyam = 0;
            }
            else if (e.Key == Key.Back)
            {
                if (countNoHesoyam > 0)
                {
                    countNoHesoyam--;
                }
                else if (_keyA)
                {
                    _keyA = !_keyA;
                }
                else if (_keyY)
                {
                    _keyY = !_keyY;
                }
                else if (_keyO)
                {
                    _keyO = !_keyO;
                }
                else if (_keyS)
                {
                    _keyS = !_keyS;
                }
                else if (_keyE)
                {
                    _keyE = !_keyE;
                }
                else if (_keyH)
                {
                    _keyH = !_keyH;
                }
            }
            else if (e.Key == Key.E && _keyH && countNoHesoyam == 0)
            {
                _keyE = true;
            }
            else if (e.Key == Key.S && _keyE && countNoHesoyam == 0)
            {
                _keyS = true;
            }
            else if (e.Key == Key.O && _keyS && countNoHesoyam == 0)
            {
                _keyO = true;
            }
            else if (e.Key == Key.Y && _keyO && countNoHesoyam == 0)
            {
                _keyY = true;
            }
            else if (e.Key == Key.A && _keyY && countNoHesoyam == 0)
            {
                _keyA = true;
            }
            else if (e.Key == Key.M && _keyA && countNoHesoyam == 0)
            {
                _keyH = false;
                _keyE = false;
                _keyS = false;
                _keyO = false;
                _keyY = false;
                _keyA = false;
                mainPage.ShowReportWindow();
            }
            else
            {
                countNoHesoyam++;
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
        public static void ReportWindowKeyUp(KeyEventArgs e, ReportWindow reportWindow)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    reportWindow.Exit_Click(null, null);
                    break;
                case Key.F5:
                    reportWindow.Refresh_Click(null, null);
                    break;
                default:
                    break;
            }
        }
        public static void VReportPageOnKeyUpHandler(object sender, KeyEventArgs e, IReport report)
        {
            switch (e.Key)
            {
                case Key.F3:
                    report.Print_Button_Click(null, null);
                    break;
                case Key.F5:
                    report.Refresh_Button_Click(null, null);
                    break;
                case Key.F4:
                    report.NavigateToMainPage();
                    break;
                default:
                    break;
            }
        }
        public static void VReportPageOnKeyUpHandler2(object sender, KeyEventArgs e, ReportWinnerPage reportWinnerPage)
        {
            if (Keyboard.IsKeyDown(Key.Space))
            {
                switch (e.Key)
                {
                    case Key.D1:
                        reportWinnerPage.NavigationService.Navigate(new ReportWinnerPage());
                        break;
                    case Key.D2:
                        reportWinnerPage.NavigationService.Navigate(new ReportPeriodPage());
                        break;
                    default:
                        break;
                }
            }
        }
        public static void VReportPageOnKeyUpHandler2(object sender, KeyEventArgs e, ReportPeriodPage reportPeriodPage)
        {
            if (Keyboard.IsKeyDown(Key.Space))
            {
                switch (e.Key)
                {
                    case Key.D1:
                        reportPeriodPage.NavigationService.Navigate(new ReportWinnerPage());
                        break;
                    case Key.D2:
                        reportPeriodPage.NavigationService.Navigate(new ReportPeriodPage());
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
