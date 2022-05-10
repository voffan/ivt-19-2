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
using Hoplits.Classes;
using Hoplits.Cs;

namespace Hoplits
{
    /// <summary>
    /// Логика взаимодействия для AddSolution.xaml
    /// </summary>
    public partial class AddSolution : Window
    {
        Error error;
        int id;
        public AddSolution(Error _error, int _id)
        {
            InitializeComponent();
            error = _error;
            id = _id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Solution solution = new Solution { Description = error.Description, ErrorId = error.id, EmployeeId = id, SolutionOfError = textbox_sol.Text };
            using (ApplicationContext a = new ApplicationContext())
            {
                a.Solutions.Add(solution);
                a.SaveChanges();
            }
        }
    }
}
