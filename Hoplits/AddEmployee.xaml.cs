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
using Hoplits.Classes;

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
                var items = a.Employers.Select(x => new Employer {id = x.id, name = x.name}).ToList();
                foreach (var item in items)
                {
                    cbEmployer.Items.Add(new
                    {
                        name = item.name.ToString(),
                        id = item.id
                    });
                }
                //cbEmployer.ItemsSource = items.Select(x => x.name);
                //cbEmployer.ItemsSource = a.Employers.Select(u => u.name).ToString();
                //shit
            }
            //errortype_list.ItemsSource = Enum.GetValues(typeof(ErrorType));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ApplicationContext a = new ApplicationContext();
            a.Employers.Where(u => u.name == cbEmployer.SelectedValue.ToString()).Select(u => u.id);
            if (cbEmployer.SelectedValue == null || login.Text == "" || password.Password == "" || fullname.Text == "" || phone.Text == "" || post.Text == "")
            {
                MessageBox.Show("Fill the empty box(es)");
                return;
            }
            Employee employee = new Employee
            {
                Login = login.Text,
                Password = password.Password,
                FullName = fullname.Text,
                PhoneNumber = phone.Text,
                Post = post.Text,
                EmployerId = int.Parse(cbEmployer.SelectedValue.ToString())
            };
            a.Employees.Add(employee);
            a.SaveChanges();
            MessageBox.Show("Employee successfully added.");
            this.Close();
        }
    }
}
