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
    /// Логика взаимодействия для EditError.xaml
    /// </summary>
    public partial class EditError : Window
    {
        int id;
        public EditError(int _id)
        {
            InitializeComponent();
            id = _id;
        }

        private void Form_Load(object sender, RoutedEventArgs e)
        {
            using (ApplicationContext a = new ApplicationContext())
            {
                var row = a.Errors.SingleOrDefault(c => c.id == id);
                var items = a.Employees.Select(x => new Employee { id = x.id, FullName = x.FullName }).ToList();

                if (row != null)
                {
                    textbox_desc.Text = row.Description;
                    datepicker.SelectedDate = row.Date;
                    cb_errortype.ItemsSource = Enum.GetValues(typeof(ErrorType));

                    foreach (var item in items)
                    {
                        cb_employeeid.Items.Add(new
                        {
                            name = item.FullName.ToString(),
                            id = item.id
                        });
                    }
                    cb_errortype.SelectedValue = row.ErrorType;
                    cb_employeeid.SelectedValue = row.EmployeeId;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(ApplicationContext a = new ApplicationContext()){
                var dbError = a.Errors.FirstOrDefault(s => s.id == id);
                dbError.Description = textbox_desc.Text;
                dbError.Date = datepicker.SelectedDate.Value.Date;
                dbError.EmployeeId = (int)cb_employeeid.SelectedValue;
                dbError.ErrorType = (ErrorType)cb_errortype.SelectedValue;
                //MessageBox.Show(datepicker.SelectedDate.Value.Date.ToString());
                a.SaveChanges();
            }
        }
    }
}