using System;
using System.Linq;
using System.Windows.Forms;
using Yaxel.Classes;

namespace Yaxel.Tables.Component
{
    public partial class AddComponents : Form
    {
        public AddComponents()
        {
            InitializeComponent();
        }

        private void AddComponents_Load(object sender, EventArgs e)
        {
            comboBox2.DataSource = new BindingSource(EnumTranslator.DescriptionAttributes<ComponentType>.RetrieveAttributes(), null);
            comboBox2.DisplayMember = "Key";
            comboBox2.ValueMember = "Value";

            using (var context = new YaxelContext())
            {
                // Вывод список сотрудников в comboBox
                comboBox1.DataSource = context.Computers.ToList();
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "Id";
            }
        }

        private void yaxelButton1_Click(object sender, EventArgs e)
        {
            using(var context = new YaxelContext())
            {
                Yaxel.Classes.Component component = new Yaxel.Classes.Component();
                component.Model = textBox1.Text;
                component.ComponentType = (ComponentType)Enum.Parse(typeof(ComponentType), (string)comboBox2.SelectedValue);
                component.ComputerId = (int) comboBox1.SelectedValue;

                context.Components.Add(component);
                context.SaveChanges();
                Close();
            }
        }
    }
}
