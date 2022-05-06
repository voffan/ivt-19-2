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
        List<int> selectedComponentsId;

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

                List<Classes.Component> componentsList = context.Components.ToList();

                dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn());
                dataGridView1.Columns.Add("Id", "Id");
                dataGridView1.Columns.Add("Model", "Модель");
                dataGridView1.Columns.Add("ComponentType", "Тип компонента");

                dataGridView1.Columns[1].Width = 25;
                dataGridView1.RowTemplate.Height = 28;

                foreach (Classes.Component c in componentsList)
                {
                    dataGridView1.Rows.Add(null, c.Id, c.Model, c.ComponentType);
                }
            }
        }

        private void applyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Computer computer = new Computer();
                computer.Name = textBoxName.Text;
                computer.Status = (Status)Enum.Parse(typeof(Status), (string)comboBoxStatus.SelectedValue);
                computer.EmployeeId = (int)comboBoxEmployee.SelectedValue;

                dataGridView1.EndEdit();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[0].Value))
                    {
                        computer.Components.Add(context.Components.ToList().Find(c => c.Id == (int)row.Cells[1].Value));
                    }
                }

                context.Computers.Add(computer);
                context.SaveChanges();

                Close();
            }
        }
    }
}
