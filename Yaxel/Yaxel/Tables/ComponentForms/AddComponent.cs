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

namespace Yaxel.Tables.ComponentForms
{
    public partial class AddComponent : Form
    {
        public AddComponent()
        {
            InitializeComponent();
        }

        private void AddComponent_Load(object sender, EventArgs e)
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

        private void applyButton_Click(object sender, EventArgs e)
        {
            using (var context = new YaxelContext())
            {
                Yaxel.Classes.Component component = new Yaxel.Classes.Component();
                component.Model = textBox1.Text;
                component.ComponentType = (ComponentType)Enum.Parse(typeof(ComponentType), (string)comboBox2.SelectedValue);
                component.ComputerId = (int)comboBox1.SelectedValue;

                context.Components.Add(component);
                context.SaveChanges();
                Close();
            }
        }
    }
}
