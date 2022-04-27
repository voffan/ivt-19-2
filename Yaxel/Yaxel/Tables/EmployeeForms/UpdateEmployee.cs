using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel.Tables.EmployeeForms
{
    public partial class UpdateEmployee : Form
    {
        private int emplId;
        public UpdateEmployee(int emplId)
        {
            InitializeComponent();
            this.emplId = emplId;
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Employee employee = context.Employees.Where(c => c.Id == emplId).ToList().First();
                textBoxName.Text = employee.Name;

                textBoxLogin.Text = employee.Login;

                textBoxPassword.Text = employee.Password;


                comboBoxPosition.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<Position>.RetrieveAttributes(), null);
                comboBoxPosition.DisplayMember = "Key";
                comboBoxPosition.ValueMember = "Value";
            }
        }

        private void yaxelButton1_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Employee employee = context.Employees.Where(c => c.Id == emplId).ToList().First();

                employee.Name = textBoxName.Text;
                employee.Login = textBoxLogin.Text;
                employee.Password = textBoxPassword.Text;
                employee.Position = (Position)Enum.Parse(typeof(Position), (string)comboBoxPosition.SelectedValue);
                //computer.ManufacturerId = (int)comboBoxManufacturer.SelectedValue;

                context.SaveChanges();
            }

            Close();
        }

    }
}
