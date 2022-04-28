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
    public class Vali
    {
        public static int MAX_HEIGHT_LENGTH = 3;
        public static int MAX_WEIGHT_LENGTH = 3;
        public static void Name(object sender, TextCompositionEventArgs e, TextBox t)
        {
            Regex regex = new Regex(@"[A-Za-z\sа-яА-Я-0-9]");
            if (regex.IsMatch(e.Text))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public static void PreviewKeyDown_OnlyOneSpace(object sender, KeyEventArgs e, TextBox t)
        {
            if (e.Key == Key.Space && (t.Text.Length == 0 || t.Text.Length != 0 && t.Text[t.CaretIndex - 1] == ' ' || t.CaretIndex < t.Text.Length && t.Text[t.CaretIndex] == ' '))
            {
                e.Handled = true;
            }
        }
        public static void PreviewKeyDown_NoSpace(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space ? true : false;
        }
        public static void Height(object sender, TextCompositionEventArgs e, TextBox textBox)
        {
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(e.Text) && textBox.Text.Length < MAX_HEIGHT_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        public static void Weight(object sender, TextCompositionEventArgs e, TextBox textBox)
        {
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(e.Text) && textBox.Text.Length < MAX_WEIGHT_LENGTH)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
