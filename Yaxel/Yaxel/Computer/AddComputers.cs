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

namespace Yaxel
{
    public partial class AddComputers : Form
    {
        private static AddComputers init;
        public static AddComputers GetForm
        {
            get
            {
                if (init == null || init.IsDisposed)
                    init = new AddComputers();
                return init;
            }
        }

        public AddComputers()
        {
            InitializeComponent();
        }

        private void AddComputers_Load(object sender, EventArgs e)
        {
            // Добавление enum (status) в comboBox
            statusComboBox.DataSource = new BindingSource(DescriptionAttributes<Status>.RetrieveAttributes(), null);
            statusComboBox.DisplayMember = "Key";
            statusComboBox.ValueMember = "Value";
                        
            using (var context = new YaxelContext())
            {
                // Вывод список сотрудников в comboBox
                employeeComboBox.DataSource = context.Employees.ToList();
                employeeComboBox.DisplayMember = "Name";
                employeeComboBox.ValueMember = "Id";

                // Вывод список производителей в comboBox
                manufacturerComboBox.DataSource = context.Manufacturers.ToList();
                manufacturerComboBox.DisplayMember = "Name";
                manufacturerComboBox.ValueMember = "Id";
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Computer computer = new Computer();
                computer.Name = nameBox.Text;
                computer.Status = (Status)Enum.Parse(typeof(Status), (string)statusComboBox.SelectedValue);
                computer.EmployeeId = (int)employeeComboBox.SelectedValue;
                computer.ManufacturerId = (int)manufacturerComboBox.SelectedValue;

                context.Computers.Add(computer);
                context.SaveChanges();

                AddComputers.GetForm.Close();
            }
        }
    }
}
