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
            listName.Content = "List of bugs";
            current = 1;
        }
        private void getEmployees(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Employees.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
            listName.Content = "List of employees";
            current = 2;
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
        private void exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            Remove();
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            Correct();
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

        private void getAbout(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private void MenuItem_Delete(object sender, RoutedEventArgs e)
        {
            Remove();
        }
        private void Show_Solutions(object sender, RoutedEventArgs e)
        {
            ShowSolutions showSolutions = new ShowSolutions();
            showSolutions.ShowDialog();
        }
        private void Add_Solution(object sender, RoutedEventArgs e)
        {
            var obj = datagrid1.SelectedItem;
            Error error = obj as Error;
            AddSolution addSolution = new AddSolution(error, id);
            addSolution.Show();
            
        }

        private void Correct()
        {
            if (datagrid1.SelectedItem == null)
            {
                MessageBox.Show("Select please");
                return;
            }
            int x;
            switch (current)
            {
                case 1:
                    x = ((Error)datagrid1.SelectedItem).id;
                    EditError editError = new EditError(x);
                    editError.Show();
                    break;
                case 2:
                    x = ((Employee)datagrid1.SelectedItem).id;
                    EditEmployee editEmployee = new EditEmployee(x);
                    editEmployee.Show();
                    break;
                default:
                    return;
            }
        }
        private void Remove()
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

            a.SaveChanges();
        }
        private void Update()
        {
            ApplicationContext a = new ApplicationContext();
            switch (current)
            {
                case 1:
                    datagrid1.ItemsSource = a.Errors.ToList();
                    datagrid1.Columns[0].Visibility = Visibility.Hidden;
                    break;
                case 2:
                    datagrid1.ItemsSource = a.Employees.ToList();
                    datagrid1.Columns[0].Visibility = Visibility.Hidden;
                    break;
                default:
                    return;
            }
        }
    }
}
