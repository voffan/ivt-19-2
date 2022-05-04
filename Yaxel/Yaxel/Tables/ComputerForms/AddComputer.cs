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

namespace Yaxel.Tables.ComputerForms
{
    public partial class AddComputer : Form
    {
        public List<int> selectedComponentsId = new List<int>();
        public AddComputer()
        {
            InitializeComponent();
        }

        private void AddComputer_Load(object sender, EventArgs e)
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
            }
        }

        private void yaxelButton2_Click(object sender, EventArgs e)
        {
            SelectComponent selectComponent = new SelectComponent(this);
            selectComponent.ShowDialog();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Classes.Computer computer = new Classes.Computer();
                computer.Name = textBoxName.Text;
                computer.Status = (Status)Enum.Parse(typeof(Status), (string)comboBoxStatus.SelectedValue);
                computer.EmployeeId = (int)comboBoxEmployee.SelectedValue;
                computer.Components.AddRange(context.Components.Where(c => selectedComponentsId.Contains(c.Id)));

                context.Computers.Add(computer);
                context.SaveChanges();

                Close();
            }
        }
    }
}
