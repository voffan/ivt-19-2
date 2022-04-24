using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaxel.Tables.EmployeeForms
{
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {

        }

        private void yaxelButton1_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Classes.Employee employee = new Classes.Employee();
                employee.Name = textBoxName.Text;
                employee.Login = textBoxLogin.Text;
                employee.Password = textBoxPassword.Text;

                context.Employees.Add(employee);
                context.SaveChanges();

                Close();
            }
        }
    }
}
