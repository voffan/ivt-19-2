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
            datagrid1.ItemsSource = a.Employees.ToList();
            datagrid1.Columns[0].Visibility = Visibility.Hidden;
          }

        private void getBugs(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            datagrid1.ItemsSource = a.Errors.ToList();
        }

        private void exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            datagrid1.SelectedItems.Clear();
        }
    }
}
