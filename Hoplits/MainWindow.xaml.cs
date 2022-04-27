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
        int current;
        int id;
        public MainWindow(int _id)
        {
            id = _id;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Errors.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
            current = 1;
        }

        private void getBugs(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Errors.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
            current = 1;
        }
        /*
        private void getSolutions(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Solutions.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
            current = 2;
        }
        */
        private void getEmployees(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Employees.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
            current = 2;
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
            switch (current)
            {
                case 1:
                    Error error = row as Error;
                    if (error != null) a.Errors.Remove(error);
                    break;
                case 2:
                    Employee employee = row as Employee;
                    if (employee != null) a.Employees.Remove(employee);
                    break;
                default:
                    return;
            }
            //Error error = row as Error;
            //if(error != null) a.Errors.Remove(error);
            a.SaveChanges();
            datagrid1.ItemsSource = a.Errors.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Window temp;
            switch (current)
            {
                case 1:
                    temp = new AddBug(id);
                    break;
                case 2:
                    temp = new AddEmployee(id);
                    break;
                default:
                    return;
            }
            temp.Show();
        }
    }
}
