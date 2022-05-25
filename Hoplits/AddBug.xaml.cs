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
    /// Логика взаимодействия для AddBug.xaml
    /// </summary>
    public partial class AddBug : Window
    {
        int id;
        public AddBug(int _id)
        {
            id = _id;
            InitializeComponent();
            errortype_list.ItemsSource = Enum.GetValues(typeof(ErrorType));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (errortype_list.SelectedValue == null || error_desc.Text == "")
            {
                MessageBox.Show("Fill the form!");
                return;
            }
            Error error = new Error { EmployeeId = id, Date = DateTime.Now, Description = error_desc.Text, ErrorType = (ErrorType)errortype_list.SelectedValue };
            ApplicationContext a = new ApplicationContext();
            a.Errors.Add(error);
            a.SaveChanges();
            MessageBox.Show("Bug successfuly added.");
            this.Close();
        }
    }
}
