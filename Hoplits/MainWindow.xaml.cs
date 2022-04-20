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
using Hoplits.Components;
using Hoplits.Cs;
using Hoplits.Classes;

namespace Hoplits
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Errors.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
          }

        private void getBugs(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Errors.ToList();
        }
        private void getSolutions(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Solutions.ToList();
        }
        private void getEmployees(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Employees.ToList();
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datagrid1.IsReadOnly = false;
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            var row = datagrid1.SelectedItem;
            Error error = row as Error;
            if(error != null) a.Errors.Remove(error);
            a.SaveChanges();
            datagrid1.ItemsSource = a.Errors.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            datagrid1.IsReadOnly = false;
            ApplicationContext a = new ApplicationContext();
            a.SaveChanges();
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            var row = datagrid1.CurrentItem;
            Error error = row as Error;
        }
    }
}
