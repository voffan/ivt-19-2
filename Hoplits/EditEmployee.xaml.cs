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
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        int id;
        public EditEmployee(int _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext a = new ApplicationContext())
            {
                var row = a.Employees.FirstOrDefault(x => x.id == id);
                var items = a.Employers.Select(y => new Employer { id = y.id, name = y.name }).ToList();
                if (row != null)
                {
                    tb_login.Text = row.Login;
                    tb_password.Text = row.Password;
                    tb_fullname.Text = row.FullName;
                    tb_phone.Text = row.PhoneNumber;
                    tb_post.Text = row.Post;
                    foreach (var item in items)
                    {
                        cb_employer.Items.Add(new
                        {
                            name = item.name.ToString(),
                            id = item.id
                        });
                    }
                    cb_employer.SelectedValue = row.EmployerId;
                }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext a = new ApplicationContext())
            {
                var dbEmployee = a.Employees.FirstOrDefault(s => s.id == id);
                dbEmployee.Login = tb_login.Text;
                dbEmployee.Password = tb_password.Text;
                dbEmployee.FullName = tb_fullname.Text;
                dbEmployee.Post = tb_post.Text;
                dbEmployee.PhoneNumber = tb_phone.Text;
                dbEmployee.EmployerId = (int)cb_employer.SelectedValue;
                a.SaveChanges();
                MessageBox.Show("Success!");
                this.Close();
            }
        }
    }
}
