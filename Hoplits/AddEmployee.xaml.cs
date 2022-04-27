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

using Hoplits.Cs;

namespace Hoplits
{
    /// <summary>
    /// Логика взаимодействия для AddEmployee.xaml
    /// </summary>
    public partial class AddEmployee : Window
    {
        public AddEmployee(int _id)
        {
            InitializeComponent();
            

            using (ApplicationContext a = new ApplicationContext())
            {
                cbEmployer.ItemsSource = a.Employers.ToList();
                //shit
            }
            //errortype_list.ItemsSource = Enum.GetValues(typeof(ErrorType));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
