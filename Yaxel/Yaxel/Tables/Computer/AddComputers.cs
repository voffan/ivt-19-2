using System;
using System.Linq;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel.Tables.Computer
{
    public partial class AddComputers : Form
    {
        public AddComputers()
        {
            InitializeComponent();
        }

        private void AddComputers_Load(object sender, EventArgs e)
        {
            // Добавление enum (status) в comboBox
            comboBoxStatus.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<Status>.RetrieveAttributes(), null);
            comboBoxStatus.DisplayMember = "Key";
            comboBoxStatus.ValueMember = "Value";

            using (var context = new YaxelContext())
            {
                // Вывод список сотрудников в comboBox
                comboBoxEmployee.DataSource = context.Employees.ToList();
                comboBoxEmployee.DisplayMember = "Name";
                comboBoxEmployee.ValueMember = "Id";

                // Вывод список производителей в comboBox
                comboBoxManufacturer.DataSource = context.Manufacturers.ToList(); 
                comboBoxManufacturer.DisplayMember = "Name";
                comboBoxManufacturer.ValueMember = "Id";
            }
        }

        private void yaxelButton1_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Classes.Computer computer = new Classes.Computer();
                computer.Name = textBoxName.Text;
                computer.Status = (Status)Enum.Parse(typeof(Status), (string)comboBoxStatus.SelectedValue);
                computer.EmployeeId = (int)comboBoxEmployee.SelectedValue;
                computer.ManufacturerId = (int)comboBoxManufacturer.SelectedValue;

                context.Computers.Add(computer);
                context.SaveChanges();

                Close();
            }
        }
    }
}
